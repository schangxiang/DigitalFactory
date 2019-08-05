using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    /// <summary>
    /// MES集成配置
    /// </summary>
    public sealed class MESIntegrSection : ConfigurationSection
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

        public static MESIntegrSection GetConfig()
        {
            MESIntegrSection configSection = (MESIntegrSection)ConfigurationManager.GetSection("MESIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [MESIntegrSection] is not found.");
            return configSection;
        }

        public static MESIntegrSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            MESIntegrSection configSection = (MESIntegrSection)config.GetSection("MESIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [MESIntegrSection] is not found.");
            return configSection;
        }
    }
}
