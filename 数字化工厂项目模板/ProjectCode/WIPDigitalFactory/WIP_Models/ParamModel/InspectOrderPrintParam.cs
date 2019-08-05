using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 送检单打印模板对象
    /// </summary>
    public class InspectOrderPrintParam
    {
        /// <summary>
        /// 质检单号
        /// </summary>
        [PrintAttribute]
        public string taskNo { get; set; }

        /// <summary>
        /// 流转卡号
        /// </summary>
        [PrintAttribute]
        public string processCardNumber { get; set; }

        /// <summary>
        /// 流转卡中填入的热处理炉号，用于流转卡打印时的展示
        /// </summary>
        [PrintAttribute]
        public string heatingNumber { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        [PrintAttribute]
        public string materialCode { get; set; }



        /// <summary>
        /// 零件号
        /// </summary>
        [PrintAttribute]
        public string partNumber { get; set; }

        /// <summary>
        /// 零件名称
        /// </summary>
        [PrintAttribute]
        public string partName { get; set; }

        /// <summary>
        /// 原材料牌号
        /// </summary>
        [PrintAttribute]
        public string typeOfSteels { get; set; }


        /// <summary>
        /// 原材料炉号
        /// </summary>
        [PrintAttribute]
        public string steelsHeatNo { get; set; }

        /// <summary>
        /// 原材料规格
        /// </summary>
        [PrintAttribute]
        public string steelsSize { get; set; }

        /// <summary>
        /// 热处理炉号
        /// </summary>
        [PrintAttribute]
        public int? loadNumber { get; set; }


        /// <summary>
        /// 试生产号
        /// </summary>
        [PrintAttribute]
        public string pilotNo { get; set; }


        /// <summary>
        /// 送检日期时间
        /// </summary>
        [PrintAttribute]
        public string requestDate { get; set; }

        /// <summary>
        /// 送检次数
        /// </summary>
        [PrintAttribute]
        public int inspectCount { get; set; }

    }
}
