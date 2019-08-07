using SysManager.Common.Utilities;
using SysManager.DB.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WIP_Models;


namespace WIP_IDAL
{
    public interface ICommonDAL
    {

        /// <summary>
        /// 清除数据
        /// </summary>
        /// <param name="procName">存储过程名</param>
        void ClearData(string procName);



        /// <summary>
        /// 初始化快照数据
        /// </summary>
        /// <returns></returns>
        ProcResultModel InitDayReportData(int year, int month, int day, string dayValue);



        /// <summary>
        /// 清空表
        /// </summary>
        /// <param name="tableName">要清空的表名</param>
        /// <returns></returns>
        bool TruncateTable(string tableName);


        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="updateArr">要更新的列集合</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        bool UpdateExtend(List<PropertyParam> updateArr, string tableName, TransactionModel transModel = null);


        /// <summary>
        /// 更新一条数据的sql参数
        /// </summary>
        /// <param name="updateArr">要更新的列集合</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        SqlParam GetStr_UpdateExtend(List<PropertyParam> updateArr, string tableName);

        /// <summary>
        /// 删除数据的sql参数
        /// </summary>
        /// <param name="tableName">要删除的表名</param>
        /// <param name="delName">要删除关联的表字段名</param>
        /// <param name="rowId">要删除的关联id</param>
        /// <returns></returns>
        SqlParam GetStr_DeleteExtend(string tableName, string delName, int rowId);


        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="sqlParamList"></param>
        void ExecuteSqlTranList(List<SqlParam> sqlParamList);



        /// <summary>
        /// 生成顺序号
        /// </summary>
        /// <param name="serialNoType"></param>
        /// <returns></returns>
        string GetSerialNo(SerialNoType serialNoType);



        #region 查找 MaterialCode(下发排产任务使用)

        /// <summary>
        /// 查找 MaterialCode(下发排产任务使用)
        /// </summary>
        /// <param name="partNumber">零件号</param>
        /// <param name="heatingOutCode">出热物料号</param>
        /// <param name="quantity">数量</param>
        /// <returns>进热物料号(即MaterialCode)</returns>
        string GetMaterialCodeForIssueTask(string partNumber, string heatingOutCode, int quantity);



        #endregion


        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        List<UserInfoLogon> GetUserAccountView();





        #region 获取邮箱基础数据配置

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        List<MailBaseData> GetMailBaseData();


        #endregion
    }
}
