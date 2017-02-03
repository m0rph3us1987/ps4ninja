using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PS4FileNinja
{
    public partial class frmUploadFiles : Form
    {
        public string[] Files;
        public string ActualPath;
        public TcpClient Client;

        public int Port;
        private Thread rcvThread;
        private Thread bckThread;
        private string FileToSend;

        public UInt64 Filesize, Sent;

        public frmUploadFiles()
        {
            InitializeComponent();
        }

        private void SendFile()
        {
            TcpListener Listener = new TcpListener(IPAddress.Any, this.Port);
            Listener.Start();

            TcpClient DataSock = Listener.AcceptTcpClient();

            byte[] DataPid = new byte[2];
            DataSock.Client.Receive(DataPid);

            FileStream fs = new FileStream(this.FileToSend, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            UInt64 FileLength = (UInt64)fs.Length;
            UInt64 sentBytes = 0;
            this.Sent = 0;

            byte[] tmpBuff = new byte[4096];

            while (sentBytes != FileLength)
            {
                while (DataSock.Available > 0)
                    Thread.Sleep(10);

                fs.Seek((long)sentBytes, SeekOrigin.Begin);

                if (FileLength - sentBytes > 4096)
                    tmpBuff = br.ReadBytes(4096);
                else
                    tmpBuff = br.ReadBytes((int)(FileLength - sentBytes));

                sentBytes += (ulong)DataSock.Client.Send(tmpBuff);
                this.Sent = sentBytes;
                this.UptControls();
            }

            br.Close();
            fs.Close();

            DataSock.Close();
        }

        private void Background()
        {
            foreach (string file in this.Files)
            {
                FileInfo f = new FileInfo(file);
                this.Filesize = (ulong)f.Length;
                String RemoteFilename = "";

                if (this.ActualPath.EndsWith("/"))
                    RemoteFilename = this.ActualPath + f.Name;
                else
                    RemoteFilename = this.ActualPath + "/" + f.Name;

                Random rnd = new Random();
                this.Port = rnd.Next(10000, 10500);

                this.FileToSend = file;

                this.rcvThread = new Thread(SendFile);
                rcvThread.Start();

                // Give PC time to start receiver thread before sending ip and port to ps4
                Thread.Sleep(200);

                UInt32 intAddress = (UInt32)BitConverter.ToInt32(IPAddress.Parse(this.Client.Client.LocalEndPoint.ToString().Split(':')[0]).GetAddressBytes(), 0);

                Commands.ps4ninja_receive_file(RemoteFilename, (UInt64)f.Length, intAddress, (uint)this.Port, this.Client);
                rcvThread.Join();
            }

            this.DialogResult = DialogResult.OK;
        }

        private void frmUploadFiles_Load(object sender, EventArgs e)
        {
            this.bckThread = new Thread(Background);
            bckThread.Start();
        }

        private void UptControls()
        {
            Thread.Sleep(10);
            String LabelTxt = "Sent: " + Convert.ToString(this.Sent) + " of " + Convert.ToString(this.Filesize) + " bytes.";

            if (this.lblFile.InvokeRequired)
            {
                this.lblFile.BeginInvoke((MethodInvoker)delegate () { this.lblFile.Text = this.FileToSend; });
            }
            else
            {
                this.lblFile.Text = this.FileToSend;
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
                    this.prgBar.Value = Convert.ToInt32((this.Sent * 100) / this.Filesize);
                    //this.prgBar.Value = (int)this.Received;
                });
            }
            else
            {
                this.prgBar.Maximum = (int)this.Filesize;
                this.prgBar.Value = (int)this.Sent;
            }
        }
    }
}
