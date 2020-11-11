using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerEmul
{
    public partial class Form1 : Form
    {
        delegate void BddText(string str);
        public void AddText(string str) //
        {
            if(tbServer.InvokeRequired)
            {
                BddText f = new BddText(AddText);
                object[] oArr = { str };
                Invoke(f, oArr);
            }
            else 
                tbServer.Text += str;
        }
        public Form1()
        {
            InitializeComponent();
        }
        // client tcp open 시 server ip & server port
        // server open 시 server port만 필요
        Thread ServerThread;
        TcpListener _listen;    // null
        byte[] Buffer = new byte[10000];
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(_listen == null) _listen = new TcpListener(int.Parse(tbServerPort.Text));
            _listen.Start();

            ServerThread = new Thread(ServerProcess);
            ServerThread.Start();
        }

        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string sConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bn\source\repos\MyTable.mdf;Integrated Security=True;Connect Timeout=30";
        private void ServerProcess()
        {
            while(true)
            {   // Packet data : [STX]100001,1200,3000,0200[ETX]
                TcpClient _client = _listen.AcceptTcpClient();
                NetworkStream ns = _client.GetStream();
                int n = ns.Read(Buffer, 0, 10000);
                string str = Encoding.Default.GetString(Buffer);
                AddText(str + "\r\n");
                //tbServer.Text += str + "\r\n";      
                string ss1 = str.Substring(0,n).Replace('\u0002',' '); // STX ==> ' '  , 문자열 뒤의 '\0' 제거
                string ss2 = ss1.Replace('\u0003',' ');   // ETX ==> ' '

                string[] sArr = ss2.Split(',');
                string s1 = sArr[0].Trim();
                string s4 = sArr[3].Trim();
                string st = DateTime.Now.ToString();
                string sql = $"insert into fstatus values ('{s1}','{sArr[1]}','{sArr[2]}','{s4}','{st}')";
                sCmd.CommandText = sql;
                sCmd.ExecuteNonQuery();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ServerThread.Suspend();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            ServerThread.Abort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sConn.ConnectionString = sConStr;
            sConn.Open();
            sCmd.Connection = sConn;
        }
    }
}
