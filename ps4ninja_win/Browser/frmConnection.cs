using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Reflection;

namespace PS4FileNinja
{
    public partial class frmConnection : Form
    {
        public frmDebugOutput FormDebugOutput;
        private TcpClient LogClient;
        private TcpClient KLogClient;

        public frmConnection()
        {
            InitializeComponent();
        }

        private void frmConnection_Load(object sender, EventArgs e)
        {
            this.txtPort.SelectionStart = this.txtPort.Text.Length;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                KLogClient = new TcpClient(this.txtIP.Text, 9081);
            }
            catch (Exception)
            {

            }

            try
            {
                TcpClient client = new TcpClient(this.txtIP.Text, 9080);
                frmBrowser br = new frmBrowser(client);
                br.Log = this.LogClient;
                br.KLog = this.KLogClient;
                br.Show();
                this.Hide();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            byte[] payload = null;
            string FileName = "PS4FileNinja.payload_176.bin";

            try
            {
                LogClient = new TcpClient(this.txtIP.Text, 5052);
            }
            catch (Exception)
            {
                
            }

            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(FileName))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                   payload  = reader.ReadBytes((int)stream.Length);
                }

            try
            {
                TcpClient client = new TcpClient(this.txtIP.Text, Convert.ToInt32(this.txtPort.Text));

                client.Client.Send(payload);
                client.Close();

                MessageBox.Show("Payload sent! If browser did not crash, try connect to PS4...", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
