namespace PS4FileNinja
{
    partial class frmBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrowser));
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstDirectory = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstFile = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcesses = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userlandASLRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rWXMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.applyKPFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kernelMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.mnuCtxFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInHexeditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCtxFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.txtKLog = new System.Windows.Forms.TextBox();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.mnuCtxFile.SuspendLayout();
            this.mnuCtxFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(261, 63);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(1122, 31);
            this.txtPath.TabIndex = 0;
            this.txtPath.Text = "/";
            this.txtPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPath_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 15.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(256, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path";
            // 
            // lstDirectory
            // 
            this.lstDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstDirectory.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDirectory.FormattingEnabled = true;
            this.lstDirectory.ItemHeight = 23;
            this.lstDirectory.Location = new System.Drawing.Point(261, 132);
            this.lstDirectory.Name = "lstDirectory";
            this.lstDirectory.Size = new System.Drawing.Size(268, 464);
            this.lstDirectory.Sorted = true;
            this.lstDirectory.TabIndex = 2;
            this.lstDirectory.DoubleClick += new System.EventHandler(this.lstDirectory_DoubleClick);
            this.lstDirectory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstDirectory_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(256, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Directories";
            // 
            // lstFile
            // 
            this.lstFile.AllowDrop = true;
            this.lstFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFile.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFile.FormattingEnabled = true;
            this.lstFile.ItemHeight = 23;
            this.lstFile.Location = new System.Drawing.Point(535, 132);
            this.lstFile.Name = "lstFile";
            this.lstFile.Size = new System.Drawing.Size(1057, 464);
            this.lstFile.Sorted = true;
            this.lstFile.TabIndex = 4;
            this.lstFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstFile_MouseClick);
            this.lstFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFile_DragDrop);
            this.lstFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFile_DragEnter);
            this.lstFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFile_MouseDoubleClick);
            this.lstFile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstFile_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 15.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(530, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Files";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Impact", 15.75F);
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(1389, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 76);
            this.label4.TabIndex = 6;
            this.label4.Text = "Double click on a file to download it";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dlgSave
            // 
            this.dlgSave.AddExtension = false;
            this.dlgSave.Title = "Save File";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 819);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Impact", 15.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(10, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "PS4FileNinja";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.systemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1604, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProcesses});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // mnuProcesses
            // 
            this.mnuProcesses.Name = "mnuProcesses";
            this.mnuProcesses.Size = new System.Drawing.Size(125, 22);
            this.mnuProcesses.Text = "&Processes";
            this.mnuProcesses.Click += new System.EventHandler(this.mnuProcesses_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userlandASLRToolStripMenuItem,
            this.rWXMappingToolStripMenuItem,
            this.applyKPFToolStripMenuItem,
            this.kernelMemoryToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.systemToolStripMenuItem.Text = "&Patches";
            // 
            // userlandASLRToolStripMenuItem
            // 
            this.userlandASLRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem,
            this.disabledToolStripMenuItem});
            this.userlandASLRToolStripMenuItem.Name = "userlandASLRToolStripMenuItem";
            this.userlandASLRToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.userlandASLRToolStripMenuItem.Text = "&Userland ASLR";
            // 
            // enabledToolStripMenuItem
            // 
            this.enabledToolStripMenuItem.Checked = true;
            this.enabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            this.enabledToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.enabledToolStripMenuItem.Text = "&Enabled";
            this.enabledToolStripMenuItem.Click += new System.EventHandler(this.enabledToolStripMenuItem_Click);
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            this.disabledToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.disabledToolStripMenuItem.Text = "&Disabled";
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.disabledToolStripMenuItem_Click);
            // 
            // rWXMappingToolStripMenuItem
            // 
            this.rWXMappingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem1,
            this.disabledToolStripMenuItem1});
            this.rWXMappingToolStripMenuItem.Name = "rWXMappingToolStripMenuItem";
            this.rWXMappingToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.rWXMappingToolStripMenuItem.Text = "&RWX Mapping";
            // 
            // enabledToolStripMenuItem1
            // 
            this.enabledToolStripMenuItem1.Name = "enabledToolStripMenuItem1";
            this.enabledToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.enabledToolStripMenuItem1.Text = "&Enabled";
            this.enabledToolStripMenuItem1.Click += new System.EventHandler(this.enabledToolStripMenuItem1_Click);
            // 
            // disabledToolStripMenuItem1
            // 
            this.disabledToolStripMenuItem1.Checked = true;
            this.disabledToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disabledToolStripMenuItem1.Name = "disabledToolStripMenuItem1";
            this.disabledToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.disabledToolStripMenuItem1.Text = "&Disabled";
            this.disabledToolStripMenuItem1.Click += new System.EventHandler(this.disabledToolStripMenuItem1_Click);
            // 
            // applyKPFToolStripMenuItem
            // 
            this.applyKPFToolStripMenuItem.Name = "applyKPFToolStripMenuItem";
            this.applyKPFToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.applyKPFToolStripMenuItem.Text = "Apply KPF";
            this.applyKPFToolStripMenuItem.Click += new System.EventHandler(this.applyKPFToolStripMenuItem_Click);
            // 
            // kernelMemoryToolStripMenuItem
            // 
            this.kernelMemoryToolStripMenuItem.Name = "kernelMemoryToolStripMenuItem";
            this.kernelMemoryToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.kernelMemoryToolStripMenuItem.Text = "Kernel Memory";
            this.kernelMemoryToolStripMenuItem.Click += new System.EventHandler(this.kernelMemoryToolStripMenuItem_Click);
            // 
            // mnuCtxFile
            // 
            this.mnuCtxFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.openInHexeditorToolStripMenuItem});
            this.mnuCtxFile.Name = "mnuCtxFile";
            this.mnuCtxFile.Size = new System.Drawing.Size(171, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // openInHexeditorToolStripMenuItem
            // 
            this.openInHexeditorToolStripMenuItem.Name = "openInHexeditorToolStripMenuItem";
            this.openInHexeditorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.openInHexeditorToolStripMenuItem.Text = "Open in Hexeditor";
            this.openInHexeditorToolStripMenuItem.Click += new System.EventHandler(this.openInHexeditorToolStripMenuItem_Click);
            // 
            // mnuCtxFolder
            // 
            this.mnuCtxFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDirectoryToolStripMenuItem,
            this.deleteToolStripMenuItem1,
            this.downloadToolStripMenuItem});
            this.mnuCtxFolder.Name = "mnuCtxFolder";
            this.mnuCtxFolder.Size = new System.Drawing.Size(160, 70);
            // 
            // createDirectoryToolStripMenuItem
            // 
            this.createDirectoryToolStripMenuItem.Name = "createDirectoryToolStripMenuItem";
            this.createDirectoryToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.createDirectoryToolStripMenuItem.Text = "Create Directory";
            this.createDirectoryToolStripMenuItem.Click += new System.EventHandler(this.createDirectoryToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLog.Location = new System.Drawing.Point(261, 602);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(583, 280);
            this.txtLog.TabIndex = 10;
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // txtKLog
            // 
            this.txtKLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKLog.Location = new System.Drawing.Point(850, 602);
            this.txtKLog.Multiline = true;
            this.txtKLog.Name = "txtKLog";
            this.txtKLog.ReadOnly = true;
            this.txtKLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtKLog.Size = new System.Drawing.Size(743, 280);
            this.txtKLog.TabIndex = 11;
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Kernel Patch File|*.kpf";
            // 
            // frmBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 894);
            this.Controls.Add(this.txtKLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PS4FileNinja by m0rph3us1987";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBrowser_FormClosed);
            this.Load += new System.EventHandler(this.frmBrowser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mnuCtxFile.ResumeLayout(false);
            this.mnuCtxFolder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuProcesses;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userlandASLRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rWXMappingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem1;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.ContextMenuStrip mnuCtxFile;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInHexeditorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnuCtxFolder;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.TextBox txtKLog;
        private System.Windows.Forms.ToolStripMenuItem applyKPFToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.ToolStripMenuItem kernelMemoryToolStripMenuItem;
    }
}