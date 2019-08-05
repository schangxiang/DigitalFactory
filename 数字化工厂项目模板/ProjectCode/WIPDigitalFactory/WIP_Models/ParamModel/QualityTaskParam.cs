using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 质检任务发起实体
    /// </summary>
    public class QualityTaskParam
    {
        /// <summary>
        /// 生产标记
        /// </summary>
        public string prodFlag { get; set; }

        /// <summary>
        /// 质检单号
        /// </summary>
        public string taskNo { get; set; }

        /// <summary>
        /// 流转卡号
        /// </summary>
        public string processCardNumber { get; set; }

        /// <summary>
        /// 零件号
        /// </summary>
        public string partNumber { get; set; }

        /// <summary>
        /// 零件名称
        /// </summary>
        public string partName { get; set; }

        /// <summary>
        /// 检测数量
        /// </summary>
        public int quantity { get; set; }

        /// <summary>
        /// 原材料牌号
        /// </summary>
        public string typeOfSteels { get; set; }


        /// <summary>
        /// 原材料炉号
        /// </summary>
        public string steelsHeatNo { get; set; }

        /// <summary>
        /// 原材料规格
        /// </summary>
        public string steelsSize { get; set; }

        /// <summary>
        /// 本次热处理炉号
        /// </summary>
        public string heatingNumber { get; set; }

        /// <summary>
        /// 上次热处理炉号
        /// </summary>
        public string lastHeatingNumber { get; set; }

        /// <summary>
        /// 生产次数（第几次生产）
        /// </summary>
        public int prodCount { get; set; }

        /// <summary>
        /// 生产线
        /// </summary>
        public string line { get; set; }

        /// <summary>
        /// 试生产号
        /// </summary>
        public string pilotNo { get; set; }

        /// <summary>
        /// 免检未取料标识
        /// </summary>
        public string virtualTest { get; set; }

        /// <summary>
        /// 无损检测请求
        /// </summary>
        public string ndt { get; set; }

        /// <summary>
        /// 送检日期时间
        /// </summary>
        public string requestDate { get; set; }
        /// <summary>
        /// 装炉量
        /// </summary>
        public int totalPartNo { get; set; }

    }
}
