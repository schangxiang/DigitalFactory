using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;
using System.Configuration;

namespace WIP_ServiceClient
{
    /// <summary>
    /// 概要描述
    /// </summary>
    public partial class WIPServiceClient : Form
    {
        #region 变量

        /// <summary>
        /// 当前打开日志路径
        /// </summary>
        private string strCurrentPath = "";

        /// <summary>
        /// 监听日志委托
        /// </summary>
        /// <param name="strMessage"></param>
        public delegate void ListenNoteDelegate(string strMessage);
        public ListenNoteDelegate addMessage;

        /// <summary>
        /// 读取日志文件的线程
        /// </summary>
        Thread readThread = null;

        ///获取服务地址
        string ServerPath = string.Empty;
        ///获取服务代码
        string ServerCode = string.Empty;
        ///获取服务名称
        string ServerName = string.Empty;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WIPServiceClient()
        {
            InitializeComponent();
        }
        #endregion

        #region 自定义函数

        #region 判断window服务是否启动
        /// <summary>  
        /// 判断Windows服务是否启动  
        /// </summary>  
        /// <returns></returns>  
        private bool IsServiceStart()
        {
            ////定义返回值
            bool bStartStatus = false;
            try
            {
                ////判断是否服务启动状态
                if (Windows.IsRunning(ServerCode))
                {
                    bStartStatus = true;
                }

                ////根据是否开启服务设置按钮权限
                if (bStartStatus)
                {
                    this.btnOpenService.Enabled = false;
                    this.btnStopService.Enabled = true;
                }
                else
                {
                    this.btnOpenService.Enabled = true;
                    this.btnStopService.Enabled = false;
                }

                ////返回服务状态
                return bStartStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 加载服务
        /// <summary>
        /// 加载服务
        /// </summary>
        private void LoadServerData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ServiceCode", typeof(string));
                dt.Columns.Add("ServiceName", typeof(string));
                dt.Columns.Add("ServiceState", typeof(string));
                dt.Columns.Add("ServicePath", typeof(string));

                #region 加载基础服务
                ServiceSection serviceSection=ServiceSection.GetConfig();
                foreach (TheKeyValue item in serviceSection.KeyValues)
                {
                    DataRow tbsRow = dt.NewRow();
                    tbsRow["ServiceCode"] = item.Name;
                    tbsRow["ServiceName"] =item.Text;
                    tbsRow["ServicePath"] = Application.StartupPath + item.Path;
                    if (Windows.isServiceIsExisted(item.Name))
                    {
                        ////判断是否服务启动状态
                        if (Windows.IsRunning(item.Name))
                        {
                            tbsRow["ServiceState"] = "服务正在运行";
                        }
                        else
                        {
                            tbsRow["ServiceState"] = "服务已停止";
                        }
                    }
                    else
                    {
                        tbsRow["ServiceState"] = "服务已卸载";
                    }
                    dt.Rows.Add(tbsRow);
                }
                //绑定数据
                ServiceList.DataSource = dt;
                #endregion




                #region 格式化一下行颜色
                for (int i = 0; i < ServiceList.RowCount; i++)
                {
                    switch (ServiceList.Rows[i].Cells["ServiceState"].Value.ToString())
                    {
                        case "服务正在运行":
                            ServiceList.Rows[i].DefaultCellStyle.BackColor = btnOpenService.BackColor;
                            break;
                        case "服务已停止":
                        case "服务已卸载":
                            ServiceList.Rows[i].DefaultCellStyle.BackColor = btnUninstall.BackColor;
                            break;
                        default:
                            break;
                    }
                }
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #endregion

        #region 自定义事件

        #region 初始化事件
        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTCVMCClient_Load(object sender, EventArgs e)
        {
            LoadServerData();
            ////初始化任务栏图标
            string icon = Directory.GetCurrentDirectory() + "\\Service.ico";
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            notifyIcon1.Icon = new Icon(icon);//指定一个图标      
            notifyIcon1.Visible = false;
            //notifyIcon1.MouseMove += notifyIcon1_MouseMove;
            notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            addMessage = new ListenNoteDelegate(ListenNote);

        }



        #endregion

        #region 开启服务
        /// <summary>
        /// 开启服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenService_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要开启"+ ServerName + "服务？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (Windows.StarmyService(ServerCode))//启动服务
                    {
                        if (Windows.IsRunning(ServerCode))//检查服务是否在运行
                        {
                            ////把日志文件展示在列表中
                            MessageBox.Show("开启" + ServerName + "成功！");
                            this.Invoke(addMessage, "开启" + ServerName + "成功！");
                            //更改服务状态
                            ServiceList.CurrentRow.Cells["ServiceState"].Value = "服务正在运行";
                            //设置一下按钮权限
                            ServiceList_Click(null, null);
                            return;
                        }
                        else
                        {
                            ////把日志文件展示在列表中
                            MessageBox.Show("开启" + ServerName + "成功！");
                            this.Invoke(addMessage, "开启" + ServerName + "成功！");
                            //设置一下按钮权限
                            IsServiceStart();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ////把日志文件展示在列表中
                MessageBox.Show("开启" + ServerName + "异常:" + ex.Message);
                this.Invoke(addMessage, "开启" + ServerName + "异常:" + ex.Message);
            }

        }
        #endregion

        #region 关闭服务
        /// <summary>
        /// 关闭服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopService_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定关闭"+ ServerName + "服务？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (Windows.StopService(ServerCode))
                    {

                        if (Windows.IsRunning(ServerCode))//检查服务是否运行
                        {
                            MessageBox.Show("关闭" + ServerName + "失败！");
                            ////把日志文件展示在列表中
                            this.Invoke(addMessage, "关闭" + ServerName + "失败！");
                            return;
                        }
                        else
                        {
                            ////把日志文件展示在列表中
                            MessageBox.Show("关闭" + ServerName + "成功！");
                            this.Invoke(addMessage, "关闭" + ServerName + "成功！");
                            //更改服务状态
                            ServiceList.CurrentRow.Cells["ServiceState"].Value = "服务已停止";
                            //设置一下按钮权限
                            ServiceList_Click(null, null);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ////把日志文件展示在列表中
                MessageBox.Show("关闭" + ServerName + "异常:" + ex.Message);
                this.Invoke(addMessage, "关闭" + ServerName + "异常:" + ex.Message);
            }

        }
        #endregion

        #region 浏览日志
        /// <summary>
        /// 浏览日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLog_Click(object sender, EventArgs e)
        {
            ////打开一个文件
            OpenFileDialog OFD = new OpenFileDialog();
            ////设定打开的文件类型
            OFD.Filter = "日志文件(*.log)|*.log|文本文件(*.txt)|*.txt";
            ////确定打开时
            if (OFD.ShowDialog(this) == DialogResult.OK)
            {
                if (readThread != null)
                {
                    ////释放线程
                    readThread.Abort();
                }
                ////清空显示内容
                this.lbRealTimeNote.Items.Clear();
                ////给当前打开文件路径赋值
                strCurrentPath = OFD.FileName;
                ////读取日志文件
                readThread = new Thread(new ThreadStart(StreamReaderLogData));
                ////开启线程
                readThread.Start();
            }

        }
        #endregion

        #region 读取日志文件
        /// <summary>
        /// 读取日志文件
        /// </summary>
        private void StreamReaderLogData()
        {
            using (FileStream fs = new FileStream(strCurrentPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                ////读取打开的日志文件
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    ////逐行读取
                    while (!sr.EndOfStream)
                    {
                        ////把日志文件展示在列表中
                        this.Invoke(addMessage, sr.ReadLine());
                    }
                }
            }
            ////释放线程
            readThread.Abort();
        }
        #endregion

        #region 监听日志
        /// <summary>
        /// 监听日志
        /// </summary>
        /// <param name="name"></param>
        public void ListenNote(string strMessage)
        {
            this.lbRealTimeNote.Items.Add(DateTime.Now + ":" + strMessage);
            ////让滚动条显示在最下面
            this.lbRealTimeNote.SelectedIndex = lbRealTimeNote.Items.Count - 1;
        }
        #endregion

        #region 最小化隐藏在任务栏中
        /// <summary>
        /// 最小化隐藏在任务栏中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTCVMCClient_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide(); //或者是this.Visible = false;
                this.notifyIcon1.Visible = true;
            }
        }
        #endregion

        #region 单击隐藏咋任务栏中的如表显示窗体
        /// <summary>
        /// 单击隐藏咋任务栏中的如表显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }
        #endregion

        #region 气泡提示
        /// <summary>
        /// 气泡提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            notifyIcon1.BalloonTipText = "WIP服务管理";
            notifyIcon1.ShowBalloonTip(5000);//显示气泡提示，参数为显示时间
        }
        #endregion

        #region 安装服务
        /// <summary>
        /// 安装服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要安装"+ ServerName + "服务么？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    IDictionary dictionary = new Hashtable();
                    if (Windows.InstallmyService(dictionary, ServerPath))//安装服务
                    {
                        ////把日志文件展示在列表中
                        MessageBox.Show("安装" + ServerName + "成功，未启动！");
                        this.Invoke(addMessage, "安装" + ServerName + "成功，未启动！");
                        //更改服务状态
                        ServiceList.CurrentRow.Cells["ServiceState"].Value = "服务已停止";
                        //设置一下按钮权限
                        ServiceList_Click(null, null);
                    }
                    else
                    {
                        ////把日志文件展示在列表中
                        MessageBox.Show(ServerName+"服务已经存在");
                        this.Invoke(addMessage,ServerName+"服务已经存在！");

                    }
                }
            }
            catch (Exception ex)
            {
                ////把日志文件展示在列表中
                MessageBox.Show(ServerName+"服务安装异常:" + ex.Message);
                this.Invoke(addMessage,ServerName + "服务安装异常:" + ex.Message);
            }
        }
        #endregion

        #region 卸载服务
        /// <summary>
        /// 卸载服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要卸载"+ ServerName + "服务么？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    IDictionary dictionary = new Hashtable();
                    if (Windows.UnInstallmyService(dictionary, ServerPath))//卸载服务
                    {
                        if (!Windows.isServiceIsExisted(ServerCode))//检查服务是否存在
                        {
                            ////把日志文件展示在列表中
                            MessageBox.Show("卸载" + ServerName + "成功！");
                            this.Invoke(addMessage, "卸载" + ServerName + "成功！");
                            //更改服务状态
                            ServiceList.CurrentRow.Cells["ServiceState"].Value = "服务已卸载";
                            //设置一下按钮权限
                            ServiceList_Click(null, null);
                        }
                        else
                        {
                            ////把日志文件展示在列表中
                            MessageBox.Show("卸载" + ServerName + "失败！");
                            this.Invoke(addMessage, "卸载" + ServerName + "失败！");
                        }
                    }
                    else
                    {
                        ////把日志文件展示在列表中
                        MessageBox.Show(ServerName + "已卸载！");
                        this.Invoke(addMessage, ServerName + "已卸载！");
                    }
                }
            }
            catch (Exception ex)
            {
                ////把日志文件展示在列表中
                MessageBox.Show(ServerName + "服务卸载异常:" + ex.Message);
                this.Invoke(addMessage, ServerName + "服务卸载异常:" + ex.Message);
            }
        }
        #endregion

        #region 列表变化时触发事件
        /// <summary>
        /// 列表变化时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceList_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServiceList.CurrentRow == null) return;
                switch (ServiceList.CurrentRow.Cells["ServiceState"].Value.ToString())
                {
                    case "服务正在运行":
                        this.btnOpenService.Enabled = false;
                        this.btnStopService.Enabled = true;
                        this.btnInstall.Enabled = false;
                        this.btnUninstall.Enabled = false;
                        //ServiceList.CurrentRow.DefaultCellStyle.BackColor = btnOpenService.BackColor;
                        break;
                    case "服务已停止":
                        this.btnOpenService.Enabled = true;
                        this.btnStopService.Enabled = false;
                        this.btnInstall.Enabled = false;
                        this.btnUninstall.Enabled = true;
                        //ServiceList.CurrentRow.DefaultCellStyle.BackColor = btnUninstall.BackColor;
                        break;
                    case "服务已卸载":
                        this.btnOpenService.Enabled = false;
                        this.btnStopService.Enabled = false;
                        this.btnInstall.Enabled = true;
                        this.btnUninstall.Enabled = false;
                        //ServiceList.CurrentRow.DefaultCellStyle.BackColor = btnUninstall.BackColor;
                        break;
                    default:
                        this.btnOpenService.Enabled = false;
                        this.btnStopService.Enabled = false;
                        this.btnInstall.Enabled = false;
                        this.btnUninstall.Enabled = false;
                        //ServiceList.CurrentRow.DefaultCellStyle.BackColor = btnUninstall.BackColor;
                        break;
                }
                //取得服务代码
                ServerCode = ServiceList.CurrentRow.Cells["ServiceCode"].Value.ToString();
                ServerPath = ServiceList.CurrentRow.Cells["ServicePath"].Value.ToString();
                ServerName = ServiceList.CurrentRow.Cells["ServiceName"].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #endregion

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("真的要退出程序吗？", "退出程序", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
