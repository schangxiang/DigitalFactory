using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WIP_Models
{
    public class ExcelSheetModel
    {
        public String sheetName { get; set; }

        public List<ExcelCellModel> dataList { get; set; }

        public String configId { get; set; }

        public String[] titleArray { get; set; }

        public List<String[]> dataArrList { get; set; }

        //为null自定义模式,1:固定title模式
        public String sheetType { get; set; }
    }
}
