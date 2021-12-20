namespace BatchHTMLValidator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tsCut = new System.Windows.Forms.ToolStrip();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbValidateHTML = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListFromCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListFromExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListFromXMLSitemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadFreeApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pleaseShareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnFacebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnGooglePlusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareOnLinkedinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareWithEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpUsersManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.pleaseDonateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebpageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtLinks = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tsCut.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsCut
            // 
            resources.ApplyResources(this.tsCut, "tsCut");
            this.tsCut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClear,
            this.toolStripSeparator6,
            this.tsbValidateHTML});
            this.tsCut.Name = "tsCut";
            // 
            // tsbClear
            // 
            resources.ApplyResources(this.tsbClear, "tsbClear");
            this.tsbClear.Image = global::BatchHTMLValidator.Properties.Resources.brush21;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // tsbValidateHTML
            // 
            resources.ApplyResources(this.tsbValidateHTML, "tsbValidateHTML");
            this.tsbValidateHTML.Image = global::BatchHTMLValidator.Properties.Resources.flash1;
            this.tsbValidateHTML.Name = "tsbValidateHTML";
            this.tsbValidateHTML.Click += new System.EventHandler(this.tsbValidateHTML_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.downloadFreeApplicationsToolStripMenuItem,
            this.pleaseShareToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importListFromTextFileToolStripMenuItem,
            this.importListFromCSVFileToolStripMenuItem,
            this.importListFromExcelFileToolStripMenuItem,
            this.importListFromXMLSitemapToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            // 
            // importListFromTextFileToolStripMenuItem
            // 
            this.importListFromTextFileToolStripMenuItem.Name = "importListFromTextFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromTextFileToolStripMenuItem, "importListFromTextFileToolStripMenuItem");
            this.importListFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.importListFromTextFileToolStripMenuItem_Click);
            // 
            // importListFromCSVFileToolStripMenuItem
            // 
            this.importListFromCSVFileToolStripMenuItem.Name = "importListFromCSVFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromCSVFileToolStripMenuItem, "importListFromCSVFileToolStripMenuItem");
            this.importListFromCSVFileToolStripMenuItem.Click += new System.EventHandler(this.importListFromCSVFileToolStripMenuItem_Click);
            // 
            // importListFromExcelFileToolStripMenuItem
            // 
            this.importListFromExcelFileToolStripMenuItem.Name = "importListFromExcelFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromExcelFileToolStripMenuItem, "importListFromExcelFileToolStripMenuItem");
            this.importListFromExcelFileToolStripMenuItem.Click += new System.EventHandler(this.importListFromExcelFileToolStripMenuItem_Click);
            // 
            // importListFromXMLSitemapToolStripMenuItem
            // 
            this.importListFromXMLSitemapToolStripMenuItem.Name = "importListFromXMLSitemapToolStripMenuItem";
            resources.ApplyResources(this.importListFromXMLSitemapToolStripMenuItem, "importListFromXMLSitemapToolStripMenuItem");
            this.importListFromXMLSitemapToolStripMenuItem.Click += new System.EventHandler(this.importListFromXMLSitemapToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.validateHTMLToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.brush2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // validateHTMLToolStripMenuItem
            // 
            this.validateHTMLToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.flash;
            this.validateHTMLToolStripMenuItem.Name = "validateHTMLToolStripMenuItem";
            resources.ApplyResources(this.validateHTMLToolStripMenuItem, "validateHTMLToolStripMenuItem");
            this.validateHTMLToolStripMenuItem.Click += new System.EventHandler(this.tsbValidateHTML_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languages1ToolStripMenuItem,
            this.languages2ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // languages1ToolStripMenuItem
            // 
            this.languages1ToolStripMenuItem.Name = "languages1ToolStripMenuItem";
            resources.ApplyResources(this.languages1ToolStripMenuItem, "languages1ToolStripMenuItem");
            // 
            // languages2ToolStripMenuItem
            // 
            this.languages2ToolStripMenuItem.Name = "languages2ToolStripMenuItem";
            resources.ApplyResources(this.languages2ToolStripMenuItem, "languages2ToolStripMenuItem");
            // 
            // downloadFreeApplicationsToolStripMenuItem
            // 
            this.downloadFreeApplicationsToolStripMenuItem.Name = "downloadFreeApplicationsToolStripMenuItem";
            resources.ApplyResources(this.downloadFreeApplicationsToolStripMenuItem, "downloadFreeApplicationsToolStripMenuItem");
            // 
            // pleaseShareToolStripMenuItem
            // 
            this.pleaseShareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shareOnFacebookToolStripMenuItem,
            this.shareOnTwitterToolStripMenuItem,
            this.shareOnGooglePlusToolStripMenuItem,
            this.shareOnLinkedinToolStripMenuItem,
            this.shareWithEmailToolStripMenuItem});
            this.pleaseShareToolStripMenuItem.Name = "pleaseShareToolStripMenuItem";
            resources.ApplyResources(this.pleaseShareToolStripMenuItem, "pleaseShareToolStripMenuItem");
            // 
            // shareOnFacebookToolStripMenuItem
            // 
            this.shareOnFacebookToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.facebook_24;
            this.shareOnFacebookToolStripMenuItem.Name = "shareOnFacebookToolStripMenuItem";
            resources.ApplyResources(this.shareOnFacebookToolStripMenuItem, "shareOnFacebookToolStripMenuItem");
            this.shareOnFacebookToolStripMenuItem.Click += new System.EventHandler(this.shareOnFacebookToolStripMenuItem_Click);
            // 
            // shareOnTwitterToolStripMenuItem
            // 
            this.shareOnTwitterToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.twitter_24;
            this.shareOnTwitterToolStripMenuItem.Name = "shareOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.shareOnTwitterToolStripMenuItem, "shareOnTwitterToolStripMenuItem");
            this.shareOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.shareOnTwitterToolStripMenuItem_Click);
            // 
            // shareOnGooglePlusToolStripMenuItem
            // 
            this.shareOnGooglePlusToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.googleplus_24;
            this.shareOnGooglePlusToolStripMenuItem.Name = "shareOnGooglePlusToolStripMenuItem";
            resources.ApplyResources(this.shareOnGooglePlusToolStripMenuItem, "shareOnGooglePlusToolStripMenuItem");
            this.shareOnGooglePlusToolStripMenuItem.Click += new System.EventHandler(this.shareOnGooglePlusToolStripMenuItem_Click);
            // 
            // shareOnLinkedinToolStripMenuItem
            // 
            this.shareOnLinkedinToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.linkedin_24;
            this.shareOnLinkedinToolStripMenuItem.Name = "shareOnLinkedinToolStripMenuItem";
            resources.ApplyResources(this.shareOnLinkedinToolStripMenuItem, "shareOnLinkedinToolStripMenuItem");
            this.shareOnLinkedinToolStripMenuItem.Click += new System.EventHandler(this.shareOnLinkedinToolStripMenuItem_Click);
            // 
            // shareWithEmailToolStripMenuItem
            // 
            this.shareWithEmailToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.mail;
            this.shareWithEmailToolStripMenuItem.Name = "shareWithEmailToolStripMenuItem";
            resources.ApplyResources(this.shareWithEmailToolStripMenuItem, "shareWithEmailToolStripMenuItem");
            this.shareWithEmailToolStripMenuItem.Click += new System.EventHandler(this.shareWithEmailToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpUsersManualToolStripMenuItem,
            this.toolStripMenuItem4,
            this.pleaseDonateToolStripMenuItem,
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem,
            this.followUsOnTwitterToolStripMenuItem,
            this.visit4dotsSoftwareWebpageToolStripMenuItem,
            this.toolStripMenuItem9,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.feedbackToolStripMenuItem,
            this.checkForNewVersionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpUsersManualToolStripMenuItem
            // 
            this.helpUsersManualToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.help2;
            this.helpUsersManualToolStripMenuItem.Name = "helpUsersManualToolStripMenuItem";
            resources.ApplyResources(this.helpUsersManualToolStripMenuItem, "helpUsersManualToolStripMenuItem");
            this.helpUsersManualToolStripMenuItem.Click += new System.EventHandler(this.helpUsersManualToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // pleaseDonateToolStripMenuItem
            // 
            resources.ApplyResources(this.pleaseDonateToolStripMenuItem, "pleaseDonateToolStripMenuItem");
            this.pleaseDonateToolStripMenuItem.ForeColor = System.Drawing.Color.ForestGreen;
            this.pleaseDonateToolStripMenuItem.Name = "pleaseDonateToolStripMenuItem";
            this.pleaseDonateToolStripMenuItem.Click += new System.EventHandler(this.pleaseDonateToolStripMenuItem_Click);
            // 
            // dotsSoftwarePRODUCTCATALOGToolStripMenuItem
            // 
            resources.ApplyResources(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem, "dotsSoftwarePRODUCTCATALOGToolStripMenuItem");
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Name = "dotsSoftwarePRODUCTCATALOGToolStripMenuItem";
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click);
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            this.followUsOnTwitterToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.twitter_24;
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.followUsOnTwitterToolStripMenuItem, "followUsOnTwitterToolStripMenuItem");
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // visit4dotsSoftwareWebpageToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.earth;
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Name = "visit4dotsSoftwareWebpageToolStripMenuItem";
            resources.ApplyResources(this.visit4dotsSoftwareWebpageToolStripMenuItem, "visit4dotsSoftwareWebpageToolStripMenuItem");
            this.visit4dotsSoftwareWebpageToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebpageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            // 
            // feedbackToolStripMenuItem
            // 
            this.feedbackToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.edit;
            this.feedbackToolStripMenuItem.Name = "feedbackToolStripMenuItem";
            resources.ApplyResources(this.feedbackToolStripMenuItem, "feedbackToolStripMenuItem");
            this.feedbackToolStripMenuItem.Click += new System.EventHandler(this.feedbackToolStripMenuItem_Click);
            // 
            // checkForNewVersionToolStripMenuItem
            // 
            this.checkForNewVersionToolStripMenuItem.Name = "checkForNewVersionToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionToolStripMenuItem, "checkForNewVersionToolStripMenuItem");
            this.checkForNewVersionToolStripMenuItem.Click += new System.EventHandler(this.checkForNewVersionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.information;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // txtLinks
            // 
            resources.ApplyResources(this.txtLinks, "txtLinks");
            this.txtLinks.Name = "txtLinks";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLinks);
            this.Controls.Add(this.tsCut);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgVideo_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgVideo_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.dgVideo_DragOver);
            this.tsCut.ResumeLayout(false);
            this.tsCut.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsCut;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbValidateHTML;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListFromTextFileToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtLinks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem languages1ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem languages2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadFreeApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pleaseShareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnFacebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnGooglePlusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareOnLinkedinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareWithEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpUsersManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem pleaseDonateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwarePRODUCTCATALOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebpageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem feedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListFromCSVFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListFromExcelFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem importListFromXMLSitemapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
    }
}

