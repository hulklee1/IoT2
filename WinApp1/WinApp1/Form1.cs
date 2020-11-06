using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            frmInput dlg = new frmInput("Column Name");
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string str = dlg.sRet;
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

                    StatusLabel1.Text = openFileDialog1.SafeFileName;  // 경로를 제외한 파일명  "Database Opened.";
                    StatusLabel1.BackColor = Color.Green;

                    RefreshTable();
                    //DataTable dt = sConn.GetSchema("Tables");
                    //for(int i=0;i<dt.Rows.Count;i++)
                    //{
                    //    string str = dt.Rows[i].ItemArray[2].ToString(); // 2번째 배열요소가 Table 이름
                    //    tbSql.Text += str + "\r\n";
                    //    stCombo1.DropDownItems.Add(str);    //sComboBox1.Items.Add(str);
                    //    stCombo1.Text = str;
                    //}    
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
            // TODO: 이 코드는 데이터를 'myTableDataSet.facility' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.facilityTableAdapter.Fill(this.myTableDataSet.facility);

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
                {   // select * from [TABLE_NAME]
                    int i, j, k;

                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    string s2 = GetToken(1, sql, " ");  // Column명이 '*' 인지를 판단
                    if (s2 == "*")
                    {
                        stCombo1.Text = GetToken(3, sql, " ");
                    }
                    else stCombo1.Text = "";

                    SqlDataReader sr = sCmd.ExecuteReader();
                    for(i=0;i<sr.FieldCount;i++)
                    {
                        dataGridView1.Columns.Add(sr.GetName(i), sr.GetName(i));
                    }
                    for(i=0;sr.Read();i++)    // Row index
                    {
                        dataGridView1.Rows.Add();   // RowHeader에 '.' 생성됨
                        for(j=0;j<sr.FieldCount;j++)  // column index
                        {
                            dataGridView1.Rows[i].Cells[j].Value = sr.GetValue(j).ToString().Trim();
                        }
//                        dataGridView1.Rows[dataGridView1.RowCount - 1].HeaderCell.Value = "";   // RowHeader에 '.' 생성됨
                        dataGridView1.Rows[i].HeaderCell.Value = "";   // RowHeader에 '.' 생성됨
                    }
                    sr.Close();
                }
                StatusLabel3.Text = "Sucess.";
                StatusLabel3.BackColor = Color.Blue;
            }
            catch(Exception e1)
            {
                StatusLabel3.Text = e1.Message;
                StatusLabel3.BackColor = Color.Red;
            }
        }

        private void mnuTestCmd1_Click(object sender, EventArgs e)
        {
//            string sTime = GetToken(0,DateTime.Now.Date.ToString()," ");   // " 2020-11-03 오전 11:46:00"
            string sTime = $"{DateTime.Now:s}";   // " 2020-11-03 오전 11:46:00"  : Locale : 지역화 <> Global
            string str = $"insert into fStatus values ('10001','10.50','50.00','02.00',N'{sTime}')"; // SQL Insert 문
            RunSql(mnuTestString1);
        }
        string mnuTestString1;
        private void mnuTestCmd1_MouseHover(object sender, EventArgs e)
        {
            frmInput dlg = new frmInput("");
            if(dlg.ShowDialog() == DialogResult.OK) 
                mnuTestString1 = dlg.sRet;
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
            stCombo1.Text = "facility";
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int x = e.ColumnIndex;
            int y = e.RowIndex;
            dataGridView1.Rows[y].Cells[x].ToolTipText = ".";
            string sHeader = dataGridView1.Columns[x].HeaderText;  // Field 명
        }

        private void mnuDBUpdate_Click(object sender, EventArgs e)
        {   // update [Table_name] set [Field_name]='[Cell_Value]' where [ID] = [ID_VALUE]
            int i, j, k;

            for(i=0;i<dataGridView1.RowCount;i++)  // Row indexing
            {
                for(j=0;j<dataGridView1.ColumnCount;j++)   // Column indexing
                {
                    if(dataGridView1.Rows[i].Cells[j].ToolTipText == ".")  // Update cell
                    {
                        string tn = stCombo1.Text;      //  Table_Name
                        string fn = dataGridView1.Columns[j].HeaderText;   // Field_Name
                        string cv = (string)dataGridView1.Rows[i].Cells[j].Value;   // Cell Value
                        string iv = dataGridView1.Columns[0].HeaderText;   // ID Field
                        string jv = (string)dataGridView1.Rows[i].Cells[0].Value;   // ID Value
                        string sql = $"update {tn} set {fn}=N'{cv}' where {iv}='{jv}'";
                        RunSql(sql);
                        dataGridView1.Rows[i].Cells[j].ToolTipText = "";
                    }
                }
            }
        }

        private void stCombo1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string str = e.ClickedItem.Text;  // Table 명
            stCombo1.Text = str;
            RunSql($"Select * from {str}");
        }

        string[] sSqlCMDs = { "select", "insert", "update", "delete", "Create", "alter" };
        private void tbSql_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                string str = tbSql.Text.Trim();
                // 마지막 문장 (ENTER KEY 입력기준) 추출
                // [ENTER] key value : '\r' CR(carrage return)  + 
                // 실제 Text에는 '\r\n' ('\n'이 추가됨)
                // Solution : '\r' 값을 구분자로 하는 GetToken 기법 사용
                string[] bStr = str.Split('\r');
                string Result = bStr.Last().Trim();  // white-space 제거
                string s1 = GetToken(0, Result, " ").ToLower();
                //string s2 = Array.Find(sSqlCMDs, s => s == s1);
                //if(s1 == "select" || s1 == "insert" || s1 == "update" || s1 == "delete" || s1 == "Create" || s1 == "alter")
                if(Array.IndexOf(sSqlCMDs,s1) != -1)
                    RunSql(Result);
            }
        }

        private void mnuExcuteSql_Click(object sender, EventArgs e)
        {
            string str = tbSql.SelectedText;
            RunSql(str);
        }

        private void mnuSaveTable_Click(object sender, EventArgs e)
        {
            int i, j, k;
            string sTable = stCombo1.Text;
            if(sTable == "")    // Table 명이 없으므로 새로운 Table 생성
            {   // cleate table [TABLE_NAME] ( [COL_NAME] nchar(20),
                frmInput dlg = new frmInput("");
                dlg.ShowDialog();
                sTable = dlg.sRet;
                string sql = $"create table {sTable} (";
                for(i=0;i<dataGridView1.Columns.Count;i++)
                {
                    string s1 = dataGridView1.Columns[i].HeaderText; //id
                    string sCol = $"{s1} nchar(20)";
                    if (i < dataGridView1.Columns.Count - 1) sCol += ",";
                    sql += sCol;
                }
                sql += ")";
                RunSql(sql);

                for(i=0;i<dataGridView1.RowCount-1;i++)
                {
                    sql = $"insert into {sTable} values (";
                    for(j=0;j<dataGridView1.ColumnCount;j++)
                    {
                        sql += $"'{dataGridView1.Rows[i].Cells[j].Value}'";
                        if (j < dataGridView1.ColumnCount - 1) sql += ",";
                    }
                    sql += ")";
                    RunSql(sql);
                }
            }
            else  // 기존 테이블이 있는 경우 Update
            {
                for (i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    for (j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].ToolTipText = ".";
                    }
                }
                mnuDBUpdate_Click(sender, e);
            }
        }

        private void RefreshTable()
        {
            stCombo1.DropDownItems.Clear();  // 기존 Items 삭제 - 초기화
            DataTable dt = sConn.GetSchema("Tables");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = dt.Rows[i].ItemArray[2].ToString(); // 2번째 배열요소가 Table 이름
                //tbSql.Text += str + "\r\n";
                stCombo1.DropDownItems.Add(str);    //sComboBox1.Items.Add(str);
                //stCombo1.Text = str;
            }
        }

        private void RefreshTable(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int n = e.RowIndex;
            dataGridView1.Rows[n].HeaderCell.Value = ".";
        }

        private void mnuDBInsert_Click(object sender, EventArgs e)
        {   // Insert into [TABLE_NAME] values ('[F1]','[F2]'...)
            int i, j;

            for (i = 0; i < dataGridView1.RowCount - 1; i++)  // Row indexing
            {
                if ((string)dataGridView1.Rows[i].HeaderCell.Value == ".")  // Update cell
                {
                    string sql = $"Insert into {stCombo1.Text} values (";
                    for (j = 0; j < dataGridView1.ColumnCount; j++)   // Column indexing
                    {
                        string cv = (string)dataGridView1.Rows[i].Cells[j].Value;   // Cell Value
                        sql += $"N'{cv}'";
                        if(j<dataGridView1.ColumnCount-1) sql += ",";
                    }
                    sql += ")";
                    RunSql(sql);
                    dataGridView1.Rows[i].HeaderCell.Value = "";
                }
            }
        }

        private void mnuDBDelete_Click(object sender, EventArgs e)
        {   // Delete [Table_Name] where [Col_Name] = '[Col_Value]'
            int y = dataGridView1.SelectedCells[0].RowIndex;
            string tn = stCombo1.Text;
            if(tn != "")
            {
                string cn = dataGridView1.Columns[0].HeaderText;
                string cv = (string)dataGridView1.Rows[y].Cells[0].Value;
                string sql = $"Delete {tn} where {cn}='{cv}'";
                RunSql(sql);
            }
        }

        private void mnuCSVImport_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {   // Stream
                int i, j, k;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                StreamReader sr = new StreamReader(openFileDialog1.FileName,Encoding.Default);
           //     StreamWriter sw = new StreamWriter(....)
                string str = sr.ReadLine();  // 컬럼 정의 라인 Read
                string[] sCols = str.Split(',');    // ',' 로 구분된 컬럼명을 문자열 배열로 분할
                for (i = 0; i < sCols.Length; i++)
                    dataGridView1.Columns.Add(sCols[i],sCols[i]);
                
                for(i = 0;;i++)
                {
                    str = sr.ReadLine();  // 1라인을 읽고 셀로 분할
                    if (str == null) break;

                    dataGridView1.Rows.Add();
                    for(j=0;j<sCols.Length;j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = GetToken(j, str, ",");
                    }
                }
                sr.Close();
            }
        }

        private void mnuCSVExport_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int i, j, k;
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName,false,Encoding.Default);
                string str = "";
                for(i=0;i<dataGridView1.ColumnCount;i++) // Header Line 작성
                {
                    str += dataGridView1.Columns[i].HeaderText;
                    if (i < dataGridView1.ColumnCount - 1) str += ",";
                }
                sw.WriteLine(str);

                for(i=0;i<dataGridView1.RowCount-1;i++)
                {
                    str = "";
                    for(j=0;j<dataGridView1.ColumnCount;j++) // Header Line 작성
                    {
                        str += (string)dataGridView1.Rows[i].Cells[j].Value;
                        if (j < dataGridView1.ColumnCount - 1) str += ",";
                    }
                    sw.WriteLine(str);
                }
                sw.Close();
            }
        }
    }
}
