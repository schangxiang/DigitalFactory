using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary>
    /// 流转卡信息实体打印类
    /// </summary>
    [DataContract]
    public class ProcessCardInfoPrintModel
    {

        /// <summary>
        /// 金相结果
        /// </summary>
        [DataMember]
        [Print]
        public int qaStatus { get; set; }


        /// <summary>
        /// 预测结果(1：建议免检，2：建议检测)
        /// </summary>
        [DataMember]
        [Print]
        public string predictionResult { get; set; }

        /// <summary>
        /// 金相检测人
        /// </summary>
        [DataMember]
        [Print]
        public string tester { get; set; }

        /// <summary>
        /// 打印类别（枚举printCategory）
        /// </summary>
        [DataMember]
        [Print]
        public int printCategory { get; set; }

        /// <summary>
        /// 流转卡打印队列表ID（用于删除流转卡打印队列数据）
        /// </summary>
        [DataMember]
        [Print]
        public int processCardPrintQueueId { get; set; }

        /// <summary>
        /// 打印头部信息（用于显示区分 返修、出库类型、报废等信息）
        /// </summary>
        [DataMember]
        [Print]
        public string printHeader { get; set; }

        /// <summary>
        /// 生产工序列表
        /// </summary>
        [DataMember]
        [Print]
        public List<PoductionProcessModel> poductProcessList { get; set; }


        /// <summary>
        /// 流转卡号
        /// </summary>
        [DataMember]
        [Print]
        public string processCardNumber { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        [DataMember]
        [Print]
        public string materialCode { get; set; }

        /// <summary>
        /// 零件号
        /// </summary>
        [DataMember]
        [Print]
        public string partNumber { get; set; }

        /// <summary>
        /// 零件名称
        /// </summary>
        [DataMember]
        [Print]
        public string partName { get; set; }

        /// <summary>
        /// 成品零件号
        /// </summary>
        [DataMember]
        [Print]
        public string endProductNumber { get; set; }

        /// <summary>
        /// 加工数量
        /// </summary>
        [DataMember]
        [Print]
        public int quantity { get; set; }

        /// <summary>
        /// 正火炉号
        /// </summary>
        [DataMember]
        [Print]
        public string furnaceNumber { get; set; }

        /// <summary>
        /// 材料炉号
        /// </summary>
        [DataMember]
        [Print]
        public string materialFurnaceNumber { get; set; }

        /// <summary>
        /// 来料批次号
        /// </summary>
        [DataMember]
        [Print]
        public string batchNumber { get; set; }

        /// <summary>
        /// 发货日期
        /// </summary>
        [DataMember]
        [Print]
        public DateTime? shipDate { get; set; }

        /// <summary>
        /// 热处理炉号
        /// </summary>
        [DataMember]
        [Print]
        public string loadNumber { get; set; }


        /// <summary>
        /// 流转卡中填入的热处理炉号，用于流转卡打印时的展示
        /// </summary>
        [DataMember]
        [Print]
        public string heatingNumber { get; set; }

        /// <summary>
        /// 生产线
        /// </summary>
        [DataMember]
        [Print]
        public string line { get; set; }

        /// <summary>
        /// 包装卡号
        /// </summary>
        [DataMember]
        [Print]
        public string packageNumber { get; set; }

        /// <summary>
        /// 试生产号
        /// </summary>
        [DataMember]
        [Print]
        public string pilotNo { get; set; }

        /// <summary>
        /// 原材料牌号
        /// </summary>
        [DataMember]
        [Print]
        public string typeOfSteels { get; set; }

        /// <summary>
        /// 原材料炉号
        /// </summary>
        [DataMember]
        [Print]
        public string steelsHeatNo { get; set; }

        /// <summary>
        /// 原材料规格
        /// </summary>
        [DataMember]
        [Print]
        public string steelsSize { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        [Print]
        public string remark { get; set; }


    }
}