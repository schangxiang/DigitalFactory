using Newtonsoft.Json;
using System;
using WIP_DAL;
using WIP_Models;

namespace WIP_common
{
    /// <summary>
    /// 顺序号生成帮助
    /// </summary>
    public class SerialNumberHelper
    {
        /// <summary>
        /// 生成顺序号
        /// </summary>
        /// <param name="serialNoType">顺序号类型</param>
        /// <returns></returns>
        public static string GenerateSerialNumber(SerialNoType serialNoType)
        {
            var newTaskNo = "";
            switch (serialNoType)
            {
                case SerialNoType.HandInStoreNo:
                    newTaskNo = "HI";
                    break;
                case SerialNoType.HandInHeatAfterStoreNo:
                    newTaskNo = "HIA";
                    break;
                case SerialNoType.RepairSerialNo:
                    newTaskNo = "R";
                    break;
                case SerialNoType.ScrapSerialNo:
                    newTaskNo = "S";
                    break;
                case SerialNoType.LockMatericalNo://锁定物料任务号
                    newTaskNo = "LOCK";
                    break;
                default:
                    newTaskNo = "";
                    break;
            }
            newTaskNo += DALCommon.GetSerialNo(serialNoType);
            return newTaskNo;
        }
    }
}
