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
    /// 初始化库存信息（热后立库）
    /// </summary>
    [DataContract]
    public class InitInventoryForPostHeatParam
    {

        /// <summary>
        /// 批次号（唯一）
        /// </summary>
        [DataMember]
        public string batchNumber { get; set; }


        /// <summary>
        /// 物料编码
        /// </summary>
        [DataMember]
        public string materialCode { get; set; }

        /// <summary>
        /// 零件号
        /// </summary>
        [DataMember]
        public string partNumber { get; set; }

        /// <summary>
        /// 零件名称
        /// </summary>
        [DataMember]
        public string partName { get; set; }

        /// <summary>
        /// 流转卡号
        /// </summary>
        [DataMember]
        public string processCardNumber { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public int quantity { get; set; }

    }
}