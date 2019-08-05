using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 基础数据同步结果类
    /// </summary>
    public class BaseDataSynResultModel
    {
        /// <summary>
        /// 成功数
        /// </summary>
        public int SuccessCount { get; set; }

        /// <summary>
        /// 失败数
        /// </summary>
        public int FailureCount { get; set; }

        /// <summary>
        /// 成功的物料号集合
        /// </summary>
        public List<string> SuccessMaterial { get; set; }

        /// <summary>
        /// 失败的物料号集合
        /// </summary>
        public List<FailureSaveMaterial> FailureMaterial { get; set; }

    }

    public class FailureSaveMaterial
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string materialCode { get; set; }

        /// <summary>
        /// 错误ID
        /// </summary>
        public int UID { get; set; }


        public string failureReason { get; set; }

        /// <summary>
        /// 失败号
        /// </summary>
        public string failureCode { get; set; }
    }

    public struct failureCode
    {
        /// <summary>
        /// 零件号为空
        /// </summary>
        public const string empty = "001";

        /// <summary>
        /// 零件号长度小于8位
        /// </summary>
        public const string leng8 = "002";

        /// <summary>
        /// 保存失败
        /// </summary>
        public const string savefail = "003";

        /// <summary>
        /// 创建物料失败
        /// </summary>
        public const string creatfail = "004";
    }
}
