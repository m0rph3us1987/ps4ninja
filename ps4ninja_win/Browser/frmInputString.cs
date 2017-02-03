using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS4FileNinja
{
    public partial class frmInputString : Form
    {
        public string Result;

        public frmInputString()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.txtString.Text == "")
            {
                MessageBox.Show("You must insert a string!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Result = this.txtString.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
