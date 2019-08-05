using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_CIMTRACK_Data")]
    public class UDT_CIMTRACK_Data : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<Int64> TRANSACTION_COUNTERAttribute = new Attribute<Int64>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        public static Attribute<int> MESSAGE_TYPEAttribute = new Attribute<int>();
        public static Attribute<int> ADAPTER_PLATE_TYPEAttribute = new Attribute<int>();
        public static Attribute<int> ADAPTER_PLATE_NUMAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> PART_UNIQUE_SERIAL_NOAttribute = new Attribute<string>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> WERS_BUILD_CODEAttribute = new Attribute<string>();
        [AttributeColumn(Length = 12)]
        public static Attribute<string> MACHINE_IDAttribute = new Attribute<string>();
        public static Attribute<bool> RSB1Attribute = new Attribute<bool>();
        public static Attribute<bool> PART_INSPECTION_ONDEMANDAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_HAND_CHECKAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_KCMM_CHECAttribute = new Attribute<bool>();
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
        public static Attribute<bool> REJECT_PARTAttribute = new Attribute<bool>();
        public static Attribute<bool> RSB4Attribute = new Attribute<bool>();
        public static Attribute<bool> PART_NOKAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_OKAttribute = new Attribute<bool>();
        public static Attribute<bool> RSB5Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB6Attribute = new Attribute<bool>();
        public static Attribute<bool> PART_PLACED_ON_CONVERYORAttribute = new Attribute<bool>();
        public static Attribute<bool> PART_PLACED_ON_SPCAttribute = new Attribute<bool>();
        public static Attribute<bool> START_OF_OPERATIONAttribute = new Attribute<bool>();
        public static Attribute<bool> RSB7Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB8Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB9Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB10Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB11Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB12Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB13Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB14Attribute = new Attribute<bool>();
        public static Attribute<bool> END_OF_OPERATIONAttribute = new Attribute<bool>();
        public static Attribute<int> DATE_TIME_STAMP_PLCAttribute = new Attribute<int>();
        public static Attribute<int> RSW1Attribute = new Attribute<int>();
        public static Attribute<int> RSW2Attribute = new Attribute<int>();
        public static Attribute<int> RSW3Attribute = new Attribute<int>();
        public static Attribute<DateTime> SYSTIMEAttribute = new Attribute<DateTime>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> ObjectIDAttribute = new Attribute<string>();


        public Guid ID
        {
            get { return GetAttributeValue(IDAttribute); }
            set { SetAttributeValue(IDAttribute, value); }
        }
        public Int64 TRANSACTION_COUNTER
        {
            get { return GetAttributeValue(TRANSACTION_COUNTERAttribute); }
            set { SetAttributeValue(TRANSACTION_COUNTERAttribute, value); }
        }
        public int FACILITYID
        {
            get { return GetAttributeValue(FACILITYIDAttribute); }
            set { SetAttributeValue(FACILITYIDAttribute, value); }
        }
        public int MESSAGE_TYPE
        {
            get { return GetAttributeValue(MESSAGE_TYPEAttribute); }
            set { SetAttributeValue(MESSAGE_TYPEAttribute, value); }
        }
        public int ADAPTER_PLATE_TYPE
        {
            get { return GetAttributeValue(ADAPTER_PLATE_TYPEAttribute); }
            set { SetAttributeValue(ADAPTER_PLATE_TYPEAttribute, value); }
        }
        public int ADAPTER_PLATE_NUM
        {
            get { return GetAttributeValue(ADAPTER_PLATE_NUMAttribute); }
            set { SetAttributeValue(ADAPTER_PLATE_NUMAttribute, value); }
        }
        public string PART_UNIQUE_SERIAL_NO
        {
            get { return GetAttributeValue(PART_UNIQUE_SERIAL_NOAttribute); }
            set { SetAttributeValue(PART_UNIQUE_SERIAL_NOAttribute, value); }
        }
        public string WERS_BUILD_CODE
        {
            get { return GetAttributeValue(WERS_BUILD_CODEAttribute); }
            set { SetAttributeValue(WERS_BUILD_CODEAttribute, value); }
        }
        public string MACHINE_ID
        {
            get { return GetAttributeValue(MACHINE_IDAttribute); }
            set { SetAttributeValue(MACHINE_IDAttribute, value); }
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
        public bool PART_KCMM_CHEC
        {
            get { return GetAttributeValue(PART_KCMM_CHECAttribute); }
            set { SetAttributeValue(PART_KCMM_CHECAttribute, value); }
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
        public bool REJECT_PART
        {
            get { return GetAttributeValue(REJECT_PARTAttribute); }
            set { SetAttributeValue(REJECT_PARTAttribute, value); }
        }
        public bool RSB4
        {
            get { return GetAttributeValue(RSB4Attribute); }
            set { SetAttributeValue(RSB4Attribute, value); }
        }
        public bool PART_NOK
        {
            get { return GetAttributeValue(PART_NOKAttribute); }
            set { SetAttributeValue(PART_NOKAttribute, value); }
        }
        public bool PART_OK
        {
            get { return GetAttributeValue(PART_OKAttribute); }
            set { SetAttributeValue(PART_OKAttribute, value); }
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
        public bool PART_PLACED_ON_CONVERYOR
        {
            get { return GetAttributeValue(PART_PLACED_ON_CONVERYORAttribute); }
            set { SetAttributeValue(PART_PLACED_ON_CONVERYORAttribute, value); }
        }
        public bool PART_PLACED_ON_SPC
        {
            get { return GetAttributeValue(PART_PLACED_ON_SPCAttribute); }
            set { SetAttributeValue(PART_PLACED_ON_SPCAttribute, value); }
        }
        public bool START_OF_OPERATION
        {
            get { return GetAttributeValue(START_OF_OPERATIONAttribute); }
            set { SetAttributeValue(START_OF_OPERATIONAttribute, value); }
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
        public bool RSB9
        {
            get { return GetAttributeValue(RSB9Attribute); }
            set { SetAttributeValue(RSB9Attribute, value); }
        }
        public bool RSB10
        {
            get { return GetAttributeValue(RSB10Attribute); }
            set { SetAttributeValue(RSB10Attribute, value); }
        }
        public bool RSB11
        {
            get { return GetAttributeValue(RSB11Attribute); }
            set { SetAttributeValue(RSB11Attribute, value); }
        }
        public bool RSB12
        {
            get { return GetAttributeValue(RSB12Attribute); }
            set { SetAttributeValue(RSB12Attribute, value); }
        }
        public bool RSB13
        {
            get { return GetAttributeValue(RSB13Attribute); }
            set { SetAttributeValue(RSB13Attribute, value); }
        }
        public bool RSB14
        {
            get { return GetAttributeValue(RSB14Attribute); }
            set { SetAttributeValue(RSB14Attribute, value); }
        }
        public bool END_OF_OPERATION
        {
            get { return GetAttributeValue(END_OF_OPERATIONAttribute); }
            set { SetAttributeValue(END_OF_OPERATIONAttribute, value); }
        }
        public int DATE_TIME_STAMP_PLC
        {
            get { return GetAttributeValue(DATE_TIME_STAMP_PLCAttribute); }
            set { SetAttributeValue(DATE_TIME_STAMP_PLCAttribute, value); }
        }
        public int RSW1
        {
            get { return GetAttributeValue(RSW1Attribute); }
            set { SetAttributeValue(RSW1Attribute, value); }
        }
        public int RSW2
        {
            get { return GetAttributeValue(RSW2Attribute); }
            set { SetAttributeValue(RSW2Attribute, value); }
        }
        public int RSW3
        {
            get { return GetAttributeValue(RSW3Attribute); }
            set { SetAttributeValue(RSW3Attribute, value); }
        }
        public DateTime SYSTIME
        {
            get { return GetAttributeValue(SYSTIMEAttribute); }
            set { SetAttributeValue(SYSTIMEAttribute, value); }
        }
        public string ObjectID
        {
            get { return GetAttributeValue(ObjectIDAttribute); }
            set { SetAttributeValue(ObjectIDAttribute, value); }
        }

    }
}
