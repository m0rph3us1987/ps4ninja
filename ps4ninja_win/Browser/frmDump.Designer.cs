namespace PS4FileNinja
{
    partial class frmDump
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDump));
            this.hxBox = new Be.Windows.Forms.HexBox();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.grpAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // hxBox
            // 
            this.hxBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hxBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hxBox.LineInfoVisible = true;
            this.hxBox.Location = new System.Drawing.Point(12, 12);
            this.hxBox.Name = "hxBox";
            this.hxBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hxBox.Size = new System.Drawing.Size(676, 551);
            this.hxBox.StringViewVisible = true;
            this.hxBox.TabIndex = 0;
            this.hxBox.UseFixedBytesPerLine = true;
            this.hxBox.VScrollBarVisible = true;
            // 
            // grpAction
            // 
            this.grpAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAction.Controls.Add(this.btnSave);
            this.grpAction.Font = new System.Drawing.Font("Impact", 11.25F);
            this.grpAction.Location = new System.Drawing.Point(694, 12);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(171, 63);
            this.grpAction.TabIndex = 3;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Action";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(6, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(159, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save to file";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dlgSave
            // 
            this.dlgSave.AddExtension = false;
            this.dlgSave.Title = "Save File";
            // 
            // frmDump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 575);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.hxBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDump";
            this.Text = "Dump Viewer";
            this.Load += new System.EventHandler(this.frmDump_Load);
            this.grpAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Be.Windows.Forms.HexBox hxBox;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog dlgSave;
    }
}