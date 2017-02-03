using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.IO;

namespace PS4FileNinja
{
    public partial class frmSelectFolder : Form
    {
        public TcpClient Client;
        private List<Dent> CurrentDents;

        public string SelectedPath;

        public frmSelectFolder()
        {
            InitializeComponent();
        }

        private void EnterDir(string Dir)
        {
            byte[] tmp = Commands.ps4ninja_get_dents(Dir, this.Client);
            ParseDents(tmp);
        }

        private void ParseDents(byte[] Dents)
        {
            this.lstDirectory.Items.Clear();

            this.CurrentDents = Utility.ResolveDents(Dents);

            foreach (Dent d in this.CurrentDents)
            {
                if (d.Type == 4)
                    this.lstDirectory.Items.Add(d.Name);
            }

        }

        private void frmSelectFolder_Load(object sender, EventArgs e)
        {
            EnterDir("/");
        }

        private void lstDirectory_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstDirectory.SelectedItem != null)
            {
                string SelectedDir = Convert.ToString(this.lstDirectory.SelectedItem);
                if (SelectedDir != ".." && SelectedDir != ".")
                {
                    if (this.txtPath.Text.EndsWith("/"))
                        this.txtPath.Text += SelectedDir;
                    else
                        this.txtPath.Text += "/" + SelectedDir;

                    EnterDir(this.txtPath.Text);
                }
                else
                {
                    if (SelectedDir == ".." && this.txtPath.Text != "/")
                    {
                        if (this.txtPath.Text.EndsWith("/"))
                            this.txtPath.Text = this.txtPath.Text.Remove(this.txtPath.Text.Length - 1, 1);

                        string[] folders = this.txtPath.Text.Split('/');

                        string newDir = "";

                        for (int i = 0; i < folders.Length - 1; i++)
                        {
                            if (folders[i] != "")
                                newDir += folders[i] + "/";
                        }

                        this.txtPath.Text = "/" + newDir;
                        EnterDir(this.txtPath.Text);
                    }

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtPath.Text != "")
            {
                this.SelectedPath = this.txtPath.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                EnterDir(this.txtPath.Text);
        }
    }
}
