using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BatchHTMLValidator
{
    public partial class frmValidationResult : BatchHTMLValidator.CustomForm
    {
        private string TotalOutput = "";

        private List<string> lstURL1;
        private  List<ValidationResult> lstvld1;
        private List<string> lstFile1;

        public frmValidationResult(List<string> _lstURL, List<ValidationResult> _lstvld, List<string> _lstFile,string totaloutput)
        {
            InitializeComponent();

            AddResults(_lstURL, _lstvld);

            TotalOutput = totaloutput;

            lstURL1 = _lstURL;
            lstvld1 = _lstvld;
            lstFile1 = _lstFile;
        }

        private void AddResults(List<string> lstURL, List<ValidationResult> lstvld)
        {
            for (int k = 0; k < lstvld.Count; k++)
            {
                try
                {
                    if (lstvld[k].NumErrors == 0 && lstvld[k].NumWarnings == 0 && !lstvld[k].Error)
                    {
                        tvS.Nodes.Add(lstURL[k]);
                        tvS.Nodes[tvS.Nodes.Count - 1].Tag = k;
                    }
                    else if (lstvld[k].NumErrors == 0 && lstvld[k].NumWarnings == 0 && lstvld[k].Error)
                    {
                        TreeNode no = tvDE.Nodes.Add(lstURL[k]);
                        tvDE.Nodes[tvDE.Nodes.Count - 1].Tag = k;

                        no.Nodes.Add(lstvld[k].ErrorMsg);
                    }
                    else if (lstvld[k].NumErrors == 0 && lstvld[k].NumWarnings > 0)
                    {
                        TreeNode no = tvW.Nodes.Add(lstURL[k] + " " + lstvld[k].NumWarnings.ToString() + " Warnings");
                        tvW.Nodes[tvW.Nodes.Count - 1].Tag = k;

                        for (int m = 0; m < lstvld[k].lstWarnings.Count; m++)
                        {
                            no.Nodes.Add(lstvld[k].lstWarnings[m]);
                        }
                    }
                    else if (lstvld[k].NumErrors > 0)
                    {
                        TreeNode no = tvE.Nodes.Add(lstURL[k] + " " +
                            lstvld[k].NumErrors.ToString() + " Errors" + " - " +
                            lstvld[k].NumWarnings.ToString() + " Warnings");

                        tvE.Nodes[tvE.Nodes.Count - 1].Tag = k;

                        for (int m = 0; m < lstvld[k].lstErrors.Count; m++)
                        {
                            no.Nodes.Add(lstvld[k].lstErrors[m]);
                        }

                        for (int m = 0; m < lstvld[k].lstWarnings.Count; m++)
                        {
                            no.Nodes.Add(lstvld[k].lstWarnings[m]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Module.ShowError(ex);
                }
            }

            lblResult.Text = TranslateHelper.Translate("Links with Errors") + " : " + tvE.Nodes.Count + " - "+
                TranslateHelper.Translate("Links with Warnings Only") + " : " + tvW.Nodes.Count + " - " +
                TranslateHelper.Translate("Successful Links") + " : " + tvS.Nodes.Count + " - " +
                TranslateHelper.Translate("Links with Download Errors") + " : " + tvDE.Nodes.Count;
        }

        
        private void frmValidationResult_Load(object sender, EventArgs e)
        {
            tvE.NodeMouseDoubleClick += tvE_NodeMouseDoubleClick;
            tvW.NodeMouseDoubleClick += tvE_NodeMouseDoubleClick;

            lvEditor.Click += lvEditor_Click;

            tvE.ContextMenuStrip = contextMenuStrip1;
            tvW.ContextMenuStrip = contextMenuStrip1;

        }

        void lvEditor_Click(object sender, EventArgs e)
        {
            if (lvEditor.SelectedItems != null && lvEditor.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvEditor.SelectedItems[0];

                int ic = (int)lvi.Tag;

                txtError.Text = lvi.Text;

                txtEditor.SelectionStart = ic;
                txtEditor.ScrollToCaret();
            }
        }        

        private bool InNodeDoubleClick = false;

        private void LoadInEditor(TreeNode no)
        {
            if (InNodeDoubleClick) return;

            try
            {
                InNodeDoubleClick = true;

                this.Cursor = Cursors.WaitCursor;

                //TreeNode no = e.Node.TreeView.SelectedNode;

                int ik;

                TreeNode nopar;

                if (no.Tag != null)
                {
                    ik = (int)no.Tag;
                    nopar = no;
                }
                else
                {
                    ik = (int)no.Parent.Tag;
                    nopar = no.Parent;
                }

                int inde = 0;
                int indw = 0;
                bool iserror = false;

                for (int m = 0; m < nopar.Nodes.Count; m++)
                {
                    if (nopar.Nodes[m].Text.Contains(" info warning: "))
                    {
                        if (nopar.Nodes[m] == no)
                        {
                            iserror = false;
                            break;
                        }

                        indw++;
                    }
                    else if (nopar.Nodes[m].Text.Contains(" error: "))
                    {
                        if (nopar.Nodes[m] == no)
                        {
                            iserror = true;
                            break;
                        }

                        inde++;
                    }
                }

                LoadEditorForURL(ik, iserror ? inde : indw, iserror);
                //LoadEditorForURL(ik, no.Index);

            }
            finally
            {
                InNodeDoubleClick = false;

                this.Cursor = null;
            }
        }

        void tvE_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                if (e.Node.Parent.Tag == null) return;

                LoadInEditor(e.Node);
            }
        }

        System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex(@"(?:(?<line>[^\n]+)\n)|(?:(?=\n)\n)|(?:(?<line>[^\n]+)$)|(?:(?=\n)$)");

        private void LoadEditorForURL(int k,int ind,bool iserror)
        {
            txtEditor.Text = "";

            txtEditor.SelectionStart = 0;
            txtEditor.SelectionLength = 0;
            txtEditor.SelectionBackColor = Color.White;
            txtEditor.SelectionFont = new Font(txtEditor.Font, FontStyle.Regular);

            txtEditor.WordWrap = false;
            lvEditor.HideSelection = false;
            txtEditor.Multiline = true;

            lblEditorFile.Text = lstURL1[k];

            lvEditor.Items.Clear();

            string file = lstFile1[k];

            string txt = System.IO.File.ReadAllText(file, Encoding.Default);

            txt = txt.Replace("\r\n", "[A!@]");
            txt = txt.Replace("\r", "[A!@]");
            txt = txt.Replace("\n", "[A!@]");

            txt = txt.Replace("[A!@]", Environment.NewLine);

            string nlc = Environment.NewLine;

            rex = new System.Text.RegularExpressions.Regex(@"(?!" + Environment.NewLine + ").+" + Environment.NewLine + "|(?=" + Environment.NewLine+")"+Environment.NewLine                
                );
                        
            System.Text.RegularExpressions.MatchCollection macol=rex.Matches(txt);                       
            
            List<int> lineind = new List<int>();

            lineind.Add(0);
            
            ImageList iml = new ImageList();
            iml.Images.Add("error", Properties.Resources.delete);
            iml.Images.Add("warning", Properties.Resources.information);

            lvEditor.SmallImageList = iml;

            StringBuilder sb = new StringBuilder();

            int charcount = 0;

            for (int m = 0; m < macol.Count;m++)
            {
                //string line1= macol[m].Value.Substring(0, macol[m].Value.Length - 1);

                //string line1 = macol[m].Value + "\n";

                string line1 = macol[m].Value;

                if (line1.EndsWith("\n"))
                {
                    line1 = line1.Substring(0, line1.Length - 1);
                }
                
                if (line1.EndsWith("\r"))
                {
                    line1 = line1.Substring(0, line1.Length - 1);
                }                                

                if (line1.EndsWith("\n"))
                {
                    line1 = line1.Substring(0, line1.Length - 1);
                }

                charcount += line1.Length + 1;

                line1 += Environment.NewLine;

                sb.Append(line1);
                
                //sb.AppendLine(line1 + "\r\n");
                
                //8txtEditor.Text +=line1 + "\r\n";

                //lineind.Add(txtEditor.Text.Length - 1);

                lineind.Add(charcount);

                
            }

            int llpos = txt.LastIndexOf(Environment.NewLine);
            string lastline = txt.Substring(llpos + Environment.NewLine.Length);

            if (lastline != string.Empty)
            {
                string line1 = lastline;

                if (line1.EndsWith("\n"))
                {
                    line1 = line1.Substring(0, line1.Length - 1);
                }

                if (line1.EndsWith("\r"))
                {
                    line1 = line1.Substring(0, line1.Length - 1);
                }

                if (line1.EndsWith("\n"))
                {
                    line1 = line1.Substring(0, line1.Length - 1);
                }

                charcount += line1.Length + 1;

                line1 += Environment.NewLine;

                sb.Append(line1);                

                lineind.Add(charcount);
            }

            txtEditor.Text = sb.ToString();

            int selstart = 0;

            for (int m = 0; m < lstvld1[k].lstErrors.Count; m++)
            {
                string line = lstvld1[k].lstErrors[m];

                int dotpos = line.IndexOf(".");
                int linenum = int.Parse(line.Substring(0, dotpos));

                int dashpos = line.IndexOf("-");
                // 201.300-301.300:
                int linecol=int.Parse(line.Substring(dotpos+1,dashpos-dotpos-1));

                int dotpos2 = line.IndexOf(".", dashpos);
                int colpos = line.IndexOf(":", dashpos);

                int linenum2 = int.Parse(line.Substring(dashpos+1, dotpos2-dashpos-1));
                int linecol2 = int.Parse(line.Substring(dotpos2 + 1, colpos - dotpos2 - 1));

                int charstart = lineind[linenum - 1] + linecol - 1;
                int charend = lineind[linenum2-1] + linecol2;                

                /*
                int charstart=txtEditor.GetFirstCharIndexFromLine(linenum-1) + linecol - 1;
                int charend = txtEditor.GetFirstCharIndexFromLine(linenum2-1) + linecol2 - 1;
                */

                //string seltext = txtEditor.Text.Substring(charstart, charend - charstart + 1);

                txtEditor.SelectionStart = charstart;
                txtEditor.SelectionLength = Math.Max(0,charend - charstart+1);
                txtEditor.SelectionBackColor = Color.Yellow;
                txtEditor.SelectionFont = new Font(txtEditor.Font, FontStyle.Bold);
                txtEditor.SelectionLength = 0;
                txtEditor.SelectionBackColor = Color.White;
                txtEditor.SelectionFont = new Font(txtEditor.Font, FontStyle.Regular);

                ListViewItem lvi=lvEditor.Items.Add(line);
                lvi.Tag = charstart;
                lvi.ImageKey = "error";

                if (m == ind && iserror)
                {
                    selstart = charstart;

                    lvEditor.Items[lvEditor.Items.Count - 1].Selected = true;
                }

                
            }

            for (int m = 0; m < lstvld1[k].lstWarnings.Count; m++)
            {
                string line = lstvld1[k].lstWarnings[m];

                int dotpos = line.IndexOf(".");
                int linenum = int.Parse(line.Substring(0, dotpos));

                int dashpos = line.IndexOf("-");
                // 201.300-301.300:
                int linecol = int.Parse(line.Substring(dotpos + 1, dashpos - dotpos - 1));

                int dotpos2 = line.IndexOf(".", dashpos);
                int colpos = line.IndexOf(":", dashpos);

                int linenum2 = int.Parse(line.Substring(dashpos + 1, dotpos2 - dashpos - 1));
                int linecol2 = int.Parse(line.Substring(dotpos2 + 1, colpos - dotpos2 - 1));

                int charstart = lineind[linenum - 1] + linecol - 1;
                int charend = lineind[linenum2 - 1] + linecol2;
                
                /*
                int charstart=txtEditor.GetFirstCharIndexFromLine(linenum-1) + linecol - 1;
                int charend = txtEditor.GetFirstCharIndexFromLine(linenum2-1) + linecol2 - 1;
                */

                txtEditor.SelectionStart = charstart;
                txtEditor.SelectionLength = Math.Max(0, charend - charstart + 1);
                txtEditor.SelectionBackColor = Color.Orange;
                txtEditor.SelectionFont = new Font(txtEditor.Font, FontStyle.Bold);
                txtEditor.SelectionLength = 0;
                txtEditor.SelectionBackColor = Color.White;
                txtEditor.SelectionFont = new Font(txtEditor.Font, FontStyle.Regular);

                ListViewItem lvi = lvEditor.Items.Add(line);
                lvi.Tag = charstart;
                lvi.ImageKey = "warning";

                if (m == ind && !iserror)
                {
                    selstart = charstart;

                    lvEditor.Items[lvEditor.Items.Count - 1].Selected = true;
                }
            }

            txtEditor.SelectionStart = selstart;

            tabControl1.SelectedTab = tabPage5;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string txt = lblResult.Text + "\n\n";

                txt += "================================================================================\n";
                txt+=TranslateHelper.Translate("Successful URLs / Files")+"\n\n";

                for (int k = 0; k < tvS.Nodes.Count; k++)
                {
                    txt += tvS.Nodes[k].Text + "\n";
                }

                txt += "================================================================================\n";
                txt+=TranslateHelper.Translate("URLs / Files with Errors or Warnings")+"\n\n";

                for (int k = 0; k < tvE.Nodes.Count; k++)
                {
                    txt += tvE.Nodes[k].Text + "\n";
                }

                txt += "================================================================================\n";
                txt+=TranslateHelper.Translate("URLs / Files with Warnings Only")+"\n\n";

                for (int k = 0; k < tvW.Nodes.Count; k++)
                {
                    txt += tvW.Nodes[k].Text + "\n";
                }

                txt += "================================================================================\n";
                txt += TranslateHelper.Translate("URLs / Files with Download Errors") + "\n\n";

                for (int k = 0; k < tvDE.Nodes.Count; k++)
                {
                    txt += tvDE.Nodes[k].Text + "\n";
                }

                txt += "================================================================================\n";
                txt += TranslateHelper.Translate("Errors and Warnings List") + "\n\n";

                txt += TotalOutput;

                txt=txt.Replace("\r\n", "\n");
                txt=txt.Replace("\n", Environment.NewLine);

                System.IO.File.WriteAllText(saveFileDialog1.FileName, txt);

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;

            ContextMenuStrip cmu = (ContextMenuStrip)ti.Owner;

            TreeView tv = (TreeView)cmu.SourceControl;

            int ind = 0;

            if (tv.SelectedNode.Tag == null)
            {
                ind = (int)tv.SelectedNode.Parent.Tag;
            }
            else
            {
                ind = (int)tv.SelectedNode.Tag;
            }

            System.Diagnostics.Process.Start(lstURL1[ind]);
        }

        private void copyLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;

            ContextMenuStrip cmu = (ContextMenuStrip)ti.Owner;

            TreeView tv = (TreeView)cmu.SourceControl;
            
                int ind = 0;

                if (tv.SelectedNode.Tag == null)
                {
                    ind = (int)tv.SelectedNode.Parent.Tag;
                }
                else
                {
                    ind = (int)tv.SelectedNode.Tag;
                }

                Clipboard.Clear();
                Clipboard.SetText(lstURL1[ind]);
        }

        private void copyErrosAndWarningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;

            ContextMenuStrip cmu = (ContextMenuStrip)ti.Owner;

            TreeView tv = (TreeView)cmu.SourceControl;

            int ind = 0;

            if (tv.SelectedNode.Tag == null)
            {
                ind = (int)tv.SelectedNode.Parent.Tag;
            }
            else
            {
                ind = (int)tv.SelectedNode.Tag;
            }

            string txt = "";

            for (int k = 0; k < lstvld1[ind].lstErrors.Count; k++)
            {
                txt += lstvld1[ind].lstErrors[k];
            }

            for (int k = 0; k < lstvld1[ind].lstWarnings.Count; k++)
            {
                txt += lstvld1[ind].lstWarnings[k];
            }

            Clipboard.Clear();
            Clipboard.SetText(txt);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;

            ContextMenuStrip cmu = (ContextMenuStrip)ti.Owner;

            TreeView tv = (TreeView)cmu.SourceControl;

            int ind = 0;

            if (tv.SelectedNode.Tag == null)
            {
                ind = (int)tv.SelectedNode.Parent.Tag;
            }
            else
            {
                ind = (int)tv.SelectedNode.Tag;
            }

            saveFileDialog1.FileName = lstURL1[ind].Replace("http://", "").Replace("https://", "").Replace("/", "_") + ".txt";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {               
                string txt = "";

                txt += TranslateHelper.Translate("URL / FIle") + " : " + lstURL1[ind] + "\n";
                txt += TranslateHelper.Translate("Errors found") + " : " + lstvld1[ind].lstErrors.Count + "\n";
                txt += TranslateHelper.Translate("Warnings found") + " : " + lstvld1[ind].lstWarnings.Count + "\n\n";
                txt += TranslateHelper.Translate("Errors and Warnings List")+"\n\n";

                for (int k = 0; k < lstvld1[ind].lstErrors.Count; k++)
                {
                    txt += lstvld1[ind].lstErrors[k];
                }

                for (int k = 0; k < lstvld1[ind].lstWarnings.Count; k++)
                {
                    txt += lstvld1[ind].lstWarnings[k];
                }

                System.IO.File.WriteAllText(saveFileDialog1.FileName, txt);
            }
        }

        private void openInEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;

            ContextMenuStrip cmu = (ContextMenuStrip)ti.Owner;

            TreeView tv = (TreeView)cmu.SourceControl;

            int ind = 0;

            TreeNode no = null;

            if (tv.SelectedNode.Tag == null)
            {
                no = tv.SelectedNode.Parent;                
            }
            else
            {
                ind = (int)tv.SelectedNode.Tag;

                no = tv.SelectedNode;                
            }

            LoadInEditor(no);
        }

        private void openInNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;

            ContextMenuStrip cmu = (ContextMenuStrip)ti.Owner;

            TreeView tv = (TreeView)cmu.SourceControl;

            int ind = 0;

            TreeNode no = null;

            if (tv.SelectedNode.Tag == null)
            {
                ind = (int)tv.SelectedNode.Parent.Tag;
            }
            else
            {
                ind = (int)tv.SelectedNode.Tag;                
            }

            System.Diagnostics.Process.Start("notepad.exe", lstFile1[ind]);
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(txtEditor.Text);
        }

        private void tsbSaveEditor_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*";
            saveFileDialog1.FileName = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, txtEditor.Text);
            }
        }
    }
}
