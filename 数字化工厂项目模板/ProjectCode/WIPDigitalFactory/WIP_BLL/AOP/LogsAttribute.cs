/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_common.AOP
 * FileName：LogsAttribute
 * CurrentYear：2019
 * CurrentTime：2019/7/22 13:35:37
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/22 13:35:37 新規作成 (by shaocx)
 */


using Newtonsoft.Json;
//using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WIP_common;
using WIP_DAL;
using WIP_Models;

namespace WIP_BLL
{

    /*
     * 我们约定每个Aspect类的命名必须为“XXXAttribute”的形式。
     * 其中“XXX”就是这个Aspect的名字。
     * PostSharp中提供了丰富的内置“Base Aspect”以便我们继承，
     * 其中这里我们继承“OnMethodBoundaryAspect ”，
     * 这个Aspect提供了进入、退出函数等连接点方法。
     * 另外，Aspect上必须设置“[Serializable] ”，
     * 这与PostSharp内部对Aspect的生命周期管理有关
     */
    /*
   [Serializable]
   [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
   public sealed class LogsAttribute : OnMethodBoundaryAspect
   {
       private static RequestRecordDAL requestRecordDAL = new WIP_DAL.RequestRecordDAL();

       /// <summary>
       /// 命名空间
       /// </summary>
       public string namespaceName { get; set; }

       /// <summary>
       /// 信息来源
       /// </summary>
       public string msgSource { get; set; }

       public override void OnEntry(MethodExecutionArgs args)
       {
           var methodName = args.Method.Name;
           Arguments arguments = args.Arguments;
           ParameterInfo[] parameters = args.Method.GetParameters();
           IDictionary<string, string> context = new Dictionary<string, string>();
           for (int i = 0; arguments != null && i < arguments.Count; i++)
           {
               //进入的参数的值
               context.Add(parameters[i].Name, JsonConvert.SerializeObject(arguments[i]));
           }
           #region 异步处理

           Task.Run(() =>
           {
               UdtWip_RequestRecord requestRecord = new UdtWip_RequestRecord()
               {
                   direction = 1,//  1  WIP接收   2 WIP 推送
                   happenHost = WIPCommon.GetHostName(msgSource),
                   fullFun = namespaceName + "." + methodName,//方法名
                   param = JsonConvert.SerializeObject(context), //入参
               };
               LogHelper.WriteInfoLogByLog4Net(typeof(LogHelper), JsonConvert.SerializeObject(requestRecord));
               requestRecordDAL.Add(requestRecord);
           });

           #endregion
       }
   }

   //*/
}
