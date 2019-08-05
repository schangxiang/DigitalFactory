/*
 * FileName：CodeSetsEntity.cs
 * FileDesc：代码项实体类
 * CreateTime：2018-9-11 13:20:31
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2018-9-11 13:20:31 新規作成 (by shaocx)
 */ 
 using System;
using System.Runtime.Serialization; 
                   
namespace WIP_Models 
{
    /// <summary>
    /// 代码项实体类
    /// </summary>
    [DataContract]
    public class CodeSetsModel 
    {
        /// <summary>
        /// 代码编码
        /// </summary>
        [DataMember]
        public string code { get; set; }

        /// <summary>
        /// 代码名称
        /// </summary>
        [DataMember]
        public string name { get; set; }

    }
}