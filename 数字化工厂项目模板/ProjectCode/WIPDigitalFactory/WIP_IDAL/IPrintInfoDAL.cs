using SysManager.DB.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_Models;

namespace WIP_IDAL
{
    public interface IPrintInfoDAL
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
         int Add(PrintInfoEntity model, TransactionModel transModel = null);


        /// <summary>
        /// 获取需要打印的数据列表(Service)
        /// </summary>
        /// <param name="printTypeStr">打印类型集合</param>
        /// <returns></returns>
         DataSet GetNeedPrintList(string printTypeStr);

        /// <summary>
        /// 重置打印状态
        /// </summary>
        /// <param name="processCardNumber">流转卡号</param>
        /// <param name="id">打印ID</param>
        /// <returns>处理结果</returns>
         ProcResultModel RestPrint(string processCardNumber, int id);

        /// <summary>
        /// 更新打印结果
        /// </summary>
        /// <param name="parameters_UpdatePrintResult"></param>
        /// <param name="transModel"></param>
        /// <returns></returns>
         int UpdatePrintResult(SqlParameter[] parameters_UpdatePrintResult, TransactionModel transModel);

    }
}
