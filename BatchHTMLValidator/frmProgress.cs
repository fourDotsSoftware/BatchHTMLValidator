using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BatchHTMLValidator
{
    public partial class frmProgress : CustomForm
    {
        private static frmProgress _Instance = null;

        public static frmProgress Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmProgress();
                }

                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
                    
        public frmProgress()
        {
            InitializeComponent();
            Instance = this;
            
        }

        private delegate void HideFormDelegate();

        public void HideForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((HideFormDelegate)HideForm, null);
            }
            else
            {
                this.Visible = false;
            }
        }

        private delegate void ShowFormDelegate();

        public void ShowForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((ShowFormDelegate)ShowForm, null);
            }
            else
            {
                this.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            

        }

        public int Secs = 0;

        private void timTime_Tick(object sender, EventArgs e)
        {
            Secs++;

            TimeSpan ts = new TimeSpan(0, 0, Secs);

            lblElapsedTime.Text = (ts.Hours > 0 ? ts.Hours.ToString("D2") + ":" : "") + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

            if (progressBar1.Value > 0)
            {
                //val elapsed time
                //max-val ?
                decimal d1 = (decimal)progressBar1.Value;
                decimal d2 = (decimal)Secs;
                decimal d3 = (decimal)progressBar1.Maximum - progressBar1.Value;

                decimal d = (d3 * d2) / d1;
                int id = (int)d;

                ts = new TimeSpan(0, 0, id);

                lblRemainingTime.Text = (ts.Hours > 0 ? ts.Hours.ToString("D2") + ":" : "") + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");
            }
            else
            {
                lblRemainingTime.Text = "";
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {            
            frmMain.Instance.Paused = !frmMain.Instance.Paused;
            timTime.Enabled = !frmMain.Instance.Paused;

            if (frmMain.Instance.Paused)
            {
                btnPause.Image = Properties.Resources.media_play;
            }
            else
            {
                btnPause.Image = Properties.Resources.media_pause;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            frmMain.Instance.Stopped = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(2, 2, this.Width - 4, this.Height - 4));
        }
    }
}

