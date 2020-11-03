using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string sConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bn\source\repos\MyTable.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection sConn = new SqlConnection();    // Database file에 연결 : ms-sql
        SqlCommand sCmd = new SqlCommand();        // sql 명령문 처리
        private void mnuAddColumn_Click(object sender, EventArgs e)
        {
            frmInput dlg = new frmInput();
            dlg.ShowDialog();
            string str = dlg.sRet;
            if (str != "")
            {
                dataGridView1.Columns.Add(str, str);
            }
        }

        private void mnuAddRow_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        public string GetToken(int index, string str, string sdel)
        {   // str 문자열을 'sDel' 구분자로 분할하여 그중 index번째의 문자열을 반환
            // ex) GetToken(3, "0|1|2|3|4|5" , "|")  ==> "3" 반환
            string[] sArr = str.Split(sdel[0]);
            return sArr[index];
        }

        private void mnuDBOpen_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ValidateNames = false;
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {   // Database 연결문자열을 구성.
                    // openFileDialog1.FileName  :  선택된 파일의 전체 경로

                    string[] sArr = sConString.Split(';');  // 4개의 필드중 2번째 필드(AttachDbFilename) 수정 필요
                    //string sConnStr = string.Format("{0};AttachDbFilename={1};{2};{3}", sArr[0], openFileDialog1.FileName,
                    //    sArr[2], sArr[3]);

                    string sConnStr = $"{sArr[0]};AttachDbFilename={openFileDialog1.FileName};{sArr[2]};{sArr[3]}";

                    sConn.ConnectionString = sConnStr;
                    sConn.Open();
                    sCmd.Connection = sConn;

                    StatusLabel1.Text = "Database Opened.";
                    StatusLabel1.BackColor = Color.Green;

                    DataTable dt = sConn.GetSchema("Tables");
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        string str = dt.Rows[i].ItemArray[2].ToString(); // 2번째 배열요소가 Table 이름
                        tbSql.Text += str + "\r\n";
                        stComboBox1.Items.Add(str);
                        stComboBox1.Text = str;
                    }    
                }
            }
            catch(Exception e1)
            {   // database 파일 오픈 에러 발생
                MessageBox.Show(e1.Message);
                StatusLabel1.Text = "Database Open Fail!!";
                StatusLabel1.BackColor = Color.Red;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mnuDBClose_Click(object sender, EventArgs e)
        {
            sConn.Close();
            StatusLabel1.Text = "Database Closed.";
            StatusLabel1.BackColor = Color.Gray;
        }

        private void StatusCombo_Click(object sender, EventArgs e)
        {

        }

        // 함수 일반화 #n
        // 함수명 : void RunSql(string sql)
        // 인수 : string sql : 조회값이 없는 SQL 명령어 (Insert, Update, delete)
        //                    Select 문을 포함한 SQL 문.
        // 리턴값 : void       select * from [table_name]  SELECT Select sElect
        public void RunSql(string sql)
        {
            try
            {   // 첫번째 단어 분리하고 소문자로 변환 
                string s1 = GetToken(0, sql, " ").ToLower();  // 
                sCmd.CommandText = sql;
                if(s1 != "select")
                {
                    sCmd.ExecuteNonQuery();     // 조회값이 없는 SQL 명령어 수행
                }
                else  // Select 문일 경우 조회된 데이터를 GridView에 표시
                {
                    int i, j, k;
                    SqlDataReader sr = sCmd.ExecuteReader();
                    for(i=0;i<sr.FieldCount;i++)
                    {
                        dataGridView1.Columns.Add(sr.GetName(i), sr.GetName(i));
                    }
                    for(i=0;sr.Read();i++)    // Row index
                    {
                        dataGridView1.Rows.Add();
                        for(j=0;j<sr.FieldCount;j++)  // column index
                        {
                            dataGridView1.Rows[i].Cells[j].Value = sr.GetValue(j);
                        }
                    }
                }
                StatusLabel2.Text = "Sucess.";
                StatusLabel2.BackColor = Color.Blue;
            }
            catch(Exception e1)
            {
                StatusLabel2.Text = e1.Message;
                StatusLabel2.BackColor = Color.Red;
            }
        }

        private void mnuTestCmd1_Click(object sender, EventArgs e)
        {
//            string sTime = GetToken(0,DateTime.Now.Date.ToString()," ");   // " 2020-11-03 오전 11:46:00"
            string sTime = $"{DateTime.Now:s}";   // " 2020-11-03 오전 11:46:00"  : Locale : 지역화 <> Global
            string str = $"insert into fStatus values ('10001','10.50','50.00','02.00','{sTime}')"; // SQL Insert 문
            RunSql(str);
        }                             

        private void mnuTestCmd2_Click(object sender, EventArgs e)
        {
            string sTime = GetToken(0,DateTime.Now.Date.ToString()," ");
            string str = $"insert into fStatus (fcode,temp,hum,wind) values ('10002','10.50','50.00','02.00')"; // SQL Insert 문
            RunSql(str);
        }

        private void mnuTestCmd3_Click(object sender, EventArgs e)
        {
            RunSql("select * from facility");
        }
    }
}
