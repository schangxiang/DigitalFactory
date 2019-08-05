using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 基础数据同步参数类
    /// </summary>
    public class BaseDataSynParamModel
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 物料编码（进热MES物料号）
        /// </summary>
        public string materialCode { get; set; }


        /// <summary>
        /// 出热MES物料号
        /// </summary>
        public string heatingOutCode { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string materailName { get; set; }


          /// <summary>
        /// 物料来源
        /// </summary>
        public string source { get; set; }


        /// <summary>
        /// 零件号
        /// </summary>
        public string partNumber { get; set; }


        /// <summary>
        /// 材料
        /// </summary>
        public string material { get; set; }


        /// <summary>
        /// 齿轮模数
        /// </summary>
        public int gearModulus { get; set; }

        /// <summary>
        /// 重量（Kg）
        /// </summary>
        public decimal weight { get; set; }

        /// <summary>
        /// 表面积(mm2)
        /// </summary>
        public decimal surfaceArea { get; set; }

        /// <summary>
        /// 体积(mm3)
        /// </summary>
        public decimal volume { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public decimal height { get; set; }

        /// <summary>
        /// 内圈直径
        /// </summary>
        public decimal innerringdiameter { get; set; }

        /// <summary>
        /// 外圈直径
        /// </summary>
        public decimal outerringdiameter { get; set; }

        /// <summary>
        /// 装夹方式
        /// </summary>
        public string clamping { get; set; }



        #region 生产线和装炉量

        /// <summary>
        /// 1号线装炉数量
        /// </summary>
        public int ECM_LINE1 { get; set; }

        /// <summary>
        /// 2号线装炉数量
        /// </summary>
        public int ECM_LINE2 { get; set; }

        /// <summary>
        /// 3号线装炉数量
        /// </summary>
        public int ECM_LINE3 { get; set; }

        /// <summary>
        /// 4号线装炉数量
        /// </summary>
        public int ECM_LINE4 { get; set; }

        /// <summary>
        /// 5号线装炉数量
        /// </summary>
        public int ECM_LINE5 { get; set; }



        #endregion

        /// <summary>
        /// DCT250或者GFX
        /// </summary>
        public string classification { get; set; }

        /// <summary>
        /// 物料出热后方向(下道)
        /// </summary>
        public string direction { get; set; }


        /// <summary>
        /// 物料出ECM后的去向(缓存区去向：B 热后立库去向：W)
        /// </summary>
        public string directionHeating { get; set; }

    }
}
