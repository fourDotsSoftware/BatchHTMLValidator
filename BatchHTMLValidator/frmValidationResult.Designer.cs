namespace BatchHTMLValidator
{
    partial class frmValidationResult
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidationResult));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvE = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvW = new System.Windows.Forms.TreeView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tvS = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tvDE = new System.Windows.Forms.TreeView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lblEditorFile = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.RichTextBox();
            this.lvEditor = new System.Windows.Forms.ListView();
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtEditor = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.tsCut = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveEditor = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openInEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyErrosAndWarningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tsCut.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tvE);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tvE
            // 
            resources.ApplyResources(this.tvE, "tvE");
            this.tvE.Name = "tvE";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tvW);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvW
            // 
            resources.ApplyResources(this.tvW, "tvW");
            this.tvW.Name = "tvW";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tvS);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tvS
            // 
            resources.ApplyResources(this.tvS, "tvS");
            this.tvS.Name = "tvS";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tvDE);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tvDE
            // 
            resources.ApplyResources(this.tvDE, "tvDE");
            this.tvDE.Name = "tvDE";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lblEditorFile);
            this.tabPage5.Controls.Add(this.txtError);
            this.tabPage5.Controls.Add(this.lvEditor);
            this.tabPage5.Controls.Add(this.txtEditor);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lblEditorFile
            // 
            resources.ApplyResources(this.lblEditorFile, "lblEditorFile");
            this.lblEditorFile.BackColor = System.Drawing.Color.LightGray;
            this.lblEditorFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEditorFile.Name = "lblEditorFile";
            // 
            // txtError
            // 
            resources.ApplyResources(this.txtError, "txtError");
            this.txtError.Name = "txtError";
            // 
            // lvEditor
            // 
            resources.ApplyResources(this.lvEditor, "lvEditor");
            this.lvEditor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDescription});
            this.lvEditor.Name = "lvEditor";
            this.lvEditor.UseCompatibleStateImageBehavior = false;
            this.lvEditor.View = System.Windows.Forms.View.SmallIcon;
            // 
            // colDescription
            // 
            resources.ApplyResources(this.colDescription, "colDescription");
            // 
            // txtEditor
            // 
            resources.ApplyResources(this.txtEditor, "txtEditor");
            this.txtEditor.Name = "txtEditor";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Image = global::BatchHTMLValidator.Properties.Resources.exit;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblResult
            // 
            resources.ApplyResources(this.lblResult, "lblResult");
            this.lblResult.Name = "lblResult";
            // 
            // tsCut
            // 
            resources.ApplyResources(this.tsCut, "tsCut");
            this.tsCut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbSaveEditor,
            this.tsbCopy});
            this.tsCut.Name = "tsCut";
            // 
            // tsbSave
            // 
            resources.ApplyResources(this.tsbSave, "tsbSave");
            this.tsbSave.Image = global::BatchHTMLValidator.Properties.Resources.disk_blue1;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbSaveEditor
            // 
            resources.ApplyResources(this.tsbSaveEditor, "tsbSaveEditor");
            this.tsbSaveEditor.Image = global::BatchHTMLValidator.Properties.Resources.disk_green;
            this.tsbSaveEditor.Name = "tsbSaveEditor";
            this.tsbSaveEditor.Click += new System.EventHandler(this.tsbSaveEditor_Click);
            // 
            // tsbCopy
            // 
            resources.ApplyResources(this.tsbCopy, "tsbCopy");
            this.tsbCopy.Image = global::BatchHTMLValidator.Properties.Resources.copy1;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInEditorToolStripMenuItem,
            this.openToolStripMenuItem,
            this.openInNotepadToolStripMenuItem,
            this.copyLocationToolStripMenuItem,
            this.copyErrosAndWarningsToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // openInEditorToolStripMenuItem
            // 
            this.openInEditorToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.edit;
            this.openInEditorToolStripMenuItem.Name = "openInEditorToolStripMenuItem";
            resources.ApplyResources(this.openInEditorToolStripMenuItem, "openInEditorToolStripMenuItem");
            this.openInEditorToolStripMenuItem.Click += new System.EventHandler(this.openInEditorToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.flash;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openInNotepadToolStripMenuItem
            // 
            this.openInNotepadToolStripMenuItem.Name = "openInNotepadToolStripMenuItem";
            resources.ApplyResources(this.openInNotepadToolStripMenuItem, "openInNotepadToolStripMenuItem");
            this.openInNotepadToolStripMenuItem.Click += new System.EventHandler(this.openInNotepadToolStripMenuItem_Click);
            // 
            // copyLocationToolStripMenuItem
            // 
            this.copyLocationToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.copy;
            this.copyLocationToolStripMenuItem.Name = "copyLocationToolStripMenuItem";
            resources.ApplyResources(this.copyLocationToolStripMenuItem, "copyLocationToolStripMenuItem");
            this.copyLocationToolStripMenuItem.Click += new System.EventHandler(this.copyLocationToolStripMenuItem_Click);
            // 
            // copyErrosAndWarningsToolStripMenuItem
            // 
            this.copyErrosAndWarningsToolStripMenuItem.Name = "copyErrosAndWarningsToolStripMenuItem";
            resources.ApplyResources(this.copyErrosAndWarningsToolStripMenuItem, "copyErrosAndWarningsToolStripMenuItem");
            this.copyErrosAndWarningsToolStripMenuItem.Click += new System.EventHandler(this.copyErrosAndWarningsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::BatchHTMLValidator.Properties.Resources.disk_blue;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // frmValidationResult
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tsCut);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmValidationResult";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmValidationResult_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tsCut.ResumeLayout(false);
            this.tsCut.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView tvE;
        private System.Windows.Forms.TreeView tvW;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TreeView tvS;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView tvDE;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ToolStrip tsCut;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListView lvEditor;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.RichTextBox txtEditor;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RichTextBox txtError;
        private System.Windows.Forms.Label lblEditorFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyErrosAndWarningsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInNotepadToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbSaveEditor;
        private System.Windows.Forms.ToolStripButton tsbCopy;
    }
}
