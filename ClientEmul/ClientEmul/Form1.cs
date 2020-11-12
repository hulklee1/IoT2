using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientEmul
{
    public partial class Form1 : Form
    {
        delegate void AddTextCB(string str);

        public void AddText(string str)
        {
            if (tbCommand.InvokeRequired)
            {
                AddTextCB cb = new AddTextCB(AddText);
                object[] ob = { str };
                Invoke(cb, ob);
            }
            else
            {
                tbCommand.Text += str;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        // // 1 Packet Process function
        // 함수명 : SendPacket(string sPack)
        // 인수   : string sPack - 전송할 패킷 문자열
        // 리턴값 : None
        // 기능  : 입력된 문자열을 byte 배열로 변환하여 서버로 전송
        //         한글 엔코딩 기능 부여
        int RetryCount = 0;
        public void SendPacket(string sPack)
        {  // 1 Packet Process
            try
            {
                Socket _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _sock.Connect(tbServerIP.Text, int.Parse(tbServerPort.Text));
                if (_sock.Connected)
                {
                    char[] cArr = sPack.ToCharArray();  // != byte[]
                    byte[] bArr = Encoding.Default.GetBytes(cArr);

                    _sock.Send(bArr);
                    RetryCount = 0;
                }
            }
            catch(Exception e)
            {
                tbRetry.Text = $"{RetryCount++}";
            }
        }
        Socket _sock;
        Thread _thread;
        byte[] bArr = new byte[10000];
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(ckbTimer.Checked == true)
            {
                timer1.Interval = int.Parse(tbInterval.Text);
                timer1.Enabled = true;
            }
            else
            {
                _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _sock.Connect(tbServerIP.Text, int.Parse(tbServerPort.Text));
                if (_sock.Connected)
                {
                    _thread = new Thread(ReadProcess);
                    _thread.Start();
                }
            }
        }
        private void ReadProcess()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(20);
                    int n = _sock.Receive(bArr); // Low level socket method
                    string str = Encoding.Default.GetString(bArr,0,n) + "\r\n";
                    AddText(str);
                }
            }
            catch (Exception e)
            {
                string s1 = $"오류 : {e.Message}\r\n"; 
                AddText(s1);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            string s1 = tbCode.Text;//"[STX:02]Hello.[ETX:03]";
            string s2 = tbVal1.Text;
            string s3 = tbVal2.Text;
            string s4 = tbVal3.Text;
            string s = tbSep.Text;  // printf("%c",2); [STX:02]
            //char[] c1 = new char[2]; 
            //char c1 = Convert.ToChar(02);//"02" : STX
            //char c2 = Convert.ToChar(03);//"03" : ETX

            SendPacket($"\u0002{s1}{s}{s2}{s}{s3}{s}{s4}\u0003");
            SendPacket($"{Convert.ToChar(02)}{s1}{s}{s2}{s}{s3}{s}{s4}{Convert.ToChar(03)}");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        public void SendString(string str)
        {
            if(_sock != null)
            {
                byte[] bArr1 = Encoding.Default.GetBytes(str);
                _sock.Send(bArr1);
            }
        }
        private void mnuSend1_Click(object sender, EventArgs e)
        {
            SendString(tbCommand.SelectedText);
        }

        private void tbCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                string str = tbCommand.Text.Trim().Split('\r').Last();
                SendString(str);
            }
        }
    }
}
