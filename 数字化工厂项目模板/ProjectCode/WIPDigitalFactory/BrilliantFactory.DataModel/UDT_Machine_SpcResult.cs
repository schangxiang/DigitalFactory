using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_Machine_SpcResult")]
    public class UDT_Machine_SpcResult : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> MACHINEIDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> RPARTIDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 12)]
        public static Attribute<string> DATETIMEAttribute = new Attribute<string>();
        public static Attribute<bool> RSB1Attribute = new Attribute<bool>();
        public static Attribute<bool> PART_INSPECTION_ONDEMANDAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_HAND_CHECKAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_CMM_CHECKAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_FULL_DEPTHAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_REJECTAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_INSPECTION_PREALARMAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_INSPECTIONAttribute = new Attribute<bool>();
        public static Attribute<bool> TOOL_BROKENAttribute = new Attribute<bool>();
        public static Attribute<bool> MOVE_PART_TO_SPCAttribute = new Attribute<bool>();
        public static Attribute<bool> RSB2Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB3Attribute = new Attribute<bool>();
        public static Attribute<bool> MACHINING_ABORTEDAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_MACHINED_FIRSTAttribute = new Attribute<bool>();
        [AttributeColumn(Length = 10)]
        public static Attribute<string> PART_REJECTED_SEATING_FAULTAttribute = new Attribute<string>();
        public static Attribute<bool> RSB4Attribute = new Attribute<bool>();
        public static Attribute<bool> OKAttribute = new Attribute<bool>();
        public static Attribute<bool> NOKAttribute = new Attribute<bool>();
        public static Attribute<bool> RSB5Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB6Attribute = new Attribute<bool>();
        public static Attribute<bool> CONVEYORAttribute = new Attribute<bool>();
        public static Attribute<bool> SPCAttribute = new Attribute<bool>();
        public static Attribute<bool> RSB7Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB8Attribute = new Attribute<bool>();
        public static Attribute<bool> PROCSTATAttribute = new Attribute<bool>();
        public static Attribute<DateTime> CreateDateTimeAttribute = new Attribute<DateTime>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> CreateByAttribute = new Attribute<string>();
        public static Attribute<DateTime> UpdateDateTimeAttribute = new Attribute<DateTime>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> UpdateByAttribute = new Attribute<string>();
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
        public string RPARTID
        {
            get { return GetAttributeValue(RPARTIDAttribute); }
            set { SetAttributeValue(RPARTIDAttribute, value); }
        }
        public string DATETIME
        {
            get { return GetAttributeValue(DATETIMEAttribute); }
            set { SetAttributeValue(DATETIMEAttribute, value); }
        }
        public bool RSB1
        {
            get { return GetAttributeValue(RSB1Attribute); }
            set { SetAttributeValue(RSB1Attribute, value); }
        }
        public bool PART_INSPECTION_ONDEMAND
        {
            get { return GetAttributeValue(PART_INSPECTION_ONDEMANDAttribute); }
            set { SetAttributeValue(PART_INSPECTION_ONDEMANDAttribute, value); }
        }
        public bool PART_HAND_CHECK
        {
            get { return GetAttributeValue(PART_HAND_CHECKAttribute); }
            set { SetAttributeValue(PART_HAND_CHECKAttribute, value); }
        }
        public bool PART_CMM_CHECK
        {
            get { return GetAttributeValue(PART_CMM_CHECKAttribute); }
            set { SetAttributeValue(PART_CMM_CHECKAttribute, value); }
        }
        public bool PART_FULL_DEPTH
        {
            get { return GetAttributeValue(PART_FULL_DEPTHAttribute); }
            set { SetAttributeValue(PART_FULL_DEPTHAttribute, value); }
        }
        public bool PART_REJECT
        {
            get { return GetAttributeValue(PART_REJECTAttribute); }
            set { SetAttributeValue(PART_REJECTAttribute, value); }
        }
        public bool PART_INSPECTION_PREALARM
        {
            get { return GetAttributeValue(PART_INSPECTION_PREALARMAttribute); }
            set { SetAttributeValue(PART_INSPECTION_PREALARMAttribute, value); }
        }
        public bool PART_INSPECTION
        {
            get { return GetAttributeValue(PART_INSPECTIONAttribute); }
            set { SetAttributeValue(PART_INSPECTIONAttribute, value); }
        }
        public bool TOOL_BROKEN
        {
            get { return GetAttributeValue(TOOL_BROKENAttribute); }
            set { SetAttributeValue(TOOL_BROKENAttribute, value); }
        }
        public bool MOVE_PART_TO_SPC
        {
            get { return GetAttributeValue(MOVE_PART_TO_SPCAttribute); }
            set { SetAttributeValue(MOVE_PART_TO_SPCAttribute, value); }
        }
        public bool RSB2
        {
            get { return GetAttributeValue(RSB2Attribute); }
            set { SetAttributeValue(RSB2Attribute, value); }
        }
        public bool RSB3
        {
            get { return GetAttributeValue(RSB3Attribute); }
            set { SetAttributeValue(RSB3Attribute, value); }
        }
        public bool MACHINING_ABORTED
        {
            get { return GetAttributeValue(MACHINING_ABORTEDAttribute); }
            set { SetAttributeValue(MACHINING_ABORTEDAttribute, value); }
        }
        public bool PART_MACHINED_FIRST
        {
            get { return GetAttributeValue(PART_MACHINED_FIRSTAttribute); }
            set { SetAttributeValue(PART_MACHINED_FIRSTAttribute, value); }
        }
        public string PART_REJECTED_SEATING_FAULT
        {
            get { return GetAttributeValue(PART_REJECTED_SEATING_FAULTAttribute); }
            set { SetAttributeValue(PART_REJECTED_SEATING_FAULTAttribute, value); }
        }
        public bool RSB4
        {
            get { return GetAttributeValue(RSB4Attribute); }
            set { SetAttributeValue(RSB4Attribute, value); }
        }
        public bool OK
        {
            get { return GetAttributeValue(OKAttribute); }
            set { SetAttributeValue(OKAttribute, value); }
        }
        public bool NOK
        {
            get { return GetAttributeValue(NOKAttribute); }
            set { SetAttributeValue(NOKAttribute, value); }
        }
        public bool RSB5
        {
            get { return GetAttributeValue(RSB5Attribute); }
            set { SetAttributeValue(RSB5Attribute, value); }
        }
        public bool RSB6
        {
            get { return GetAttributeValue(RSB6Attribute); }
            set { SetAttributeValue(RSB6Attribute, value); }
        }
        public bool CONVEYOR
        {
            get { return GetAttributeValue(CONVEYORAttribute); }
            set { SetAttributeValue(CONVEYORAttribute, value); }
        }
        public bool SPC
        {
            get { return GetAttributeValue(SPCAttribute); }
            set { SetAttributeValue(SPCAttribute, value); }
        }
        public bool RSB7
        {
            get { return GetAttributeValue(RSB7Attribute); }
            set { SetAttributeValue(RSB7Attribute, value); }
        }
        public bool RSB8
        {
            get { return GetAttributeValue(RSB8Attribute); }
            set { SetAttributeValue(RSB8Attribute, value); }
        }
        public bool PROCSTAT
        {
            get { return GetAttributeValue(PROCSTATAttribute); }
            set { SetAttributeValue(PROCSTATAttribute, value); }
        }
        public DateTime CreateDateTime
        {
            get { return GetAttributeValue(CreateDateTimeAttribute); }
            set { SetAttributeValue(CreateDateTimeAttribute, value); }
        }
        public string CreateBy
        {
            get { return GetAttributeValue(CreateByAttribute); }
            set { SetAttributeValue(CreateByAttribute, value); }
        }
        public DateTime UpdateDateTime
        {
            get { return GetAttributeValue(UpdateDateTimeAttribute); }
            set { SetAttributeValue(UpdateDateTimeAttribute, value); }
        }
        public string UpdateBy
        {
            get { return GetAttributeValue(UpdateByAttribute); }
            set { SetAttributeValue(UpdateByAttribute, value); }
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
