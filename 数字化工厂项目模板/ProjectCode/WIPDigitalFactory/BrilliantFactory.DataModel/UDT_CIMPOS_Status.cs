using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_CIMPOS_Status")]
    public class UDT_CIMPOS_Status : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<Int64> TRANSACTION_COUNTERAttribute = new Attribute<Int64>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> PART_UNIQUE_SERIAL_NOAttribute = new Attribute<string>();
        public static Attribute<bool> MANUAL_INTERVENTIONAttribute = new Attribute<bool>();
        public static Attribute<bool> TOOL_CHANGE_SELECTEDAttribute = new Attribute<bool>();
        public static Attribute<bool> SETUP_MODEAttribute = new Attribute<bool>();
        public static Attribute<bool> BYPASS_SELECTEDAttribute = new Attribute<bool>();
        public static Attribute<bool> BREAKAttribute = new Attribute<bool>();
        public static Attribute<bool> IN_FAULTAttribute = new Attribute<bool>();
        public static Attribute<bool> CRM_ONAttribute = new Attribute<bool>();
        public static Attribute<bool> HEARTBEAT_TIMEOUTAttribute = new Attribute<bool>();
        public static Attribute<bool> BLOCKEDAttribute = new Attribute<bool>();
        public static Attribute<bool> STARVEDAttribute = new Attribute<bool>();
        public static Attribute<bool> EMPTY_AUX_LOADERAttribute = new Attribute<bool>();
        public static Attribute<bool> PASS_THROUGH_CYCLEAttribute = new Attribute<bool>();
        public static Attribute<bool> AUTOAttribute = new Attribute<bool>();
        public static Attribute<bool> REQUEST_CYCLE_STARTAttribute = new Attribute<bool>();
        public static Attribute<bool> MANUAL_CONTROLLED_STOPAttribute = new Attribute<bool>();
        public static Attribute<bool> MANUAL_EMERGENCY_STOPAttribute = new Attribute<bool>();
        public static Attribute<DateTime> SYSTIMEAttribute = new Attribute<DateTime>();


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
        public string PART_UNIQUE_SERIAL_NO
        {
            get { return GetAttributeValue(PART_UNIQUE_SERIAL_NOAttribute); }
            set { SetAttributeValue(PART_UNIQUE_SERIAL_NOAttribute, value); }
        }
        public bool MANUAL_INTERVENTION
        {
            get { return GetAttributeValue(MANUAL_INTERVENTIONAttribute); }
            set { SetAttributeValue(MANUAL_INTERVENTIONAttribute, value); }
        }
        public bool TOOL_CHANGE_SELECTED
        {
            get { return GetAttributeValue(TOOL_CHANGE_SELECTEDAttribute); }
            set { SetAttributeValue(TOOL_CHANGE_SELECTEDAttribute, value); }
        }
        public bool SETUP_MODE
        {
            get { return GetAttributeValue(SETUP_MODEAttribute); }
            set { SetAttributeValue(SETUP_MODEAttribute, value); }
        }
        public bool BYPASS_SELECTED
        {
            get { return GetAttributeValue(BYPASS_SELECTEDAttribute); }
            set { SetAttributeValue(BYPASS_SELECTEDAttribute, value); }
        }
        public bool BREAK
        {
            get { return GetAttributeValue(BREAKAttribute); }
            set { SetAttributeValue(BREAKAttribute, value); }
        }
        public bool IN_FAULT
        {
            get { return GetAttributeValue(IN_FAULTAttribute); }
            set { SetAttributeValue(IN_FAULTAttribute, value); }
        }
        public bool CRM_ON
        {
            get { return GetAttributeValue(CRM_ONAttribute); }
            set { SetAttributeValue(CRM_ONAttribute, value); }
        }
        public bool HEARTBEAT_TIMEOUT
        {
            get { return GetAttributeValue(HEARTBEAT_TIMEOUTAttribute); }
            set { SetAttributeValue(HEARTBEAT_TIMEOUTAttribute, value); }
        }
        public bool BLOCKED
        {
            get { return GetAttributeValue(BLOCKEDAttribute); }
            set { SetAttributeValue(BLOCKEDAttribute, value); }
        }
        public bool STARVED
        {
            get { return GetAttributeValue(STARVEDAttribute); }
            set { SetAttributeValue(STARVEDAttribute, value); }
        }
        public bool EMPTY_AUX_LOADER
        {
            get { return GetAttributeValue(EMPTY_AUX_LOADERAttribute); }
            set { SetAttributeValue(EMPTY_AUX_LOADERAttribute, value); }
        }
        public bool PASS_THROUGH_CYCLE
        {
            get { return GetAttributeValue(PASS_THROUGH_CYCLEAttribute); }
            set { SetAttributeValue(PASS_THROUGH_CYCLEAttribute, value); }
        }
        public bool AUTO
        {
            get { return GetAttributeValue(AUTOAttribute); }
            set { SetAttributeValue(AUTOAttribute, value); }
        }
        public bool REQUEST_CYCLE_START
        {
            get { return GetAttributeValue(REQUEST_CYCLE_STARTAttribute); }
            set { SetAttributeValue(REQUEST_CYCLE_STARTAttribute, value); }
        }
        public bool MANUAL_CONTROLLED_STOP
        {
            get { return GetAttributeValue(MANUAL_CONTROLLED_STOPAttribute); }
            set { SetAttributeValue(MANUAL_CONTROLLED_STOPAttribute, value); }
        }
        public bool MANUAL_EMERGENCY_STOP
        {
            get { return GetAttributeValue(MANUAL_EMERGENCY_STOPAttribute); }
            set { SetAttributeValue(MANUAL_EMERGENCY_STOPAttribute, value); }
        }
        public DateTime SYSTIME
        {
            get { return GetAttributeValue(SYSTIMEAttribute); }
            set { SetAttributeValue(SYSTIMEAttribute, value); }
        }

    }
}
