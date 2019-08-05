using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Interfaces.Model
{
    [DataContract]
    public class QuarantineLot
    {
        [DataMember]
        public string MaterialLotId { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public string ShopOrderNumber { get; set; }

        [DataMember]
        public string PartNumber { get; set; }

        [DataMember]
        public string SfcNumber { get; set; }

        [DataMember]
        public string QuStatus { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
