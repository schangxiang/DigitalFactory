using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Interfaces.Model
{
    [DataContract]
    public class MarpossOvercheckResponse
    {

        [DataMember]
        public string USN { get; set; }

        [DataMember]
        public string LOPN { get; set; }

        [DataMember]
        public string PTPE { get; set; }


        [DataMember]
        public string GNG { get; set; }

        [DataMember]
        public string EMGE { get; set; }


    }
}
