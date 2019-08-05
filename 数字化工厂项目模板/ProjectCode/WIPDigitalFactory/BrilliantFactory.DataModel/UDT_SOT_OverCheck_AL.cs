using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_SOT_OverCheck_AL")]
    public class UDT_SOT_OverCheck_AL : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<int> TELEGRAMTYPAttribute = new Attribute<int>();
        public static Attribute<int> MESQFLAGAttribute = new Attribute<int>();
        public static Attribute<int> LASTOPRESAttribute = new Attribute<int>();
        public static Attribute<int> OCHECKRESAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> NEXTOPREFAttribute = new Attribute<string>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> DATETIME_PAttribute = new Attribute<string>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> PARTIDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 100)]
        public static Attribute<string> SUPCOMPARTIDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 100)]
        public static Attribute<string> SUBCOMPARTIDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> SAPORDAttribute = new Attribute<string>();
        public static Attribute<int> PROCSTATAttribute = new Attribute<int>();
        public static Attribute<int> CYCLECOUNTAttribute = new Attribute<int>();
        public static Attribute<int> BOLTCOUNTAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> PLATENAttribute = new Attribute<string>();
        public static Attribute<int> AdapterPlateNumAttribute = new Attribute<int>();
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
        public int TELEGRAMTYP
        {
            get { return GetAttributeValue(TELEGRAMTYPAttribute); }
            set { SetAttributeValue(TELEGRAMTYPAttribute, value); }
        }
        public int MESQFLAG
        {
            get { return GetAttributeValue(MESQFLAGAttribute); }
            set { SetAttributeValue(MESQFLAGAttribute, value); }
        }
        public int LASTOPRES
        {
            get { return GetAttributeValue(LASTOPRESAttribute); }
            set { SetAttributeValue(LASTOPRESAttribute, value); }
        }
        public int OCHECKRES
        {
            get { return GetAttributeValue(OCHECKRESAttribute); }
            set { SetAttributeValue(OCHECKRESAttribute, value); }
        }
        public string NEXTOPREF
        {
            get { return GetAttributeValue(NEXTOPREFAttribute); }
            set { SetAttributeValue(NEXTOPREFAttribute, value); }
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
        public string SUPCOMPARTID
        {
            get { return GetAttributeValue(SUPCOMPARTIDAttribute); }
            set { SetAttributeValue(SUPCOMPARTIDAttribute, value); }
        }
        public string SUBCOMPARTID
        {
            get { return GetAttributeValue(SUBCOMPARTIDAttribute); }
            set { SetAttributeValue(SUBCOMPARTIDAttribute, value); }
        }
        public string SAPORD
        {
            get { return GetAttributeValue(SAPORDAttribute); }
            set { SetAttributeValue(SAPORDAttribute, value); }
        }
        public int PROCSTAT
        {
            get { return GetAttributeValue(PROCSTATAttribute); }
            set { SetAttributeValue(PROCSTATAttribute, value); }
        }
        public int CYCLECOUNT
        {
            get { return GetAttributeValue(CYCLECOUNTAttribute); }
            set { SetAttributeValue(CYCLECOUNTAttribute, value); }
        }
        public int BOLTCOUNT
        {
            get { return GetAttributeValue(BOLTCOUNTAttribute); }
            set { SetAttributeValue(BOLTCOUNTAttribute, value); }
        }
        public string PLATEN
        {
            get { return GetAttributeValue(PLATENAttribute); }
            set { SetAttributeValue(PLATENAttribute, value); }
        }
        public int AdapterPlateNum
        {
            get { return GetAttributeValue(AdapterPlateNumAttribute); }
            set { SetAttributeValue(AdapterPlateNumAttribute, value); }
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
