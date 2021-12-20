using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BatchHTMLValidator
{
    public partial class frmAbout : CustomForm
    {
        public static string lblf = "";

        // license email
        public static string LDT = "";

        public frmAbout()
        {
            InitializeComponent();
        }
                     
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblAbout.Text = Module.ApplicationTitle + "\n\n" +
            "Developed by Alexander Triantafyllou\n" +
            "Copyright � 2021 - 4dots Software\n";

            ullProductWebpage.Text = Module.ProductWebpageURL;

            /*
            if (!SettingsHelper.RenMove && !frmPurchase.RenMove)
            {
                if (frmAbout.LDT == string.Empty)
                {
                    lblRegistered.Text = TranslateHelper.Translate("Tral Version - Unlicensed");
                }
                else if (frmAbout.LDT.StartsWith("BUS"))
                {
                    lblRegistered.Text = TranslateHelper.Translate("Business Version - Licensed");
                }
                else if (!frmAbout.LDT.StartsWith("BUS"))
                {
                    lblRegistered.Text = TranslateHelper.Translate("Personal/EDU Version - Licensed");
                }

                lblLicenseKey.Text = LDT;

                if (LDT != string.Empty)
                {
                    btnRegister.Visible = false;
                }
            }
            else
            {
                lblRegistered.Text = TranslateHelper.Translate("Tral Version - Unlicensed");
            } 
            */
        }
                
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/support/");
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.BuyURL);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
           
        }

        private void llLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void llLicense_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Module.ShowMessage(Application.StartupPath + "\\NuHtmlChecker_license.txt");
            System.Diagnostics.Process.Start(Application.StartupPath + "\\NuHtmlChecker_license.txt");
        }
    }
}