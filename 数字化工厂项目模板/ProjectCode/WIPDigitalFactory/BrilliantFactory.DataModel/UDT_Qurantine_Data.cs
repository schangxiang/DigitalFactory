using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_Qurantine_Data")]
    public class UDT_Qurantine_Data : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<int> QuarantineAttribute = new Attribute<int>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> PARTID_SAttribute = new Attribute<string>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> PARTID_EAttribute = new Attribute<string>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> SUBCOMPARTID_SAttribute = new Attribute<string>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> SUBCOMPARTID_EAttribute = new Attribute<string>();
        public static Attribute<DateTime> StartTimeAttribute = new Attribute<DateTime>();
        public static Attribute<DateTime> EndTimeAttribute = new Attribute<DateTime>();
        public static Attribute<DateTime> SysTimeAttribute = new Attribute<DateTime>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> RS1Attribute = new Attribute<string>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> RS2Attribute = new Attribute<string>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> RS3Attribute = new Attribute<string>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> RS4Attribute = new Attribute<string>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> RS5Attribute = new Attribute<string>();


        public Guid ID
        {
            get { return GetAttributeValue(IDAttribute); }
            set { SetAttributeValue(IDAttribute, value); }
        }
        public int Quarantine
        {
            get { return GetAttributeValue(QuarantineAttribute); }
            set { SetAttributeValue(QuarantineAttribute, value); }
        }
        public string PARTID_S
        {
            get { return GetAttributeValue(PARTID_SAttribute); }
            set { SetAttributeValue(PARTID_SAttribute, value); }
        }
        public string PARTID_E
        {
            get { return GetAttributeValue(PARTID_EAttribute); }
            set { SetAttributeValue(PARTID_EAttribute, value); }
        }
        public string SUBCOMPARTID_S
        {
            get { return GetAttributeValue(SUBCOMPARTID_SAttribute); }
            set { SetAttributeValue(SUBCOMPARTID_SAttribute, value); }
        }
        public string SUBCOMPARTID_E
        {
            get { return GetAttributeValue(SUBCOMPARTID_EAttribute); }
            set { SetAttributeValue(SUBCOMPARTID_EAttribute, value); }
        }
        public DateTime StartTime
        {
            get { return GetAttributeValue(StartTimeAttribute); }
            set { SetAttributeValue(StartTimeAttribute, value); }
        }
        public DateTime EndTime
        {
            get { return GetAttributeValue(EndTimeAttribute); }
            set { SetAttributeValue(EndTimeAttribute, value); }
        }
        public DateTime SysTime
        {
            get { return GetAttributeValue(SysTimeAttribute); }
            set { SetAttributeValue(SysTimeAttribute, value); }
        }
        public string RS1
        {
            get { return GetAttributeValue(RS1Attribute); }
            set { SetAttributeValue(RS1Attribute, value); }
        }
        public string RS2
        {
            get { return GetAttributeValue(RS2Attribute); }
            set { SetAttributeValue(RS2Attribute, value); }
        }
        public string RS3
        {
            get { return GetAttributeValue(RS3Attribute); }
            set { SetAttributeValue(RS3Attribute, value); }
        }
        public string RS4
        {
            get { return GetAttributeValue(RS4Attribute); }
            set { SetAttributeValue(RS4Attribute, value); }
        }
        public string RS5
        {
            get { return GetAttributeValue(RS5Attribute); }
            set { SetAttributeValue(RS5Attribute, value); }
        }


    }
}
