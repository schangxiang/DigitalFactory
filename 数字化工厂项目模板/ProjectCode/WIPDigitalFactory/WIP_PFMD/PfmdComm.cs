using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_common;

namespace WIP_PFMD
{
    public class PfmdComm
    {
        public GEBF.BrilliantFactoryClient bfclient;
        public PfmdComm(string GEBFUrl)
        {
            bfclient = new GEBF.BrilliantFactoryClient("BasicHttpBinding_IBrilliantFactory", GEBFUrl);
            bfclient.ClientCredentials.UserName.UserName = "GESystem";
            bfclient.ClientCredentials.UserName.Password = "proficy";
            Util.SetCertificatePolicy();//绕过验证，正式发布的时候注释掉 【2018-07-27】
        }

        /// <summary>
        /// 根据立库查找立库自动化出口
        /// </summary>
        /// <param name="prodlineName">立库</param>
        /// <returns>立库自动化出口名称</returns>
        public string GetAutoExitByProdLineForWCS(string prodlineName)
        {
            return bfclient.GetAutoExitByProdLineForWCS(prodlineName);
        }

        /// <summary>
        /// 根据生产线查找生产线的上/下料口
        /// </summary>
        /// <param name="line">生产线号</param>
        /// <param name="orificeFlag">料口类型(1上料口 2下料口)</param>
        /// <returns>生产线的上/下料口</returns>
        public string GetEcmOrificeByLine(string line, string orificeFlag)
        {
            return bfclient.GetEcmOrificeByLine(line, orificeFlag);
        }

        /// <summary>
        /// 根据产线名称获取产线下的所有WorkCell
        /// </summary>
        /// <param name="prodlineName">生产线名称</param>
        /// <returns></returns>
        public string[] GetLineListByProdLine(string prodlineName)
        {
            return bfclient.GetLineListByProdLine(prodlineName);
        }


        /// <summary>
        /// 更新设备的属性值
        /// </summary>
        /// <param name="equipName">设备名称</param>
        /// <param name="propertyName">设备属性名称</param>
        /// <param name="value">设备属性值</param>
        public void WriteEquipmentPropertyValue(string equipName, string propertyName, object value)
        {
            bfclient.WriteEquipmentPropertyValue(equipName, propertyName, value);
      
        }


        #region 物料相关

        /// <summary>
        /// 根据物料编码获取物料的属性字段
        /// </summary>
        /// <param name="materialName">物料编码</param>
        /// <returns>物料的属性字段字典</returns>
        public Dictionary<String, String> GetAllMaterialProperty(String materialName)
        {
            try
            {
                Dictionary<string, string> retDict = bfclient.GetAllProperty(materialName);
                if (retDict == null)
                    throw new Exception(string.Format("没有找到物料编码为'{0}'的物料", materialName));
                return retDict;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
