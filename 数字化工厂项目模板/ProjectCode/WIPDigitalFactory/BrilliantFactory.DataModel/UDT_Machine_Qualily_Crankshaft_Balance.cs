using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_Machine_Qualily_Crankshaft_Balance")]
    public class UDT_Machine_Qualily_Crankshaft_Balance : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> MACHINEIDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PARTIDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 12)]
        public static Attribute<string> DATETIME_PAttribute = new Attribute<string>();
        [AttributeColumn(Length = 5)]
        public static Attribute<string> INCU1Attribute = new Attribute<string>();
        [AttributeColumn(Length = 5)]
        public static Attribute<string> INCA1Attribute = new Attribute<string>();
        [AttributeColumn(Length = 5)]
        public static Attribute<string> INCU2Attribute = new Attribute<string>();
        [AttributeColumn(Length = 5)]
        public static Attribute<string> INCA2Attribute = new Attribute<string>();
        [AttributeColumn(Length = 5)]
        public static Attribute<string> OUTU1Attribute = new Attribute<string>();
        [AttributeColumn(Length = 5)]
        public static Attribute<string> OUTA1Attribute = new Attribute<string>();
        [AttributeColumn(Length = 5)]
        public static Attribute<string> OUTU2Attribute = new Attribute<string>();
        [AttributeColumn(Length = 5)]
        public static Attribute<string> OUTA2Attribute = new Attribute<string>();
        public static Attribute<bool> PROCSTATAttribute = new Attribute<bool>();
        public static Attribute<DateTime> SYSTIMEAttribute = new Attribute<DateTime>();
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
        public int FACILITYID
        {
            get { return GetAttributeValue(FACILITYIDAttribute); }
            set { SetAttributeValue(FACILITYIDAttribute, value); }
        }
        public string MACHINEID
        {
            get { return GetAttributeValue(MACHINEIDAttribute); }
            set { SetAttributeValue(MACHINEIDAttribute, value); }
        }
        public string PARTID
        {
            get { return GetAttributeValue(PARTIDAttribute); }
            set { SetAttributeValue(PARTIDAttribute, value); }
        }
        public string DATETIME_P
        {
            get { return GetAttributeValue(DATETIME_PAttribute); }
            set { SetAttributeValue(DATETIME_PAttribute, value); }
        }
        public string INCU1
        {
            get { return GetAttributeValue(INCU1Attribute); }
            set { SetAttributeValue(INCU1Attribute, value); }
        }
        public string INCA1
        {
            get { return GetAttributeValue(INCA1Attribute); }
            set { SetAttributeValue(INCA1Attribute, value); }
        }
        public string INCU2
        {
            get { return GetAttributeValue(INCU2Attribute); }
            set { SetAttributeValue(INCU2Attribute, value); }
        }
        public string INCA2
        {
            get { return GetAttributeValue(INCA2Attribute); }
            set { SetAttributeValue(INCA2Attribute, value); }
        }
        public string OUTU1
        {
            get { return GetAttributeValue(OUTU1Attribute); }
            set { SetAttributeValue(OUTU1Attribute, value); }
        }
        public string OUTA1
        {
            get { return GetAttributeValue(OUTA1Attribute); }
            set { SetAttributeValue(OUTA1Attribute, value); }
        }
        public string OUTU2
        {
            get { return GetAttributeValue(OUTU2Attribute); }
            set { SetAttributeValue(OUTU2Attribute, value); }
        }
        public string OUTA2
        {
            get { return GetAttributeValue(OUTA2Attribute); }
            set { SetAttributeValue(OUTA2Attribute, value); }
        }
        public bool PROCSTAT
        {
            get { return GetAttributeValue(PROCSTATAttribute); }
            set { SetAttributeValue(PROCSTATAttribute, value); }
        }
        public DateTime SYSTIME
        {
            get { return GetAttributeValue(SYSTIMEAttribute); }
            set { SetAttributeValue(SYSTIMEAttribute, value); }
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
