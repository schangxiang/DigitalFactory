using Newtonsoft.Json;
using SysManager.Common.Utilities;
using SysManager.DB.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WIP_common;
using WIP_SQLServerDAL;
using WIP_Models;

namespace WIP_BLL
{
    /// <summary> 
    /// 邮件类别业务处理类 
    /// </summary> 
    public class MailRuleBLL
    {
        #region 单例模式（饿汉模式）

        private static MailRuleBLL _instance = null;
        private MailRuleBLL() { }
        static MailRuleBLL()
        {
            _instance = new MailRuleBLL();
        }
        public static MailRuleBLL GetInstance()
        {
            return _instance;
        }

        #endregion

        private readonly MailRuleDAL mailRuleDAL = MailRuleDAL.GetInstance();

        /// <summary>
        /// 更新邮箱人员
        /// </summary>
        /// <param name="param"></param>
        /// <param name="lastModifier"></param>
        /// <returns></returns>
        public MethodReturnResultModel UpdateMailPerson(UpdateMailPersonParam param, string lastModifier)
        {
            MethodReturnResultModel funRes = null;
            try
            {
                #region 准备数据

                string truncateSql = " DELETE udtWip_MailPerson WHERE categoryId='" + param.categoryId + "' ";
                string insertSql = "";

                #endregion
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
                            SQLServerHelper.ExecuteSql(truncateSql, transModel);

                            foreach (var item in param.mailPersonParamList)
                            {
                                insertSql = @" INSERT INTO udtWip_MailPerson(categoryId,mailAddress,mailName,creator,createTime,lastModifier,lastModifyTime)
  SELECT  '" + param.categoryId + "','" + item.mailAddress + "','" + item.mailName + "','" + lastModifier + "',getdate(),'" + lastModifier + "',GETDATE()  ";
                                SQLServerHelper.ExecuteSql(insertSql, transModel);
                            }


                            funRes = new MethodReturnResultModel()
                            {
                                IsSuccess = true
                            };
                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return funRes;
        }

        #region 获得邮件类别数据列表

        /// <summary> 
        /// 获得邮件类别数据列表 
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>邮件类别数据集合</returns> 
        public List<MailRuleEntity> GetMailRuleList()
        {
            DataSet ds = mailRuleDAL.GetMailRuleList();
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary> 
        /// 获得邮件类别数据列表 
        /// </summary> 
        private List<MailRuleEntity> DataTableToList(DataTable dt)
        {
            List<MailRuleEntity> modelList = new List<MailRuleEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MailRuleEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new MailRuleEntity();
                    var dataRow = dt.Rows[n];

                    if (dataRow["id"].ToString() != "")
                    {
                        model.id = int.Parse(dataRow["id"].ToString());
                    }
                    model.categoryId = dataRow["categoryId"].ToString();
                    model.categoryName = dataRow["categoryName"].ToString();
                    model.remark = dataRow["remark"].ToString();

                    model.creator = dataRow["creator"].ToString();
                    if (dataRow["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dataRow["createTime"].ToString());
                    }
                    model.lastModifier = dataRow["lastModifier"].ToString();
                    if (dataRow["lastModifyTime"].ToString() != "")
                    {
                        model.lastModifyTime = DateTime.Parse(dataRow["lastModifyTime"].ToString());
                    }



                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        #region 获得邮件人员数据列表

        /// <summary> 
        /// 获得邮件人员数据列表 
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>邮件类别数据集合</returns> 
        public List<MailPersonModel> GetMailPersonList(string categoryId)
        {
            DataSet ds = mailRuleDAL.GetMailPersonList(categoryId);
            return DataTableToListForPerson(ds.Tables[0]);
        }

        /// <summary> 
        /// 获得邮件人员数据列表 
        /// </summary> 
        private List<MailPersonModel> DataTableToListForPerson(DataTable dt)
        {
            List<MailPersonModel> modelList = new List<MailPersonModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MailPersonModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new MailPersonModel();
                    var dataRow = dt.Rows[n];

                    if (dataRow["id"].ToString() != "")
                    {
                        model.id = int.Parse(dataRow["id"].ToString());
                    }
                    model.categoryId = dataRow["categoryId"].ToString();
                    model.categoryName = dataRow["categoryName"].ToString();
                    model.mailAddress = dataRow["mailAddress"].ToString();
                    model.mailName = dataRow["mailName"].ToString();
                    model.remark = dataRow["remark"].ToString();

                    model.creator = dataRow["creator"].ToString();
                    if (dataRow["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dataRow["createTime"].ToString());
                    }
                    model.lastModifier = dataRow["lastModifier"].ToString();
                    if (dataRow["lastModifyTime"].ToString() != "")
                    {
                        model.lastModifyTime = DateTime.Parse(dataRow["lastModifyTime"].ToString());
                    }



                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        #region 获得邮件人员数据列表(收件人邮箱地址、支持发送多个人,每个地址用 ; 号隔开)

        /// <summary> 
        /// 获得邮件人员数据列表(收件人邮箱地址、支持发送多个人,每个地址用 ; 号隔开)
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>邮件类别数据集合</returns> 
        public string GetMailPersonListRetStr(string categoryId)
        {
            string mailAddres = string.Empty;
            try
            {
                List<MailPersonModel> list = GetMailPersonList(categoryId);
                if (list != null && list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        mailAddres += item.mailAddress + ";";
                    }
                }
            }
            catch
            {
                throw;
            }
            if (mailAddres == string.Empty)
            {//记录业务异常信息 
                BusinessExceptionMgrParam businessExceptionParam = new BusinessExceptionMgrParam()
                {
                    exceptionCode = BusinessExceptionCode.WIP_NoMailAddress,
                    exceptionMsg = BusinessExceptionMessage.WIP_NoMailAddress + ",邮箱类型ID:" + categoryId,
                };
                BusinessExceptionMgrBLL.GetInstance().AddBusinessException(businessExceptionParam, "sys", false);
            }
            return mailAddres;
        }


        #endregion


        /// <summary>
        /// 发送邮件(异常情况)
        /// </summary>
        /// <param name="mail"></param>
        public void MailSendingForException(MailModel mail, string categoryId)
        {
            Task.Run(() =>
            {
                StringBuilder Describe = new StringBuilder();
                Describe.Append("错误信息:" + mail.Describe.exceptionMsg + "<br/>");
                Describe.Append("异常信息:" + mail.Describe.exceptionData + "<br/>");
                Describe.Append("源数据:" + mail.Describe.sourceData + "<br/>");


                IMail mail_1 = new Mail(categoryId);
                mail_1.MailSending(mail.MailSubject, Describe.ToString(), mail.File_Path);
            });
        }

        /// <summary>
        /// 发送邮件(业务异常情况)
        /// </summary>
        /// <param name="mail"></param>
        public void MailSendingForBusinessException(BusinessExceptionMgrEntity businessExceptionMgr, string categoryId)
        {
            try
            {
                StringBuilder Describe = new StringBuilder();
                Describe.Append("错误信息:" + businessExceptionMgr.exceptionMsg + "<br/>");
                Describe.Append("任务号:" + businessExceptionMgr.taskNo + "<br/>");
                Describe.Append("流转卡号:" + businessExceptionMgr.processCardNumber + "<br/>");
                Describe.Append("系统编码:" + businessExceptionMgr.sysCode + "<br/>");
                Describe.Append("异常代码:" + businessExceptionMgr.exceptionCode + "<br/>");
                Describe.Append("物料编码:" + businessExceptionMgr.materialCode + "<br/>");
                Describe.Append("零件号:" + businessExceptionMgr.partNumber + "<br/>");
                Describe.Append("零件名称:" + businessExceptionMgr.partName + "<br/>");
                Describe.Append("主机名:" + businessExceptionMgr.host + "<br/>");
               

                IMail mail = new Mail(categoryId);
                mail.MailSending("业务异常-" + businessExceptionMgr.exceptionMsg, Describe.ToString(), "");
            }
            catch (Exception ex)
            {
                Dictionary<string, object> logDict = new Dictionary<string, object>();
                logDict.Add("businessExceptionMgr", businessExceptionMgr);
                logDict.Add("ex", ex);
                string errMsg = "准备发送邮件(业务异常情况)出现异常：" + JsonConvert.SerializeObject(logDict);
                Log4netHelper.WriteErrorLogByLog4Net(typeof(MailRuleBLL), errMsg);
            }
        }
    }
}
