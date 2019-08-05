using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    /// <summary>
    /// WCS集成配置
    /// </summary>
    public sealed class WCSIntegrSection : ConfigurationSection
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

        public static WCSIntegrSection GetConfig()
        {
            WCSIntegrSection configSection = (WCSIntegrSection)ConfigurationManager.GetSection("WCSIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [WCSIntegrSection] is not found.");
            return configSection;
        }

        public static WCSIntegrSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            WCSIntegrSection configSection = (WCSIntegrSection)config.GetSection("WCSIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [WCSIntegrSection] is not found.");
            return configSection;
        }
    }
   
}
