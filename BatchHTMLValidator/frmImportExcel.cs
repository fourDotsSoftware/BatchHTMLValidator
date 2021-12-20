using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel;

namespace BatchHTMLValidator
{
    public partial class frmImportExcel : BatchHTMLValidator.CustomForm
    {
        private int Column = 1;
        
        private bool BatchJoin = false;

        public frmImportExcel():this(false)
        {
            
        }

        public frmImportExcel(bool batchjoin)
        {
            InitializeComponent();

            if (!batchjoin)
            {
                lblOutputColumn.Visible = false;
                txtOutputColumn.Visible = false;
                txtColumn.Text = "A";
            }

            BatchJoin = batchjoin;
        }

        public void ImportListExcel(string filepath)
        {
            using (FileStream stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelReader = null;

                string curdir = Environment.CurrentDirectory;

                try
                {
                    Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(filepath);

                    if (filepath.ToLower().EndsWith(".xls") || filepath.ToLower().EndsWith(".xlt"))
                    {
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (filepath.ToLower().EndsWith(".xlsx"))
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }

                    excelReader.IsFirstRowAsColumnNames = chkHasHeaders.Checked;

                    DataSet result = excelReader.AsDataSet(false);

                    if (result.Tables.Count > 0)
                    {
                        for (int m = 0; m < result.Tables.Count; m++)
                        {                                                        
                            for (int k = 0; k < result.Tables[m].Rows.Count; k++)
                            {
                                if (result.Tables[m].Columns.Count > 0)
                                {                                    
                                    if (result.Tables[m].Rows[k][Column].ToString() != string.Empty)
                                    {
                                        string file = result.Tables[m].Rows[k][Column].ToString();
                                        
                                            file = GetPart(file);

                                            if (!(file.ToLower().StartsWith("http://") || file.ToLower().StartsWith("https://")))
                                            {
                                                file = Path.GetFullPath(file);
                                            }

                                            frmMain.Instance.AddFile(file);
                                        
                                    }                                                                                                          
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Environment.CurrentDirectory = curdir;

                    if (excelReader != null)
                    {
                        excelReader.Close();
                        excelReader.Dispose();
                    }
                }
            }
        }               

        private static string GetPart(string part)
        {
            if (part.StartsWith("\""))
            {
                int epos = part.IndexOf("\"", 1);

                if (epos > 0)
                {
                    part = part.Substring(1, epos - 1);
                }
            }
            else if (part.StartsWith("'"))
            {
                int epos = part.IndexOf("'", 1);

                if (epos > 0)
                {
                    part = part.Substring(1, epos - 1);
                }
            }

            return part;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel Files (*.xls;*.xlsx;*.xlt)|*.xls;*.xlsx;*.xlt";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilepath.Text = openFileDialog1.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFilepath.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify a CSV File !");
                return;
            }

            if (!System.IO.File.Exists(txtFilepath.Text))
            {
                Module.ShowMessage("Please specify a valid CSV FIle !");
                return;

            }            

            int column;

            if (txtColumn.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify a valid Videos to Join Column !");
                return;
            }
            else
            {
                if (!int.TryParse(txtColumn.Text, out column))
                {
                    char achar = 'A';
                    char colchar = txtColumn.Text.ToUpper()[0];

                    int dif = colchar - achar;
                    column = dif + 1;
                }
            }

            Column = column - 1;

            ImportListExcel(txtFilepath.Text);


            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
