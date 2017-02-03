using System.IO;
using System.Windows.Forms;
using System.Net.Sockets;
using System;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Be.Windows.Forms;
using System.Globalization;
using System.Drawing;

namespace PS4FileNinja
{
    public partial class frmVMEntries : Form
    {
        public TcpClient Client;
        public byte[] VMData;
        public byte[] Data;
        public byte[] Code;
        public string FlagRegs;
        public bool Attached;

        public UInt64 SelectedStart;
        public UInt64 SelectedSize;
        public short PID;
        public UInt64 SelectedRIP;
        private string PrgBarText;

        private PS4CPU ps4Cpu;

        public UInt64 SelectedCodeAddr;

        private UInt64 dataReceived = 0;

        private BackgroundWorker backgroundWorkerSingleDump;
        private BackgroundWorker backgroundWorkerFullDump;
        private string OutputFolder;

        private List<MasterEntry> MasterEntries;

        public frmVMEntries()
        {
            InitializeComponent();
            this.backgroundWorkerSingleDump = new BackgroundWorker();
            this.backgroundWorkerSingleDump.DoWork += new System.ComponentModel.DoWorkEventHandler(ReadData);
            this.backgroundWorkerSingleDump.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ReadDataComplete);

            this.backgroundWorkerFullDump = new BackgroundWorker();
            this.backgroundWorkerFullDump.DoWork += new DoWorkEventHandler(ReadFullDump);
            this.backgroundWorkerFullDump.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ReadFullComplete);
        }

        private void ReadDataComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            frmDump FRMDump = new frmDump();
            FRMDump.Data = this.Data;
            FRMDump.LineOff = (ulong)this.SelectedStart;
            FRMDump.Text = this.Text + " - DUMP - " + string.Format("0x{0:X} - 0x{1:X}", this.SelectedStart, this.SelectedStart + this.SelectedSize);
            FRMDump.Filename = string.Format("0x{0:X}_0x{1:X}.bin", this.SelectedStart, this.SelectedStart + this.SelectedSize);
            FRMDump.ShowDialog();

            this.prgBar.Value = 0;
        }

        private void ParseData()
        {
            this.dtSet.Tables[0].Clear();

            MemoryStream ms = new MemoryStream(this.VMData);

            byte[] CurrEntry;

            while (ms.Position != ms.Length)
            {
                byte[] EntryLenByte = new byte[4];
                ms.Read(EntryLenByte, 0, 4);
                UInt32 EntrySize = BitConverter.ToUInt32(EntryLenByte, 0) - 4;

                CurrEntry = new byte[EntrySize];
                ms.Read(CurrEntry, 0, CurrEntry.Length);

                UInt64 StartAdr = BitConverter.ToUInt64(CurrEntry, 8 - 4);
                UInt64 EndAdr = BitConverter.ToUInt64(CurrEntry, 16 - 4);
                UInt64 Size = EndAdr - StartAdr;
                UInt32 Protection = BitConverter.ToUInt32(CurrEntry, 56 - 4);

                System.Data.DataRow dr = this.dtSet.Tables[0].NewRow();
                dr[0] = string.Format("0x{0:X}", StartAdr);
                dr[1] = string.Format("0x{0:X}", EndAdr);
                dr[2] = string.Format("0x{0:X}", Size);

                if ((Protection & (1 << 0)) != 0)
                {
                    dr[3] = "R";

                    if ((Protection & (1 << 1)) != 0)
                        dr[3] += "W";
                    else
                        dr[3] += "-";

                    if ((Protection & (1 << 2)) != 0)
                        dr[3] += "X";
                    else
                        dr[3] += "-";

                    this.dtSet.Tables[0].Rows.Add(dr);
                }
            }

            ms.Close();
        }

        private void frmVMEntries_Load(object sender, EventArgs e)
        {
            ParseData();

            try
            {
                this.SelectedStart = UInt64.Parse(Convert.ToString(this.dataGridView1[0, 0].Value).Substring(2), System.Globalization.NumberStyles.HexNumber);
                this.SelectedSize = UInt64.Parse(Convert.ToString(this.dataGridView1[2, 0].Value).Substring(2), System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception) { }

            this.Attached = true;
            UpdateDebugUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.prgBar.Maximum = Convert.ToInt32(this.SelectedSize);
            } catch (Exception)
            {

            }
            this.backgroundWorkerSingleDump.RunWorkerAsync();
        }

        private void ReadData(object sender, DoWorkEventArgs e)
        {
            this.Data = new byte[this.SelectedSize];

            int Retry = 0;
            dataReceived = 0;

            while (dataReceived < this.SelectedSize)
            {
                UInt64 toRead = 0;

                if ((dataReceived + (0x100000)) > this.SelectedSize)
                    toRead = this.SelectedSize - dataReceived;
                else
                    toRead = (0x100000);

                byte[] tmp = Commands.ps4ninja_read_proc_mem(this.PID, this.SelectedStart + dataReceived, toRead, this.Client);
                if (tmp != null)
                {
                    Array.Copy(tmp, 0, this.Data, (long)dataReceived, tmp.Length);
                    dataReceived += (ulong)tmp.Length;
                    UptControlsPrgBar();
                }
                else
                {
                    Retry++;
                    if (Retry == 10)
                        break;
                }
            }
            UptControlsPrgBar();
        }

        private void UptControlsPrgBar()
        {
            Thread.Sleep(2);

            try
            {
                if (this.prgBar.InvokeRequired)
                {
                    this.prgBar.BeginInvoke((MethodInvoker)delegate () {
                        try {
                            if (this.prgBar.Maximum != (int)this.SelectedSize)
                                this.prgBar.Maximum = Convert.ToInt32(this.SelectedSize);

                            this.prgBar.Value = (int)this.dataReceived;
                            this.prgBar.CustomText = this.PrgBarText;
                        } catch (Exception) { }
                    });
                }
                else
                {
                    if (this.prgBar.Maximum != (int)this.SelectedSize)
                        this.prgBar.Maximum = Convert.ToInt32(this.SelectedSize);

                    this.prgBar.Value = (int)this.dataReceived;
                    this.prgBar.CustomText = this.PrgBarText;
                }
            }
            catch (Exception) { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedStart = UInt64.Parse(Convert.ToString(this.dataGridView1[0, e.RowIndex].Value).Substring(2), System.Globalization.NumberStyles.HexNumber);
                this.SelectedSize = UInt64.Parse(Convert.ToString(this.dataGridView1[2, e.RowIndex].Value).Substring(2), System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception) { }
        }

        private void frmVMEntries_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.Attached)
                Commands.ps4ninja_detach(this.PID, this.Client);
        }

        private void btnDumpAll_Click(object sender, EventArgs e)
        {
            if (dlgFolder.ShowDialog() != DialogResult.OK)
                return;

            this.OutputFolder = this.dlgFolder.SelectedPath;
            this.backgroundWorkerFullDump.RunWorkerAsync();
        }

        private void ReadFullDump(object sender, DoWorkEventArgs e)
        {
            this.MasterEntries = new List<MasterEntry>();

            for (int i = 0; i < this.dtSet.Tables[0].Rows.Count; i++)
            {
                PrgBarText = string.Format("Dumping page {0} of {1} ", i + 1, this.dtSet.Tables[0].Rows.Count);

                this.SelectedStart = UInt64.Parse(Convert.ToString(this.dtSet.Tables[0].Rows[i][0]).Substring(2), System.Globalization.NumberStyles.HexNumber);
                this.SelectedSize = UInt64.Parse(Convert.ToString(this.dtSet.Tables[0].Rows[i][2]).Substring(2), System.Globalization.NumberStyles.HexNumber);
                ReadData(sender, e);

                string Filename;

                if (i == 0)
                {
                    Filename = string.Format("Master_0x{0:X}_0x{1:X}.bin", this.SelectedStart, this.SelectedStart + this.SelectedSize);
                    Utility.DumpToFile(this.OutputFolder + "\\" + Filename, this.Data);
                }
                else
                {
                    Filename = string.Format("0x{0:X}_0x{1:X}.bin", this.SelectedStart, this.SelectedStart + this.SelectedSize);
                    Utility.DumpToFile(this.OutputFolder + "\\" + Filename, this.Data);

                    MasterEntry me = new MasterEntry();
                    me.FilenameLen = Convert.ToUInt16(Filename.Length);
                    me.Filename = Filename;
                    me.StartOffset = this.SelectedStart;
                    me.StartSegment = 0;
                    me.EndSegment = 0;
                    this.MasterEntries.Add(me);
                }

                this.Data = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            if(this.MasterEntries.Count > 0)
            {
                if (File.Exists(this.OutputFolder + "\\ida.master"))
                    File.Delete(this.OutputFolder + "\\ida.master");

                FileStream fs = new FileStream(this.OutputFolder + "\\ida.master", FileMode.Create, FileAccess.Write);
                BinaryWriter br = new BinaryWriter(fs);

                foreach(MasterEntry me in this.MasterEntries)
                {
                    br.Write(me.FilenameLen);
                    br.Write(Encoding.ASCII.GetBytes(me.Filename), 0, Convert.ToInt32(me.FilenameLen));
                    br.Write(me.StartOffset);
                    br.Write(me.StartSegment);
                    br.Write(me.EndSegment);
                }

                br.Close();
                fs.Close();
            }
        }

        private void ReadFullComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Dump complete!");
            this.prgBar.Value = 0;
        }

        private void UpdateDebugUI()
        {
            byte[] regs = Commands.ps4ninja_read_regs(this.PID, this.Client);

            PS4CPU cpu = new PS4CPU(regs);
            this.ps4Cpu = cpu;

            this.txtRAX.Text = string.Format("{0:X16}", this.ps4Cpu.r_rax);
            this.txtRBX.Text = string.Format("{0:X16}", this.ps4Cpu.r_rbx);
            this.txtRCX.Text = string.Format("{0:X16}", this.ps4Cpu.r_rcx);
            this.txtRDX.Text = string.Format("{0:X16}", this.ps4Cpu.r_rdx);
            this.txtRDI.Text = string.Format("{0:X16}", this.ps4Cpu.r_rdi);
            this.txtRSI.Text = string.Format("{0:X16}", this.ps4Cpu.r_rsi);
            this.txtRBP.Text = string.Format("{0:X16}", this.ps4Cpu.r_rbp);
            this.txtRSP.Text = string.Format("{0:X16}", this.ps4Cpu.r_rsp);
            this.txtR15.Text = string.Format("{0:X16}", this.ps4Cpu.r_r15);
            this.txtR14.Text = string.Format("{0:X16}", this.ps4Cpu.r_r14);
            this.txtR13.Text = string.Format("{0:X16}", this.ps4Cpu.r_r13);
            this.txtR12.Text = string.Format("{0:X16}", this.ps4Cpu.r_r12);
            this.txtR11.Text = string.Format("{0:X16}", this.ps4Cpu.r_r11);
            this.txtR10.Text = string.Format("{0:X16}", this.ps4Cpu.r_r10);
            this.txtR9.Text = string.Format("{0:X16}", this.ps4Cpu.r_r9);
            this.txtR8.Text = string.Format("{0:X16}", this.ps4Cpu.r_r8);
            this.txtCS.Text = string.Format("{0:X16}", this.ps4Cpu.r_cs);
            this.txtDS.Text = string.Format("{0:X16}", this.ps4Cpu.r_ds);
            this.txtFP.Text = string.Format("{0:X16}", this.ps4Cpu.r_rflags);

            this.SelectedCodeAddr = this.ps4Cpu.r_rip;
            this.txtRIP.Text = string.Format("{0:X16}", this.ps4Cpu.r_rip);
            this.SelectedRIP = this.ps4Cpu.r_rip;

            this.FlagRegs = Utility.ReverseString(Convert.ToString((long)this.ps4Cpu.r_rflags, 2));


            LoadNewCode(this.SelectedRIP, 0x100);
            UpdateUIControls();
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            Commands.ps4ninja_step(this.PID, this.Client);
            UpdateDebugUI();
        }

        private void LoadNewCode(UInt64 Addr, UInt64 len)
        {
            // Refresh Disasm view
            this.dtSet.Tables[1].Rows.Clear();
            this.Code = Commands.ps4ninja_read_proc_mem(this.PID, Addr, len, this.Client);
            // Configure the translator to output instruction addresses and instruction binary as hex
            SharpDisasm.Disassembler.Translator.IncludeAddress = false;
            SharpDisasm.Disassembler.Translator.IncludeBinary = false;
            // Create the disassembler
            var disasm = new SharpDisasm.Disassembler(this.Code, SharpDisasm.ArchitectureMode.x86_64, Addr, true);

            for (int i = 0; ; i++)
            {
                try
                {
                    System.Data.DataRow dr = this.dtSet.Tables[1].NewRow();

                    SharpDisasm.Instruction insn = disasm.NextInstruction();

                    dr["Address"] = string.Format("{0:X16}", insn.Offset);
                    dr["ASM"] = insn.ToString();
                    this.dtSet.Tables[1].Rows.Add(dr);
                }
                catch (Exception)
                {
                    break;
                }
            }

            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (this.dtSet.Tables[2].Rows.Count == 0)
            {
                if (this.Attached)
                {
                    this.Attached = false;
                    Commands.ps4ninja_detach(this.PID, this.Client);
                    this.btnContinue.Text = "Stop";
                    UpdateUIControls();
                }
                else
                {
                    this.Attached = true;

                    Commands.ps4ninja_attach(this.PID, 0, this.Client);
                    UpdateDebugUI();
                    this.btnContinue.Text = "Continue";
                }
            }
            else
            {
                Commands.ps4ninja_continue(this.PID, this.Client);
                byte[] regs = Commands.ps4ninja_read_regs(this.PID, this.Client);

                PS4CPU cpu = new PS4CPU(regs);
                String tmpRIP = string.Format("{0:X16}", cpu.r_rip - 1);

                foreach (System.Data.DataRow dr in this.dtSet.Tables[2].Rows)
                {
                    if (Convert.ToString(dr["Address"]) == tmpRIP)
                    {
                        byte tmpOpcode = StringToByteArray(Convert.ToString(dr["OriginalByte"]))[0];
                        Commands.ps4ninja_exit_breakpoint(this.PID, tmpOpcode, this.Client);
                        this.dtSet.Tables[2].Rows.Remove(dr);
                        UpdateDebugUI();
                        return;
                    }
                }
            }
        }

        private void UpdateUIControls()
        {
            // Enable/Disbale controls
            this.btnBreakpoint.Enabled = this.Attached;
            this.btnStep.Enabled = this.Attached;
            this.grpMemory.Enabled = this.Attached;
            this.grpRegisters.Enabled = this.Attached;
            this.btnDumpAll.Enabled = this.Attached;
            this.btnDumpSelected.Enabled = this.Attached;
            this.textBox1.Enabled = this.Attached;
            this.txtMemAdr.Enabled = this.Attached;

            // Update flag register label color
            if (this.FlagRegs[0] == '0')
                this.lblCF.ForeColor = Color.Red;
            else
                this.lblCF.ForeColor = Color.Green;

            if (this.FlagRegs[2] == '0')
                this.lblPF.ForeColor = Color.Red;
            else
                this.lblPF.ForeColor = Color.Green;

            if (this.FlagRegs[4] == '0')
                this.lblAF.ForeColor = Color.Red;
            else
                this.lblAF.ForeColor = Color.Green;

            if (this.FlagRegs[6] == '0')
                this.lblZF.ForeColor = Color.Red;
            else
                this.lblZF.ForeColor = Color.Green;

            if (this.FlagRegs[7] == '0')
                this.lblSF.ForeColor = Color.Red;
            else
                this.lblSF.ForeColor = Color.Green;
        }

        private void frmVMEntries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
                btnStep_Click(sender, e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.textBox1.Text == "")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string AddrStr = "";
                    if (this.textBox1.Text.StartsWith(""))
                        AddrStr = this.textBox1.Text.Substring(2);
                    else
                        AddrStr = this.textBox1.Text;

                    UInt64 Addr = 0;
                    UInt64.TryParse(AddrStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out Addr);

                    LoadNewCode(Addr, 0x100);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMemAdr_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtMemAdr.Text == "")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string AddrStr = "";
                    if (this.txtMemAdr.Text.StartsWith(""))
                        AddrStr = this.txtMemAdr.Text.Substring(2);
                    else
                        AddrStr = this.txtMemAdr.Text;

                    UInt64 Addr = 0;
                    UInt64.TryParse(AddrStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out Addr);

                    this.Data = null;
                    this.Data = Commands.ps4ninja_read_proc_mem(this.PID, Addr, 0x100, this.Client);

                    if (this.Data != null)
                    {
                        DynamicByteProvider dbp = new DynamicByteProvider(this.Data);
                        this.hxBox.ReadOnly = true;
                        this.hxBox.ByteProvider = dbp;
                        this.hxBox.LineInfoOffset = Convert.ToUInt64(Addr);
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedCodeAddr = UInt64.Parse(Convert.ToString(this.dataGridView2[0, e.RowIndex].Value).Substring(2), System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception) { }
        }

        private void btnBreakpoint_Click(object sender, EventArgs e)
        {
            byte original = Commands.ps4ninja_set_breakpoint(this.PID, this.SelectedCodeAddr, this.Client);

            System.Data.DataRow dr = this.dtSet.Tables[2].NewRow();
            dr["Address"] = string.Format("{0:X16}", this.SelectedCodeAddr);
            dr["OriginalByte"] = string.Format("{0:X2}", Convert.ToInt16(original));
            this.dtSet.Tables[2].Rows.Add(dr);

            dataBox.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private void btnWriteRegs_Click(object sender, EventArgs e)
        {
            byte[] tmp = Commands.ps4ninja_write_regs(this.PID, this.ps4Cpu.Serialise(), this.Client);
            UpdateDebugUI();
        }

        private void txtRAX_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_rax = UInt64.Parse(this.txtRAX.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtRBX_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_rbx = UInt64.Parse(this.txtRBX.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtRCX_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_rcx = UInt64.Parse(this.txtRCX.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtRDX_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_rdx = UInt64.Parse(this.txtRDX.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtRDI_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_rdi = UInt64.Parse(this.txtRDI.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtRSI_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_rsi = UInt64.Parse(this.txtRSI.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtRSP_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_rsp = UInt64.Parse(this.txtRSP.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtR8_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_r8 = UInt64.Parse(this.txtR8.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtRBP_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_rbp = UInt64.Parse(this.txtRBP.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtR9_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_r9 = UInt64.Parse(this.txtR9.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtR10_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_r10 = UInt64.Parse(this.txtR10.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtR11_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_r11 = UInt64.Parse(this.txtR11.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtR12_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_r12 = UInt64.Parse(this.txtR12.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtR13_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_r13 = UInt64.Parse(this.txtR13.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtR14_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_r14 = UInt64.Parse(this.txtR14.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtR15_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_r15 = UInt64.Parse(this.txtR15.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtCS_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_cs = UInt64.Parse(this.txtCS.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtDS_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_ds = UInt16.Parse(this.txtDS.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }

        private void txtRIP_TextChanged(object sender, EventArgs e)
        {
            try { this.ps4Cpu.r_rip = UInt64.Parse(this.txtRIP.Text, System.Globalization.NumberStyles.HexNumber); } catch (Exception) { }
        }
    }
}
