using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    /// <summary>
    /// 打印类型配置
    /// </summary>
    public sealed class PrintTypeSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property = new ConfigurationProperty(string.Empty, typeof(PrintKeyValueCollection), null,
                                       ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public PrintKeyValueCollection KeyValues
        {
            get
            {
                return (PrintKeyValueCollection)base[s_property];
            }
        }

        public static PrintTypeSection GetConfig()
        {
            PrintTypeSection configSection = (PrintTypeSection)ConfigurationManager.GetSection("PrintTypeSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [PrintTypeSection] is not found.");
            return configSection;
        }

        public static PrintTypeSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            PrintTypeSection configSection = (PrintTypeSection)config.GetSection("PrintTypeSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [PrintTypeSection] is not found.");
            return configSection;
        }
        /// <summary>
        /// 获取指定的配置对象
        /// </summary>
        /// <param name="keyName">配置名称</param>
        /// <returns></returns>
        public static PrintKeyValue GetTheKeyValueCollection(string keyName)
        {
            PrintTypeSection configSection = (PrintTypeSection)ConfigurationManager.GetSection("PrintTypeSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [PrintTypeSection] is not found.");
            foreach (PrintKeyValue item in configSection.KeyValues)
            {
                if (item.Name == keyName)
                    return item;
            }
            return null;
        }
    }

}
