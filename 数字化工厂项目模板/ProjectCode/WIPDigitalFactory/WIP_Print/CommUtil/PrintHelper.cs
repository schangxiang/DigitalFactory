using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Drawing.Printing;
using Aspose.Cells;
using Aspose.Cells.Rendering;
using System.IO;
using WIP_common;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace WIP_Print
{
    public static class PrintHelper
    {
        public static string appPath;
        public static Dictionary<string, string> printDevKeyDic;
        public static string defaultPrint;
        public static PrintDocument fPrintDocument = new PrintDocument();
        public static string connStr;

        /// <summary>
        /// 打印Excel
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="printName"></param>
        ///  <param name="orientation">打印方向,默认纵向</param>
        public static void PrintExcel(byte[] bs, string printName, PageOrientationType orientation)
        {
            string printArea = "";//默认
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream(bs);
                Workbook workbook = new Workbook(ms);
                Worksheet worksheet = workbook.Worksheets[0];
                //打印设置
                PageSetup pageSetup = worksheet.PageSetup;
                pageSetup.CenterHorizontally = true;//水平居中
                pageSetup.CenterVertically = false;//不需要垂直居中
                if (printArea != "")
                {
                    //pageSetup.PrintArea = "A1:I22";
                }

                pageSetup.Orientation =orientation;
                // pageSetup.Orientation = PageOrientationType.Landscape;//横向
                // pageSetup.Orientation = PageOrientationType.Portrait;//纵向

                ImageOrPrintOptions options = new ImageOrPrintOptions();
                System.Drawing.Printing.PrinterSettings printSettings = new System.Drawing.Printing.PrinterSettings();

                defaultPrint = fPrintDocument.PrinterSettings.PrinterName;
                //defaultPrint = @"\\prtsvr\MP 3054 PCL 6 jszx";
                //new Log4netHelper().AddLog("默认打印机名称是:"+defaultPrint);

                SheetRender sr = new SheetRender(worksheet, options);
                if (printName != "")
                {
                    sr.ToPrinter(printName);
                }
                else
                {
                    sr.ToPrinter(defaultPrint);
                }
            }
            catch
            {
                throw;
            }
            finally
            {

                GC.Collect(); //垃圾回收机制
                if (ms != null)
                    ms.Close();
            }
        }
    }
}
