using System;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace PS4FileNinja
{
    public partial class frmDump : Form
    {
        public byte[] Data;
        public ulong LineOff;
        public string Filename;

        public frmDump()
        {
            InitializeComponent();
        }

        private void frmDump_Load(object sender, EventArgs e)
        {
            DynamicByteProvider dbp = new DynamicByteProvider(this.Data);
            this.hxBox.ReadOnly = true;
            this.hxBox.ByteProvider = dbp;
            this.hxBox.LineInfoOffset = this.LineOff;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.dlgSave.FileName = this.Filename;

            if (this.dlgSave.ShowDialog() == DialogResult.OK)
                Utility.DumpToFile(this.dlgSave.FileName, this.Data);
                
        }
    }
}
