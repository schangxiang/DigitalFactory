using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    /// <summary>
    /// RabbitMQConfig配置
    /// </summary>
    public sealed class RabbitMQConfigSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property = new ConfigurationProperty(string.Empty, typeof(RabbitMQConfigCollection), null,
                                       ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public RabbitMQConfigCollection KeyValues
        {
            get
            {
                return (RabbitMQConfigCollection)base[s_property];
            }
        }

        public static RabbitMQConfigSection GetConfig()
        {
            RabbitMQConfigSection configSection = (RabbitMQConfigSection)ConfigurationManager.GetSection("RabbitMQConfigSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [RabbitMQConfigSection] is not found.");
            return configSection;
        }

        public static RabbitMQConfigSection GetConfig(string configPath)
        {
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configPath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            RabbitMQConfigSection configSection = (RabbitMQConfigSection)config.GetSection("RabbitMQConfigSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [RabbitMQConfigSection] is not found.");
            return configSection;
        }
        /// <summary>
        /// 获取指定的配置对象
        /// </summary>
        /// <param name="keyName">配置名称</param>
        /// <returns></returns>
        public static RabbitMQConfigValue GetTheKeyValueCollection()
        {
            RabbitMQConfigSection configSection = (RabbitMQConfigSection)ConfigurationManager.GetSection("RabbitMQConfigSection");
            if (configSection == null)
                throw new ConfigurationErrorsException("Section [RabbitMQConfigSection] is not found.");


            IDictionary rabbitMQConfigDict = (IDictionary)configSection.Properties;
            RabbitMQConfigValue ret = new RabbitMQConfigValue()
            {
                HostName = (string)rabbitMQConfigDict["hostName"],
                Port = (string)rabbitMQConfigDict["port"],
                UserName = (string)rabbitMQConfigDict["userName"],
                UserPassword = (string)rabbitMQConfigDict["userPassword"]
            };
            return ret;
        }
    }

}
