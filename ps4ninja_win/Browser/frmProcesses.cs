using System;
using System.IO;
using System.Windows.Forms;
using System.Net.Sockets;

namespace PS4FileNinja
{
    public partial class frmProcesses : Form
    {
        public byte[] ProcessData;

        public TcpClient Client;

        private UInt32 SelectedPID;
        private String SelectedCommand;

        public frmProcesses()
        {
            InitializeComponent();
        }

        private void frmProcesses_Load(object sender, EventArgs e)
        {
            ParseData(this.ProcessData);

            try
            {
                this.SelectedPID = Convert.ToUInt32(this.dataGridView1[0, 0].Value);
                this.SelectedCommand = Convert.ToString(this.dataGridView1[1, 0].Value);
            }
            catch (Exception){}
        }

        private void ParseData(byte[] Data)
        {
            MemoryStream ms = new MemoryStream(Data);

            byte[] CurrEntry;

            while (ms.Position != ms.Length)
            {
                byte[] EntryLenByte = new byte[4];
                ms.Read(EntryLenByte, 0, 4);
                UInt32 EntrySize = BitConverter.ToUInt32(EntryLenByte, 0) - 4;

                CurrEntry = new byte[EntrySize];
                ms.Read(CurrEntry, 0, CurrEntry.Length);

                //UInt64 VMAddr = BitConverter.ToUInt64(CurrEntry, 0x4);
                UInt32 PID = BitConverter.ToUInt32(CurrEntry, 0x44);
                UInt32 PPID = BitConverter.ToUInt32(CurrEntry, 0x48);

                String ThreadName = "";

                for (int x = 0; x < 16; x++)
                    if (CurrEntry[0x186 + x] != 0)
                        ThreadName += Convert.ToChar(CurrEntry[0x186 + x]);

                String User = "";

                for (int x = 0; x < 18; x++)
                    if (CurrEntry[0x186 + 0x1A + x] != 0)
                        User += Convert.ToChar(CurrEntry[0x186 + 0x1A + x]);

                String Command = "";

                for (int x = 0; x < 18; x++)
                    if (CurrEntry[0x186 + 0x35 + x] != 0)
                        Command += Convert.ToChar(CurrEntry[0x186 + 0x35 + x]);

                System.Data.DataRow dr = this.dtSet.Tables[0].NewRow();
                dr[0] = PID;
                dr[1] = Command;
                dr[2] = User;
                dr[3] = ThreadName;
                dr[4] = PPID;

                if(PPID != 0)   // Do not show kthreads
                    this.dtSet.Tables[0].Rows.Add(dr);
            }

            ms.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Structures.TCPCommandSimple com = new Structures.TCPCommandSimple();
            com.command = 2805;
            com.param = Convert.ToUInt16(this.SelectedPID);

            byte[] tmp2 = Structures.getBytesFromStruct(com);
            tmp2 = Network.SendCommand64(tmp2, false, "", this.Client, true);

            if (tmp2 != null)
            {
                Int32 attachResult = Commands.ps4ninja_attach(Convert.ToInt16(this.SelectedPID),0, this.Client);

                if (attachResult == 0)
                {
                    frmVMEntries FRMVMEntries = new frmVMEntries();
                    FRMVMEntries.VMData = tmp2;
                    FRMVMEntries.Client = this.Client;
                    FRMVMEntries.PID = Convert.ToInt16(this.SelectedPID);
                    FRMVMEntries.Text = string.Format("Debug - PID {0} - {1}", this.SelectedPID, this.SelectedCommand);
                    FRMVMEntries.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("There was an error! Maybe the process is not active anymore.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(string.Format("Kill PID {0} - {1}", this.SelectedPID, this.SelectedCommand), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Send kill command
                Commands.ps4ninja_kill_pid((short)this.SelectedPID, this.Client);

                //Refresh process list
                Structures.TCPCommandComplex com2 = new Structures.TCPCommandComplex();
                com2.command = 2803;
                com2.param = "DUMMY";

                byte[] tmp = Structures.getBytesFromStruct(com2);
                tmp = Network.SendCommand64(tmp, false, "", this.Client, true);

                this.dtSet.Tables[0].Clear();
                this.ParseData(tmp);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedPID = Convert.ToUInt32(this.dataGridView1[0, e.RowIndex].Value);
                this.SelectedCommand = Convert.ToString(this.dataGridView1[1, e.RowIndex].Value);
            } catch (Exception)
            {

            }
        }
    }
}
