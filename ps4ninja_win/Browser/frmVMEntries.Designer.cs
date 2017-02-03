namespace PS4FileNinja
{
    partial class frmVMEntries
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVMEntries));
            this.dtSet = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.Breakpoints = new System.Data.DataTable();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.grpMemory = new System.Windows.Forms.GroupBox();
            this.btnDumpAll = new System.Windows.Forms.Button();
            this.btnDumpSelected = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.startAddrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endAddrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBreakpoint = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.hxBox = new Be.Windows.Forms.HexBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpRegisters = new System.Windows.Forms.GroupBox();
            this.btnWriteRegs = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtFP = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lblSF = new System.Windows.Forms.Label();
            this.lblZF = new System.Windows.Forms.Label();
            this.lblAF = new System.Windows.Forms.Label();
            this.lblPF = new System.Windows.Forms.Label();
            this.lblCF = new System.Windows.Forms.Label();
            this.txtRIP = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDS = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCS = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtR15 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtR14 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtR13 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtR12 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtR11 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtR10 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtR9 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtR8 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRBP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRSP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRSI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRDI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRDX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRCX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRBX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRAX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMemAdr = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataBox = new System.Windows.Forms.DataGridView();
            this.addressDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalByte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prgBar = new PS4FileNinja.ColoredProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dtSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Breakpoints)).BeginInit();
            this.grpMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.grpRegisters.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dtSet
            // 
            this.dtSet.DataSetName = "NewDataSet";
            this.dtSet.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2,
            this.Breakpoints});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
            this.dataTable1.TableName = "VMEntry";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "Start Addr.";
            this.dataColumn1.ColumnName = "StartAddr";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "End Addr.";
            this.dataColumn2.ColumnName = "EndAddr";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Size";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Protection";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn5,
            this.dataColumn6});
            this.dataTable2.TableName = "Disasm";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Address";
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "ASM";
            this.dataColumn6.ColumnName = "ASM";
            // 
            // Breakpoints
            // 
            this.Breakpoints.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn7,
            this.dataColumn8});
            this.Breakpoints.TableName = "Breakpoints";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "Address";
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "Original Byte";
            this.dataColumn8.ColumnName = "OriginalByte";
            // 
            // grpMemory
            // 
            this.grpMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMemory.Controls.Add(this.btnDumpAll);
            this.grpMemory.Controls.Add(this.btnDumpSelected);
            this.grpMemory.Font = new System.Drawing.Font("Impact", 11.25F);
            this.grpMemory.Location = new System.Drawing.Point(505, 31);
            this.grpMemory.Name = "grpMemory";
            this.grpMemory.Size = new System.Drawing.Size(176, 97);
            this.grpMemory.TabIndex = 2;
            this.grpMemory.TabStop = false;
            this.grpMemory.Text = "Memory";
            // 
            // btnDumpAll
            // 
            this.btnDumpAll.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDumpAll.Location = new System.Drawing.Point(6, 61);
            this.btnDumpAll.Name = "btnDumpAll";
            this.btnDumpAll.Size = new System.Drawing.Size(159, 30);
            this.btnDumpAll.TabIndex = 6;
            this.btnDumpAll.Text = "Dump all pages";
            this.btnDumpAll.UseVisualStyleBackColor = true;
            this.btnDumpAll.Click += new System.EventHandler(this.btnDumpAll_Click);
            // 
            // btnDumpSelected
            // 
            this.btnDumpSelected.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDumpSelected.Location = new System.Drawing.Point(6, 25);
            this.btnDumpSelected.Name = "btnDumpSelected";
            this.btnDumpSelected.Size = new System.Drawing.Size(159, 30);
            this.btnDumpSelected.TabIndex = 1;
            this.btnDumpSelected.Text = "Dump selected page";
            this.btnDumpSelected.UseVisualStyleBackColor = true;
            this.btnDumpSelected.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Impact", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.startAddrDataGridViewTextBoxColumn,
            this.endAddrDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.protectionDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "VMEntry";
            this.dataGridView1.DataSource = this.dtSet;
            this.dataGridView1.Location = new System.Drawing.Point(12, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(487, 804);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // startAddrDataGridViewTextBoxColumn
            // 
            this.startAddrDataGridViewTextBoxColumn.DataPropertyName = "StartAddr";
            this.startAddrDataGridViewTextBoxColumn.HeaderText = "StartAddr";
            this.startAddrDataGridViewTextBoxColumn.Name = "startAddrDataGridViewTextBoxColumn";
            // 
            // endAddrDataGridViewTextBoxColumn
            // 
            this.endAddrDataGridViewTextBoxColumn.DataPropertyName = "EndAddr";
            this.endAddrDataGridViewTextBoxColumn.HeaderText = "EndAddr";
            this.endAddrDataGridViewTextBoxColumn.Name = "endAddrDataGridViewTextBoxColumn";
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            // 
            // protectionDataGridViewTextBoxColumn
            // 
            this.protectionDataGridViewTextBoxColumn.DataPropertyName = "Protection";
            this.protectionDataGridViewTextBoxColumn.HeaderText = "Protection";
            this.protectionDataGridViewTextBoxColumn.Name = "protectionDataGridViewTextBoxColumn";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnBreakpoint);
            this.groupBox1.Controls.Add(this.btnStep);
            this.groupBox1.Controls.Add(this.btnContinue);
            this.groupBox1.Font = new System.Drawing.Font("Impact", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(505, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 145);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Debug";
            // 
            // btnBreakpoint
            // 
            this.btnBreakpoint.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBreakpoint.Location = new System.Drawing.Point(6, 25);
            this.btnBreakpoint.Name = "btnBreakpoint";
            this.btnBreakpoint.Size = new System.Drawing.Size(159, 30);
            this.btnBreakpoint.TabIndex = 7;
            this.btnBreakpoint.Text = "Breakpoint";
            this.btnBreakpoint.UseVisualStyleBackColor = true;
            this.btnBreakpoint.Click += new System.EventHandler(this.btnBreakpoint_Click);
            // 
            // btnStep
            // 
            this.btnStep.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStep.Location = new System.Drawing.Point(6, 97);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(159, 30);
            this.btnStep.TabIndex = 7;
            this.btnStep.Text = "&Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(6, 61);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(159, 30);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // hxBox
            // 
            this.hxBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hxBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hxBox.LineInfoVisible = true;
            this.hxBox.Location = new System.Drawing.Point(505, 327);
            this.hxBox.Name = "hxBox";
            this.hxBox.ReadOnly = true;
            this.hxBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hxBox.Size = new System.Drawing.Size(848, 516);
            this.hxBox.StringViewVisible = true;
            this.hxBox.TabIndex = 12;
            this.hxBox.UseFixedBytesPerLine = true;
            this.hxBox.VScrollBarVisible = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Impact", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressDataGridViewTextBoxColumn,
            this.aSMDataGridViewTextBoxColumn});
            this.dataGridView2.DataMember = "Disasm";
            this.dataGridView2.DataSource = this.dtSet;
            this.dataGridView2.Location = new System.Drawing.Point(687, 39);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(666, 245);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aSMDataGridViewTextBoxColumn
            // 
            this.aSMDataGridViewTextBoxColumn.DataPropertyName = "ASM";
            this.aSMDataGridViewTextBoxColumn.HeaderText = "ASM";
            this.aSMDataGridViewTextBoxColumn.Name = "aSMDataGridViewTextBoxColumn";
            this.aSMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // grpRegisters
            // 
            this.grpRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRegisters.Controls.Add(this.btnWriteRegs);
            this.grpRegisters.Controls.Add(this.btnReload);
            this.grpRegisters.Controls.Add(this.txtFP);
            this.grpRegisters.Controls.Add(this.label22);
            this.grpRegisters.Controls.Add(this.lblSF);
            this.grpRegisters.Controls.Add(this.lblZF);
            this.grpRegisters.Controls.Add(this.lblAF);
            this.grpRegisters.Controls.Add(this.lblPF);
            this.grpRegisters.Controls.Add(this.lblCF);
            this.grpRegisters.Controls.Add(this.txtRIP);
            this.grpRegisters.Controls.Add(this.label19);
            this.grpRegisters.Controls.Add(this.txtDS);
            this.grpRegisters.Controls.Add(this.label20);
            this.grpRegisters.Controls.Add(this.txtCS);
            this.grpRegisters.Controls.Add(this.label21);
            this.grpRegisters.Controls.Add(this.txtR15);
            this.grpRegisters.Controls.Add(this.label10);
            this.grpRegisters.Controls.Add(this.txtR14);
            this.grpRegisters.Controls.Add(this.label11);
            this.grpRegisters.Controls.Add(this.txtR13);
            this.grpRegisters.Controls.Add(this.label12);
            this.grpRegisters.Controls.Add(this.txtR12);
            this.grpRegisters.Controls.Add(this.label13);
            this.grpRegisters.Controls.Add(this.txtR11);
            this.grpRegisters.Controls.Add(this.label14);
            this.grpRegisters.Controls.Add(this.txtR10);
            this.grpRegisters.Controls.Add(this.label15);
            this.grpRegisters.Controls.Add(this.txtR9);
            this.grpRegisters.Controls.Add(this.label16);
            this.grpRegisters.Controls.Add(this.txtR8);
            this.grpRegisters.Controls.Add(this.label17);
            this.grpRegisters.Controls.Add(this.txtRBP);
            this.grpRegisters.Controls.Add(this.label6);
            this.grpRegisters.Controls.Add(this.txtRSP);
            this.grpRegisters.Controls.Add(this.label7);
            this.grpRegisters.Controls.Add(this.txtRSI);
            this.grpRegisters.Controls.Add(this.label8);
            this.grpRegisters.Controls.Add(this.txtRDI);
            this.grpRegisters.Controls.Add(this.label9);
            this.grpRegisters.Controls.Add(this.txtRDX);
            this.grpRegisters.Controls.Add(this.label3);
            this.grpRegisters.Controls.Add(this.txtRCX);
            this.grpRegisters.Controls.Add(this.label4);
            this.grpRegisters.Controls.Add(this.txtRBX);
            this.grpRegisters.Controls.Add(this.label2);
            this.grpRegisters.Controls.Add(this.txtRAX);
            this.grpRegisters.Controls.Add(this.label1);
            this.grpRegisters.Font = new System.Drawing.Font("Impact", 11.25F);
            this.grpRegisters.Location = new System.Drawing.Point(1365, 2);
            this.grpRegisters.Name = "grpRegisters";
            this.grpRegisters.Size = new System.Drawing.Size(406, 317);
            this.grpRegisters.TabIndex = 8;
            this.grpRegisters.TabStop = false;
            this.grpRegisters.Text = "Registers";
            // 
            // btnWriteRegs
            // 
            this.btnWriteRegs.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriteRegs.Location = new System.Drawing.Point(315, 292);
            this.btnWriteRegs.Name = "btnWriteRegs";
            this.btnWriteRegs.Size = new System.Drawing.Size(85, 19);
            this.btnWriteRegs.TabIndex = 57;
            this.btnWriteRegs.Text = "Write Regs";
            this.btnWriteRegs.UseVisualStyleBackColor = true;
            this.btnWriteRegs.Click += new System.EventHandler(this.btnWriteRegs_Click);
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.btnReload.Location = new System.Drawing.Point(224, 292);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(85, 19);
            this.btnReload.TabIndex = 56;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // txtFP
            // 
            this.txtFP.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFP.Location = new System.Drawing.Point(281, 261);
            this.txtFP.Name = "txtFP";
            this.txtFP.ReadOnly = true;
            this.txtFP.Size = new System.Drawing.Size(119, 18);
            this.txtFP.TabIndex = 55;
            this.txtFP.Text = "0xFFFFFFFFFFFFFFFF";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label22.Location = new System.Drawing.Point(243, 256);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 26);
            this.label22.TabIndex = 54;
            this.label22.Text = "FP";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSF
            // 
            this.lblSF.AutoSize = true;
            this.lblSF.ForeColor = System.Drawing.Color.Red;
            this.lblSF.Location = new System.Drawing.Point(120, 292);
            this.lblSF.Name = "lblSF";
            this.lblSF.Size = new System.Drawing.Size(23, 19);
            this.lblSF.TabIndex = 53;
            this.lblSF.Text = "SF";
            // 
            // lblZF
            // 
            this.lblZF.AutoSize = true;
            this.lblZF.ForeColor = System.Drawing.Color.Red;
            this.lblZF.Location = new System.Drawing.Point(93, 292);
            this.lblZF.Name = "lblZF";
            this.lblZF.Size = new System.Drawing.Size(21, 19);
            this.lblZF.TabIndex = 52;
            this.lblZF.Text = "ZF";
            // 
            // lblAF
            // 
            this.lblAF.AutoSize = true;
            this.lblAF.ForeColor = System.Drawing.Color.Red;
            this.lblAF.Location = new System.Drawing.Point(64, 292);
            this.lblAF.Name = "lblAF";
            this.lblAF.Size = new System.Drawing.Size(22, 19);
            this.lblAF.TabIndex = 51;
            this.lblAF.Text = "AF";
            // 
            // lblPF
            // 
            this.lblPF.AutoSize = true;
            this.lblPF.ForeColor = System.Drawing.Color.Red;
            this.lblPF.Location = new System.Drawing.Point(35, 293);
            this.lblPF.Name = "lblPF";
            this.lblPF.Size = new System.Drawing.Size(23, 19);
            this.lblPF.TabIndex = 50;
            this.lblPF.Text = "PF";
            // 
            // lblCF
            // 
            this.lblCF.AutoSize = true;
            this.lblCF.ForeColor = System.Drawing.Color.Red;
            this.lblCF.Location = new System.Drawing.Point(6, 293);
            this.lblCF.Name = "lblCF";
            this.lblCF.Size = new System.Drawing.Size(23, 19);
            this.lblCF.TabIndex = 49;
            this.lblCF.Text = "CF";
            // 
            // txtRIP
            // 
            this.txtRIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRIP.Location = new System.Drawing.Point(44, 263);
            this.txtRIP.Name = "txtRIP";
            this.txtRIP.Size = new System.Drawing.Size(119, 18);
            this.txtRIP.TabIndex = 48;
            this.txtRIP.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtRIP.TextChanged += new System.EventHandler(this.txtRIP_TextChanged);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(6, 258);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 26);
            this.label19.TabIndex = 47;
            this.label19.Text = "RIP";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDS
            // 
            this.txtDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDS.Location = new System.Drawing.Point(281, 237);
            this.txtDS.Name = "txtDS";
            this.txtDS.Size = new System.Drawing.Size(119, 18);
            this.txtDS.TabIndex = 46;
            this.txtDS.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtDS.TextChanged += new System.EventHandler(this.txtDS_TextChanged);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label20.Location = new System.Drawing.Point(244, 232);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 26);
            this.label20.TabIndex = 45;
            this.label20.Text = "DS";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCS
            // 
            this.txtCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCS.Location = new System.Drawing.Point(44, 237);
            this.txtCS.Name = "txtCS";
            this.txtCS.Size = new System.Drawing.Size(119, 18);
            this.txtCS.TabIndex = 44;
            this.txtCS.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtCS.TextChanged += new System.EventHandler(this.txtCS_TextChanged);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(6, 232);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 26);
            this.label21.TabIndex = 43;
            this.label21.Text = "CS";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtR15
            // 
            this.txtR15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR15.Location = new System.Drawing.Point(281, 210);
            this.txtR15.Name = "txtR15";
            this.txtR15.Size = new System.Drawing.Size(119, 18);
            this.txtR15.TabIndex = 42;
            this.txtR15.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtR15.TextChanged += new System.EventHandler(this.txtR15_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(244, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 26);
            this.label10.TabIndex = 41;
            this.label10.Text = "R15";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtR14
            // 
            this.txtR14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR14.Location = new System.Drawing.Point(44, 210);
            this.txtR14.Name = "txtR14";
            this.txtR14.Size = new System.Drawing.Size(119, 18);
            this.txtR14.TabIndex = 40;
            this.txtR14.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtR14.TextChanged += new System.EventHandler(this.txtR14_TextChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(6, 205);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 26);
            this.label11.TabIndex = 39;
            this.label11.Text = "R14";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtR13
            // 
            this.txtR13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR13.Location = new System.Drawing.Point(281, 184);
            this.txtR13.Name = "txtR13";
            this.txtR13.Size = new System.Drawing.Size(119, 18);
            this.txtR13.TabIndex = 38;
            this.txtR13.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtR13.TextChanged += new System.EventHandler(this.txtR13_TextChanged);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(244, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 26);
            this.label12.TabIndex = 37;
            this.label12.Text = "R13";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtR12
            // 
            this.txtR12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR12.Location = new System.Drawing.Point(44, 184);
            this.txtR12.Name = "txtR12";
            this.txtR12.Size = new System.Drawing.Size(119, 18);
            this.txtR12.TabIndex = 36;
            this.txtR12.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtR12.TextChanged += new System.EventHandler(this.txtR12_TextChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(6, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 26);
            this.label13.TabIndex = 35;
            this.label13.Text = "R12";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtR11
            // 
            this.txtR11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR11.Location = new System.Drawing.Point(281, 158);
            this.txtR11.Name = "txtR11";
            this.txtR11.Size = new System.Drawing.Size(119, 18);
            this.txtR11.TabIndex = 34;
            this.txtR11.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtR11.TextChanged += new System.EventHandler(this.txtR11_TextChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label14.Location = new System.Drawing.Point(244, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 26);
            this.label14.TabIndex = 33;
            this.label14.Text = "R11";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtR10
            // 
            this.txtR10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR10.Location = new System.Drawing.Point(44, 158);
            this.txtR10.Name = "txtR10";
            this.txtR10.Size = new System.Drawing.Size(119, 18);
            this.txtR10.TabIndex = 32;
            this.txtR10.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtR10.TextChanged += new System.EventHandler(this.txtR10_TextChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label15.Location = new System.Drawing.Point(6, 153);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 26);
            this.label15.TabIndex = 31;
            this.label15.Text = "R10";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtR9
            // 
            this.txtR9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR9.Location = new System.Drawing.Point(281, 132);
            this.txtR9.Name = "txtR9";
            this.txtR9.Size = new System.Drawing.Size(119, 18);
            this.txtR9.TabIndex = 30;
            this.txtR9.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtR9.TextChanged += new System.EventHandler(this.txtR9_TextChanged);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label16.Location = new System.Drawing.Point(244, 127);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 26);
            this.label16.TabIndex = 29;
            this.label16.Text = "R9";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtR8
            // 
            this.txtR8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR8.Location = new System.Drawing.Point(44, 132);
            this.txtR8.Name = "txtR8";
            this.txtR8.Size = new System.Drawing.Size(119, 18);
            this.txtR8.TabIndex = 28;
            this.txtR8.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtR8.TextChanged += new System.EventHandler(this.txtR8_TextChanged);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label17.Location = new System.Drawing.Point(6, 127);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 26);
            this.label17.TabIndex = 27;
            this.label17.Text = "R8";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRBP
            // 
            this.txtRBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRBP.Location = new System.Drawing.Point(281, 105);
            this.txtRBP.Name = "txtRBP";
            this.txtRBP.Size = new System.Drawing.Size(119, 18);
            this.txtRBP.TabIndex = 26;
            this.txtRBP.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtRBP.TextChanged += new System.EventHandler(this.txtRBP_TextChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(244, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 26);
            this.label6.TabIndex = 25;
            this.label6.Text = "RBP";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRSP
            // 
            this.txtRSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRSP.Location = new System.Drawing.Point(44, 105);
            this.txtRSP.Name = "txtRSP";
            this.txtRSP.Size = new System.Drawing.Size(119, 18);
            this.txtRSP.TabIndex = 24;
            this.txtRSP.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtRSP.TextChanged += new System.EventHandler(this.txtRSP_TextChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(6, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 26);
            this.label7.TabIndex = 23;
            this.label7.Text = "RSP";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRSI
            // 
            this.txtRSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRSI.Location = new System.Drawing.Point(281, 79);
            this.txtRSI.Name = "txtRSI";
            this.txtRSI.Size = new System.Drawing.Size(119, 18);
            this.txtRSI.TabIndex = 22;
            this.txtRSI.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtRSI.TextChanged += new System.EventHandler(this.txtRSI_TextChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(244, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 26);
            this.label8.TabIndex = 21;
            this.label8.Text = "RSI";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRDI
            // 
            this.txtRDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRDI.Location = new System.Drawing.Point(44, 79);
            this.txtRDI.Name = "txtRDI";
            this.txtRDI.Size = new System.Drawing.Size(119, 18);
            this.txtRDI.TabIndex = 20;
            this.txtRDI.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtRDI.TextChanged += new System.EventHandler(this.txtRDI_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 26);
            this.label9.TabIndex = 19;
            this.label9.Text = "RDI";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRDX
            // 
            this.txtRDX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRDX.Location = new System.Drawing.Point(281, 53);
            this.txtRDX.Name = "txtRDX";
            this.txtRDX.Size = new System.Drawing.Size(119, 18);
            this.txtRDX.TabIndex = 18;
            this.txtRDX.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtRDX.TextChanged += new System.EventHandler(this.txtRDX_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(244, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "RDX";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRCX
            // 
            this.txtRCX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRCX.Location = new System.Drawing.Point(44, 53);
            this.txtRCX.Name = "txtRCX";
            this.txtRCX.Size = new System.Drawing.Size(119, 18);
            this.txtRCX.TabIndex = 16;
            this.txtRCX.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtRCX.TextChanged += new System.EventHandler(this.txtRCX_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 26);
            this.label4.TabIndex = 15;
            this.label4.Text = "RCX";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRBX
            // 
            this.txtRBX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRBX.Location = new System.Drawing.Point(281, 27);
            this.txtRBX.Name = "txtRBX";
            this.txtRBX.Size = new System.Drawing.Size(119, 18);
            this.txtRBX.TabIndex = 14;
            this.txtRBX.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtRBX.TextChanged += new System.EventHandler(this.txtRBX_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(244, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 26);
            this.label2.TabIndex = 13;
            this.label2.Text = "RBX";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRAX
            // 
            this.txtRAX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRAX.Location = new System.Drawing.Point(44, 27);
            this.txtRAX.Name = "txtRAX";
            this.txtRAX.Size = new System.Drawing.Size(119, 18);
            this.txtRAX.TabIndex = 12;
            this.txtRAX.Text = "0xFFFFFFFFFFFFFFFF";
            this.txtRAX.TextChanged += new System.EventHandler(this.txtRAX_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "RAX";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(505, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Memory addr.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMemAdr
            // 
            this.txtMemAdr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemAdr.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemAdr.Location = new System.Drawing.Point(615, 289);
            this.txtMemAdr.Name = "txtMemAdr";
            this.txtMemAdr.Size = new System.Drawing.Size(738, 31);
            this.txtMemAdr.TabIndex = 11;
            this.txtMemAdr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMemAdr_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(615, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(738, 31);
            this.textBox1.TabIndex = 14;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label18.Location = new System.Drawing.Point(501, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(108, 26);
            this.label18.TabIndex = 13;
            this.label18.Text = "Jmp to Code at.:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataBox);
            this.groupBox2.Font = new System.Drawing.Font("Impact", 11.25F);
            this.groupBox2.Location = new System.Drawing.Point(1359, 327);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 514);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Breakpoints";
            // 
            // dataBox
            // 
            this.dataBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBox.AutoGenerateColumns = false;
            this.dataBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressDataGridViewTextBoxColumn1,
            this.OriginalByte});
            this.dataBox.DataMember = "Breakpoints";
            this.dataBox.DataSource = this.dtSet;
            this.dataBox.Location = new System.Drawing.Point(6, 25);
            this.dataBox.Name = "dataBox";
            this.dataBox.ReadOnly = true;
            this.dataBox.Size = new System.Drawing.Size(406, 483);
            this.dataBox.TabIndex = 8;
            // 
            // addressDataGridViewTextBoxColumn1
            // 
            this.addressDataGridViewTextBoxColumn1.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn1.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn1.Name = "addressDataGridViewTextBoxColumn1";
            this.addressDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // OriginalByte
            // 
            this.OriginalByte.DataPropertyName = "OriginalByte";
            this.OriginalByte.HeaderText = "Original Byte";
            this.OriginalByte.Name = "OriginalByte";
            this.OriginalByte.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn1.HeaderText = "Address";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Address";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // prgBar
            // 
            this.prgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgBar.CustomText = null;
            this.prgBar.DisplayStyle = PS4FileNinja.ProgressBarDisplayText.Percentage;
            this.prgBar.Location = new System.Drawing.Point(12, 820);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(487, 23);
            this.prgBar.TabIndex = 4;
            // 
            // frmVMEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1789, 852);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.hxBox);
            this.Controls.Add(this.txtMemAdr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpRegisters);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpMemory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVMEntries";
            this.Text = "Debug";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVMEntries_FormClosed);
            this.Load += new System.EventHandler(this.frmVMEntries_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVMEntries_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Breakpoints)).EndInit();
            this.grpMemory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.grpRegisters.ResumeLayout(false);
            this.grpRegisters.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet dtSet;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Windows.Forms.GroupBox grpMemory;
        private System.Windows.Forms.Button btnDumpSelected;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAddrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endAddrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn protectionDataGridViewTextBoxColumn;
        private ColoredProgressBar prgBar;
        private System.Windows.Forms.Button btnDumpAll;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBreakpoint;
        private System.Windows.Forms.Button btnStep;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSMDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox grpRegisters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMemAdr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRAX;
        private System.Windows.Forms.TextBox txtRBX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRBP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRSP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRSI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRDI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRDX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRCX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtR15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtR14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtR13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtR12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtR11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtR10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtR9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtR8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtRIP;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDS;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCS;
        private System.Windows.Forms.Label label21;
        private Be.Windows.Forms.HexBox hxBox;
        private System.Windows.Forms.Label lblCF;
        private System.Windows.Forms.Label lblSF;
        private System.Windows.Forms.Label lblZF;
        private System.Windows.Forms.Label lblAF;
        private System.Windows.Forms.Label lblPF;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label18;
        private System.Data.DataTable Breakpoints;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalByte;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox txtFP;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnWriteRegs;
    }
}