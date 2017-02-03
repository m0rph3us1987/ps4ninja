using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.IO;

namespace PS4FileNinja
{
    public partial class frmBrowser : Form
    {
        TcpClient Client;
        public TcpClient Log;
        public TcpClient KLog;

        NetworkStream Stream;
        List<Dent> CurrentDents;
        List<MountPoint> MountPoints;

        public frmBrowser()
        {
            InitializeComponent();
        }

        public frmBrowser(TcpClient client)
        {
            InitializeComponent();
            this.Client = client;
            this.Stream = client.GetStream();
            this.CurrentDents = new List<Dent>();
            this.MountPoints = new List<MountPoint>();
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            this.Timer.Enabled = true;
            EnterDir("/");
        }

        private void EnterDir(string Dir)
        {
            byte[] tmp = Commands.ps4ninja_get_dents(Dir, this.Client);
            ParseDents(tmp);

            if(tmp == null)
                MessageBox.Show("ERROR: Folder " + Dir + " could not be read!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void ExitServer()
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 0508;
            com.param = "DUMMY";

            byte[] tmp = Structures.getBytesFromStruct(com);

            if (Client.Client.Available > 0)
            {
                byte[] tmp2 = new byte[Client.Client.Available];
                Client.Client.Receive(tmp2);
            }

            Network.WriteU32((UInt32)tmp.Length,this.Client.Client);
            Thread.Sleep(50);
            byte res = Network.ReadByte(this.Client.Client);

            if (res != 0x4f)
                return;

            Thread.Sleep(50);
            Network.WriteBytes(tmp, this.Client.Client);
            Thread.Sleep(50);
            this.Client.Close();
            return;
        }

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                EnterDir(this.txtPath.Text);
        }

        private void ParseDents(byte[] Dents)
        {
            this.lstDirectory.Items.Clear();
            this.lstFile.Items.Clear();
            this.CurrentDents.Clear();

            this.CurrentDents = Utility.ResolveDents(Dents);

            foreach(Dent d in this.CurrentDents)
            {
                if (d.Type == 4)
                    this.lstDirectory.Items.Add(d.Name);
                else
                    this.lstFile.Items.Add(d.Name);
            }

        }

        private void lstDirectory_DoubleClick(object sender, EventArgs e)
        {
            if(this.lstDirectory.SelectedItem != null)
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
                    if(SelectedDir == ".." && this.txtPath.Text != "/")
                    {
                        if (this.txtPath.Text.EndsWith("/"))
                            this.txtPath.Text = this.txtPath.Text.Remove(this.txtPath.Text.Length - 1, 1);

                        string[] folders = this.txtPath.Text.Split('/');

                        string newDir = "";

                        for(int i = 0; i < folders.Length - 1; i++)
                        {
                            if(folders[i] != "")
                                newDir += folders[i] + "/";
                        }

                        this.txtPath.Text = "/" + newDir;
                        EnterDir(this.txtPath.Text);
                    }

                }
            }
        }
        
        private void lstFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.dlgSave.FileName = Convert.ToString(this.lstFile.SelectedItem);
            if (this.dlgSave.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(this.dlgSave.FileName))
                    File.Delete(this.dlgSave.FileName);

                string tmpStr = "";

                if (this.txtPath.Text.EndsWith("/"))
                    tmpStr = this.txtPath.Text + Convert.ToString(this.lstFile.SelectedItem);
                else
                    tmpStr = this.txtPath.Text + "/" + Convert.ToString(this.lstFile.SelectedItem);


                if (GetFile(tmpStr, this.dlgSave.FileName) != null)
                {
                    MessageBox.Show("File downloaded!");
                }
            }
           
        }

        private byte[] GetFile(string path, string LocalFile)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();

            // Auto decrypt executable formats
            if (path.EndsWith(".elf") || path.EndsWith(".sprx") || path.EndsWith(".self") || path.EndsWith("eboot.bin") || path.EndsWith("prx"))
                com.command = 2801;
            else
                com.command = 2802;

            // Force normal file transfer
            //com.command = 2802;

            com.param = path;
            byte[] tmp = Structures.getBytesFromStruct(com);
            return Network.SendCommand(tmp, true, LocalFile, this.Client);
        }

        private void frmBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mnuProcesses_Click(object sender, EventArgs e)
        {
            Structures.TCPCommandComplex com = new Structures.TCPCommandComplex();
            com.command = 2803;
            com.param = "DUMMY";

            byte[] tmp = Structures.getBytesFromStruct(com);
            tmp = Network.SendCommand64(tmp, false, "", this.Client, true);

            frmProcesses FormProc = new frmProcesses();
            FormProc.Client = this.Client;
            FormProc.ProcessData = tmp;
            FormProc.Show();
        }

        private void btnDownloadFolder_Click(object sender, EventArgs e)
        {
            if (dlgFolder.ShowDialog() != DialogResult.OK)
                return;

            frmTransferFolder FRMFolder = new frmTransferFolder();
            FRMFolder.RemoteFolder = this.txtPath.Text;
            FRMFolder.LocalFolder = this.dlgFolder.SelectedPath;
            FRMFolder.CommandSock = this.Client;

            if (FRMFolder.ShowDialog() == DialogResult.OK)
                MessageBox.Show("Folder downloaded!");
        }

        private void lstFile_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void lstFile_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (Convert.ToString(this.lstFile.SelectedItem) != "")
                {
                    this.mnuCtxFile.Show(Cursor.Position);
                    this.mnuCtxFile.Visible = true;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(this.lstFile.SelectedItem) != "")
            {
                string tmpStr;

                if (this.txtPath.Text.EndsWith("/"))
                    tmpStr = this.txtPath.Text + Convert.ToString(this.lstFile.SelectedItem);
                else
                    tmpStr = this.txtPath.Text + "/" + Convert.ToString(this.lstFile.SelectedItem);

                if(MessageBox.Show("Do you want to delete file: " + tmpStr, "Delete file!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Commands.ps4ninja_rmfile(tmpStr, this.Client);
                    EnterDir(this.txtPath.Text);
                }
            }
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(this.lstFile.SelectedItem) != "")
            {
                string tmpStr;

                if (this.txtPath.Text.EndsWith("/"))
                    tmpStr = this.txtPath.Text + Convert.ToString(this.lstFile.SelectedItem);
                else
                    tmpStr = this.txtPath.Text + "/" + Convert.ToString(this.lstFile.SelectedItem);

                if (MessageBox.Show("Do you want to execute file: " + tmpStr, "Execute file!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UInt64 result = Commands.ps4ninja_execve(tmpStr, this.Client);
                    MessageBox.Show("Execve returned " + Convert.ToString(result));
                }
            }
        }

        private void openInHexeditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tmpStr = "";

            if (this.txtPath.Text.EndsWith("/"))
                tmpStr = this.txtPath.Text + Convert.ToString(this.lstFile.SelectedItem);
            else
                tmpStr = this.txtPath.Text + "/" + Convert.ToString(this.lstFile.SelectedItem);

            if (File.Exists("ninja.tmp"))
                File.Delete("ninja.tmp");

            GetFile(tmpStr, "ninja.tmp");

            FileStream fs = new FileStream("ninja.tmp", FileMode.Open, FileAccess.Read);
            byte[] fileContent = new byte[fs.Length];
            fs.Read(fileContent, 0, fileContent.Length);
            fs.Close();
            File.Delete("ninja.tmp");

            frmDump DUMPForm = new frmDump();
            DUMPForm.Filename = tmpStr;
            DUMPForm.Data = fileContent;
            DUMPForm.LineOff = 0;
            DUMPForm.ShowDialog();
        }

        private void lstDirectory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Convert.ToString(this.lstDirectory.SelectedItem) != "")
                {
                    this.mnuCtxFolder.Show(Cursor.Position);
                    this.mnuCtxFolder.Visible = true;
                }
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(this.lstDirectory.SelectedItem) != "")
            {
                string SelectedDir = Convert.ToString(this.lstDirectory.SelectedItem);
                if (SelectedDir != ".." && SelectedDir != ".")
                {
                    if (this.txtPath.Text.EndsWith("/"))
                        this.txtPath.Text += SelectedDir;
                    else
                        this.txtPath.Text += "/" + SelectedDir;

                    if (dlgFolder.ShowDialog() != DialogResult.OK)
                        return;

                    

                    frmTransferFolder FRMFolder = new frmTransferFolder();

                    if (MessageBox.Show("Do you want to replace existing files?", "Question!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        FRMFolder.OverwriteFiles = false;

                    FRMFolder.RemoteFolder = this.txtPath.Text;
                    FRMFolder.LocalFolder = this.dlgFolder.SelectedPath;
                    FRMFolder.CommandSock = this.Client;

                    if (FRMFolder.ShowDialog() == DialogResult.OK)
                        MessageBox.Show("Folder downloaded!");

                    EnterDir(this.txtPath.Text);
                }
            }
        }

        private void mountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectFolder SelectFolder = new frmSelectFolder();
            SelectFolder.Client = this.Client;
            if(SelectFolder.ShowDialog() == DialogResult.OK)
            {
                if (Convert.ToString(this.lstFile.SelectedItem) != "")
                {
                    string SaveFilename;
                    string MountFolder = SelectFolder.SelectedPath;

                    if (this.txtPath.Text.EndsWith("/"))
                        SaveFilename = this.txtPath.Text + Convert.ToString(this.lstFile.SelectedItem);
                    else
                        SaveFilename = this.txtPath.Text + "/" + Convert.ToString(this.lstFile.SelectedItem);

                    if (MessageBox.Show("Do you want to mount savegame " + SaveFilename + " to " + MountFolder + " ?","Mount savegame!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Int64 res = Commands.ps4ninja_mountsave(SaveFilename, MountFolder, this.Client);

                        if(res != -1)
                        {
                            MountPoint mp = new MountPoint(MountFolder, (int)res);
                            this.MountPoints.Add(mp);
                            MessageBox.Show("Savegame mounted!");
                        }
                        else
                            MessageBox.Show("ERROR: PS4 returned error no: " + Convert.ToString(res), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void unmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(this.lstDirectory.SelectedItem) != "")
            {
                string Dirname = "";

                if (this.txtPath.Text.EndsWith("/"))
                    Dirname = this.txtPath.Text + Convert.ToString(this.lstDirectory.SelectedItem);
                else
                    Dirname = this.txtPath.Text + "/" + Convert.ToString(this.lstDirectory.SelectedItem);

                for (int i = 0; i < this.MountPoints.Count; i++)
                    if (this.MountPoints[i].Path == Dirname)
                    {
                        Commands.ps4ninja_unmountsave(Dirname, this.MountPoints[i].DeviceID, this.Client);
                        this.MountPoints.RemoveAt(i);
                        return;
                    }

                MessageBox.Show("ERROR: No mount point found for " + Dirname, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            frmUploadFiles upload = new frmUploadFiles();
            upload.Files = files;
            upload.ActualPath = this.txtPath.Text;
            upload.Client = this.Client;

            if (upload.ShowDialog() == DialogResult.OK)
                EnterDir(this.txtPath.Text);
        }
        

        private void lstFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void createDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInputString strInput = new frmInputString();
            strInput.Text = "Insert a folder name: ";
            if(strInput.ShowDialog() == DialogResult.OK)
            {
                string Dirname = "";

                if (this.txtPath.Text.EndsWith("/"))
                    Dirname = this.txtPath.Text + strInput.Result;
                else
                    Dirname = this.txtPath.Text + "/" + strInput.Result;

                Commands.ps4ninja_mkdir(Dirname, this.Client);
                EnterDir(this.txtPath.Text);
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string Dirname = "";

            if (this.txtPath.Text.EndsWith("/"))
                Dirname = this.txtPath.Text + Convert.ToString(this.lstDirectory.SelectedItem);
            else
                Dirname = this.txtPath.Text + "/" + Convert.ToString(this.lstDirectory.SelectedItem);

            Commands.ps4ninja_rmdir(Dirname, this.Client);
            EnterDir(this.txtPath.Text);
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commands.ps4ninja_enable_userland_aslr(this.Client);
            MessageBox.Show("Userland ASLR enabled!");
            this.disabledToolStripMenuItem.Checked = false;
            this.enabledToolStripMenuItem.Checked = true;
        }

        private void disabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commands.ps4ninja_disable_userland_aslr(this.Client);
            MessageBox.Show("Userland ASLR disabled!");
            this.disabledToolStripMenuItem.Checked = true;
            this.enabledToolStripMenuItem.Checked = false;            
        }

        private void enabledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Commands.ps4ninja_enable_rwx_mapping(this.Client);
            MessageBox.Show("RWX mapping enabled!");
            this.disabledToolStripMenuItem1.Checked = false;
            this.enabledToolStripMenuItem1.Checked = true;
        }

        private void disabledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Commands.ps4ninja_disable_rwx_mapping(this.Client);
            MessageBox.Show("RWX mapping disabled!");
            this.disabledToolStripMenuItem1.Checked = true;
            this.enabledToolStripMenuItem1.Checked = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Log.Available != 0)
                {
                    byte[] Output = new byte[this.Log.Available];
                    this.Log.Client.Receive(Output);
                    this.txtLog.Text += System.Text.Encoding.ASCII.GetString(Output).Replace("\n", Environment.NewLine);
                    this.txtLog.SelectionStart = this.txtLog.Text.Length;
                    this.txtLog.ScrollToCaret();
                }

                if (this.KLog.Available != 0)
                {
                    byte[] Output = new byte[this.KLog.Available];
                    this.KLog.Client.Receive(Output);
                    this.txtKLog.Text += System.Text.Encoding.ASCII.GetString(Output).Replace("\n", Environment.NewLine);
                    this.txtKLog.SelectionStart = this.txtKLog.Text.Length;
                    this.txtKLog.ScrollToCaret();
                }
            }
            catch (Exception)
            {

            }
        }

        private void applyKPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UInt64 offset, len;
            byte[] patch;
            byte[] tmp = new byte[8];

            if(this.dlgOpen.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(this.dlgOpen.FileName, FileMode.Open, FileAccess.Read);
                byte[] kpf = new byte[fs.Length];
                fs.Read(kpf, 0, kpf.Length);
                fs.Close();

                MemoryStream ms = new MemoryStream(kpf);
                while(ms.Position != ms.Length)
                {
                    ms.Read(tmp, 0, 8);
                    offset = BitConverter.ToUInt64(tmp, 0);
                    ms.Read(tmp, 0, 8);
                    len = BitConverter.ToUInt64(tmp, 0);
                    patch = new byte[len];
                    ms.Read(patch, 0, (int)len);

                    Commands.ps4ninja_write_kmem(offset, len, patch, this.Client);
                }
            }
        }

        private void mountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSelectFolder SelectFolder = new frmSelectFolder();
            SelectFolder.Client = this.Client;
            if (SelectFolder.ShowDialog() == DialogResult.OK)
            {
                if (Convert.ToString(this.lstFile.SelectedItem) != "")
                {
                    string ISOFilename;
                    string MountFolder = SelectFolder.SelectedPath;

                    if (this.txtPath.Text.EndsWith("/"))
                        ISOFilename = this.txtPath.Text + Convert.ToString(this.lstFile.SelectedItem);
                    else
                        ISOFilename = this.txtPath.Text + "/" + Convert.ToString(this.lstFile.SelectedItem);

                    if (MessageBox.Show("Do you want to mount ISO " + ISOFilename + " to " + MountFolder + " ?", "Mount ISO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Int64 res = Commands.ps4ninja_mount_iso(ISOFilename, MountFolder, this.Client);

                        if (res != -1)
                        {
                            MountPoint mp = new MountPoint(MountFolder, (int)res);
                            this.MountPoints.Add(mp);
                            MessageBox.Show("ISO mounted!");
                        }
                        else
                            MessageBox.Show("ERROR: PS4 returned error no: " + Convert.ToString(res), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void kernelMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKernelMemory kmem = new frmKernelMemory();
            kmem.Client = this.Client;
            kmem.Show();
        }
    }
}
