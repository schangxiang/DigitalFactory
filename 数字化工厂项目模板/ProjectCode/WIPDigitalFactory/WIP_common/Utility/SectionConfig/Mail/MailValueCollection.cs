using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    [ConfigurationCollection(typeof(MailKeyValue))]
    public class MailValueCollection : ConfigurationElementCollection        // 自定义一个集合
    {
        new MailKeyValue this[string name]
        {
            get
            {
                return (MailKeyValue)base.BaseGet(name);
            }
        }

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new MailKeyValue();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MailKeyValue)element).Name;
        }
    }

    public class MailKeyValue : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return this["value"].ToString(); }
            set { this["value"] = value; }
        }
    }
}
