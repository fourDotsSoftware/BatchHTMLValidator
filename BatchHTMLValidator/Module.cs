using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;

namespace BatchHTMLValidator
{
    class Module
    {
        public static System.Drawing.Color BlueForeColor = System.Drawing.Color.FromArgb(52, 89, 152);

        public static string ApplicationName = "Batch HTML Validator";
        public static string Version = "1.6";

        public static string ShortApplicationTitle = ApplicationName + " V" + Version;
        public static string ApplicationTitle = ShortApplicationTitle + " - 4dots Software";        
        
        public static string DownloadURL = "http://www.4dots-software.com/d/BatchHTMLValidator/";
        public static string HelpURL = "http://www.4dots-software.com/batch-html-validator/how-to-use.php";
        public static string TipText = "Great application to Batch HTML Validate entire Sites !";

        public static string BuyURL = "http://www.4dots-software.com/store/buy-batch-html-validator.php";
        public static string ProductWebpageURL = "http://www.4dots-software.com/batch-html-validator/";
        public static string VersionURL = "http://cssspritestool.com/versions/batch-html-validator.txt";

        public static string[] args = null;

        public static string AppDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Video Cutter Expert\\";

        public static string SelectedLanguage = "";

        public static string StoreUrl = "http://www.pdfdocmerge.com/store/";                                          
        
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam,
        int lParam);

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        public static void WaitNMSeconds(int mseconds)
        {
            if (mseconds < 1) return;
            DateTime _desired = DateTime.Now.AddMilliseconds(mseconds);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public static string GetRelativePath(string mainDirPath, string absoluteFilePath)
        {
            string[] firstPathParts = mainDirPath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
            string[] secondPathParts = absoluteFilePath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);

            int sameCounter = 0;
            for (int i = 0; i < Math.Min(firstPathParts.Length,
            secondPathParts.Length); i++)
            {
                if (
                !firstPathParts[i].ToLower().Equals(secondPathParts[i].ToLower()))
                {
                    break;
                }
                sameCounter++;
            }

            if (sameCounter == 0)
            {
                return absoluteFilePath;
            }

            string newPath = String.Empty;
            for (int i = sameCounter; i < firstPathParts.Length; i++)
            {
                if (i > sameCounter)
                {
                    newPath += Path.DirectorySeparatorChar;
                }
                newPath += "..";
            }
            if (newPath.Length == 0)
            {
                newPath = ".";
            }
            for (int i = sameCounter; i < secondPathParts.Length; i++)
            {
                newPath += Path.DirectorySeparatorChar;
                newPath += secondPathParts[i];
            }
            return newPath;
        }

        public static void ShowMessage(string msg)
        {            
            MessageBox.Show(TranslateHelper.Translate(msg));            
        }

        public static DialogResult ShowQuestionDialog(string msg, string caption)
        {
            return MessageBox.Show(TranslateHelper.Translate(msg), TranslateHelper.Translate(caption), MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
        }


        public static void ShowError(Exception ex)
        {
            ShowError("Error", ex);
        }

        public static void ShowError(string msg)
        {
            try
            {
                frmError f = new frmError("Error", msg);
                f.ShowDialog();
            }
            catch
            {

            }
        }


        public static void ShowError(string msg, Exception ex)
        {
            ShowError(msg + "\n\n" + ex.Message);
        }

        public static void ShowError(string msg, string exstr)
        {
            ShowError(msg + "\n\n" + exstr);
        }

        public static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {           
            
        }

        public static DialogResult ShowQuestionDialogYesFocus(string msg, string caption)
        {
            return MessageBox.Show(TranslateHelper.Translate(msg), TranslateHelper.Translate(caption), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }       
        
        public static int _Modex64 = -1;

        public static bool Modex64
        {
            get
            {
                if (_Modex64 == -1)
                {
                    if (Marshal.SizeOf(typeof(IntPtr)) == 8)
                    {
                        _Modex64 = 1;
                        return true;
                    }
                    else
                    {
                        _Modex64 = 0;
                        return false;
                    }
                }
                else if (_Modex64 == 1)
                {
                    return true;
                }
                else if (_Modex64 == 0)
                {
                    return false;
                }
                return false;
            }
        }

        public static string DownloadPage(string uri)
        {
            try
            {
                WebClient client = new WebClient();

                Stream data = client.OpenRead(uri);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                return s;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        public static void CheckVersion(bool onstart)
        {
            try
            {
                string str = DownloadPage("http://www.4dots-software.com/versions.txt");

                if (str != "Error" && str != String.Empty)
                {
                    StringReader sr = new StringReader(str);
                    string line;

                    bool found = false;

                    while ((line = sr.ReadLine()) != null)
                    {
                        int epos = line.IndexOf("=");

                        string title = line.Substring(0, epos);
                        string version = line.Substring(epos + 1, line.Length - epos - 1);

                        string app = title + " V" + version;

                        if (Module.ShortApplicationTitle.StartsWith(title) && app != Module.ShortApplicationTitle)
                        {
                            found = true;
                            Module.ShowMessage("A new version has been released. Press the OK button to download the new version");

                            System.Diagnostics.Process.Start(Module.DownloadURL);
                        }
                        else if (Module.ShortApplicationTitle.StartsWith(title))
                        {
                            found = true;
                            if (!onstart)
                            {
                                Module.ShowMessage("This is the latest version !");
                            }
                        }
                    }

                    if (!found)
                    {
                        if (!onstart)
                        {
                            Module.ShowMessage("An error occured !");
                        }
                    }
                }
                else
                {
                    if (!onstart)
                    {
                        Module.ShowMessage("An error occured !");
                    }
                }
            }
            catch
            {
                if (!onstart)
                {
                    Module.ShowMessage("An error occured !");
                }
            }
        }

        public static CheckVersionResult CheckVersionBackground()
        {
            bool onstart = true;
            CheckVersionResult res = new CheckVersionResult();

            try
            {
                string str = DownloadPage("http://www.4dots-software.com/versions.txt");

                if (str != "Error" && str != String.Empty)
                {
                    StringReader sr = new StringReader(str);
                    string line;

                    bool found = false;

                    while ((line = sr.ReadLine()) != null)
                    {
                        int epos = line.IndexOf("=");

                        string title = line.Substring(0, epos);
                        string version = line.Substring(epos + 1, line.Length - epos - 1);

                        string app = title + " V" + version;

                        if (Module.ShortApplicationTitle.StartsWith(title) && app != Module.ShortApplicationTitle)
                        {
                            found = true;
                            res.OutputMessage=TranslateHelper.Translate("A new version has been released. Press the OK button to download the new version");
                            res.NewVersionReleased = true;

                            //System.Diagnostics.Process.Start(Module.DownloadURL);
                        }
                        else if (Module.ShortApplicationTitle.StartsWith(title))
                        {
                            found = true;
                            if (!onstart)
                            {
                                res.OutputMessage=TranslateHelper.Translate("This is the latest version !");
                            }
                        }
                    }

                    if (!found)
                    {
                        if (!onstart)
                        {
                            res.OutputMessage=TranslateHelper.Translate("An error occured !");
                        }
                    }
                }
                else
                {
                    if (!onstart)
                    {
                        res.OutputMessage = TranslateHelper.Translate("An error occured !");
                    }
                }
            }
            catch
            {
                if (!onstart)
                {
                    res.OutputMessage = TranslateHelper.Translate("An error occured !");
                }
            }

            return res;
        }

        public static bool DeleteApplicationSettingsFile()
        {
            try
            {
                string settingsFile = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;

                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();

                System.IO.FileInfo fi = new FileInfo(settingsFile);
                fi.Attributes = System.IO.FileAttributes.Normal;
                fi.Delete();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }        
}
