using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinChatting
{
    public partial class frmInput : Form
    {
        public frmInput(string s1 = "")
        {
            InitializeComponent();
            lblTitle.Text = s1;
        }

        public string sInput;
        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r') // [Enter] key pressed
            {
                sInput = tbInput.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else if(e.KeyChar == '\x001b') // [ESC] key pressed
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
