using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System;
using System.IO;

namespace PS4FileNinja
{
    public partial class frmTransfer : Form
    {
        private TcpListener Listener;
        public TcpClient CommandSock; 
        private TcpClient DataSock;

        public UInt64 Filesize, Received;
        public bool Continue;
        private int Port = 9099;
        public int ClientPID;
        private Thread rcvThread;
        public string LocalFile;

        private FileStream fs;
        private BinaryWriter br;

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            this.lblFile.Text = this.LocalFile;

            // Choose random port for file transfer
            Random rnd = new Random();
            this.Port = rnd.Next(10000, 10500);

            this.rcvThread = new Thread(ReceiveFile);
            rcvThread.Start();

            // Give PC time to start receiver thread before sending ip and port to ps4
            Thread.Sleep(500);  
                
            //Send port
            byte[] tmp = BitConverter.GetBytes((UInt32)this.Port);
            this.CommandSock.Client.Send(tmp);

            //Send PC IP
            UInt32 intAddress = (UInt32)BitConverter.ToInt32(IPAddress.Parse(this.CommandSock.Client.LocalEndPoint.ToString().Split(':')[0]).GetAddressBytes(), 0);
            tmp = BitConverter.GetBytes(intAddress);
            this.CommandSock.Client.Send(tmp);
        }

        public frmTransfer(TcpClient pCommandSock, UInt64 pFilezie)
        {
            InitializeComponent();
            this.Filesize = pFilezie;
            this.CommandSock = pCommandSock;
            this.prgBar.Maximum = (int) this.Filesize;
            this.Continue = true;
        }

        public frmTransfer()
        {
            InitializeComponent();
        }

        private void ReceiveFile()
        {
            this.Received = 0;

            // Start data server
            this.Listener = new TcpListener(IPAddress.Any, this.Port);
            this.Listener.Start();
            this.DataSock = Listener.AcceptTcpClient();

            // Create file
            if (File.Exists(this.LocalFile))
                File.Delete(this.LocalFile);

            fs = new FileStream(this.LocalFile, FileMode.CreateNew, FileAccess.ReadWrite);
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
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            // Return dialog cancelled
            this.DialogResult = DialogResult.Cancel;
        }

        private void UptControls()
        {
            Thread.Sleep(2);
            String LabelTxt = "Received: " + Convert.ToString(this.Received) + " of " + Convert.ToString(this.Filesize) + " bytes.";

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
                this.prgBar.BeginInvoke((MethodInvoker)delegate () { this.prgBar.Value = (int)this.Received; });
            }
            else
            {
                this.prgBar.Value = (int) this.Received;
            }
        }
    }
}
