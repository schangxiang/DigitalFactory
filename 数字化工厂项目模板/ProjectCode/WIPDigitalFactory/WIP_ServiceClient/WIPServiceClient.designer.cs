namespace WIP_ServiceClient
{
    partial class WIPServiceClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIPServiceClient));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnOpenService = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ServiceList = new System.Windows.Forms.DataGridView();
            this.ServiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbRealTimeNote = new System.Windows.Forms.ListBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUninstall);
            this.groupBox1.Controls.Add(this.btnInstall);
            this.groupBox1.Controls.Add(this.btnViewLog);
            this.groupBox1.Controls.Add(this.btnStopService);
            this.groupBox1.Controls.Add(this.btnOpenService);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工具栏";
            // 
            // btnUninstall
            // 
            this.btnUninstall.BackColor = System.Drawing.Color.Red;
            this.btnUninstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUninstall.ForeColor = System.Drawing.Color.White;
            this.btnUninstall.Location = new System.Drawing.Point(420, 20);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(103, 47);
            this.btnUninstall.TabIndex = 5;
            this.btnUninstall.Text = "卸载服务";
            this.btnUninstall.UseVisualStyleBackColor = false;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.BackColor = System.Drawing.Color.Cyan;
            this.btnInstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstall.ForeColor = System.Drawing.Color.Black;
            this.btnInstall.Location = new System.Drawing.Point(286, 20);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(103, 47);
            this.btnInstall.TabIndex = 4;
            this.btnInstall.Text = "安装服务";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnViewLog
            // 
            this.btnViewLog.BackColor = System.Drawing.Color.Blue;
            this.btnViewLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewLog.ForeColor = System.Drawing.Color.White;
            this.btnViewLog.Location = new System.Drawing.Point(559, 20);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(103, 47);
            this.btnViewLog.TabIndex = 3;
            this.btnViewLog.Text = "浏览日志";
            this.btnViewLog.UseVisualStyleBackColor = false;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.BackColor = System.Drawing.Color.Red;
            this.btnStopService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopService.ForeColor = System.Drawing.Color.White;
            this.btnStopService.Location = new System.Drawing.Point(153, 20);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(103, 47);
            this.btnStopService.TabIndex = 2;
            this.btnStopService.Text = "关闭服务";
            this.btnStopService.UseVisualStyleBackColor = false;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnOpenService
            // 
            this.btnOpenService.BackColor = System.Drawing.Color.Aqua;
            this.btnOpenService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenService.ForeColor = System.Drawing.Color.Black;
            this.btnOpenService.Location = new System.Drawing.Point(22, 20);
            this.btnOpenService.Name = "btnOpenService";
            this.btnOpenService.Size = new System.Drawing.Size(103, 47);
            this.btnOpenService.TabIndex = 1;
            this.btnOpenService.Text = "开启服务";
            this.btnOpenService.UseVisualStyleBackColor = false;
            this.btnOpenService.Click += new System.EventHandler(this.btnOpenService_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(900, 414);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实时日志";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ServiceList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbRealTimeNote);
            this.splitContainer1.Size = new System.Drawing.Size(894, 394);
            this.splitContainer1.SplitterDistance = 419;
            this.splitContainer1.TabIndex = 1;
            // 
            // ServiceList
            // 
            this.ServiceList.AllowUserToAddRows = false;
            this.ServiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceCode,
            this.ServiceName,
            this.ServiceState,
            this.ServicePath});
            this.ServiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceList.Location = new System.Drawing.Point(0, 0);
            this.ServiceList.Name = "ServiceList";
            this.ServiceList.ReadOnly = true;
            this.ServiceList.RowTemplate.Height = 23;
            this.ServiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServiceList.Size = new System.Drawing.Size(419, 394);
            this.ServiceList.TabIndex = 0;
            this.ServiceList.Click += new System.EventHandler(this.ServiceList_Click);
            // 
            // ServiceCode
            // 
            this.ServiceCode.DataPropertyName = "ServiceCode";
            this.ServiceCode.HeaderText = "服务代码";
            this.ServiceCode.Name = "ServiceCode";
            this.ServiceCode.ReadOnly = true;
            // 
            // ServiceName
            // 
            this.ServiceName.DataPropertyName = "ServiceName";
            this.ServiceName.HeaderText = "服务名称";
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.ReadOnly = true;
            this.ServiceName.Width = 175;
            // 
            // ServiceState
            // 
            this.ServiceState.DataPropertyName = "ServiceState";
            this.ServiceState.HeaderText = "服务状态";
            this.ServiceState.Name = "ServiceState";
            this.ServiceState.ReadOnly = true;
            // 
            // ServicePath
            // 
            this.ServicePath.DataPropertyName = "ServicePath";
            this.ServicePath.HeaderText = "服务地址";
            this.ServicePath.Name = "ServicePath";
            this.ServicePath.ReadOnly = true;
            this.ServicePath.Visible = false;
            // 
            // lbRealTimeNote
            // 
            this.lbRealTimeNote.BackColor = System.Drawing.Color.Black;
            this.lbRealTimeNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRealTimeNote.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRealTimeNote.ForeColor = System.Drawing.Color.Lime;
            this.lbRealTimeNote.FormattingEnabled = true;
            this.lbRealTimeNote.ItemHeight = 14;
            this.lbRealTimeNote.Location = new System.Drawing.Point(0, 0);
            this.lbRealTimeNote.Name = "lbRealTimeNote";
            this.lbRealTimeNote.Size = new System.Drawing.Size(471, 394);
            this.lbRealTimeNote.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "WIP服务";
            this.notifyIcon1.Visible = true;
            // 
            // WIPServiceClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 495);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WIPServiceClient";
            this.ShowInTaskbar = false;
            this.Text = "WIP服务管理";
            this.Load += new System.EventHandler(this.FrmTCVMCClient_Load);
            this.SizeChanged += new System.EventHandler(this.FrmTCVMCClient_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnOpenService;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbRealTimeNote;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView ServiceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicePath;

    }
}

