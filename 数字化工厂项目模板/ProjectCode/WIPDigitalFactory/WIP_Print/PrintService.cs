using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_BLL;
using WIP_Models;

namespace WIP_Print
{
    public class PrintService
    {

        #region 单例模式

        private static PrintService _instance = null;
        private PrintService() { }
        static PrintService()
        {
            _instance = new PrintService();
        }

        public static PrintService GetInstance()
        {
            return _instance;
        }

        #endregion

        private readonly PrintInfoBLL printBll = PrintInfoBLL.GetInstance();

        public void Print()
        {
            try
            {
                List<PrintInfoModel> printInfoList = printBll.GetNeedPrintList();
                if (printInfoList != null)
                {
                    PrintFactory printFactory = null;
                    PrintMgr printMgr = null;
                    string json_cellList = null;
                    PrintType printType = default(PrintType);
                    foreach (var item in printInfoList)
                    {
                        printType = (PrintType)Enum.Parse(typeof(PrintType), item.printType);
                        printFactory = new PrintFactory();
                        printMgr = printFactory.GetPrintMgr(printType);
                        json_cellList = printMgr.GetJsonDataAsExcelCellModel(item.printJson, item.tempName);
                        printMgr.Print(json_cellList, item, printFactory.orientation);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
