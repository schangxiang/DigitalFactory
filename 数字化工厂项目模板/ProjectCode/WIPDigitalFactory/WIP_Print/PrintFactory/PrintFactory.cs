using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_Models;

namespace WIP_Print
{
    public class PrintFactory
    {
        public PageOrientationType orientation = PageOrientationType.Portrait;//打印方向，默认纵向
        public PrintMgr GetPrintMgr(PrintType printType)
        {
            PrintMgr printMgr = null;
            switch (printType)
            {
                case PrintType.ProcessCardForPostHeatStorageOut:
                case PrintType.ProcessCardForBuffer:
                case PrintType.ProcessCardForWCSByWhGate1:
                case PrintType.ProcessCardForWCSByWhGate3:
                    printMgr = new ProcessCardPrint(printType);
                    break;
                case PrintType.InspectOrder://人工抽检位送检单
                case PrintType.InspectOrderForReject://不良品打印送检单
                    printMgr = new InspectOrderPrint(printType);
                    orientation = PageOrientationType.Landscape;//横向打印
                    break;
            }
            return printMgr;
        }
    }
}
