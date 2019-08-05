using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WIP_Models
{
    public class ExcelCellModel
    {
        public String location{get;set;}

        public int rowNum { get; set; }

        public int cellNum { get; set; }

        public int cellWidth { get; set; }

        public short cellHeight { get; set; }

        public short fontSize { get; set; }

        public String cellValue { get; set; }

        public int[] cellColor { get; set; }

        public String fontName { get; set; }

        public bool wrapText { get; set; }

        public int[] backColor { get; set; }

        public BorderStyle[] borderLine { get; set; }

        public int[] regionCell { get; set; }

        public bool Boldweight { get; set; }

        public HorizontalAlignment horizontalAlignment { get; set; }

        public VerticalAlignment verticalAlignment { get; set; }

        public ExcelPictureModel excelPictureModel { get; set; }
    }
}
