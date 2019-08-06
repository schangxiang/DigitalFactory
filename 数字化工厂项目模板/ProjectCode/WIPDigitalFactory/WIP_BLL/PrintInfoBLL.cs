using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using WIP_DAL;
using WIP_Models;
using Newtonsoft.Json;
using WIP_common;
using SysManager.Common.Utilities;

namespace WIP_BLL
{
    //打印
    public partial class PrintInfoBLL
    {
        #region 单例模式（饿汉模式）

        private static PrintInfoBLL _instance = null;
        private PrintInfoBLL() { }
        static PrintInfoBLL()
        {
            _instance = new PrintInfoBLL();
        }
        public static PrintInfoBLL GetInstance()
        {
            return _instance;
        }
        #endregion

        private readonly PrintInfoDAL dal = PrintInfoDAL.GetInstance();
        string namespaceName = "WIP_BLL.PrintInfoBLL";

        #region  Method

        /// <summary>
        /// 获取本地能打印的打印类型列表
        /// </summary>
        /// <returns></returns>
        private List<string> GetPrintTypeList()
        {
            List<string> printTypeList = new List<string>();
            PrintTypeSection printTypeSection = PrintTypeSection.GetConfig();
            foreach (PrintKeyValue item in printTypeSection.KeyValues)
            {
                printTypeList.Add(item.Value);
            }
            return printTypeList;
        }

        /// <summary>
        /// 获取本地能打印的打印类型名称列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetPrintTypeNameList()
        {
            List<string> printTypeList = new List<string>();
            PrintTypeSection printTypeSection = PrintTypeSection.GetConfig();
            foreach (PrintKeyValue item in printTypeSection.KeyValues)
            {
                printTypeList.Add(item.Name);
            }
            return printTypeList;
        }

        /// <summary>
        /// 获取需要打印的数据列表
        /// </summary>
        /// <param name="tempName">模板名称</param>
        /// <returns></returns>
        public List<PrintInfoModel> GetNeedPrintList()
        {
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<string>(namespaceName,
                "GetNeedPrintList", "", "", "", ExceptionSource.WIPReceive, ExceptionLevel.BusinessError, WipSource.PrintService);
            List<PrintInfoModel> printList = null;
            try
            {
                string printTypeStr = string.Join(",", GetPrintTypeList());
                DataSet ds = dal.GetNeedPrintList(printTypeStr);
                printList = DataTableToListForNeedPrint(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                //判断ex的内容，如果是数据库超时，则过滤，直接光写文本日志
                if (ex.Message.Contains("信号灯超时时间已到") || ex.Message.Contains("未找到或无法访问服务器")
                    || ex.Message.Contains("超时时间已到"))
                {
                    Log4netHelper.WriteErrorLogByLog4Net(typeof(PrintConfigBLL), ex.Message, ex);
                }
                else
                {
                    WipLogHelper.WriteExceptionInfo(exception);
                }
            }
            return printList;
        }
        private List<PrintInfoModel> DataTableToListForNeedPrint(DataTable dt)
        {
            List<PrintInfoModel> modelList = new List<PrintInfoModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PrintInfoModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new PrintInfoModel();
                    model.id = Convert.ToInt32(dt.Rows[n]["id"].ToString());
                    model.processCardNumber = dt.Rows[n]["processCardNumber"].ToString();
                    model.tempName = dt.Rows[n]["tempName"].ToString();
                    model.printJson = dt.Rows[n]["printJson"].ToString();
                    model.printType = dt.Rows[n]["printType"].ToString();
                    model.printerName = dt.Rows[n]["printerName"].ToString();
                    model.printArea = dt.Rows[n]["printArea"].ToString();

                    if (dt.Rows[n]["delFlag"].ToString() != "")
                    {
                        model.delFlag = Convert.ToBoolean(dt.Rows[n]["delFlag"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }



        /// <summary>
        ///  初始化打印数据对象
        /// </summary>
        /// <typeparam name="T">json</typeparam>
        /// <param name="t"></param>
        /// <param name="printType">打印类型</param>
        /// <param name="processCardNumber">流转卡号</param>
        /// <param name="isOnlyPrint">是否仅仅是打印，不处理业务</param>
        /// <returns></returns>
        public bool Add<T>(T t, PrintType printType, string processCardNumber, bool isOnlyPrint, TransactionModel transModel = null)
        {
            try
            {
                PrintInfoEntity printInfo = new PrintInfoEntity()
                {
                    processCardNumber = processCardNumber,
                    printJson = JsonConvert.SerializeObject(t),
                    delFlag = isOnlyPrint,
                    printFlag = Convert.ToInt32(PrintStatus.ToPrint).ToString(),//代表初始
                    createTime = DateTime.Now,
                    lastModifyTime = DateTime.Now,
                    creator = JwtHelp.GetCurUserName(),
                    lastModifier = JwtHelp.GetCurUserName(),
                    printType = Convert.ToInt32(printType).ToString()
                };
                return dal.Add(printInfo, transModel) > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 重置打印状态
        /// </summary>
        /// <param name="processCardNumber">流转卡号</param>
        /// <param name="id">打印ID</param>
        /// <returns>处理结果</returns>
        public bool RestPrint(string processCardNumber, int id)
        {
            try
            {
                ProcResultModel ret = dal.RestPrint(processCardNumber, id);
                if (ret.execResult == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        #endregion

    }
}