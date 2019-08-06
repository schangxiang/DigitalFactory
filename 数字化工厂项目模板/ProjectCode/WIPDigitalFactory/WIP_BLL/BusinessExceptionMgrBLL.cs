using Newtonsoft.Json;
using SysManager.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WIP_common;
using WIP_DAL;
using WIP_Models;

namespace WIP_BLL
{
    /// <summary> 
    /// 业务异常管理业务处理类 
    /// </summary> 
    public class BusinessExceptionMgrBLL
    {
        #region 单例模式（饿汉模式）

        private static BusinessExceptionMgrBLL _instance = null;
        private BusinessExceptionMgrBLL() { }
        static BusinessExceptionMgrBLL()
        {
            _instance = new BusinessExceptionMgrBLL();
        }
        public static BusinessExceptionMgrBLL GetInstance()
        {
            return _instance;
        }

        #endregion

        private readonly BusinessExceptionMgrDAL businessExceptionMgrDAL = BusinessExceptionMgrDAL.GetInstance();

        #region Edit

        /// <summary> 
        /// 更新业务异常信息为已处理 
        /// </summary> 
        /// <param name="model">要更新的业务异常管理实体</param> 
        /// <param name="lastModifier">最后修改人</param> 
        /// <returns>更新是否成功</returns> 
        public bool UpdateToHasDo(BusinessExceptionMgrEntity model, string lastModifier)
        {
            model.lastModifier = lastModifier;
            return businessExceptionMgrDAL.UpdateToHasDo(model);
        }

        #endregion

        #region QueryList(Page)

        /// <summary> 
        /// 获得业务异常管理数据列表(分页) 
        /// </summary> 
        /// <param name="strOrderBy">排序字段</param> 
        /// <param name="strWhere">查询条件</param> 
        /// <param name="model">分页数据</param> 
        /// <returns>业务异常管理分页数据</returns> 
        public PageResultModel<BusinessExceptionMgrModel> GetModelListForPage(string strOrderBy, string strWhere, QueryBusinessExceptionMgrModel model)
        {
            DataSet ds = businessExceptionMgrDAL.GetListForPage(strOrderBy, strWhere, model);
            List<BusinessExceptionMgrModel> list = DataTableToList(ds.Tables[0]);
            int total = Convert.ToInt32(ds.Tables[1].Rows[0]["COUNT"]);
            PageResultModel<BusinessExceptionMgrModel> result = new PageResultModel<BusinessExceptionMgrModel>();
            result.total = total;
            result.rows = list;
            return result;
        }

        #endregion

        #region Common

        /// <summary> 
        /// 获得业务异常管理数据列表 
        /// </summary> 
        private List<BusinessExceptionMgrModel> DataTableToList(DataTable dt)
        {
            List<BusinessExceptionMgrModel> modelList = new List<BusinessExceptionMgrModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BusinessExceptionMgrModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BusinessExceptionMgrModel();
                    var dataRow = dt.Rows[n];

                    if (dataRow["id"].ToString() != "")
                    {
                        model.id = int.Parse(dataRow["id"].ToString());
                    }
                    if (dataRow["taskNo"].ToString() != "")
                    {
                        model.taskNo = dataRow["taskNo"].ToString();
                    }
                    model.taskType = dataRow["taskType"].ToString();
                    model.taskTypeName = dataRow["taskTypeName"].ToString();
                    model.processCardNumber = dataRow["processCardNumber"].ToString();
                    model.sysCode = dataRow["sysCode"].ToString();
                    model.sysCodeName = dataRow["sysCodeName"].ToString();
                    model.exceptionCode = dataRow["exceptionCode"].ToString();
                    model.exceptionMsg = dataRow["exceptionMsg"].ToString();
                    model.qaStatus = dataRow["qaStatus"].ToString();
                    model.materialStatus = dataRow["materialStatus"].ToString();
                    model.materialCode = dataRow["materialCode"].ToString();
                    model.partName = dataRow["partName"].ToString();
                    model.partNumber = dataRow["partNumber"].ToString();
                    if (dataRow["quantity"].ToString() != "")
                    {
                        model.quantity = int.Parse(dataRow["quantity"].ToString());
                    }
                    model.disposeResult = dataRow["disposeResult"].ToString();
                    model.disposeStatus = dataRow["disposeStatus"].ToString();
                    model.disposeStatus_str = model.disposeStatus == "0" ? "未处理" : "已处理";
                    model.disposeNote = dataRow["disposeNote"].ToString();
                    if (dataRow["timestamp"].ToString() != "")
                    {
                        model._timestamp = DateTime.Parse(dataRow["timestamp"].ToString());
                        model._timestamp_str = WIPCommon.FormatDateTime(model._timestamp);
                    }
                    model.host = dataRow["host"].ToString();
                    if (dataRow["delFlag"].ToString() != "")
                    {
                        if ((dataRow["delFlag"].ToString() == "1") || (dataRow["delFlag"].ToString().ToLower() == "true"))
                        {
                            model.delFlag = true;
                        }
                        else
                        {
                            model.delFlag = false;
                        }
                    }
                    model.creator = dataRow["creator"].ToString();
                    if (dataRow["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dataRow["createTime"].ToString());
                        model.createTime_str = WIPCommon.FormatDateTime(model.createTime);
                    }
                    model.lastModifier = dataRow["lastModifier"].ToString();
                    if (dataRow["lastModifyTime"].ToString() != "")
                    {
                        model.lastModifyTime = DateTime.Parse(dataRow["lastModifyTime"].ToString());
                        model.lastModifyTime_str = WIPCommon.FormatDateTime(model.lastModifyTime);
                    }



                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public string GetWhereFilter(QueryBusinessExceptionMgrModel queryModel)
        {
            var strWhere = "";
            if (queryModel != null)
            {
                if (queryModel._timestamp != null && queryModel._timestamp.Length == 2)
                {
                    strWhere += " AND businessExceptionMgr.[timestamp] >= '" + WIPCommon.FormatDateTimePreciseToFFF(Convert.ToDateTime(queryModel._timestamp[0])) + "' ";
                    strWhere += " AND businessExceptionMgr.[timestamp] <= '" + WIPCommon.FormatDateTimePreciseToFFF(Convert.ToDateTime(queryModel._timestamp[1])) + "' ";
                }
                if (!string.IsNullOrEmpty(queryModel.taskNo))
                {
                    strWhere += " AND businessExceptionMgr.taskNo = '" + queryModel.taskNo + "' ";
                }
                if (!string.IsNullOrEmpty(queryModel.taskType))
                {
                    strWhere += " AND businessExceptionMgr.taskType LIKE '%" + queryModel.taskType + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.processCardNumber))
                {
                    strWhere += " AND businessExceptionMgr.processCardNumber LIKE '%" + queryModel.processCardNumber + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.sysCode))
                {
                    strWhere += " AND businessExceptionMgr.sysCode LIKE '%" + queryModel.sysCode + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.exceptionCode))
                {
                    strWhere += " AND businessExceptionMgr.exceptionCode LIKE '%" + queryModel.exceptionCode + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.exceptionMsg))
                {
                    strWhere += " AND businessExceptionMgr.exceptionMsg LIKE '%" + queryModel.exceptionMsg + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.qaStatus))
                {
                    strWhere += " AND businessExceptionMgr.qaStatus LIKE '%" + queryModel.qaStatus + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.materialStatus))
                {
                    strWhere += " AND businessExceptionMgr.materialStatus LIKE '%" + queryModel.materialStatus + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.materialCode))
                {
                    strWhere += " AND businessExceptionMgr.materialCode LIKE '%" + queryModel.materialCode + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.partName))
                {
                    strWhere += " AND businessExceptionMgr.partName LIKE '%" + queryModel.partName + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.partNumber))
                {
                    strWhere += " AND businessExceptionMgr.partNumber LIKE '%" + queryModel.partNumber + "%'";
                }
                if (queryModel.quantity != 0)
                {
                    strWhere += " AND businessExceptionMgr.quantity = " + queryModel.quantity + "";
                }

                if (!string.IsNullOrEmpty(queryModel.disposeResult))
                {
                    strWhere += " AND businessExceptionMgr.disposeResult LIKE '%" + queryModel.disposeResult + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.disposeStatus))
                {
                    strWhere += " AND businessExceptionMgr.disposeStatus LIKE '%" + queryModel.disposeStatus + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.disposeNote))
                {
                    strWhere += " AND businessExceptionMgr.disposeNote LIKE '%" + queryModel.disposeNote + "%'";
                }
                if (!string.IsNullOrEmpty(queryModel.host))
                {
                    strWhere += " AND businessExceptionMgr.host LIKE '%" + queryModel.host + "%'";
                }
            }
            return strWhere;
        }

        #endregion


        #region 增加一条业务异常管理数据

        /// <summary> 
        /// 增加一条业务异常管理数据
        /// </summary> 
        /// <param name="businessExceptionParam">要增加的业务异常管理实体</param> 
        /// <param name="creator">创建人</param> 
        /// <param name="isNeedThrowException">是否需要抛出异常</param> 
        /// <param name="isNeedSendMail">是否需要发送邮件</param> 
        /// <returns>插入的最新主键值</returns> 
        public void AddBusinessException(BusinessExceptionMgrParam businessExceptionParam, string creator,
            bool isNeedThrowException = false, bool isNeedSendMail = false)
        {
            BusinessExceptionMgrEntity businessExceptionMgr = null;
            try
            {
                businessExceptionMgr = CommonHelper.T1ToT2<BusinessExceptionMgrParam, BusinessExceptionMgrEntity>(businessExceptionParam);
                businessExceptionMgr.creator = businessExceptionMgr.lastModifier = creator;
                businessExceptionMgr.createTime = businessExceptionMgr.lastModifyTime = DateTime.Now;
                businessExceptionMgr.delFlag = false;
                businessExceptionMgr.disposeStatus = Convert.ToInt32(DisposeStatus.Undisposed).ToString();
                businessExceptionMgr.host = WIPCommon.GetHostName();
                if (string.IsNullOrEmpty(businessExceptionParam.timestamp))
                {
                    businessExceptionMgr._timestamp = DateTime.Now;
                }
                else
                {
                    businessExceptionMgr._timestamp = Convert.ToDateTime(businessExceptionParam.timestamp);
                }
                businessExceptionMgrDAL.AddByLastVersion(businessExceptionMgr);

                if (isNeedSendMail)
                {
                    Task.Run(() =>
                    {
                        //推送邮件
                        MailRuleBLL.GetInstance().MailSendingForBusinessException(businessExceptionMgr, WIPCommon.GetMailCategoryBySysIntegr(businessExceptionParam.sysCode));
                    });
                }
            }
            catch (Exception ex)
            {
                if (isNeedThrowException)
                    throw;
                Dictionary<string, object> logDict = new Dictionary<string, object>();
                logDict.Add("businessExceptionParam", businessExceptionParam);
                logDict.Add("businessExceptionMgr", businessExceptionMgr);
                logDict.Add("creator", creator);
                logDict.Add("ex", ex);
                string errMsg = "增加一条业务异常管理数据出现异常：" + JsonConvert.SerializeObject(logDict);
                Log4netHelper.WriteErrorLogByLog4Net(typeof(BusinessExceptionMgrBLL), errMsg);
            }
        }

        #endregion

    }
}
