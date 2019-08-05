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
    /// UnixTimeStampParam
    /// </summary>
    [DataContract]
    public class UnixTimeStampParam
    {

        /// <summary>
        /// 是否解密( 0 加密 1解密)
        /// </summary>
        [DataMember]
        public string isEncrypt { get; set; }

        /// <summary>
        /// 原始值
        /// </summary>
        [DataMember]
        public long value { get; set; }


    }
}