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
    /// 热后出库流转卡打印
    /// </summary>
    public class ProcessCardPrint : PrintMgr
    {
        public ProcessCardPrint(PrintType printType)
            : base(printType)
        {
        }
        public override string GetJsonDataAsExcelCellModel(string printJson, string tempFileName)
        {
            var json_dataList = base.InitTempleteFileJsonData(tempFileName);

            ProcessCardInfoPrintModel card = JsonConvert.DeserializeObject<ProcessCardInfoPrintModel>(printJson);

            //替换数据
            /*
            json_dataList = json_dataList.Replace("[printHeader]", StringHelper.NullToEmpty(card.printHeader));
            json_dataList = json_dataList.Replace("[processCardNumber]", StringHelper.NullToEmpty(card.processCardNumber));
            json_dataList = json_dataList.Replace("[partNumber]", StringHelper.NullToEmpty(card.materialCode));//注意：这里显示的partNumber其实是物料编码 [EditBy shaocx,2019-02-18]
            json_dataList = json_dataList.Replace("[quantity]", card.quantity.ToString());
            json_dataList = json_dataList.Replace("[heatingNumber]", StringHelper.NullToEmpty(card.heatingNumber));
            json_dataList = json_dataList.Replace("[partName]", StringHelper.NullToEmpty(card.partName));
            json_dataList = json_dataList.Replace("[furnaceNumber]", StringHelper.NullToEmpty(card.furnaceNumber));
            json_dataList = json_dataList.Replace("[batchNumber]", StringHelper.NullToEmpty(card.batchNumber));
            json_dataList = json_dataList.Replace("[endProductNumber]", StringHelper.NullToEmpty(card.endProductNumber));
            json_dataList = json_dataList.Replace("[materialFurnaceNumber]", StringHelper.NullToEmpty(card.materialFurnaceNumber));
            json_dataList = json_dataList.Replace("[shipDate]", WIPCommon.FormatDateTime(card.shipDate));
            json_dataList = json_dataList.Replace("[remark]", StringHelper.NullToEmpty(card.remark));//备注
            json_dataList = json_dataList.Replace("[predictionResult]", StringHelper.NullToEmpty(card.predictionResult));//预测结果
            //*/

            //新版本替换（反射）
            json_dataList = base.Replace<ProcessCardInfoPrintModel>(card, json_dataList);
            json_dataList = json_dataList.Replace("[partNumber]", StringHelper.NullToEmpty(card.materialCode));//注意：这里显示的partNumber其实是物料编码 [EditBy shaocx,2019-02-18]

            //金相结果
            var qaStatus = "";
            if (card.qaStatus != 0)
            {
                json_dataList = json_dataList.Replace("[qaStatus]", EnumHelper.GetEnumDescription((QAStatus)Enum.Parse(typeof(QAStatus),
                    card.qaStatus.ToString())));//金相结果
            }
            else
            {
                json_dataList = json_dataList.Replace("[qaStatus]", qaStatus);//金相结果
            }
            json_dataList = json_dataList.Replace("[tester]", StringHelper.NullToEmpty(card.tester));//金相检测人


            //流转卡打印一维码
            json_dataList = json_dataList.Replace(PrintStruct.BARCODE, StringHelper.NullToEmpty(card.processCardNumber));//一维码



            //替换生产工序 
            int start = 1;
            if (card.poductProcessList != null && card.poductProcessList.Count > 0)
            {
                for (int i = 0; i < card.poductProcessList.Count; i++)
                {
                    json_dataList = json_dataList.Replace("[procedureName" + (i + 1).ToString() + "]", card.poductProcessList[i].procedureName);
                    json_dataList = json_dataList.Replace("[procedureDesc" + (i + 1).ToString() + "]", card.poductProcessList[i].procedureDesc);
                }
                start = card.poductProcessList.Count + 1;
            }
            json_dataList = Clear(start, json_dataList);
            return json_dataList;
        }

        public override bool DoByPrintResult(bool printResult, PrintInfoModel printInfo, string errMsg = "")
        {
            return base.DoByPrintResult(printResult, printInfo, errMsg);
        }

        /// <summary>
        /// 清空值
        /// </summary>
        /// <param name="json_dataList"></param>
        /// <returns></returns>
        private string Clear(int start, string json_dataList)
        {
            for (int i = start; i <= 50; i++)
            {
                json_dataList = json_dataList.Replace("[procedureName" + i.ToString() + "]", "");
                json_dataList = json_dataList.Replace("[procedureDesc" + i.ToString() + "]", "");
            }
            return json_dataList;
        }
    }
}
