using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    /// <summary>
    /// LIMS集成配置
    /// </summary>
    public sealed class LIMSIntegrSection : ConfigurationSection
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

        public static LIMSIntegrSection GetConfig()
        {
            LIMSIntegrSection configSection = (LIMSIntegrSection)ConfigurationManager.GetSection("LIMSIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [LIMSIntegrSection] is not found.");
            return configSection;
        }

        public static LIMSIntegrSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            LIMSIntegrSection configSection = (LIMSIntegrSection)config.GetSection("LIMSIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [LIMSIntegrSection] is not found.");
            return configSection;
        }
    }
   
}
