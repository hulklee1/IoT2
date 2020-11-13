namespace WinChatting
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PopupMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSend1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbClient = new System.Windows.Forms.TextBox();
            this.PopupClient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuClientStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientStop = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PopupMain.SuspendLayout();
            this.PopupClient.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.ContextMenuStrip = this.PopupMain;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbServer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbClient);
            this.splitContainer1.Size = new System.Drawing.Size(480, 318);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 0;
            // 
            // PopupMain
            // 
            this.PopupMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PopupMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuServerStop,
            this.toolStripMenuItem1,
            this.mnuSetup,
            this.toolStripMenuItem2,
            this.종료ToolStripMenuItem,
            this.mnuSend1});
            this.PopupMain.Name = "PopupMain";
            this.PopupMain.Size = new System.Drawing.Size(209, 136);
            // 
            // mnuStart
            // 
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.mnuStart.Size = new System.Drawing.Size(208, 24);
            this.mnuStart.Text = "Server 시작";
            this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // mnuServerStop
            // 
            this.mnuServerStop.Name = "mnuServerStop";
            this.mnuServerStop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.mnuServerStop.Size = new System.Drawing.Size(208, 24);
            this.mnuServerStop.Text = "Server Stop ";
            this.mnuServerStop.Click += new System.EventHandler(this.mnuServerStop_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 6);
            // 
            // mnuSetup
            // 
            this.mnuSetup.Name = "mnuSetup";
            this.mnuSetup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.mnuSetup.Size = new System.Drawing.Size(208, 24);
            this.mnuSetup.Text = "Setup";
            this.mnuSetup.Click += new System.EventHandler(this.mnuSetup_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(205, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.종료ToolStripMenuItem.Text = "종료";
            // 
            // mnuSend1
            // 
            this.mnuSend1.Name = "mnuSend1";
            this.mnuSend1.Size = new System.Drawing.Size(208, 24);
            this.mnuSend1.Text = "선택된 메시지 전송";
            this.mnuSend1.Click += new System.EventHandler(this.mnuSend1_Click);
            // 
            // tbServer
            // 
            this.tbServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServer.ContextMenuStrip = this.PopupMain;
            this.tbServer.Location = new System.Drawing.Point(3, 0);
            this.tbServer.Multiline = true;
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(223, 315);
            this.tbServer.TabIndex = 0;
            this.tbServer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServer_KeyPress);
            // 
            // tbClient
            // 
            this.tbClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbClient.ContextMenuStrip = this.PopupClient;
            this.tbClient.Location = new System.Drawing.Point(3, 0);
            this.tbClient.Multiline = true;
            this.tbClient.Name = "tbClient";
            this.tbClient.Size = new System.Drawing.Size(241, 315);
            this.tbClient.TabIndex = 0;
            this.tbClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbClient_KeyPress);
            // 
            // PopupClient
            // 
            this.PopupClient.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PopupClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClientStart,
            this.mnuClientStop});
            this.PopupClient.Name = "PopupClient";
            this.PopupClient.Size = new System.Drawing.Size(144, 52);
            // 
            // mnuClientStart
            // 
            this.mnuClientStart.Name = "mnuClientStart";
            this.mnuClientStart.Size = new System.Drawing.Size(143, 24);
            this.mnuClientStart.Text = "접속 요청";
            this.mnuClientStart.Click += new System.EventHandler(this.mnuClientStart_Click);
            // 
            // mnuClientStop
            // 
            this.mnuClientStop.Name = "mnuClientStop";
            this.mnuClientStop.Size = new System.Drawing.Size(143, 24);
            this.mnuClientStop.Text = "접속 종료";
            this.mnuClientStop.Click += new System.EventHandler(this.mnuClientStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel1,
            this.StatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 323);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(482, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(152, 20);
            this.StatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // StatusLabel2
            // 
            this.StatusLabel2.Name = "StatusLabel2";
            this.StatusLabel2.Size = new System.Drawing.Size(152, 20);
            this.StatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 349);
            this.ContextMenuStrip = this.PopupMain;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Cocoa ver.2.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.PopupMain.ResumeLayout(false);
            this.PopupClient.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip PopupMain;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuServerStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuSetup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbClient;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem mnuSend1;
        private System.Windows.Forms.ContextMenuStrip PopupClient;
        private System.Windows.Forms.ToolStripMenuItem mnuClientStart;
        private System.Windows.Forms.ToolStripMenuItem mnuClientStop;
    }
}

