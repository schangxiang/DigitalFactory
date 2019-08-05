using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    /// <summary>
    /// Schedule集成配置
    /// </summary>
    public sealed class ScheduleIntegrSection : ConfigurationSection
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

        public static ScheduleIntegrSection GetConfig()
        {
            ScheduleIntegrSection configSection = (ScheduleIntegrSection)ConfigurationManager.GetSection("ScheduleIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [ScheduleIntegrSection] is not found.");
            return configSection;
        }

        public static ScheduleIntegrSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            ScheduleIntegrSection configSection = (ScheduleIntegrSection)config.GetSection("ScheduleIntegrSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [ScheduleIntegrSection] is not found.");
            return configSection;
        }
    }
   
}
