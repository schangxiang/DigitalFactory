using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    [ConfigurationCollection(typeof(RabbitMQConfigValue))]
    public class RabbitMQConfigCollection : ConfigurationElementCollection        // 自定义一个集合
    {
        new RabbitMQConfigValue this[string name]
        {
            get
            {
                return (RabbitMQConfigValue)base.BaseGet(name);
            }
        }

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new RabbitMQConfigValue();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return null;
        }
    }

    public class RabbitMQConfigValue : ConfigurationElement
    {
        [ConfigurationProperty("hostName", IsRequired = true)]
        public string HostName
        {
            get { return this["hostName"].ToString(); }
            set { this["hostName"] = value; }
        }

        [ConfigurationProperty("port", IsRequired = true)]
        public string Port
        {
            get { return this["port"].ToString(); }
            set { this["port"] = value; }
        }

        [ConfigurationProperty("userName", IsRequired = true)]
        public string UserName
        {
            get { return this["userName"].ToString(); }
            set { this["userName"] = value; }
        }

        [ConfigurationProperty("userPassword", IsRequired = true)]
        public string UserPassword
        {
            get { return this["userPassword"].ToString(); }
            set { this["userPassword"] = value; }
        }
    }
}
