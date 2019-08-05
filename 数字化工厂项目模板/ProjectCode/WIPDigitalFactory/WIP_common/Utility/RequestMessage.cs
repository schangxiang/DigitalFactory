using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WIP_common
{
    [Serializable]
    public class RequestMessage
    {
        [DataMember]
        public string no { get; set; }

        [DataMember]
        public decimal x { get; set; }

        [DataMember]
        public decimal y { get; set; }


        [DataMember]
        public long timestamp { get; set; }
    }


}
