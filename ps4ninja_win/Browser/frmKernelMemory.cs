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
    public partial class frmKernelMemory : Form
    {
        public TcpClient Client;
        public byte[] VMData;
        public byte[] Data;
        public byte[] Code;

        public frmKernelMemory()
        {
            InitializeComponent();
        }

        private void frmKernelMemory_Load(object sender, EventArgs e)
        {

        }

        private void txtMemAdr_KeyDown(object sender, KeyEventArgs e)
        {

            if (this.txtMemAdr.Text == "")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                btnRead_Click(sender, e);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                string AddrStr = "";
                string LenStr = "";
                if (this.txtMemAdr.Text.StartsWith("0x"))
                    AddrStr = this.txtMemAdr.Text.Substring(2);
                else
                    AddrStr = this.txtMemAdr.Text;

                if (this.txtLen.Text.StartsWith("0x"))
                    LenStr = this.txtLen.Text.Substring(2);
                else
                    LenStr = this.txtLen.Text;

                UInt64 Addr = 0;
                UInt64.TryParse(AddrStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out Addr);

                UInt64 Len = 0;
                UInt64.TryParse(LenStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out Len);

                this.Data = null;
                this.Data = Commands.ps4ninja_read_kmem(0, Addr, Len, this.Client);

                if (this.Data != null)
                {
                    DynamicByteProvider dbp = new DynamicByteProvider(this.Data);
                    this.hxBox.ReadOnly = false;
                    this.hxBox.ByteProvider = dbp;
                    this.hxBox.LineInfoOffset = Convert.ToUInt64(Addr);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLen_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtLen.Text == "")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                btnRead_Click(sender, e);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            DynamicByteProvider dbp = this.hxBox.ByteProvider as DynamicByteProvider;
            dbp.ApplyChanges();

            for (int i = 0; i < dbp.Bytes.Count; i++)
                this.Data[i] = dbp.Bytes[i];

            string AddrStr = "";

            if (this.txtMemAdr.Text.StartsWith("0x"))
                AddrStr = this.txtMemAdr.Text.Substring(2);
            else
                AddrStr = this.txtMemAdr.Text;

            UInt64 Addr = 0;
            UInt64.TryParse(AddrStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out Addr);

            Commands.ps4ninja_write_kmem(Addr, (UInt64)this.Data.Length, this.Data, this.Client);
        }
    }
}
