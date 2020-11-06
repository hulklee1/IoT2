using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WinApp1
{
    public partial class frmInput : Form
    {
        public frmInput(string str="",int x=0, int y=0) // 초기값 설정
        {
            InitializeComponent();
            lblPrompt.Text = str;
            Location = new Point(x, y);
        }

        public string sRet = "";
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')   // [Enter] Key pressed  (13:0d)
            {
                sRet = textBox1.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (e.KeyChar == (char)Keys.Escape)  // [Enter] Key pressed  (13:0d)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
