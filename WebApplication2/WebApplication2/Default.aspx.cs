using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bn\source\repos\MyTable.mdf;Integrated Security=True;Connect Timeout=30";

        public string GetDBData(string tn, string kfn, string kfv, string rfn)
        {
            string sql = $"select {rfn} from {tn} where {kfn}='{kfv}'";
            sCmd.CommandText = sql;
            object o = sCmd.ExecuteScalar();  // 1 Record, 1 field
            if (o == null) return null;
            string sRet = (string)o;
            return sRet.Trim();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            sConn.ConnectionString = ConnectionString;
            sConn.Open();
            sCmd.Connection = sConn;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {   // Login button Click Event
            string s1 = TextBox1.Text;  // ID
            string s2 = TextBox2.Text;  // Passwd

            string s3 = GetDBData("members", "uid", s1, "passwd");

            if(s2 == s3)
                lblMessage.Text = $"{s1}님 반갑습니다.";
            else if(s3 == null)  // passwd 부존재 : 미가입 사용자
            {
                lblMessage.Text = "존재하지 않는 사용자입니다. 먼저 회원가입을 해 주세요.";
                Button3.Visible = true;
            }
            else // passwd 오류
            {
                lblMessage.Text = "패스워드가 틀렸습니다. 다시 입력해 주세요.";
                Button3.Visible = false;
            }
        }

        //protected void Button3_Click(object sender, EventArgs e)
        //{

        //}
    }
}