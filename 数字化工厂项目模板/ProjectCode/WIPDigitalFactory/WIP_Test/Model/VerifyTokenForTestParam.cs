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
    /// VerifyTokenForTestParam
    /// </summary>
    [DataContract]
    public class VerifyTokenForTestParam
    {

        /// <summary>
        /// token
        /// </summary>
        [DataMember]
        public string token { get; set; }

    }
}