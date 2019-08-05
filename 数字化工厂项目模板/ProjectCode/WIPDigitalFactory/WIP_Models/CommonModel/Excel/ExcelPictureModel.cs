using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WIP_Models
{
    public class ExcelPictureModel
    {
        public int endColNum { get; set; }
        public int endRowNum { get; set; }
        public String qrCode { get; set; }

        /// <summary>
        /// 编码类型（一维码OR二维码）
        /// </summary>
        public string CodeType { get; set; }
    }
}
