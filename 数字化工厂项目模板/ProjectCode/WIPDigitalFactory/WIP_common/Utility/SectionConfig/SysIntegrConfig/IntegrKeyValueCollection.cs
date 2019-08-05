using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_common
{
    [ConfigurationCollection(typeof(IntegrKeyValue))]
    public class IntegrKeyValueCollection : ConfigurationElementCollection        // 自定义一个集合
    {
        new IntegrKeyValue this[string name]
        {
            get
            {
                return (IntegrKeyValue)base.BaseGet(name);
            }
        }

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new IntegrKeyValue();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((IntegrKeyValue)element).Name;
        }
    }

    public class IntegrKeyValue : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get { return this["url"].ToString(); }
            set { this["url"] = value; }
        }
    }
}
