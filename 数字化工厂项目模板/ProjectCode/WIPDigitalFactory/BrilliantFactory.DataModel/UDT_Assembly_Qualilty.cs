using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_Assembly_Qualilty")]
    public class UDT_Assembly_Qualilty : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> DATETIME_PAttribute = new Attribute<string>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> PARTIDAttribute = new Attribute<string>();
        public static Attribute<double> ENGINEOILAttribute = new Attribute<double>();
        [AttributeColumn(Length = 4)]
        public static Attribute<string> CRANKFLOATAttribute = new Attribute<string>();
        [AttributeColumn(Length = 6)]
        public static Attribute<string> PARTSELECTAttribute = new Attribute<string>();
        public static Attribute<bool> PROCSTATAttribute = new Attribute<bool>();
        [AttributeColumn(Length = 60)]
        public static Attribute<string> COMPONENTIDAttribute = new Attribute<string>();
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
        public string DATETIME_P
        {
            get { return GetAttributeValue(DATETIME_PAttribute); }
            set { SetAttributeValue(DATETIME_PAttribute, value); }
        }
        public string PARTID
        {
            get { return GetAttributeValue(PARTIDAttribute); }
            set { SetAttributeValue(PARTIDAttribute, value); }
        }
        public double ENGINEOIL
        {
            get { return GetAttributeValue(ENGINEOILAttribute); }
            set { SetAttributeValue(ENGINEOILAttribute, value); }
        }
        public string CRANKFLOAT
        {
            get { return GetAttributeValue(CRANKFLOATAttribute); }
            set { SetAttributeValue(CRANKFLOATAttribute, value); }
        }
        public string PARTSELECT
        {
            get { return GetAttributeValue(PARTSELECTAttribute); }
            set { SetAttributeValue(PARTSELECTAttribute, value); }
        }
        public bool PROCSTAT
        {
            get { return GetAttributeValue(PROCSTATAttribute); }
            set { SetAttributeValue(PROCSTATAttribute, value); }
        }
        public string COMPONENTID
        {
            get { return GetAttributeValue(COMPONENTIDAttribute); }
            set { SetAttributeValue(COMPONENTIDAttribute, value); }
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
