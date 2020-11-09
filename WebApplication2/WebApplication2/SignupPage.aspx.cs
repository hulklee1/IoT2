using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class SignupPage : System.Web.UI.Page
    {
        SqlConnection sConn = new SqlConnection();
        SqlCommand sCmd = new SqlCommand();
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bn\source\repos\MyTable.mdf;Integrated Security=True;Connect Timeout=30";

        // 함수 정의 : string GetDBData(...)
        // 인수 : string Table_Name : 테이블 명
        //        string Key_fiele_Name : Key Field 명
        //        string Key_field_Value : Key Field의 값
        //        string Read_Field_Name : 읽어 올 Field 명
        // sql : select [R_F_N] from [T_N] where [K_F_N]=[K_F_V]
        // 리턴값 : string :DB에서의 조회 결과 값
        public string GetDBData(string tn,string kfn, string kfv, string rfn)
        {
            string sql = $"select {rfn} from {tn} where {kfn}='{kfv}'";
            sCmd.CommandText = sql;
            string sRet = (string)sCmd.ExecuteScalar();  // 1 Record, 1 field
            return sRet;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            sConn.ConnectionString = ConnectionString;
            sConn.Open();
            sCmd.Connection = sConn;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s1 = TextBox1.Text;  // 이름
            string s2 = TextBox2.Text;  // UID
            string s3 = TextBox3.Text;  // Passwd

            string str = GetDBData("Members", "Uid", s2, "Name"); 
                       // "Members" 테이블에서 "Uid"=s2 인 사람의 "Name"을 검색하시오
            if(str == "" || str == null)
            {
                string sql = $"insert into members (Name,uid,passwd) values (N'{s1}','{s2}','{s3}')";
                sCmd.CommandText = sql;
                sCmd.ExecuteNonQuery();
                Label1.Text = "가입을 축하합니다.";
            }
            else
            {
                string sql = $"update members set Name=N'{s1}',passwd='{s3}' where uid='{s2}'";
                sCmd.CommandText = sql;
                sCmd.ExecuteNonQuery();
                Label1.Text = "가입 정보가 수정되었습니다.";
            }
        }
    }
}