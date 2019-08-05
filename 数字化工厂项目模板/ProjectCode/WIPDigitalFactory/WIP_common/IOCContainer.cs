/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_common
 * FileName：Class1
 * CurrentYear：2019
 * CurrentTime：2019/7/15 15:20:47
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/15 15:20:47 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WIP_common
{
    public class IOCContainer
    {
        /// <summary>
        /// 容器
        /// </summary>
        public static CompositionContainer Container { get; private set; }

        private static IOCContainer instance = new IOCContainer();

        private IOCContainer()
        {
            if (Container == null)
            {
                try
                {
                    //获取包含当前执行的代码的程序集
                    //var path1 = AppDomain.CurrentDomain.BaseDirectory + "\\bin"; //另一种写法
                    string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                    UriBuilder uri = new UriBuilder(codeBase);
                    string path = Uri.UnescapeDataString(uri.Path);
                    path = Path.GetDirectoryName(path);

                    //创建一个程序集目录，用于从一个程序集获取所有的组件定义
                    var catalog = new DirectoryCatalog(path, "WIP_BLL.dll");
                    //创建容器
                    Container = new CompositionContainer(catalog);
                    //_container.ComposeParts(this); //将部件（part）和宿主程序添加到组合容器，此时会初始化除了懒加载之外的Import的对象，
                    //执行组合 【组合这一行代码，并不影响我们的使用，有没有皆可】
                    Container.ComposeParts();
                }
                catch (Exception ex)
                {//吞掉异常
                    LogHelper.WriteErrorLogByLog4Net(typeof(IOCContainer), "注册MEF出错：ex:" + JsonConvert.SerializeObject(ex));
                }
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public static IOCContainer RegisterContainer()
        {
            return instance;
        }

    }

}
