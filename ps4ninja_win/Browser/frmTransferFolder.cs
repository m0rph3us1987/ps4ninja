using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System;
using System.IO;
using System.Collections.Generic;

namespace PS4FileNinja
{
    public partial class frmTransferFolder : Form
    {
        private TcpListener Listener;
        public TcpClient CommandSock; 
        private TcpClient DataSock;

        public UInt64 Filesize, Received;
        public bool Continue;
        private int Port = 9099;
        public int ClientPID;
        private Thread rcvThread;

        private FileStream fs;
        private BinaryWriter br;

        public String RemoteFolder;
        public String LocalFolder;
        public String ReceivingFile;

        public bool OverwriteFiles = true;

        private bool SendingCommand = false;

        private void DownloadFolder(string RemoteFolder, string LocalFolder)
        {
            byte[] reqResult = Commands.ps4ninja_get_dents(RemoteFolder, this.CommandSock);
            List<Dent> dents = Utility.ResolveDents(reqResult);

            foreach (Dent d in dents)
            {
                if (d.Type == 4)
                {
                    if (d.Name != "." && d.Name != "..")
                    {
                        if (!Directory.Exists(LocalFolder + "\\" + d.Name))
                            Directory.CreateDirectory(LocalFolder + "\\" + d.Name);

                        DownloadFolder(RemoteFolder + "/" + d.Name, LocalFolder + "\\" + d.Name);
                    }
                }

                if (d.Type == 8)
                {
                    DownloadFile(RemoteFolder + "/" + d.Name, LocalFolder + "\\" + d.Name);
                }
            }
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            this.rcvThread = new Thread(ReceiveFolder);
            rcvThread.Start();
        }

        public frmTransferFolder(TcpClient pCommandSock, UInt64 pFilezie)
        {
            InitializeComponent();
            this.Filesize = pFilezie;
            this.CommandSock = pCommandSock;
            this.prgBar.Maximum = (int) this.Filesize;
            this.Continue = true;
        }

        private void ReceiveFolder()
        {
            DownloadFolder(this.RemoteFolder, this.LocalFolder);
            this.DialogResult = DialogResult.OK;
        }

        public frmTransferFolder()
        {
            InitializeComponent();
        }

        private void DownloadFile(string RemoteFile, string LocalFile)
        {
            this.Received = 0;
            this.ReceivingFile = LocalFile;
            bool portSelected = false;

            // Create file
            if (File.Exists(LocalFile) && this.OverwriteFiles == false)
                return;

            while (!portSelected)
            {
                try
                {
                    // Choose random port for file transfer
                    Random rnd = new Random();
                    this.Port = rnd.Next(10000, 14000);

                    // Start data server
                    this.Listener = new TcpListener(IPAddress.Any, this.Port);
                    this.Listener.Start();
                    portSelected = true;
                }
                catch (Exception) { }
            }

            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();

            // Auto decrypt executable formats
            if (RemoteFile.EndsWith(".elf") || RemoteFile.EndsWith(".sprx") || RemoteFile.EndsWith(".self") || RemoteFile.EndsWith("eboot.bin") || RemoteFile.EndsWith("prx"))
                com.command = 2801;
            else
                com.command = 2802;

            // Force normal file transfer
            //com.command = 2802;

            com.param = RemoteFile;
            byte[] Command = Structures.getBytesFromStruct(com);

            //Send port
            byte[] Port = BitConverter.GetBytes((UInt32)this.Port);

            //Send PC IP
            UInt32 intAddress = (UInt32)BitConverter.ToInt32(IPAddress.Parse(this.CommandSock.Client.LocalEndPoint.ToString().Split(':')[0]).GetAddressBytes(), 0);
            byte[] IP = BitConverter.GetBytes(intAddress);

            this.SendingCommand = true;
            this.Filesize = Network.SendFileRequest(Command, Port, IP, this.CommandSock);
            this.SendingCommand = false;
            
            if(this.Filesize > 0)
                this.DataSock = Listener.AcceptTcpClient();

            // Create file
            if (File.Exists(LocalFile))
                File.Delete(LocalFile);

            fs = new FileStream(LocalFile, FileMode.CreateNew, FileAccess.ReadWrite);

            if(Filesize == 0)       // if its an empty file, stop right here!
            {
                fs.Close();
                this.Listener.Stop();
                return;
            }


            br = new BinaryWriter(fs);
            
            byte[] tmp = new byte[2];

            // Receive PS4 data PID
            while (this.DataSock.Client.Available == 0) { };
            this.DataSock.Client.Receive(tmp);
            this.ClientPID = BitConverter.ToUInt16(tmp, 0);

            // Read all data that arrives over network
            while (this.Received < this.Filesize)
            {
                if (DataSock.Available != 0)
                {
                    byte[] tmpBuffer = new byte[DataSock.Available];
                    DataSock.Client.Receive(tmpBuffer);
                    br.Write(tmpBuffer);
                    this.Received += (UInt32)tmpBuffer.Length;
                    
                    UptControls();
                }
            }

            // Close file
            br.Close();
            fs.Close();

            // Close listener server and dialog
            this.Listener.Stop();
            this.DataSock.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while(this.SendingCommand)
            {

            }

            // Quit receiver thread
            this.rcvThread.Abort();
            if(this.DataSock != null)
                this.DataSock.Close();

            // Stop listener and close file
            this.Listener.Stop();
            try
            {
                br.Close();
                fs.Close();
            } catch (Exception)
            {

            }

            //Commands.ps4ninja_kill_pid((short)this.ClientPID, this.CommandSock);

            // Return dialog cancelled
            this.DialogResult = DialogResult.Cancel;
        }

        private void UptControls()
        {
            Thread.Sleep(10);
            String LabelTxt = "Received: " + Convert.ToString(this.Received) + " of " + Convert.ToString(this.Filesize) + " bytes.";

            if(this.lblFile.InvokeRequired)
            {
                this.lblFile.BeginInvoke((MethodInvoker)delegate () { this.lblFile.Text = this.ReceivingFile; });
            }
            else
            {
                this.lblFile.Text = ReceivingFile;
            }

            if (this.label1.InvokeRequired)
            {
                this.label1.BeginInvoke((MethodInvoker)delegate () { this.label1.Text = LabelTxt; });
            }
            else
            {
                this.label1.Text = LabelTxt;
            }

            if (this.prgBar.InvokeRequired)
            {
                this.prgBar.BeginInvoke((MethodInvoker)delegate () {
                    this.prgBar.Maximum = 100;
                    //this.prgBar.Maximum = (int)this.Filesize;
                    this.prgBar.Value = Convert.ToInt32((this.Received * 100) / this.Filesize);
                    //this.prgBar.Value = (int)this.Received;
                });
            }
            else
            {
                this.prgBar.Maximum = (int)this.Filesize;
                this.prgBar.Value = (int) this.Received;
            }
        }
    }
}
