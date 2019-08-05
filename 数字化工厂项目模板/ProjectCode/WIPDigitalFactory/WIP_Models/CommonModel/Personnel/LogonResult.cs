using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WIP_Models
{
    //[DataContract]
    public class LogonResult
    {
        //[DataMember(Order= 1)]
        public bool isSuccess { get; set; }
        //[DataMember(Order = 2)]
        public String loginMessage { get; set; }
        //[DataMember(Order= 3)]
        public String sendToken { get; set; }
        //[DataMember]
        public List<ResourceMenu> resoruceMenu { get; set; }
    }
}
