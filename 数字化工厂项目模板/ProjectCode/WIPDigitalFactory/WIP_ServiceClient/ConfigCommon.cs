/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_common.CommonUtility
 * FileName：ConfigCommon
 * CurrentYear：2018
 * CurrentTime：2018/8/16 16:07:12
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2018/8/16 16:07:12 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_ServiceClient
{
    [ConfigurationCollection(typeof(TheKeyValue))]
    public class TheKeyValueCollection : ConfigurationElementCollection        // 自定义一个集合
    {
        new TheKeyValue this[string name]
        {
            get
            {
                return (TheKeyValue)base.BaseGet(name);
            }
        }

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new TheKeyValue();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TheKeyValue)element).Name;
        }
    }

    public class TheKeyValue : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("text", IsRequired = true)]
        public string Text
        {
            get { return this["text"].ToString(); }
            set { this["text"] = value; }
        }
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return this["path"].ToString(); }
            set { this["path"] = value; }
        }
    }
}
