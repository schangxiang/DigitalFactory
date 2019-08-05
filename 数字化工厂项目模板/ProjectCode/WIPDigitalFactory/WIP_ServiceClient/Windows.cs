using System;
using System.Collections;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Configuration.Install;
using System.Diagnostics;

namespace WIP_ServiceClient
{
    class Windows
    {

        #region 检查服务存在的存在性
        /// <summary>
        /// 检查服务存在的存在性
        /// </summary>
        /// <param name=" NameService ">服务名</param>
        /// <returns>存在返回 true,否则返回 false;</returns>
        public static bool isServiceIsExisted(string NameService)
        {

            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName.ToLower() == NameService.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 安装Windows服务
        /// <summary>
        /// 安装Windows服务
        /// </summary>
        /// <param name="stateSaver">集合，当传递给 Install 方法时，stateSaver 参数指定的 IDictionary 应为空。</param>
        /// <param name="filepath">程序文件路径</param>
        public static bool InstallmyService(IDictionary stateSaver, string filepath)
        {
            try
            {
                if (filepath == "")
                {
                    return false;
                }
                AssemblyInstaller AssemblyInstaller1 = new AssemblyInstaller();
                AssemblyInstaller1.UseNewContext = true;
                AssemblyInstaller1.Path = filepath;
                stateSaver.Clear();
                AssemblyInstaller1.Install(stateSaver);
                AssemblyInstaller1.Commit(stateSaver);
                AssemblyInstaller1.Dispose();
                return true;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 卸载Windows服务
        /// <summary>
        /// 卸载Windows服务
        /// </summary>
        /// <param name="filepath">程序文件路径</param>
        public static bool UnInstallmyService(IDictionary stateSaver, string filepath)
        {
            try
            {
                if (filepath == "")
                {
                    return false;
                }
                AssemblyInstaller AssemblyInstaller1 = new AssemblyInstaller();
                AssemblyInstaller1.UseNewContext = true;
                AssemblyInstaller1.Path = filepath;
                AssemblyInstaller1.Uninstall(stateSaver);
                AssemblyInstaller1.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 检查Windows服务是否在运行
        /// <summary>
        /// 检查Windows服务是否在运行
        /// </summary>
        /// <param name="name">程序的服务名</param>
        public static bool IsRunning(string name)
        {
            bool IsRun = false;
            try
            {
                if (!isServiceIsExisted(name))
                {
                    return false;
                }
                ServiceController sc = new ServiceController(name);
                if (sc.Status == ServiceControllerStatus.StartPending ||
                    sc.Status == ServiceControllerStatus.Running)
                {
                    IsRun = true;
                }
                sc.Close();
            }
            catch
            {
                IsRun = false;
            }
            return IsRun;
        }
        #endregion

        #region 启动Windows服务
        /// <summary>
        /// 启动Windows服务
        /// </summary>
        /// <param name="name">程序的服务名</param>
        /// <returns>启动成功返回 true,否则返回 false;</returns>
        public static bool StarmyService(string name)
        {
            ServiceController sc = new ServiceController(name);
            if (sc.Status == ServiceControllerStatus.Stopped || sc.Status == ServiceControllerStatus.StopPending)
            {

                sc.Start();
                //sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 3, 0));//等待3min
            }
            else
            {
            }
            sc.Close();
            return true;
        }
        #endregion

        #region 停止Windows服务
        /// <summary>
        /// 停止Windows服务
        /// </summary>
        /// <param name="name">程序的服务名</param>
        /// <returns>停止成功返回 true,否则返回 false;</returns>
        public static bool StopmyService(string name)
        {
            ServiceController sc = new ServiceController(name);
            if (sc.Status == ServiceControllerStatus.Running ||
                sc.Status == ServiceControllerStatus.StartPending)
            {
                try
                {

                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 10));
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                }
            }
            else
            {
            }
            sc.Close();
            return true;
        }
        #endregion

        #region 重启Windows服务
        /// <summary>
        /// 重启Windows服务
        /// </summary>
        /// <param name="name">程序的服务名</param>
        /// <returns>重启成功返回 true,否则返回 false;</returns>
        public static bool RefreshmyService(string name)
        {
            return StopService(name) && StarmyService(name);
        }
        #endregion

        #region 停止服务 命令强制停止
        /// <summary>
        ///  停止服务
        /// Author:SunZhiXiang
        /// Time:2015-04-27 02:49:08
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool StopService(string name)
        {
            try
            {
                while (true)
                {
                    if (Windows.IsRunning(name))//检查服务是否运行
                    {
                        //关闭服务  
                        ProcessStartInfo psi = new ProcessStartInfo(@"cmd.exe", "/c  sc stop " + name + "");
                        psi.WindowStyle = ProcessWindowStyle.Hidden;
                        Process process = Process.Start(psi);
                    }
                    else
                    {
                        break;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
