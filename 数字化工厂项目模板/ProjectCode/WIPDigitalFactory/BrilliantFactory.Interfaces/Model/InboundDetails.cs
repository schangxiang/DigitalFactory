using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BrilliantFactory.Interfaces.Model
{
    [DataContract]
    public class InboundDetails
    {
        [DataMember]
        public Int32 ErrorCode { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string MainData { get; set; }

        public Guid SegmentResponseId { get; set; }
    }
}
