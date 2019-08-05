using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    /// <summary>
    /// MangoDB配置
    /// </summary>
    public sealed class MangoDBSection : ConfigurationSection
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

        public static MangoDBSection GetConfig()
        {
            MangoDBSection configSection = (MangoDBSection)ConfigurationManager.GetSection("MangoDBSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [MangoDBSection] is not found.");
            return configSection;
        }

        public static MangoDBSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            MangoDBSection configSection = (MangoDBSection)config.GetSection("MangoDBSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [MangoDBSection] is not found.");
            return configSection;
        }
    }

}
