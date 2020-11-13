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
        delegate void AddTextCB(string str,int n);

        public void AddText(string str,int n)
        {
            if(tbServer.InvokeRequired)
            {
                AddTextCB cb = new AddTextCB(AddText);
                object[] ob = { str, n };
                Invoke(cb, ob);
            }
            else
            {
                if(n == 0)
                    tbServer.Text += str;
                else if(n == 1)
                    tbClient.Text += str;
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
        int ServerPort = 9001;  // 어딘가에서 수정할 수 있음

        private void mnuStart_Click(object sender, EventArgs e)
        {
            if (_listen == null)
                _listen = new TcpListener(ServerPort);
            AddText($"Chatting Server started.[{ServerPort}]\r\n",0);
            StatusLabel1.Text = $"{ServerPort} opened.";
            this.Text += "[SERVER]";
            _SessionThread = new Thread(ServerProcess);
            _SessionThread.Start();

            timer1.Enabled = true;
        }

        public void ServerProcess()
        {   // 접속 요청 수락시까지만 ...
            _listen.Start();
            while(true)
            {
                if(_listen.Pending())
                {
                    _socket = _listen.AcceptTcpClient();
                    string s1 = _socket.Client.RemoteEndPoint.ToString();
                    string s2 = s1.Split(':')[0];
                    AddText($"Connected to Remote Client..[{s2}]\r\n",0);
                    StatusLabel2.Text = $"Remote IP:[{s2}]";
                    break;
                }
            }
        }

        private void ReadProcess()
        {
            try
            {
                while (true)  // ----> Hello....
                {
                    Thread.Sleep(20);
                    NetworkStream ns = _socket.GetStream();
                    int n = ns.Read(bArr, 0, 10000);
                    string str = "---->" + Encoding.Default.GetString(bArr, 0, n)+"\r\n";
                    AddText(str,0);
                }
            }
            catch(Exception e)
            {
                string s1 = $"오류:{e.Message}\r\n";
                AddText(s1,0);
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

        public void SendString(string str)
        {
            if (_socket != null)
            {
                NetworkStream ns = _socket.GetStream();
                byte[] bArr1 = Encoding.Default.GetBytes(str);
                ns.Write(bArr1, 0, bArr1.Length);
            }
        }

        private void mnuSend1_Click(object sender, EventArgs e)
        {
            SendString(tbClient.SelectedText);
        }

        private void tbClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r' && _sock != null)
            {
                string str = tbClient.Text.Trim().Split('\r').Last();
//                byte[] bArr1 = Encoding.Default.GetBytes(str);
                _sock.Send(Encoding.Default.GetBytes(str));
            }
        }
        /// <summary>
        /// Client Mode methods
        /// Target(server) IP/Port에 대하여 접속 요청
        /// -Socket
        /// -Connect 사용
        /// Client method ReadThread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        string RemoteIP = "169.254.86.142";  // My IP
        int RemotePort = 9001;
        Thread _ClientThread;
        Socket _sock;

        private void mnuClientStart_Click(object sender, EventArgs e)
        {
            _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _sock.Connect(RemoteIP, RemotePort);
            if (_sock.Connected)
            {
                this.Text += "[CLIENT]";
                _ClientThread = new Thread(ClientProcess);
                _sock.ReceiveTimeout = 1000;
                _ClientThread.Start();
            }
        }

        private void ClientProcess()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(20);
                    int n = _sock.Receive(bArr); // Low level socket method
                    string str = Encoding.Default.GetString(bArr, 0, n) + "\r\n";
                    AddText(str,1);
                }
                catch (SocketException e)
                {
                    if(e.SocketErrorCode != SocketError.TimedOut)
                    {
                        string s1 = $"오류 : {e.Message}\r\n";
                        AddText(s1,1);
                        return; // 비정상 오류에 의한 쓰레드 종료
                    }
                }
            }
        }

        private void mnuClientStop_Click(object sender, EventArgs e)
        {

        }

        private void mnuServerStop_Click(object sender, EventArgs e)
        {
            if (_SessionThread != null)
            {
                _SessionThread.Interrupt();
                _SessionThread.Abort();
            }
            if (_ReadThread != null)
            {
                _ReadThread.Interrupt();
                _ReadThread.Abort();
            }
            StatusLabel1.Text = "Server closed.";
        }

        private void mnuSetup_Click(object sender, EventArgs e)
        {
            frmInput dlg = new frmInput("Port");
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                ServerPort = int.Parse(dlg.sInput);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_SessionThread != null)
            {
                _SessionThread.Interrupt();
                _SessionThread.Abort();
            }
            if (_ReadThread != null)
            {
                _ReadThread.Interrupt();
                _ReadThread.Abort();
            }
            if(_ClientThread != null)
            {
                _ClientThread.Interrupt();
                _ClientThread.Abort();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_SessionThread != null)
            {
                _SessionThread.Interrupt();
                _SessionThread.Abort();
            }
            if (_ReadThread != null)
            {
                _ReadThread.Interrupt();
                _ReadThread.Abort();
            }
            if(_ClientThread != null)
            {
                _ClientThread.Interrupt();
                _ClientThread.Abort();
            }
        }

        private void tbServer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                string str = tbServer.Text.Trim().Split('\r').Last();
                SendString(str);
            }
        }
    }
}
