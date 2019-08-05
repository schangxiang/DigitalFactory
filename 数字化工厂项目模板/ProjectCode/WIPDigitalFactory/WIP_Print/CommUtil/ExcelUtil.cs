using Aspose.Cells;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using WIP_Models;

namespace WIP_Print
{
    public class ExcelUtil
    {
        public static Dictionary<string, string> printTypeDict = new Dictionary<string, string>();//打印类型字典(Key:打印类型，Value：相应打印类型的模板ExceJSON数据)

        /// <summary>
        /// 通过模板文件获取单元格集合
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="qrCode">二维码Code</param>
        /// <returns></returns>
        public static List<ExcelCellModel> GetCellListByTemplateFile(XSSFWorkbook workbook)
        {
            XSSFSheet sheet = (XSSFSheet)workbook.GetSheetAt(0);
            List<ExcelCellModel> dataList = null;
            ExcelCellModel data = null;
            IRow row = null;
            ICell cell = null;
            ExcelPictureModel pictureModel = null;
            var columnWith = 0;
            BorderStyle[] border = new BorderStyle[4];
            try
            {
                //总行数
                int rowCount = sheet.LastRowNum;
                if (rowCount > 0)
                {
                    dataList = new List<ExcelCellModel>();
                    IRow firstRow = sheet.GetRow(0);//第一行
                    int cellCount = firstRow.LastCellNum;//总列数

                    //填充行
                    for (int i = 0; i <= rowCount; ++i)
                    {
                        //清空值
                        border = new BorderStyle[4];

                        row = sheet.GetRow(i);
                        if (row == null) continue;
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            cell = row.GetCell(j);
                            if (cell == null)
                            {

                            }
                            else
                            {
                                #region cell赋值

                                //四个边框按照 上下左右
                                border[0] = cell.CellStyle.BorderTop;
                                border[1] = cell.CellStyle.BorderBottom;
                                border[2] = cell.CellStyle.BorderLeft;
                                border[3] = cell.CellStyle.BorderRight;
                                columnWith = sheet.GetColumnWidth(j);
                                data = new ExcelCellModel()
                                {
                                    rowNum = cell.RowIndex,
                                    cellNum = cell.ColumnIndex,
                                    cellWidth = columnWith,
                                    cellHeight = row.Height,
                                    fontSize = cell.CellStyle.GetFont(workbook).FontHeightInPoints,
                                    wrapText = cell.CellStyle.WrapText,
                                    borderLine = border,
                                    Boldweight = cell.CellStyle.GetFont(workbook).IsBold,
                                    verticalAlignment = cell.CellStyle.VerticalAlignment,
                                    horizontalAlignment = cell.CellStyle.Alignment,
                                    fontName = cell.CellStyle.GetFont(workbook).FontName,
                                    //cellColor=cell.CellStyle.GetFont(workbook).Color 
                                    location = "",
                                    // regionCell=""
                                };
                                //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)
                                switch (cell.CellType)
                                {
                                    case CellType.Blank:
                                        data.cellValue = "";
                                        break;
                                    case CellType.Numeric:
                                        short format = cell.CellStyle.DataFormat;
                                        //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                        if (format == 14 || format == 31 || format == 57 || format == 58)
                                            data.cellValue = cell.DateCellValue.ToString();
                                        else
                                            data.cellValue = cell.NumericCellValue.ToString();
                                        break;
                                    case CellType.String:
                                        data.cellValue = cell.StringCellValue;
                                        break;
                                }


                                //二维码单独处理
                                if (data.cellValue == PrintStruct.QRCODE)
                                {
                                    pictureModel = new ExcelPictureModel()
                                    {
                                        endColNum = data.cellNum,
                                        endRowNum = data.rowNum,
                                        qrCode = PrintStruct.QRCODE,
                                        CodeType = PrintStructFlag.QRCODE
                                    };
                                    data.excelPictureModel = pictureModel;
                                }

                                //一维码单独处理
                                if (data.cellValue == PrintStruct.BARCODE)
                                {
                                    pictureModel = new ExcelPictureModel()
                                    {
                                        endColNum = data.cellNum,
                                        endRowNum = data.rowNum,
                                        qrCode = PrintStruct.BARCODE,
                                        CodeType = PrintStructFlag.BARCODE
                                    };
                                    data.excelPictureModel = pictureModel;
                                }

                                #endregion
                                dataList.Add(data);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dataList;
        }

        /// <summary>
        /// 通过模板生成EXCEL
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="dataList">sheet集合</param>
        /// <param name="temName">模板名称</param>
        /// <returns></returns>
        public static byte[] writeExcelToFile(XSSFWorkbook workbook, List<ExcelSheetModel> dataList, String temName)
        {
            // 列宽一个像素的固定值
            //decimal pixCellConst = 31.94888178913738m;
            // 行宽一个像素的固定值
            //decimal pixRowConst = 15.15151515151515m;
            String location = null;
            XSSFRow row = null;


            foreach (ExcelSheetModel dataSheet in dataList)
            {

                if (!string.IsNullOrEmpty(dataSheet.sheetType))
                {


                }
                else
                {
                    #region 自定义模式

                    XSSFSheet sheet = (XSSFSheet)workbook.GetSheet(dataSheet.sheetName);
                    // 自动更新公式
                    sheet.ForceFormulaRecalculation = true;
                    foreach (ExcelCellModel dataCell in dataSheet.dataList)
                    {

                        if (!string.IsNullOrEmpty(dataCell.location))
                        {

                            location = dataCell.location.ToUpper();
                            int dataNum = 0;
                            int dataRow = 0;
                            string rowStr = "";
                            string columnStr = "";

                            for (int i = 0; i < location.Length; i++)
                            {
                                var locationArr = location.ToCharArray();
                                if (locationArr[i] >= 48 && locationArr[i] <= 57)
                                {
                                    columnStr += locationArr[i];
                                }
                                if (locationArr[i] >= 65 && locationArr[i] <= 90)
                                {
                                    rowStr += locationArr[i];
                                }
                            }
                            for (int i = 0; i < rowStr.Length; i++)
                            {
                                var rowStrArr = rowStr.ToCharArray();
                                char ch = rowStrArr[rowStr.Length - i - 1];
                                dataNum = (int)(ch - 'A' + 1);
                                dataNum *= int.Parse(Math.Pow(26, i).ToString());
                                dataRow += dataNum;
                            }

                            dataCell.rowNum = int.Parse(columnStr) - 1;
                            dataCell.cellNum = dataRow - 1;
                        }

                        //logger.Debug(dataSheet.sheetName + "->Row:" + dataCell.rowNum + "->Cell:"
                        //+ dataCell.cellNum + "->Strat");

                        XSSFCellStyle setBorder = (XSSFCellStyle)workbook.CreateCellStyle();
                        XSSFFont font = (XSSFFont)workbook.CreateFont();
                        XSSFColor fontColor = null;
                        XSSFColor backColor = null;
                        if (row == null || row.RowNum != dataCell.rowNum)
                        {

                            row = (XSSFRow)sheet.GetRow(dataCell.rowNum);
                        }

                        XSSFCell cell = (XSSFCell)row.CreateCell(dataCell.cellNum);

                        // check合并单元格
                        if (dataCell.regionCell != null)
                        {

                            if (dataCell.regionCell.Length == 2)
                            {

                                if (dataCell.rowNum > dataCell.regionCell[0])
                                {

                                    //logger.Debug("RegionCella结束行小于当前行");

                                }
                                else if (dataCell.cellNum > dataCell.regionCell[1])
                                {

                                    //logger.Debug("RegionCella结束列小于当前列");

                                }
                                else
                                {

                                    sheet.AddMergedRegion(
                                            new CellRangeAddress(dataCell.rowNum, dataCell.regionCell[0],
                                                    dataCell.cellNum, dataCell.regionCell[1]));
                                }

                            }
                            else
                            {

                                //logger.Debug("RegionCell参数异常");
                            }
                        }

                        // check列宽
                        if (dataCell.cellWidth != 0)
                        {
                            /*
                            sheet.SetColumnWidth(dataCell.cellNum,
                                    int.Parse(decimal.Multiply(pixCellConst, decimal.Parse(dataCell.cellWidth.ToString())).ToString()));
                            //*/
                            /*
                             sheet.SetColumnWidth(dataCell.cellNum,
                                    Convert.ToInt32(decimal.Multiply(pixCellConst, decimal.Parse(dataCell.cellWidth.ToString()))));
                            //*/
                            sheet.SetColumnWidth(dataCell.cellNum, dataCell.cellWidth);
                        }

                        // check行高
                        if (dataCell.cellHeight != 0)
                        {
                            row.Height = dataCell.cellHeight;
                        }

                        // check字体颜色
                        if (dataCell.cellColor != null)
                        {

                            if (dataCell.cellColor.Length == 3)
                            {

                                if (((dataCell.cellColor[0] >= 0) || (dataCell.cellColor[0] <= 255))
                                        && ((dataCell.cellColor[1] >= 0) || (dataCell.cellColor[1] <= 255))
                                        && ((dataCell.cellColor[2] >= 0) || (dataCell.cellColor[2] <= 255)))
                                {

                                    fontColor = new XSSFColor(Color.FromArgb(dataCell.cellColor[0],
                                            dataCell.cellColor[1], dataCell.cellColor[2]));

                                    font.SetColor(fontColor);
                                }
                            }
                        }

                        // check背景色
                        if (dataCell.backColor != null)
                        {

                            if (dataCell.backColor.Length == 3)
                            {

                                if (((dataCell.backColor[0] >= 0) || (dataCell.backColor[0] <= 255))
                                        && ((dataCell.backColor[1] >= 0) || (dataCell.backColor[1] <= 255))
                                        && ((dataCell.backColor[2] >= 0) || (dataCell.backColor[2] <= 255)))
                                {

                                    backColor = new XSSFColor(Color.FromArgb(dataCell.backColor[0],
                                            dataCell.backColor[1], dataCell.backColor[2]));

                                    setBorder.FillPattern = FillPattern.SolidForeground;
                                    setBorder.SetFillForegroundColor(backColor);
                                }
                            }
                        }

                        // check边框
                        if (dataCell.borderLine != null)
                        {

                            if (dataCell.borderLine.Length == 4)
                            {

                                setBorder.BorderTop = dataCell.borderLine[0];
                                setBorder.BorderBottom = dataCell.borderLine[1];
                                setBorder.BorderLeft = dataCell.borderLine[2];
                                setBorder.BorderRight = dataCell.borderLine[3];
                            }
                        }

                        // check字体
                        if (!string.IsNullOrEmpty(dataCell.fontName))
                        {

                            font.FontName = dataCell.fontName;
                        }
                        else
                        {

                            font.FontName = "宋体";
                        }

                        // check字体大小
                        if (dataCell.fontSize != 0)
                        {

                            font.FontHeightInPoints = dataCell.fontSize;
                        }
                        else
                        {

                            font.FontHeightInPoints = (short)10;
                        }

                        // 字体是否加粗
                        if (dataCell.Boldweight)
                        {

                            font.IsBold = true;
                        }

                        // 是否自动换行
                        if (dataCell.wrapText)
                        {

                            setBorder.WrapText = true;
                        }

                        // 单元格的值
                        if (!string.IsNullOrEmpty(dataCell.cellValue))
                        {

                            cell.SetCellValue(dataCell.cellValue);
                        }
                        else
                        {

                            cell.SetCellValue("");
                        }

                        // 水平类型
                        setBorder.Alignment = dataCell.horizontalAlignment;

                        // 垂直类型
                        setBorder.VerticalAlignment = dataCell.verticalAlignment;


                        // 图片
                        if (dataCell.excelPictureModel != null)
                        {
                            int col2 = 0;
                            int row2 = 0;
                            byte[] arr = null;
                            if (dataCell.excelPictureModel.CodeType == PrintStructFlag.QRCODE)
                            {//二维码
                                MemoryStream pictureIS = QRCodeUtil.GetQRCode(dataCell.excelPictureModel.qrCode);
                                arr = new byte[pictureIS.Length];
                                pictureIS.Position = 0;
                                pictureIS.Read(arr, 0, (int)pictureIS.Length);
                                pictureIS.Close();

                                col2 = dataCell.excelPictureModel.endColNum + 1;
                                row2 = dataCell.excelPictureModel.endRowNum + 1;
                            }
                            else if (dataCell.excelPictureModel.CodeType == PrintStructFlag.BARCODE)
                            { //一维码
                                BarCodeClass bc = new BarCodeClass();
                                Image image = bc.ZXCreateBarCode(dataCell.excelPictureModel.qrCode);
                                ImageConverter imgconv = new ImageConverter();
                                arr = (byte[])imgconv.ConvertTo(image, typeof(byte[]));

                                col2 = dataCell.excelPictureModel.endColNum + 4;
                                row2 = dataCell.excelPictureModel.endRowNum + 1;
                            }

                            int pIndex = workbook.AddPicture(arr, NPOI.SS.UserModel.PictureType.JPEG);
                            XSSFDrawing patriarch = (XSSFDrawing)sheet.CreateDrawingPatriarch();
                            XSSFClientAnchor anchor = new XSSFClientAnchor(0, 0, 0, 0, dataCell.cellNum,
                                    dataCell.rowNum,
                                    col2,
                                    row2);
                            patriarch.CreatePicture(anchor, pIndex);
                        }

                        setBorder.SetFont(font);
                        cell.CellStyle = setBorder;
                        //logger.Debug(dataSheet.sheetName + "->Row:" + dataCell.rowNum + "->Cell:"
                        //+ dataCell.cellNum + "->End");
                    }

                    #endregion

                }
            }

            string filePath = System.Threading.Thread.GetDomain().BaseDirectory + "\\";
            var new_tempFileName = "to_" + temName + ".xlsx";
            FileStream files = new FileStream(filePath + @"PrintTemplete\" + new_tempFileName, FileMode.Create);
            workbook.Write(files);
            files.Close();
            files = new FileStream(filePath + @"PrintTemplete\" + new_tempFileName, FileMode.OpenOrCreate);
            byte[] bytes = new byte[files.Length];
            files.Read(bytes, 0, bytes.Length);
            files.Close();
            workbook.Close();

            return bytes;
        }

    }
}
