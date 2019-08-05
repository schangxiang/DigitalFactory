using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    /// <summary>
    /// QAMS集成配置
    /// </summary>
    public sealed class QAMSIntegrSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property = new ConfigurationProperty(string.Empty, typeof(IntegrKeyValueCollection), null,
                                       ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public IntegrKeyValueCollection KeyValues
        {
            get
            {
                return (IntegrKeyValueCollection)base[s_property];
            }
        }

        public static QAMSIntegrSection GetConfig()
        {
            QAMSIntegrSection configSection = (QAMSIntegrSection)ConfigurationManager.GetSection("QAMSIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [QAMSIntegrSection] is not found.");
            return configSection;
        }

        public static QAMSIntegrSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            QAMSIntegrSection configSection = (QAMSIntegrSection)config.GetSection("QAMSIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [QAMSIntegrSection] is not found.");
            return configSection;
        }
    }
   
}
