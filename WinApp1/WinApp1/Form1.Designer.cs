namespace WinApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PopupMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDBUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDBOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDBClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.종료XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.편집EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestCmd1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestCmd2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTestCmd3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbSql = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.stCombo1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.StatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.PopupMenu2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExcuteSql = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveTable = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PopupMenu1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PopupMenu2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.PopupMenu1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(730, 211);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            // 
            // PopupMenu1
            // 
            this.PopupMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PopupMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddColumn,
            this.mnuAddRow,
            this.toolStripMenuItem3,
            this.mnuDBUpdate,
            this.mnuSaveTable});
            this.PopupMenu1.Name = "PopupMenu1";
            this.PopupMenu1.Size = new System.Drawing.Size(211, 134);
            // 
            // mnuAddColumn
            // 
            this.mnuAddColumn.Name = "mnuAddColumn";
            this.mnuAddColumn.Size = new System.Drawing.Size(210, 24);
            this.mnuAddColumn.Text = "Column 추가";
            this.mnuAddColumn.Click += new System.EventHandler(this.mnuAddColumn_Click);
            // 
            // mnuAddRow
            // 
            this.mnuAddRow.Name = "mnuAddRow";
            this.mnuAddRow.Size = new System.Drawing.Size(210, 24);
            this.mnuAddRow.Text = "Row 추가";
            this.mnuAddRow.Click += new System.EventHandler(this.mnuAddRow_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(207, 6);
            // 
            // mnuDBUpdate
            // 
            this.mnuDBUpdate.Name = "mnuDBUpdate";
            this.mnuDBUpdate.Size = new System.Drawing.Size(210, 24);
            this.mnuDBUpdate.Text = "DB Update";
            this.mnuDBUpdate.Click += new System.EventHandler(this.mnuDBUpdate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.편집EToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(736, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDBOpen,
            this.mnuDBClose,
            this.toolStripMenuItem1,
            this.종료XToolStripMenuItem});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.파일FToolStripMenuItem.Text = "파일(F)";
            // 
            // mnuDBOpen
            // 
            this.mnuDBOpen.Name = "mnuDBOpen";
            this.mnuDBOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuDBOpen.Size = new System.Drawing.Size(254, 26);
            this.mnuDBOpen.Text = "Database Open";
            this.mnuDBOpen.Click += new System.EventHandler(this.mnuDBOpen_Click);
            // 
            // mnuDBClose
            // 
            this.mnuDBClose.Name = "mnuDBClose";
            this.mnuDBClose.Size = new System.Drawing.Size(254, 26);
            this.mnuDBClose.Text = "Database Close";
            this.mnuDBClose.Click += new System.EventHandler(this.mnuDBClose_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(251, 6);
            // 
            // 종료XToolStripMenuItem
            // 
            this.종료XToolStripMenuItem.Name = "종료XToolStripMenuItem";
            this.종료XToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.종료XToolStripMenuItem.Text = "종료(X)";
            // 
            // 편집EToolStripMenuItem
            // 
            this.편집EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTestCmd1,
            this.mnuTestCmd2,
            this.toolStripMenuItem2,
            this.mnuTestCmd3,
            this.toolStripMenuItem4});
            this.편집EToolStripMenuItem.Name = "편집EToolStripMenuItem";
            this.편집EToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.편집EToolStripMenuItem.Text = "편집(E)";
            // 
            // mnuTestCmd1
            // 
            this.mnuTestCmd1.Name = "mnuTestCmd1";
            this.mnuTestCmd1.Size = new System.Drawing.Size(224, 26);
            this.mnuTestCmd1.Text = "Test 명령 1";
            this.mnuTestCmd1.Click += new System.EventHandler(this.mnuTestCmd1_Click);
            // 
            // mnuTestCmd2
            // 
            this.mnuTestCmd2.Name = "mnuTestCmd2";
            this.mnuTestCmd2.Size = new System.Drawing.Size(224, 26);
            this.mnuTestCmd2.Text = "Test 명령 2";
            this.mnuTestCmd2.Click += new System.EventHandler(this.mnuTestCmd2_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuTestCmd3
            // 
            this.mnuTestCmd3.Name = "mnuTestCmd3";
            this.mnuTestCmd3.Size = new System.Drawing.Size(224, 26);
            this.mnuTestCmd3.Text = "Test 명령 3";
            this.mnuTestCmd3.Click += new System.EventHandler(this.mnuTestCmd3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(221, 6);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel1,
            this.stCombo1,
            this.StatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 373);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(736, 30);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(134, 24);
            this.StatusLabel1.Text = "SQL Database file";
            // 
            // tbSql
            // 
            this.tbSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSql.ContextMenuStrip = this.PopupMenu2;
            this.tbSql.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSql.Location = new System.Drawing.Point(3, 3);
            this.tbSql.Multiline = true;
            this.tbSql.Name = "tbSql";
            this.tbSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSql.Size = new System.Drawing.Size(730, 112);
            this.tbSql.TabIndex = 6;
            this.tbSql.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSql_KeyPress);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbSql);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(736, 339);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.TabIndex = 7;
            // 
            // stCombo1
            // 
            this.stCombo1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stCombo1.Image = ((System.Drawing.Image)(resources.GetObject("stCombo1.Image")));
            this.stCombo1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stCombo1.Name = "stCombo1";
            this.stCombo1.Size = new System.Drawing.Size(75, 28);
            this.stCombo1.Text = "Tables...";
            this.stCombo1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.stCombo1_DropDownItemClicked);
            // 
            // StatusLabel3
            // 
            this.StatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.StatusLabel3.Name = "StatusLabel3";
            this.StatusLabel3.Size = new System.Drawing.Size(102, 24);
            this.StatusLabel3.Text = "Sql message...";
            // 
            // PopupMenu2
            // 
            this.PopupMenu2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PopupMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExcuteSql});
            this.PopupMenu2.Name = "PopupMenu2";
            this.PopupMenu2.Size = new System.Drawing.Size(156, 28);
            // 
            // mnuExcuteSql
            // 
            this.mnuExcuteSql.Name = "mnuExcuteSql";
            this.mnuExcuteSql.Size = new System.Drawing.Size(155, 24);
            this.mnuExcuteSql.Text = "SQL문 실행";
            this.mnuExcuteSql.Click += new System.EventHandler(this.mnuExcuteSql_Click);
            // 
            // mnuSaveTable
            // 
            this.mnuSaveTable.Name = "mnuSaveTable";
            this.mnuSaveTable.Size = new System.Drawing.Size(210, 24);
            this.mnuSaveTable.Text = "Table 저장";
            this.mnuSaveTable.Click += new System.EventHandler(this.mnuSaveTable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 403);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PopupMenu1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.PopupMenu2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip PopupMenu1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddColumn;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDBOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuDBClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 종료XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 편집EToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1;
        private System.Windows.Forms.TextBox tbSql;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem mnuTestCmd1;
        private System.Windows.Forms.ToolStripMenuItem mnuTestCmd2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuTestCmd3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuDBUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripDropDownButton stCombo1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel3;
        private System.Windows.Forms.ContextMenuStrip PopupMenu2;
        private System.Windows.Forms.ToolStripMenuItem mnuExcuteSql;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveTable;
    }
}

