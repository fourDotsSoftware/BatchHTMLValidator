using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;

namespace BatchHTMLValidator
{
    public partial class frmMain : CustomForm
    {
        public string err = "";

        private string tidyOutput = "";

        public string TotalOutput = "";

        public static frmMain Instance = null;

        private System.Net.WebClient webclient = new System.Net.WebClient();

        public static string TempDirectory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "BatchHTMLValidatorTemp");

        public List<string> lstURL = new List<string>();
        public List<string> lstFile = new List<string>();
        public List<string> lstLines = new List<string>();

        public List<ValidationResult> lstResult = new List<ValidationResult>();

        public bool Paused = false;
        public bool Stopped = false;

        public frmMain()
        {
            InitializeComponent();

            Instance = this;

            bwValidate.DoWork += bwValidate_DoWork;
            bwValidate.ProgressChanged += bwValidate_ProgressChanged;
            bwValidate.RunWorkerCompleted += bwValidate_RunWorkerCompleted;

            bwValidate.WorkerReportsProgress = true;
            bwValidate.WorkerSupportsCancellation = true;

        }

        #region Validation Function

        void bwValidate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        void bwValidate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                frmProgress.Instance.lblURL.Text = e.UserState.ToString();

                if (frmProgress.Instance.progressBar1.Value < frmProgress.Instance.progressBar1.Maximum)
                {
                    frmProgress.Instance.progressBar1.Value++;

                    frmProgress.Instance.lblProgress.Text = frmProgress.Instance.progressBar1.Value.ToString()
                        + " / " + frmProgress.Instance.progressBar1.Maximum.ToString();
                }
            }
        }

        void bwValidate_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int k = 0; k < lstLines.Count; k++)
            {
                if (Stopped)
                {
                    break;
                }

                while (Paused)
                {
                    Application.DoEvents();
                }

                bwValidate.ReportProgress(1, lstLines[k]);

                if (lstLines[k].Trim() != string.Empty)
                {
                    ValidationResult vld = new ValidationResult();

                    lstResult.Add(vld);

                    try
                    {
                        string file = System.IO.Path.Combine(TempDirectory, Guid.NewGuid().ToString() + ".html");

                        if (!System.IO.Directory.Exists(TempDirectory))
                        {
                            System.IO.Directory.CreateDirectory(TempDirectory);
                        }

                        lstURL.Add(lstLines[k]);

                        if (lstLines[k].ToLower().StartsWith("http://") || lstLines[k].ToLower().StartsWith("https://"))
                        {
                            lstFile.Add(file);
                            webclient.DownloadFile(lstLines[k], file);
                            RunNu(lstLines[k],file, vld);
                        }
                        else
                        {
                            lstFile.Add(lstLines[k]);
                            RunNu(lstLines[k],lstLines[k], vld);
                        }
                        //RunTidy(file,vld);

                        //8RunNu(lstLines[k], vld);


                    }
                    catch (Exception ex)
                    {
                        err += TranslateHelper.Translate("Error could not Download Webpage : ") + lstLines[k] + " " + ex.Message;

                        vld.Error = true;

                        vld.ErrorMsg = TranslateHelper.Translate("Error could not Download Webpage : ") + lstLines[k] + " " + ex.Message;
                    }
                }
            }
        }

        private void RunTidy(string file, ValidationResult vld)
        {
            tidyOutput = "";

            Process psFFMpeg = new Process();

            psFFMpeg.StartInfo.FileName = "tidy ";
            psFFMpeg.StartInfo.CreateNoWindow = true;
            psFFMpeg.StartInfo.UseShellExecute = false;
            psFFMpeg.StartInfo.RedirectStandardError = true;
            psFFMpeg.StartInfo.RedirectStandardOutput = true;

            psFFMpeg.StartInfo.Arguments = "\"" + file + "\"";

            psFFMpeg.ErrorDataReceived += psFFMpeg_ErrorDataReceived;
            psFFMpeg.OutputDataReceived += psFFMpeg_OutputDataReceived;
            psFFMpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            psFFMpeg.Start();

            psFFMpeg.BeginOutputReadLine();
            psFFMpeg.BeginErrorReadLine();

            psFFMpeg.WaitForExit();

            psFFMpeg.Close();

            ParseTidyOutput(tidyOutput, vld);
        }

        private void RunNu(string url, string file, ValidationResult vld)
        {
            tidyOutput = "";

            Process psFFMpeg = new Process();

            psFFMpeg.StartInfo.FileName = "java";
            psFFMpeg.StartInfo.CreateNoWindow = true;
            psFFMpeg.StartInfo.UseShellExecute = false;
            psFFMpeg.StartInfo.RedirectStandardError = true;
            psFFMpeg.StartInfo.RedirectStandardOutput = true;

            psFFMpeg.StartInfo.Arguments = "-Xss512k -jar vnu.jar \"" + file + "\"";

            psFFMpeg.ErrorDataReceived += psFFMpeg_ErrorDataReceived;
            psFFMpeg.OutputDataReceived += psFFMpeg_OutputDataReceived;
            psFFMpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            psFFMpeg.Start();

            psFFMpeg.BeginOutputReadLine();
            psFFMpeg.BeginErrorReadLine();

            psFFMpeg.WaitForExit();

            psFFMpeg.Close();

            //ParseTidyOutput(tidyOutput, vld);

            ParseNuOutput(tidyOutput, vld);

            if (tidyOutput != string.Empty)
            {
                TotalOutput += "================================================================================\n";
                TotalOutput += url + "\n";
                TotalOutput += tidyOutput + "\n";
            }
        }

        void psFFMpeg_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            tidyOutput += e.Data;
        }

        void psFFMpeg_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;

            string str = e.Data;

            if (str.StartsWith("\""))
            {
                str = str.Substring(1);

                int epos = str.IndexOf("\"");

                str = str.Substring(epos + 2);

            }

            str = str.Replace("β€", "");

            tidyOutput += str + "\n";
        }

        private void ParseTidyOutput(string txt, ValidationResult vld)
        {
            using (System.IO.StringReader sr = new System.IO.StringReader(txt))
            {
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(" - Warning:"))
                    {
                        vld.lstWarnings.Add(line);
                    }
                    else if (line.Contains(" - Error:"))
                    {
                        vld.lstErrors.Add(line);
                    }

                    System.Text.RegularExpressions.Regex rgResult = new System.Text.RegularExpressions.Regex
                    ("Tidy found (?<warn>\\d+) warning(?:s)* and (?<err>\\d+) error(?:s)*");

                    if (rgResult.IsMatch(line))
                    {
                        vld.NumErrors = int.Parse(rgResult.Match(line).Groups["err"].Value);
                        vld.NumWarnings = int.Parse(rgResult.Match(line).Groups["warn"].Value);
                    }
                }
            }
        }

        private void ParseNuOutput(string txt, ValidationResult vld)
        {
            using (System.IO.StringReader sr = new System.IO.StringReader(txt))
            {
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(" info warning: "))
                    {
                        vld.lstWarnings.Add(line);
                        vld.NumWarnings++;
                    }
                    else if (line.Contains(" error: "))
                    {
                        vld.lstErrors.Add(line);
                        vld.NumErrors++;
                    }
                }
            }
        }

        BackgroundWorker bwValidate = new BackgroundWorker();

        private void tsbValidateHTML_Click(object sender, EventArgs e)
        {
            err = "";
            TotalOutput = "";

            for (int k = 0; k < txtLinks.Lines.Length; k++)
            {
                if (txtLinks.Lines[k].Trim() != string.Empty && (!(txtLinks.Lines[k].StartsWith("http://") || txtLinks.Lines[k].StartsWith("https://"))
                    && !System.IO.File.Exists(txtLinks.Lines[k])))
                {
                    err += TranslateHelper.Translate("Error ! Invalid URL or File does not exist !") + " " + txtLinks.Lines[k];
                }
            }

            if (err != string.Empty)
            {
                frmError fe = new frmError("Error", err);
                fe.ShowDialog();
                return;
            }

            lstURL.Clear();
            lstFile.Clear();
            lstLines.Clear();
            lstResult.Clear();

            
            if (true)
            {
                for (int k = 0; k < txtLinks.Lines.Length; k++)
                {
                    lstLines.Add(txtLinks.Lines[k]);
                }
            }

            Paused = false;
            Stopped = false;

            frmProgress f = new frmProgress();
            f.Show(this);
            f.timTime.Enabled = true;
            this.Enabled = false;
            f.progressBar1.Maximum = txtLinks.Lines.Length;
            f.progressBar1.Value = 0;

            bwValidate.RunWorkerAsync();

            while (bwValidate.IsBusy)
            {
                Application.DoEvents();
            }

            if (frmProgress.Instance != null && frmProgress.Instance.Visible)
            {
                frmProgress.Instance.Close();
            }

            this.Enabled = true;

            if (Stopped)
            {
                Module.ShowMessage("Operation Stopped !");
                return;
            }

            frmValidationResult fv = new frmValidationResult(lstURL, lstResult, lstFile, TotalOutput);
            fv.ShowDialog(this);
        }

        #endregion

        #region Toolbar

        private void tsbClear_Click(object sender, EventArgs e)
        {
            txtLinks.Text = "";
        }

        public void AddFile(string filepath)
        {
            txtLinks.Text += filepath + "\r\n";
        }

        #endregion

        #region Help

        private void helpUsersManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.StartupPath + "\\Video Cutter Joiner Expert - User's Manual.chm");
            System.Diagnostics.Process.Start(Module.HelpURL);
        }

        private void pleaseDonateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/donate.php");
        }

        private void dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/downloads/4dots-Software-PRODUCT-CATALOG.pdf");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            frmUninstallQuestionnaire f = new frmUninstallQuestionnaire(false);
            f.ShowDialog();
            */

            System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
        }

        private void followUsOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.twitter.com/4dotsSoftware");
        }

        private void visit4dotsSoftwareWebpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com");
        }

        private void checkForNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Module.CheckVersion(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buyApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.BuyURL);
        }

        private void enterLicenseKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Share

        private void shareOnFacebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareFacebook();
        }

        private void shareOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareTwitter();
        }

        private void shareOnGooglePlusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareGooglePlus();
        }

        private void shareOnLinkedinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareLinkedIn();
        }

        private void shareWithEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareEmail();
        }

        #endregion

        #region Localization

        private void AddLanguageMenuItems()
        {
            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = frmLanguage.LangDesc[k];
                ti.Tag = frmLanguage.LangCodes[k];
                ti.Image = frmLanguage.LangImg[k];

                if (Properties.Settings.Default.Language == frmLanguage.LangCodes[k])
                {
                    ti.Checked = true;
                }

                ti.Click += new EventHandler(tiLang_Click);

                if (k < 25)
                {
                    languages1ToolStripMenuItem.DropDownItems.Add(ti);
                }
                else
                {
                    languages2ToolStripMenuItem.DropDownItems.Add(ti);
                }

                //languageToolStripMenuItem.DropDownItems.Add(ti);
            }
        }

        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            //for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            for (int k = 0; k < languages1ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages1ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }

            for (int k = 0; k < languages2ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages2ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }
        }

        private bool InChangeLanguage = false;

        private void ChangeLanguage(string language_code)
        {
            try
            {

                InChangeLanguage = true;

                Properties.Settings.Default.Language = language_code;
                frmLanguage.SetLanguage();

                bool maximized = (this.WindowState == FormWindowState.Maximized);
                this.WindowState = FormWindowState.Normal;

                /*
                RegistryKey key = Registry.CurrentUser;
                RegistryKey key2 = Registry.CurrentUser;

                try
                {
                    key = key.OpenSubKey("Software\\4dots Software", true);

                    if (key == null)
                    {
                        key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\4dots Software");
                    }

                    key2 = key.OpenSubKey(frmLanguage.RegKeyName, true);

                    if (key2 == null)
                    {
                        key2 = key.CreateSubKey(frmLanguage.RegKeyName);
                    }

                    key = key2;

                    //key.SetValue("Language", language_code);
                    key.SetValue("Menu Item Caption", TranslateHelper.Translate("Change PDF Properties"));
                }
                catch (Exception ex)
                {
                    Module.ShowError(ex);
                    return;
                }
                finally
                {
                    key.Close();
                    key2.Close();
                }
                */
                //1SaveSizeLocation();

                SavePositionSize();

                this.Controls.Clear();

                InitializeComponent();

                SetupOnLoad();

                if (maximized)
                {
                    this.WindowState = FormWindowState.Maximized;
                }

                this.ResumeLayout(true);
            }
            finally
            {
                InChangeLanguage = false;
            }
        }

        #endregion

        #region OnLoad

        private void ImportFileFromOpenWith(string filepath)
        {
            try
            {
                string ext = System.IO.Path.GetExtension(filepath).ToLower();

                if (ext == ".xml")
                {
                    ImportXMLSitemapFile(filepath);
                }
                else if (ext == ".xls" || ext == ".xlsx" || ext == ".ods")
                {
                    frmImportExcel f = new frmImportExcel();
                    f.ImportListExcel(filepath);
                }
                else if (ext == ".csv")
                {
                    frmImportCSV f = new frmImportCSV();
                    f.ImportCSV(filepath);
                }
                else
                {
                    ImportTextFile(filepath);
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not Open File !", ex);
                return;
            }
        }

        private void SetupOnLoad()
        {
            this.Text = Module.ApplicationTitle;

            DownloadSuggestionsHelper ds = new DownloadSuggestionsHelper();
            ds.SetupDownloadMenuItems(downloadFreeApplicationsToolStripMenuItem);

            /*
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Shutdown"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Sleep"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Hibernate"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Logoff"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Lock Workstation"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Restart"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Exit Application"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Explore Output Video"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Do Nothing"));

            foreach (ToolStripMenuItem ti in whenFinishedToolStripMenuItem.DropDownItems)
            {
                ti.Click += tiWhenFinished_Click;
            }            

            if (Properties.Settings.Default.WhenFinishedIndex != -1)
            {
                ToolStripMenuItem ti = (ToolStripMenuItem)whenFinishedToolStripMenuItem.DropDownItems[Properties.Settings.Default.WhenFinishedIndex];
                ti.Checked = true;
            }

            */

            RepositionResize();

            AddLanguageMenuItems();

            SetEnabled(false);

            this.Text = GetAppTitle();

            checkForNewVersionEachWeekToolStripMenuItem.Checked = Properties.Settings.Default.CheckWeek;
        }

        private string GetAppTitle()
        {
            return Module.ApplicationTitle;

            
        }

        /*
        void tiWhenFinished_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem ti2 in whenFinishedToolStripMenuItem.DropDownItems)
            {
                ti2.Checked = false;
            }

            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            ti.Checked = true;

        }
        */

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetupOnLoad();

            if (Properties.Settings.Default.CheckWeek)
            {
                UpdateHelper.InitializeCheckVersionWeek();
            }

            txtLinks.AllowDrop = true;

            txtLinks.DragDrop += dgVideo_DragDrop;
            txtLinks.DragEnter += dgVideo_DragEnter;

            if (Module.args != null && Module.args.Length > 0 && System.IO.File.Exists(Module.args[0]))
            {
                ImportFileFromOpenWith(Module.args[0]);
            }

            ResizeControls();            
        }

        private void RepositionResize()
        {
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

                if (Properties.Settings.Default.Width != -1)
                {
                    this.Width = Properties.Settings.Default.Width;
                }


                if (Properties.Settings.Default.Height != -1)
                {
                    this.Height = Properties.Settings.Default.Height;
                }

                if (Properties.Settings.Default.Left != -1)
                {
                    this.Left = Properties.Settings.Default.Left;
                }

                if (Properties.Settings.Default.Top != -1)
                {
                    this.Top = Properties.Settings.Default.Top;
                }
            }

            if (this.Width < 300)
            {
                this.Width = 300;
            }

            if (this.Height < 300)
            {
                this.Height = 300;
            }

            if (this.Top < 0)
            {
                this.Top = 0;
            }

            if (this.Left < 0)
            {
                this.Left = 0;
            }

            this.Show();
            this.BringToFront();
            this.Visible = true;
        }

        private void SavePositionSize()
        {
            Properties.Settings.Default.Maximized = (this.WindowState == FormWindowState.Maximized);
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Save();

        }

        private void SetEnabled(bool enabled)
        {

        }


        #endregion

        #region Imports

        private void importListFromCSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportCSV f = new frmImportCSV();
            f.ShowDialog();

        }

        private void importListFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportExcel f = new frmImportExcel();
            f.ShowDialog();
        }

        private void ImportTextFile(string filepath)
        {
            string curdir = Environment.CurrentDirectory;

            try
            {
                Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(filepath);

                using (System.IO.StreamReader sr = new System.IO.StreamReader(filepath, Encoding.Default, true))
                {
                    string line = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string fullfilepath = line;

                        if (!(line.ToLower().StartsWith("http://") || line.ToLower().StartsWith("https://")))
                        {
                            fullfilepath = System.IO.Path.GetFullPath(line);
                        }

                        try
                        {
                            AddFile(fullfilepath);
                        }
                        catch (Exception ex)
                        {
                            Module.ShowError("Error. Could not Add to list", ex);
                        }
                    }
                }
            }
            finally
            {
                Environment.CurrentDirectory = curdir;
            }
        }

        private void importListFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportTextFile(openFileDialog1.FileName);                
            }
        }

        private void ImportXMLSitemapFile(string filepath)
        {
            try
            {
                string txt = System.IO.File.ReadAllText(filepath,Encoding.Default);

                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(txt);

                System.Xml.XmlNodeList nolos = doc.SelectNodes("//*[local-name() = 'loc']");

                for (int k = 0; k < nolos.Count; k++)
                {
                    AddFile(nolos[k].InnerText);
                }

            }
            finally
            {

            }
        }

        private void importListFromXMLSitemapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Sitemap XML Files (*.xml)|*.xml";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportXMLSitemapFile(openFileDialog1.FileName);
            }
        }

        #endregion

        #region Drag and Drop

        private void dgVideo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgVideo_DragOver(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void dgVideo_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                // get list of files that were dropped

                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        if (System.IO.File.Exists(filez[k]))
                        {
                            AddFile(filez[k]);
                        }
                        else if (System.IO.Directory.Exists(filez[k]))
                        {
                            string[] fz = System.IO.Directory.GetFiles(filez[k], "*.*", System.IO.SearchOption.AllDirectories);

                            for (int m = 0; m < fz.Length; m++)
                            {
                                AddFile(fz[m]);
                            }
                        }
                        

                    }
                    finally
                    {
                        this.Cursor = null;
                    }
                }
            }
        }


        #endregion        

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!InChangeLanguage)
            {
                
            }

            Properties.Settings.Default.CheckWeek = checkForNewVersionEachWeekToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();
        }

        

    }

    public class ValidationResult
    {
        public int NumErrors = 0;
        public int NumWarnings = 0;

        public List<string> lstErrors = new List<string>();
        public List<string> lstWarnings = new List<string>();

        public bool Error = false;

        public string ErrorMsg = "";
    }
}
