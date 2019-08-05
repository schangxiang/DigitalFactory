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
    /// QualityTaskcsParam
    /// </summary>
    [DataContract]
    public class QualityTaskcsParam
    {
        [DataMember]
        public PropertyUpdateParam updateSubmissionTime { get; set; }


        [DataMember]
        public QualityTaskParam qualityTaskParam { get; set; }


    }
}