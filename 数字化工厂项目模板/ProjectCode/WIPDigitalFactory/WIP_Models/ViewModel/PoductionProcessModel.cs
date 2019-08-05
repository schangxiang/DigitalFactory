using System;
using System.Runtime.Serialization; 
                   
namespace WIP_Models 
{
    /// <summary>
    /// 生产工序表实体类
    /// </summary>
    [DataContract]
    public class PoductionProcessModel
    {

        /// <summary>
        /// 工序名称
        /// </summary>
        [DataMember]
        public string procedureName { get; set; }

        /// <summary>
        /// 工序描述
        /// </summary>
        [DataMember]
        public string procedureDesc { get; set; }


    }
}