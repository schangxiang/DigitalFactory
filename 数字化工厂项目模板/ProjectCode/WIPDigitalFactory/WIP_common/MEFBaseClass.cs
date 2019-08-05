/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_common
 * FileName：MEFBaseClass
 * CurrentYear：2019
 * CurrentTime：2019/7/4 9:08:54
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/4 9:08:54 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;

namespace WIP_common
{
    public abstract class MEFBaseClass
    {
        public MEFBaseClass()
        {
            try
            {
                //获取包含当前执行的代码的程序集
                //var path1 = AppDomain.CurrentDomain.BaseDirectory + "\\bin"; //另一种写法
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                path = Path.GetDirectoryName(path);

                var catalog = new DirectoryCatalog(path, "WIP_BLL.dll");
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this); //将部件（part）和宿主程序添加到组合容器，此时会初始化除了懒加载之外的Import的对象，
                //*/
            }
            catch
            {

            }
        }
    }
}
