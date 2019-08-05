using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using WIP_Models;

namespace WIP_Models
{
    /// <summary>
    /// 测试初始化质量预测数据参数
    /// </summary>
    [DataContract]
    public class TestInitInspectionSummaryParam
    {

        /// <summary>
        /// 生产线
        /// </summary>
        [DataMember]
        public string line { get; set; }

        /// <summary>
        /// 热处理炉号
        /// </summary>
        [DataMember]
        public int loadNumber { get; set; }

    }
}