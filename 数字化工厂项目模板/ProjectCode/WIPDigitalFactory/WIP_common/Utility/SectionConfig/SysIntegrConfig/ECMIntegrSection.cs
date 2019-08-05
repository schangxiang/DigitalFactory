using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_Models;

namespace WIP_common
{
    /// <summary>
    /// ECM集成配置
    /// </summary>
    public sealed class ECMIntegrSection : ConfigurationSection
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

        public static ECMIntegrSection GetConfig()
        {
            ECMIntegrSection configSection = (ECMIntegrSection)ConfigurationManager.GetSection("ECMIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [ECMIntegrSection] is not found.");
            return configSection;
        }

        public static ECMIntegrSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            ECMIntegrSection configSection = (ECMIntegrSection)config.GetSection("ECMIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [ECMIntegrSection] is not found.");
            return configSection;
        }
    }

}
