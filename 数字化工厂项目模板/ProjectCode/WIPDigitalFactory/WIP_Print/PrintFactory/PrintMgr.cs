using Aspose.Cells;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_BLL;
using WIP_SQLServerDAL;
using WIP_Models;
using WIP_common;
using System.Reflection;
using SysManager.Common.Utilities;
using SysManager.DB.Utilities;

namespace WIP_Print
{
    public class PrintMgr
    {
        public XSSFWorkbook workbook;
        public string strPrintType = "";//打印类型值
        public string namespaceName = "WIP_Print.PrintMgr";
        private readonly string wipSource = WipSource.PrintService;

        public PrintMgr(PrintType printType)
        {
            this.strPrintType = Convert.ToInt32(printType).ToString();
        }

        #region 虚方法

        /// <summary>
        /// 将要打印的实体对象转为Cell集合对象的JSON字符串
        /// </summary>
        /// <param name="printJson">要打印的实体对象</param>
        /// <param name="tempFileName">模板名称</param>
        /// <returns>Cell集合对象的JSON字符串</returns>
        public virtual string GetJsonDataAsExcelCellModel(string printJson, string tempFileName)
        {
            return "";
        }


        /// <summary>
        /// 处理打印结果
        /// </summary>
        /// <param name="printResult">打印结果</param>
        /// <param name="printInfo">打印信息</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns></returns>
        public virtual bool DoByPrintResult(bool printResult, PrintInfoModel printInfo, string errMsg = "")
        {

            var retResult = false;//返回结果 
            IDictionary<string, object> logDict = new Dictionary<string, object>();
            logDict.Add("printResult", printResult);
            logDict.Add("printInfo", printInfo);
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<IDictionary<string, object>>(namespaceName, "DoByPrintResult", logDict
                , "", printInfo == null ? "" : printInfo.processCardNumber, ExceptionSource.WIPPost, ExceptionLevel.BusinessError, wipSource);
            try
            {

                #region 准备数据

                SqlParameter[] parameters_UpdatePrintResult = this.GetSqlParamForUpdatePrintResult(printResult, printInfo, errMsg);

                #endregion

                #region 事务处理

                using (SqlConnection conn = new SqlConnection(SQLServerHelper.connectionString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        TransactionModel transModel = new TransactionModel()
                        {
                            conn = conn,
                            trans = trans
                        };
                        try
                        {
                            var execResult = new PrintInfoDAL().UpdatePrintResult(parameters_UpdatePrintResult, transModel);
                            if (execResult != 1)
                            {//返回1代表执行成功,返回-1代表失败
                                throw new Exception("处理打印结果失败,parameters:" + JsonConvert.SerializeObject(parameters_UpdatePrintResult)
                                    + ",execResult:" + execResult.ToString());
                            }

                            trans.Commit();
                            retResult = true;
                        }
                        catch
                        {
                            retResult = false;
                            trans.Rollback();
                            throw;
                        }
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                retResult = false;
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                WipLogHelper.WriteExceptionInfo(exception);
            }
            return retResult;
        }

        #endregion

        /// <summary>
        /// 初始化模板的JSON数据
        /// </summary>
        /// <param name="tempFileName"></param>
        /// <returns></returns>
        public string InitTempleteFileJsonData(string tempFileName)
        {
            this.workbook = this.CreateWorkbook(tempFileName);

            string json_dataList = "";
            //判断是否已经有了模板的JSON数据
            if (ExcelUtil.printTypeDict.ContainsKey(strPrintType))
            {
                json_dataList = ExcelUtil.printTypeDict[strPrintType];
            }
            else
            {
                json_dataList = this.TempleteFileToJSON();
            }
            return json_dataList;
        }

        /// <summary>
        /// 打印操作
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="printInfo"></param>
        /// <returns></returns>
        public void Print(string json_cellList, PrintInfoModel printInfo, PageOrientationType orientation)
        {
            IDictionary<string, object> logDict = new Dictionary<string, object>();
            logDict.Add("json_cellList", json_cellList);
            logDict.Add("printInfo", printInfo);
            logDict.Add("orientation", orientation);
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<IDictionary<string, object>>(namespaceName, "Print", logDict
                , "", printInfo == null ? "" : printInfo.processCardNumber, ExceptionSource.WIPPost, ExceptionLevel.BusinessError, wipSource);
            try
            {
                //创建文件
                List<ExcelSheetModel> sheetModelList = new List<ExcelSheetModel>();
                List<ExcelCellModel> cellModelList = JsonConvert.DeserializeObject<List<ExcelCellModel>>(json_cellList);
                ExcelSheetModel sheetModel = new ExcelSheetModel()
                {
                    sheetName = this.workbook.GetSheetAt(0).SheetName,
                    dataList = cellModelList,
                    sheetType = "",
                };
                sheetModelList.Add(sheetModel);
                byte[] bytes = ExcelUtil.writeExcelToFile(this.workbook, sheetModelList, printInfo.tempName);

                //修改为“打印中”
                var result = UpdatePrintStatusToPrinting(printInfo.id);
                if (!result)
                    throw new Exception("更新状态为打印中失败,printInfo.id:" + printInfo.id.ToString());

                PrintHelper.PrintExcel(bytes, printInfo.printerName, orientation);

                //打印成功
                this.DoByPrintResultSuccess(printInfo);

            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                WipLogHelper.WriteExceptionInfo(exception);

                //打印失败
                this.DoByPrintResultFailure(printInfo, ex);
            }
        }


        /// <summary>
        /// 替换打印的占位符
        /// </summary>
        /// <typeparam name="T">要取值的实体对象</typeparam>
        /// <param name="obj">要取值的实体对象值</param>
        /// <param name="json_dataList"></param>
        /// <returns></returns>
        public string Replace<T>(T obj, string json_dataList)
        {
            PropertyInfo[] properArray = typeof(T).GetProperties();
            Object value = null;
            string str = "";
            foreach (var proper in properArray)
            {
                if (proper.GetCustomAttribute(typeof(PrintAttribute), false) != null)
                {
                    value = proper.GetValue(obj, null);
                    if (value == null)
                        value = "";
                    if (proper.PropertyType == typeof(string))
                    {
                        str = StringHelper.NullToEmpty(value.ToString());
                    }
                    else if (proper.PropertyType == typeof(int?) || proper.PropertyType == typeof(int))
                    {
                        str = StringHelper.NullToEmpty(value == null ? "" : value.ToString());
                    }
                    else if (proper.PropertyType == typeof(DateTime) || proper.PropertyType == typeof(DateTime?))
                    {
                        str = WIPCommon.FormatDateTime((DateTime?)value);
                    }
                    //替换
                    json_dataList = json_dataList.Replace("[" + proper.Name + "]", str);
                }
            }
            return json_dataList;
        }


        #region 私有方法

        /// <summary>
        /// 打印成功的操作
        /// </summary>
        /// <param name="printInfo"></param>
        private void DoByPrintResultSuccess(PrintInfoModel printInfo)
        {
            if (printInfo.delFlag == false)
            {
                DoByPrintResult(true, printInfo);
            }
            else
            {//只打印 

            }
        }

        /// <summary>
        /// 打印失败的操作
        /// </summary>
        /// <param name="printInfo"></param>
        /// <param name="ex"></param>
        private void DoByPrintResultFailure(PrintInfoModel printInfo, Exception ex)
        {
            if (printInfo.delFlag == false)
            {
                DoByPrintResult(false, printInfo, ex.Message);
            }
        }

        /// <summary>
        /// 获取更新打印结果的sql参数
        /// </summary>
        /// <param name="printResult"></param>
        /// <param name="printInfo"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private SqlParameter[] GetSqlParamForUpdatePrintResult(bool printResult, PrintInfoModel printInfo, string errMsg)
        {
            var isPrintProcessCard = "0";//是否是打印流转卡
            var isPrintSuccess = "0";//是否打印成功
            var processCardPrintQueueId = 0;
            if (printInfo.delFlag == false && printInfo.printType == Convert.ToInt32(PrintType.ProcessCardForBuffer).ToString()
                 || printInfo.printType == Convert.ToInt32(PrintType.ProcessCardForPostHeatStorageOut).ToString())
            {
                isPrintProcessCard = "1";
                processCardPrintQueueId = 0;//模拟写死
            }
            if (printResult)
            {//打印成功 
                isPrintSuccess = "1";
            }

            SqlParameter[] parameters = { 
                  new SqlParameter("@printResult",SqlDbType.VarChar,2),
                  new SqlParameter("@printInfoId",SqlDbType.Int),
                  new SqlParameter("@printErrMsg",SqlDbType.NVarChar,100),
                  new SqlParameter("@isPrintProcessCard",SqlDbType.VarChar,2),
                  new SqlParameter("@processCardPrintQueueId",SqlDbType.Int),
                  new SqlParameter("@printTime",SqlDbType.DateTime),
                  new SqlParameter("@processCardNumber",SqlDbType.NVarChar,50)
                };
            parameters[0].Value = isPrintSuccess;
            parameters[1].Value = printInfo.id;
            parameters[2].Value = errMsg;
            parameters[3].Value = isPrintProcessCard;
            parameters[4].Value = processCardPrintQueueId;
            parameters[5].Value = DateTime.Now;
            parameters[6].Value = printInfo.processCardNumber;
            return parameters;
        }

        /// <summary>
        /// 转模板文件为JSON数据
        /// </summary>
        /// <returns></returns>
        private string TempleteFileToJSON()
        {
            List<ExcelCellModel> dataList = ExcelUtil.GetCellListByTemplateFile(workbook);
            string json_templete_dataList = JsonConvert.SerializeObject(dataList);
            //记录模板的JSON数据
            if (!ExcelUtil.printTypeDict.ContainsKey(strPrintType))
            {
                ExcelUtil.printTypeDict.Add(strPrintType, json_templete_dataList);
            }
            return json_templete_dataList;
        }

        /// <summary>
        /// 获取要打印模块的XSSFWorkbook
        /// </summary>
        /// <param name="tempFileName">模板名称</param>
        /// <returns></returns>
        private XSSFWorkbook CreateWorkbook(string tempFileName)
        {
            string filePath = System.Threading.Thread.GetDomain().BaseDirectory + "\\";
            string filePostfix = ".xlsx";
            using (FileStream fs = new FileStream(filePath + @"PrintTemplete\" + tempFileName + filePostfix, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fs);
                fs.Close();
            }

            return workbook;
        }

        /// <summary>
        /// 更新状态为“打印中”
        /// </summary>
        /// <param name="printId"></param>
        /// <returns></returns>
        private bool UpdatePrintStatusToPrinting(int printId)
        {
            var nowTime = DateTime.Now;
            List<PropertyParam> list = new List<PropertyParam>() {
                new PropertyParam(){ PropertyName="lastModifyTime",ObjectValue=nowTime,dbType=SqlDbType.DateTime},
                new PropertyParam() { PropertyName = "printFlag", ObjectValue = Convert.ToInt32(PrintStatus.Printing).ToString(), dbType = SqlDbType.NVarChar, size = 10 }
            };
            list.Add(new PropertyParam()
            {
                IsWhereFilter = true,
                PropertyName = "id",
                ObjectValue = printId,
                dbType = SqlDbType.Int
            });
            var result = DALCommon.UpdateExtend(list, Table.PrintInfo);
            return result;
        }

        #endregion

    }
}
