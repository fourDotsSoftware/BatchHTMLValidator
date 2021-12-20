using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BatchHTMLValidator
{
    public partial class frmJavaCheck : BatchHTMLValidator.CustomForm
    {
        public frmJavaCheck()
        {
            InitializeComponent();
        }

        public static bool CheckJavaInstalled()
        {
            bool success = false;

            RegistryKey rk = Registry.LocalMachine;

            try
            {
                RegistryKey subKey = rk.OpenSubKey("SOFTWARE\\Wow6432Node\\JavaSoft\\Java Runtime Environment");

                string currentVerion = subKey.GetValue("CurrentVersion").ToString();

                subKey.Close();

                success = true;

                return true;
            }
            catch
            {

            }

            if (!success)
            {
                try
                {
                    RegistryKey subKey = rk.OpenSubKey("SOFTWARE\\JavaSoft\\Java Runtime Environment");

                    string currentVerion = subKey.GetValue("CurrentVersion").ToString();

                    return true;
                }
                catch
                {
                    frmJavaCheck f = new frmJavaCheck();
                    f.ShowDialog();

                    return false;
                }
            }

            return true;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://java.com/en/download/");

            Application.Exit();
        }
    }
}
