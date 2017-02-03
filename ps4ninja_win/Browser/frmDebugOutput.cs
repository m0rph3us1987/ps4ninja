using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PS4FileNinja
{
    public partial class frmDebugOutput : Form
    {
        public String IP;
        public TcpClient Client;

        public frmDebugOutput()
        {
            InitializeComponent();
        }

        private void frmDebugOutput_Load(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Client.Available != 0)
                {
                    byte[] Output = new byte[this.Client.Available];
                    this.Client.Client.Receive(Output);
                    this.txtLog.Text += System.Text.Encoding.ASCII.GetString(Output).Replace("\n", Environment.NewLine);
                }
            } catch (Exception)
            {

            }
        }

        public void ConnectToServer()
        {
            try
            {
                this.Client = new TcpClient(this.IP, 5052);
                this.timer1.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }
    }
}
