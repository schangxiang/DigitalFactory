using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_Machine_Qualily_Crankshaft_FRP")]
    public class UDT_Machine_Qualily_Crankshaft_FRP : ObjectType
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
        public static Attribute<int> POSTGAUGE1P1Attribute = new Attribute<int>();
        public static Attribute<int> POSTGAUGE1P2Attribute = new Attribute<int>();
        public static Attribute<int> POSTGAUGE2P1Attribute = new Attribute<int>();
        public static Attribute<int> POSTGAUGE2P2Attribute = new Attribute<int>();
        public static Attribute<int> POSTGAUGE3P1Attribute = new Attribute<int>();
        public static Attribute<int> POSTGAUGE3P2Attribute = new Attribute<int>();
        public static Attribute<int> POSTGAUGE4P2Attribute = new Attribute<int>();
        public static Attribute<int> POSTGAUGE5P1Attribute = new Attribute<int>();
        public static Attribute<int> POSTGAUGE5P2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE1P1_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE1P1_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE2P1_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE2P1_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE3P1_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE3P1_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE4P1_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE4P1_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE5P1_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE5P1_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE1P2_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE1P2_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE2P2_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE2P2_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE3P2_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE3P2_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE4P2_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE4P2_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE5P2_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE5P2_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE1P3_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE1P3_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE2P3_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE2P3_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE3P3_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE3P3_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE4P3_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE4P3_2Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE5P3_1Attribute = new Attribute<int>();
        public static Attribute<int> STRGAUGE5P3_2Attribute = new Attribute<int>();
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
        public int POSTGAUGE1P1
        {
            get { return GetAttributeValue(POSTGAUGE1P1Attribute); }
            set { SetAttributeValue(POSTGAUGE1P1Attribute, value); }
        }
        public int POSTGAUGE1P2
        {
            get { return GetAttributeValue(POSTGAUGE1P2Attribute); }
            set { SetAttributeValue(POSTGAUGE1P2Attribute, value); }
        }
        public int POSTGAUGE2P1
        {
            get { return GetAttributeValue(POSTGAUGE2P1Attribute); }
            set { SetAttributeValue(POSTGAUGE2P1Attribute, value); }
        }
        public int POSTGAUGE2P2
        {
            get { return GetAttributeValue(POSTGAUGE2P2Attribute); }
            set { SetAttributeValue(POSTGAUGE2P2Attribute, value); }
        }
        public int POSTGAUGE3P1
        {
            get { return GetAttributeValue(POSTGAUGE3P1Attribute); }
            set { SetAttributeValue(POSTGAUGE3P1Attribute, value); }
        }
        public int POSTGAUGE3P2
        {
            get { return GetAttributeValue(POSTGAUGE3P2Attribute); }
            set { SetAttributeValue(POSTGAUGE3P2Attribute, value); }
        }
        public int POSTGAUGE4P2
        {
            get { return GetAttributeValue(POSTGAUGE4P2Attribute); }
            set { SetAttributeValue(POSTGAUGE4P2Attribute, value); }
        }
        public int POSTGAUGE5P1
        {
            get { return GetAttributeValue(POSTGAUGE5P1Attribute); }
            set { SetAttributeValue(POSTGAUGE5P1Attribute, value); }
        }
        public int POSTGAUGE5P2
        {
            get { return GetAttributeValue(POSTGAUGE5P2Attribute); }
            set { SetAttributeValue(POSTGAUGE5P2Attribute, value); }
        }
        public int STRGAUGE1P1_1
        {
            get { return GetAttributeValue(STRGAUGE1P1_1Attribute); }
            set { SetAttributeValue(STRGAUGE1P1_1Attribute, value); }
        }
        public int STRGAUGE1P1_2
        {
            get { return GetAttributeValue(STRGAUGE1P1_2Attribute); }
            set { SetAttributeValue(STRGAUGE1P1_2Attribute, value); }
        }
        public int STRGAUGE2P1_1
        {
            get { return GetAttributeValue(STRGAUGE2P1_1Attribute); }
            set { SetAttributeValue(STRGAUGE2P1_1Attribute, value); }
        }
        public int STRGAUGE2P1_2
        {
            get { return GetAttributeValue(STRGAUGE2P1_2Attribute); }
            set { SetAttributeValue(STRGAUGE2P1_2Attribute, value); }
        }
        public int STRGAUGE3P1_1
        {
            get { return GetAttributeValue(STRGAUGE3P1_1Attribute); }
            set { SetAttributeValue(STRGAUGE3P1_1Attribute, value); }
        }
        public int STRGAUGE3P1_2
        {
            get { return GetAttributeValue(STRGAUGE3P1_2Attribute); }
            set { SetAttributeValue(STRGAUGE3P1_2Attribute, value); }
        }
        public int STRGAUGE4P1_1
        {
            get { return GetAttributeValue(STRGAUGE4P1_1Attribute); }
            set { SetAttributeValue(STRGAUGE4P1_1Attribute, value); }
        }
        public int STRGAUGE4P1_2
        {
            get { return GetAttributeValue(STRGAUGE4P1_2Attribute); }
            set { SetAttributeValue(STRGAUGE4P1_2Attribute, value); }
        }
        public int STRGAUGE5P1_1
        {
            get { return GetAttributeValue(STRGAUGE5P1_1Attribute); }
            set { SetAttributeValue(STRGAUGE5P1_1Attribute, value); }
        }
        public int STRGAUGE5P1_2
        {
            get { return GetAttributeValue(STRGAUGE5P1_2Attribute); }
            set { SetAttributeValue(STRGAUGE5P1_2Attribute, value); }
        }
        public int STRGAUGE1P2_1
        {
            get { return GetAttributeValue(STRGAUGE1P2_1Attribute); }
            set { SetAttributeValue(STRGAUGE1P2_1Attribute, value); }
        }
        public int STRGAUGE1P2_2
        {
            get { return GetAttributeValue(STRGAUGE1P2_2Attribute); }
            set { SetAttributeValue(STRGAUGE1P2_2Attribute, value); }
        }
        public int STRGAUGE2P2_1
        {
            get { return GetAttributeValue(STRGAUGE2P2_1Attribute); }
            set { SetAttributeValue(STRGAUGE2P2_1Attribute, value); }
        }
        public int STRGAUGE2P2_2
        {
            get { return GetAttributeValue(STRGAUGE2P2_2Attribute); }
            set { SetAttributeValue(STRGAUGE2P2_2Attribute, value); }
        }
        public int STRGAUGE3P2_1
        {
            get { return GetAttributeValue(STRGAUGE3P2_1Attribute); }
            set { SetAttributeValue(STRGAUGE3P2_1Attribute, value); }
        }
        public int STRGAUGE3P2_2
        {
            get { return GetAttributeValue(STRGAUGE3P2_2Attribute); }
            set { SetAttributeValue(STRGAUGE3P2_2Attribute, value); }
        }
        public int STRGAUGE4P2_1
        {
            get { return GetAttributeValue(STRGAUGE4P2_1Attribute); }
            set { SetAttributeValue(STRGAUGE4P2_1Attribute, value); }
        }
        public int STRGAUGE4P2_2
        {
            get { return GetAttributeValue(STRGAUGE4P2_2Attribute); }
            set { SetAttributeValue(STRGAUGE4P2_2Attribute, value); }
        }
        public int STRGAUGE5P2_1
        {
            get { return GetAttributeValue(STRGAUGE5P2_1Attribute); }
            set { SetAttributeValue(STRGAUGE5P2_1Attribute, value); }
        }
        public int STRGAUGE5P2_2
        {
            get { return GetAttributeValue(STRGAUGE5P2_2Attribute); }
            set { SetAttributeValue(STRGAUGE5P2_2Attribute, value); }
        }
        public int STRGAUGE1P3_1
        {
            get { return GetAttributeValue(STRGAUGE1P3_1Attribute); }
            set { SetAttributeValue(STRGAUGE1P3_1Attribute, value); }
        }
        public int STRGAUGE1P3_2
        {
            get { return GetAttributeValue(STRGAUGE1P3_2Attribute); }
            set { SetAttributeValue(STRGAUGE1P3_2Attribute, value); }
        }
        public int STRGAUGE2P3_1
        {
            get { return GetAttributeValue(STRGAUGE2P3_1Attribute); }
            set { SetAttributeValue(STRGAUGE2P3_1Attribute, value); }
        }
        public int STRGAUGE2P3_2
        {
            get { return GetAttributeValue(STRGAUGE2P3_2Attribute); }
            set { SetAttributeValue(STRGAUGE2P3_2Attribute, value); }
        }
        public int STRGAUGE3P3_1
        {
            get { return GetAttributeValue(STRGAUGE3P3_1Attribute); }
            set { SetAttributeValue(STRGAUGE3P3_1Attribute, value); }
        }
        public int STRGAUGE3P3_2
        {
            get { return GetAttributeValue(STRGAUGE3P3_2Attribute); }
            set { SetAttributeValue(STRGAUGE3P3_2Attribute, value); }
        }
        public int STRGAUGE4P3_1
        {
            get { return GetAttributeValue(STRGAUGE4P3_1Attribute); }
            set { SetAttributeValue(STRGAUGE4P3_1Attribute, value); }
        }
        public int STRGAUGE4P3_2
        {
            get { return GetAttributeValue(STRGAUGE4P3_2Attribute); }
            set { SetAttributeValue(STRGAUGE4P3_2Attribute, value); }
        }
        public int STRGAUGE5P3_1
        {
            get { return GetAttributeValue(STRGAUGE5P3_1Attribute); }
            set { SetAttributeValue(STRGAUGE5P3_1Attribute, value); }
        }
        public int STRGAUGE5P3_2
        {
            get { return GetAttributeValue(STRGAUGE5P3_2Attribute); }
            set { SetAttributeValue(STRGAUGE5P3_2Attribute, value); }
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
