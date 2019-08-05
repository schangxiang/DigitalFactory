using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Interfaces.Model
{
    [DataContract]
    public class ShopOrderSchedule
    {
        [DataMember]
        public string ShopOrderNumber { get; set; }

        [DataMember]
        public string FacilityID { get; set; }

        [DataMember]
        public string RawPartNumber { get; set; }

        [DataMember]
        public string PartNumber { get; set; }

        [DataMember]
        public double TotalQty { get; set; }

        [DataMember]
        public double CompletedQty { get; set; }

        [DataMember]
        public double ScrappedQty { get; set; }

        [DataMember]
        public double AvailableQty { get; set; }

        [DataMember]
        public double RemainingQty { get; set; }

        [DataMember]
        public string OrderStatus { get; set; }

        [DataMember]
        public int Priority { get; set; }

        [DataMember]
        public DateTime EstimatedStartDate { get; set; }

        [DataMember]
        public DateTime EstimatedEndDate { get; set; }

        [DataMember]
        public DateTime ActualStartDate { get; set; }

        [DataMember]
        public DateTime ActualEndTime { get; set; }

        [DataMember]
        public double TaktTimeLabor { get; set; }

        [DataMember]
        public double TaktTimeProcessing { get; set; }

        [DataMember]
        public double TotalTimeLabor { get; set; }

        [DataMember]
        public double TotalTimeProcessing { get; set; }

        [DataMember]
        public string TimeZoneName { get; set; }


        [DataMember]
        public double QtyScrapped { get; set; }

        [DataMember]
        public double QtyInProgress { get; set; }

        [DataMember]
        public double QtyHold { get; set; }

        [DataMember]
        public double QtyQueued { get; set; }

        [DataMember]
        public bool HasNCR { get; set; }



    }
}
