using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    public struct ResCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const string SUCCESS = "00000";

        /// <summary>
        /// 失败
        /// </summary>
        public const string FAILURE = "00001";

        /// <summary>
        /// 超时
        /// </summary>
        public const string OUTTIME = "00002";

        /// <summary>
        /// 通信异常
        /// </summary>
        public const string COMMUNICATIONEXCEPTION = "00003";

        /// <summary>
        /// 参数不能为空
        /// </summary>
        public const string PARAMETERNOEMPTY = "01001";

        /// <summary>
        /// 参数错误
        /// </summary>
        public const string PARAMETERERROR = "01002";
    }

    public struct ResMsg
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const string SUCCESS = "成功";

        /// <summary>
        /// 失败
        /// </summary>
        public const string FAILURE = "失败";

        /// <summary>
        /// 超时
        /// </summary>
        public const string OUTTIME = "超时";

        /// <summary>
        /// 通信异常
        /// </summary>
        public const string COMMUNICATIONEXCEPTION = "通信异常";

        /// <summary>
        /// 参数不能为空
        /// </summary>
        public const string PARAMETERNOEMPTY = "参数不能为空";

        /// <summary>
        /// 参数错误
        /// </summary>
        public const string PARAMETERERROR = "参数错误";
    }
}
