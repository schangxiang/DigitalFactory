using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    /// <summary>
    /// 邮箱配置
    /// </summary>
    public sealed class MailSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property = new ConfigurationProperty(string.Empty, typeof(MailValueCollection), null,
                                       ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public MailValueCollection KeyValues
        {
            get
            {
                return (MailValueCollection)base[s_property];
            }
        }

        public static MailSection GetConfig()
        {
            MailSection configSection = (MailSection)ConfigurationManager.GetSection("MailSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [MailSection] is not found.");
            return configSection;
        }

        public static MailSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            MailSection configSection = (MailSection)config.GetSection("MailSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [MailSection] is not found.");
            return configSection;
        }
        /// <summary>
        /// 获取指定的配置对象
        /// </summary>
        /// <param name="keyName">配置名称</param>
        /// <returns></returns>
        public static PrintKeyValue GetTheKeyValueCollection(string keyName)
        {
            MailSection configSection = (MailSection)ConfigurationManager.GetSection("MailSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [MailSection] is not found.");
            foreach (PrintKeyValue item in configSection.KeyValues)
            {
                if (item.Name == keyName)
                    return item;
            }
            return null;
        }
    }

}
