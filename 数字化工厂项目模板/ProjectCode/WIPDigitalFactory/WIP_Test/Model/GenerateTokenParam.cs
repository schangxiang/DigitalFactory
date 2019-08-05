using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using WIP_Models;

namespace WIP_Models
{
    /// <summary>
    /// GenerateTokenParam
    /// </summary>
    [DataContract]
    public class GenerateTokenParam
    {

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 有效天数
        /// </summary>
        [DataMember]
        public int ExpDays { get; set; }


    }
}