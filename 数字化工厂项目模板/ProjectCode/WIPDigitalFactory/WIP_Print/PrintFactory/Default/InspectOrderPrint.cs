using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SysManager.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_common;
using WIP_Models;

namespace WIP_Print
{
    /// <summary>
    /// 送检单打印
    /// </summary>
    public class InspectOrderPrint : PrintMgr
    {
        public InspectOrderPrint(PrintType printType)
            : base(printType)
        {
            
        }
        public override string GetJsonDataAsExcelCellModel(string printJson, string tempFileName)
        {
            var json_dataList = base.InitTempleteFileJsonData(tempFileName);

            InspectOrderPrintParam inspectOrderPrintParam = JsonConvert.DeserializeObject<InspectOrderPrintParam>(printJson);
            if (inspectOrderPrintParam == null)
            {
                throw new Exception("转换送检单对象为NULL");
            }

            //替换数据
            /*
            json_dataList = json_dataList.Replace("[taskNo]", StringHelper.NullToEmpty(inspectOrderPrintParam.taskNo));
            json_dataList = json_dataList.Replace("[processCardNumber]", StringHelper.NullToEmpty(inspectOrderPrintParam.processCardNumber));
            json_dataList = json_dataList.Replace("[heatingNumber]", StringHelper.NullToEmpty(inspectOrderPrintParam.heatingNumber));
            json_dataList = json_dataList.Replace("[requestDate]", StringHelper.NullToEmpty(inspectOrderPrintParam.requestDate));
            json_dataList = json_dataList.Replace("[partNumber]", StringHelper.NullToEmpty(inspectOrderPrintParam.materialCode));//注意：这里显示的partNumber其实是物料编码 [EditBy shaocx,2019-02-18]
            json_dataList = json_dataList.Replace("[loadNumber]", inspectOrderPrintParam.loadNumber == null ? "" : inspectOrderPrintParam.loadNumber.ToString());
            json_dataList = json_dataList.Replace("[partName]", StringHelper.NullToEmpty(inspectOrderPrintParam.partName));
            json_dataList = json_dataList.Replace("[typeOfSteels]", StringHelper.NullToEmpty(inspectOrderPrintParam.typeOfSteels));
            json_dataList = json_dataList.Replace("[steelsHeatNo]", StringHelper.NullToEmpty(inspectOrderPrintParam.steelsHeatNo));
            json_dataList = json_dataList.Replace("[steelsSize]", StringHelper.NullToEmpty(inspectOrderPrintParam.steelsSize));
            json_dataList = json_dataList.Replace("[pilotNo]", StringHelper.NullToEmpty(inspectOrderPrintParam.pilotNo));
            json_dataList = json_dataList.Replace("[inspectCount]", inspectOrderPrintParam.inspectCount.ToString());

            json_dataList = json_dataList.Replace(PrintStruct.QRCODE, StringHelper.NullToEmpty(inspectOrderPrintParam.taskNo));//二维码

            //*/

            //最新版(使用反射)
            json_dataList = base.Replace<InspectOrderPrintParam>(inspectOrderPrintParam, json_dataList);
            json_dataList = json_dataList.Replace("[partNumber]", StringHelper.NullToEmpty(inspectOrderPrintParam.materialCode));//注意：这里显示的partNumber其实是物料编码 [EditBy shaocx,2019-02-18]
            json_dataList = json_dataList.Replace(PrintStruct.QRCODE, StringHelper.NullToEmpty(inspectOrderPrintParam.taskNo));//二维码

            return json_dataList;
        }

        public override bool DoByPrintResult(bool printResult, PrintInfoModel printInfo, string errMsg = "")
        {
            return base.DoByPrintResult(printResult, printInfo, errMsg);
        }

    }
}
