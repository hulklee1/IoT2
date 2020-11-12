using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinChatting
{
    public partial class Form1 : Form   // Ethernet Chatting 
    {
        delegate void AddTextCB(string str);

        public void AddText(string str)
        {
            if(tbServer.InvokeRequired)
            {
                AddTextCB cb = new AddTextCB(AddText);
                object[] ob = { str };
                Invoke(cb, ob);
            }
            else
            {
                tbServer.Text += str;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        TcpListener _listen;
        TcpClient _socket;
        Thread _SessionThread;
        Thread _ReadThread;
        byte[] bArr = new byte[10000];
        int ServerPort = 9000;  // 어딘가에서 수정할 수 있음

        private void mnuStart_Click(object sender, EventArgs e)
        {
            if (_listen == null)
                _listen = new TcpListener(ServerPort);
            AddText($"Chatting Server started.[{ServerPort}]\r\n");
            _SessionThread = new Thread(ServerProcess);
            _SessionThread.Start();

            timer1.Enabled = true;
        }

        public void ServerProcess()
        {   // 접속 요청 수락시까지만 ...
            _listen.Start();
            _socket = _listen.AcceptTcpClient();
            AddText($"Connected to Remote Client..[{_socket.Client.RemoteEndPoint.ToString()}]\r\n");
        }

        private void ReadProcess()
        {
            try
            {
                while (true)
                {   
                    NetworkStream ns = _socket.GetStream();
                    int n = ns.Read(bArr, 0, 10000);
                    string str = Encoding.Default.GetString(bArr,0,n)+"\r\n";
                    AddText(str);
                }
            }
            catch(Exception e)
            {
                string s1 = $"오류:{e.Message}\r\n";
                AddText(s1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_socket != null)
            {
                _ReadThread = new Thread(ReadProcess);
                _ReadThread.Start();
                 timer1.Enabled = false;
            }
        }

        private void mnuSend1_Click(object sender, EventArgs e)
        {
            if (_socket != null)
            {
                NetworkStream ns = _socket.GetStream();
                string str = tbClient.SelectedText;
                byte[] bArr1 = Encoding.Default.GetBytes(str);
                ns.Write(bArr1, 0, bArr1.Length);
            }
        }
    }
}
