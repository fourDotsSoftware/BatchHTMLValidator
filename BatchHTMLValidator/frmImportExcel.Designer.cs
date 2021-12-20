namespace BatchHTMLValidator
{
    partial class frmImportExcel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportExcel));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtOutputColumn = new System.Windows.Forms.TextBox();
            this.lblOutputColumn = new System.Windows.Forms.Label();
            this.chkHasHeaders = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtColumn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFilepath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtOutputColumn
            // 
            resources.ApplyResources(this.txtOutputColumn, "txtOutputColumn");
            this.txtOutputColumn.Name = "txtOutputColumn";
            // 
            // lblOutputColumn
            // 
            resources.ApplyResources(this.lblOutputColumn, "lblOutputColumn");
            this.lblOutputColumn.BackColor = System.Drawing.Color.Transparent;
            this.lblOutputColumn.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblOutputColumn.Name = "lblOutputColumn";
            // 
            // chkHasHeaders
            // 
            resources.ApplyResources(this.chkHasHeaders, "chkHasHeaders");
            this.chkHasHeaders.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkHasHeaders.Name = "chkHasHeaders";
            this.chkHasHeaders.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::BatchHTMLValidator.Properties.Resources.exit;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::BatchHTMLValidator.Properties.Resources.check;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtColumn
            // 
            resources.ApplyResources(this.txtColumn, "txtColumn");
            this.txtColumn.Name = "txtColumn";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Name = "label6";
            // 
            // txtFilepath
            // 
            resources.ApplyResources(this.txtFilepath, "txtFilepath");
            this.txtFilepath.Name = "txtFilepath";
            // 
            // frmImportExcel
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.txtOutputColumn);
            this.Controls.Add(this.lblOutputColumn);
            this.Controls.Add(this.chkHasHeaders);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtColumn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFilepath);
            this.Name = "frmImportExcel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox chkHasHeaders;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox txtColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtFilepath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.TextBox txtOutputColumn;
        private System.Windows.Forms.Label lblOutputColumn;
    }
}
