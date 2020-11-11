using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientEmul
{
    public partial class Form1 : Form
    {
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(tbInterval.Text);
            timer1.Enabled = true;
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
    }
}
