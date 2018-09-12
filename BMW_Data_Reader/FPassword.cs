using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMW_Data_Reader
{
    public partial class FPassword : Form
    {
        public String Password = "";
        public FPassword()
        {
            InitializeComponent();
        }

        private void BOK_Click(object sender, EventArgs e)
        {
            this.Password = TBPassword.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void TBPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Password = TBPassword.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
