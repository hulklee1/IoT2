using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp1
{
    public partial class frmInput : Form
    {
        public frmInput()
        {
            InitializeComponent();
        }

        public string sRet = "";
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')   // [Enter] Key pressed  (13:0d)
            {
                sRet = textBox1.Text;
                Close();
            }
        }
    }
}
