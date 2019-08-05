using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_ServiceClient
{
    public sealed class ServiceSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property = new ConfigurationProperty(string.Empty, typeof(TheKeyValueCollection), null,
                                       ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public TheKeyValueCollection KeyValues
        {
            get
            {
                return (TheKeyValueCollection)base[s_property];
            }
        }

        public static ServiceSection GetConfig()
        {
            ServiceSection configSection = (ServiceSection)ConfigurationManager.GetSection("ServiceSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [ServiceSection] is not found.");
            return configSection;
        }

        public static ServiceSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            ServiceSection configSection = (ServiceSection)config.GetSection("ServiceSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [ServiceSection] is not found.");
            return configSection;
        }
        /// <summary>
        /// 获取指定的配置对象
        /// </summary>
        /// <param name="keyName">配置名称</param>
        /// <returns></returns>
        public static TheKeyValue GetTheKeyValueCollection(string keyName)
        {
            ServiceSection configSection = (ServiceSection)ConfigurationManager.GetSection("ServiceSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [ServiceSection] is not found.");
            foreach (TheKeyValue item in configSection.KeyValues)
            {
                if (item.Name == keyName)
                    return item;
            }
            return null;
        }
    }
   
}
