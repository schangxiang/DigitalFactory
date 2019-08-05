using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Interfaces.Model
{
    [DataContract]
    public class MarpossParameter
    {
        [DataMember]
        public string ParaName { get; set; }

        [DataMember]
        public string ParaValue { get; set; }
    }
}
