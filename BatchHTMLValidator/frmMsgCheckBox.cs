using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BatchHTMLValidator
{
    public partial class frmMsgCheckBox : BatchHTMLValidator.CustomForm
    {
        public enum MsgModeEnum
        {
            OnUsageLimits            
        }

        public MsgModeEnum MsgMode;

        public frmMsgCheckBox()
        {
            InitializeComponent();
        }

        public frmMsgCheckBox(MsgModeEnum msgmode,string msg):this()
        {
            MsgMode = msgmode;
            lblMsg.Text = msg;
            lblMsg.Left = this.ClientRectangle.Width / 2 - lblMsg.Width / 2;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkDoNotShowAgain.Checked)
            {
                if (MsgMode == MsgModeEnum.OnUsageLimits)
                {
                    Properties.Settings.Default.MsgShowTrialUsageLimits = false;
                }                
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
