using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_CIMPOS_Data")]
    public class UDT_CIMPOS_Data : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<Int64> TRANSACTION_COUNTERAttribute = new Attribute<Int64>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> PART_UNIQUE_SERIAL_NOAttribute = new Attribute<string>();
        public static Attribute<int> MESSAGE_TYPEAttribute = new Attribute<int>();
        public static Attribute<bool> DRY_CYCLEAttribute = new Attribute<bool>();
        public static Attribute<bool> NON_CONTINUOUSAttribute = new Attribute<bool>();
        public static Attribute<bool> GOOD_CYCLEAttribute = new Attribute<bool>();
        public static Attribute<bool> BAD_CYCLEAttribute = new Attribute<bool>();
        public static Attribute<bool> CYCLE_STARTAttribute = new Attribute<bool>();
        public static Attribute<bool> CYCLE_ENDAttribute = new Attribute<bool>();
        public static Attribute<bool> DRESS_CYCLEAttribute = new Attribute<bool>();
        public static Attribute<bool> RSB1Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB2Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB3Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB4Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB5Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB6Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB7Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB8Attribute = new Attribute<bool>();
        public static Attribute<bool> RSB9Attribute = new Attribute<bool>();
        public static Attribute<int> LAST_CYCLE_TIMEAttribute = new Attribute<int>();
        public static Attribute<int> ACCUM_CYCLE_TIME_CNTAttribute = new Attribute<int>();
        public static Attribute<int> GOOD_MACHINE_CYCLESAttribute = new Attribute<int>();
        public static Attribute<int> BAD_MACHINE_CYCLESAttribute = new Attribute<int>();
        public static Attribute<int> TOTAL_CYCLESAttribute = new Attribute<int>();
        public static Attribute<bool> MANUAL_INTERVENTIONAttribute = new Attribute<bool>();
        public static Attribute<bool> TOOL_CHANGE_SELECTEDAttribute = new Attribute<bool>();
        public static Attribute<bool> SETUP_MODEAttribute = new Attribute<bool>();
        public static Attribute<bool> BYPASS_SELECTEDAttribute = new Attribute<bool>();
        public static Attribute<bool> BREAK_BAttribute = new Attribute<bool>();
        public static Attribute<bool> IN_FAULTAttribute = new Attribute<bool>();
        public static Attribute<bool> CRM_ONAttribute = new Attribute<bool>();
        public static Attribute<bool> HEARTBEAT_TIMEOUTAttribute = new Attribute<bool>();
        public static Attribute<bool> BLOCKEDAttribute = new Attribute<bool>();
        public static Attribute<bool> STARVEDAttribute = new Attribute<bool>();
        public static Attribute<bool> EMPTY_AUX_LOADERAttribute = new Attribute<bool>();
        public static Attribute<bool> PASS_THROUGH_CYCLEAttribute = new Attribute<bool>();
        public static Attribute<bool> AUTO_BAttribute = new Attribute<bool>();
        public static Attribute<bool> REQUEST_CYCLE_STARTAttribute = new Attribute<bool>();
        public static Attribute<bool> MANUAL_CONTROLLED_STOPAttribute = new Attribute<bool>();
        public static Attribute<bool> MANUAL_EMERGENCY_STOPAttribute = new Attribute<bool>();
        public static Attribute<int> PROCESS_ID1Attribute = new Attribute<int>();
        public static Attribute<int> PROCESS_ID2Attribute = new Attribute<int>();
        public static Attribute<int> FAULT_CODE1Attribute = new Attribute<int>();
        public static Attribute<int> FAULT_CODE2Attribute = new Attribute<int>();
        public static Attribute<int> FAULT_CODE3Attribute = new Attribute<int>();
        public static Attribute<int> REASON_CODEAttribute = new Attribute<int>();
        public static Attribute<bool> POWER_ALARMAttribute = new Attribute<bool>();
        public static Attribute<bool> FLUID_TANK_LOW_PRESSUREAttribute = new Attribute<bool>();
        public static Attribute<bool> STOCKLOWAttribute = new Attribute<bool>();
        public static Attribute<bool> LOW_AIR_PRESSUREAttribute = new Attribute<bool>();
        public static Attribute<bool> FLUID_FILTER_DIRTYAttribute = new Attribute<bool>();
        public static Attribute<bool> LUBE_LOW_LEVELAttribute = new Attribute<bool>();
        public static Attribute<bool> ERROR_PROOFING_DISABLEDAttribute = new Attribute<bool>();
        public static Attribute<bool> POWER_SAVING_SHUTDOWN1Attribute = new Attribute<bool>();
        public static Attribute<bool> POWER_SAVING_SHUTDOWN2Attribute = new Attribute<bool>();
        public static Attribute<bool> TOOLLIFE_NEARLY_EXPIREDAttribute = new Attribute<bool>();
        public static Attribute<bool> PEAK_VIBRATION_WARNINGAttribute = new Attribute<bool>();
        public static Attribute<bool> FEEDRATEAttribute = new Attribute<bool>();
        public static Attribute<bool> STATION_OVER_CYCLEAttribute = new Attribute<bool>();
        public static Attribute<bool> RETRYAttribute = new Attribute<bool>();
        public static Attribute<bool> QUARANTINEAttribute = new Attribute<bool>();
        public static Attribute<bool> TOOL_LIFE_CHANGEAttribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_0Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_1Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_2Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_3Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_4Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_5Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_6Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_7Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_8Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_9Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_10Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_11Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_12Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_13Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_14Attribute = new Attribute<bool>();
        public static Attribute<bool> ALERT_NOTIFIC_BIT_15Attribute = new Attribute<bool>();
        public static Attribute<int> WARNING_WORD3Attribute = new Attribute<int>();
        [AttributeColumn(Length = 50)]
        public static Attribute<string> PLC_CHECKSUMAttribute = new Attribute<string>();
        public static Attribute<int> WORD_22Attribute = new Attribute<int>();
        public static Attribute<int> WORD_23Attribute = new Attribute<int>();
        public static Attribute<int> WORD_24Attribute = new Attribute<int>();
        public static Attribute<int> WORD_25Attribute = new Attribute<int>();
        public static Attribute<int> WORD_26Attribute = new Attribute<int>();
        public static Attribute<int> WORD_27Attribute = new Attribute<int>();
        public static Attribute<int> WORD_28Attribute = new Attribute<int>();
        public static Attribute<int> WORD_29Attribute = new Attribute<int>();
        public static Attribute<int> WORD_30Attribute = new Attribute<int>();
        public static Attribute<int> WORD_31Attribute = new Attribute<int>();
        public static Attribute<int> WORD_32Attribute = new Attribute<int>();
        public static Attribute<int> WORD_33Attribute = new Attribute<int>();
        public static Attribute<int> WORD_34Attribute = new Attribute<int>();
        public static Attribute<int> WORD_35Attribute = new Attribute<int>();
        public static Attribute<int> WORD_36Attribute = new Attribute<int>();
        public static Attribute<int> WORD_37Attribute = new Attribute<int>();
        public static Attribute<int> WORD_38Attribute = new Attribute<int>();
        public static Attribute<int> WORD_39Attribute = new Attribute<int>();
        public static Attribute<int> WORD_40Attribute = new Attribute<int>();
        public static Attribute<bool> CWWB1Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB2Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB3Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB4Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB5Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB6Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB7Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB8Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB9Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB10Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB11Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB12Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB13Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB14Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB15Attribute = new Attribute<bool>();
        public static Attribute<bool> CWWB16Attribute = new Attribute<bool>();
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
        public string PART_UNIQUE_SERIAL_NO
        {
            get { return GetAttributeValue(PART_UNIQUE_SERIAL_NOAttribute); }
            set { SetAttributeValue(PART_UNIQUE_SERIAL_NOAttribute, value); }
        }
        public int MESSAGE_TYPE
        {
            get { return GetAttributeValue(MESSAGE_TYPEAttribute); }
            set { SetAttributeValue(MESSAGE_TYPEAttribute, value); }
        }
        public bool DRY_CYCLE
        {
            get { return GetAttributeValue(DRY_CYCLEAttribute); }
            set { SetAttributeValue(DRY_CYCLEAttribute, value); }
        }
        public bool NON_CONTINUOUS
        {
            get { return GetAttributeValue(NON_CONTINUOUSAttribute); }
            set { SetAttributeValue(NON_CONTINUOUSAttribute, value); }
        }
        public bool GOOD_CYCLE
        {
            get { return GetAttributeValue(GOOD_CYCLEAttribute); }
            set { SetAttributeValue(GOOD_CYCLEAttribute, value); }
        }
        public bool BAD_CYCLE
        {
            get { return GetAttributeValue(BAD_CYCLEAttribute); }
            set { SetAttributeValue(BAD_CYCLEAttribute, value); }
        }
        public bool CYCLE_START
        {
            get { return GetAttributeValue(CYCLE_STARTAttribute); }
            set { SetAttributeValue(CYCLE_STARTAttribute, value); }
        }
        public bool CYCLE_END
        {
            get { return GetAttributeValue(CYCLE_ENDAttribute); }
            set { SetAttributeValue(CYCLE_ENDAttribute, value); }
        }
        public bool DRESS_CYCLE
        {
            get { return GetAttributeValue(DRESS_CYCLEAttribute); }
            set { SetAttributeValue(DRESS_CYCLEAttribute, value); }
        }
        public bool RSB1
        {
            get { return GetAttributeValue(RSB1Attribute); }
            set { SetAttributeValue(RSB1Attribute, value); }
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
        public bool RSB4
        {
            get { return GetAttributeValue(RSB4Attribute); }
            set { SetAttributeValue(RSB4Attribute, value); }
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
        public int LAST_CYCLE_TIME
        {
            get { return GetAttributeValue(LAST_CYCLE_TIMEAttribute); }
            set { SetAttributeValue(LAST_CYCLE_TIMEAttribute, value); }
        }
        public int ACCUM_CYCLE_TIME_CNT
        {
            get { return GetAttributeValue(ACCUM_CYCLE_TIME_CNTAttribute); }
            set { SetAttributeValue(ACCUM_CYCLE_TIME_CNTAttribute, value); }
        }
        public int GOOD_MACHINE_CYCLES
        {
            get { return GetAttributeValue(GOOD_MACHINE_CYCLESAttribute); }
            set { SetAttributeValue(GOOD_MACHINE_CYCLESAttribute, value); }
        }
        public int BAD_MACHINE_CYCLES
        {
            get { return GetAttributeValue(BAD_MACHINE_CYCLESAttribute); }
            set { SetAttributeValue(BAD_MACHINE_CYCLESAttribute, value); }
        }
        public int TOTAL_CYCLES
        {
            get { return GetAttributeValue(TOTAL_CYCLESAttribute); }
            set { SetAttributeValue(TOTAL_CYCLESAttribute, value); }
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
        public bool BREAK_B
        {
            get { return GetAttributeValue(BREAK_BAttribute); }
            set { SetAttributeValue(BREAK_BAttribute, value); }
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
        public bool AUTO_B
        {
            get { return GetAttributeValue(AUTO_BAttribute); }
            set { SetAttributeValue(AUTO_BAttribute, value); }
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
        public int PROCESS_ID1
        {
            get { return GetAttributeValue(PROCESS_ID1Attribute); }
            set { SetAttributeValue(PROCESS_ID1Attribute, value); }
        }
        public int PROCESS_ID2
        {
            get { return GetAttributeValue(PROCESS_ID2Attribute); }
            set { SetAttributeValue(PROCESS_ID2Attribute, value); }
        }
        public int FAULT_CODE1
        {
            get { return GetAttributeValue(FAULT_CODE1Attribute); }
            set { SetAttributeValue(FAULT_CODE1Attribute, value); }
        }
        public int FAULT_CODE2
        {
            get { return GetAttributeValue(FAULT_CODE2Attribute); }
            set { SetAttributeValue(FAULT_CODE2Attribute, value); }
        }
        public int FAULT_CODE3
        {
            get { return GetAttributeValue(FAULT_CODE3Attribute); }
            set { SetAttributeValue(FAULT_CODE3Attribute, value); }
        }
        public int REASON_CODE
        {
            get { return GetAttributeValue(REASON_CODEAttribute); }
            set { SetAttributeValue(REASON_CODEAttribute, value); }
        }
        public bool POWER_ALARM
        {
            get { return GetAttributeValue(POWER_ALARMAttribute); }
            set { SetAttributeValue(POWER_ALARMAttribute, value); }
        }
        public bool FLUID_TANK_LOW_PRESSURE
        {
            get { return GetAttributeValue(FLUID_TANK_LOW_PRESSUREAttribute); }
            set { SetAttributeValue(FLUID_TANK_LOW_PRESSUREAttribute, value); }
        }
        public bool STOCKLOW
        {
            get { return GetAttributeValue(STOCKLOWAttribute); }
            set { SetAttributeValue(STOCKLOWAttribute, value); }
        }
        public bool LOW_AIR_PRESSURE
        {
            get { return GetAttributeValue(LOW_AIR_PRESSUREAttribute); }
            set { SetAttributeValue(LOW_AIR_PRESSUREAttribute, value); }
        }
        public bool FLUID_FILTER_DIRTY
        {
            get { return GetAttributeValue(FLUID_FILTER_DIRTYAttribute); }
            set { SetAttributeValue(FLUID_FILTER_DIRTYAttribute, value); }
        }
        public bool LUBE_LOW_LEVEL
        {
            get { return GetAttributeValue(LUBE_LOW_LEVELAttribute); }
            set { SetAttributeValue(LUBE_LOW_LEVELAttribute, value); }
        }
        public bool ERROR_PROOFING_DISABLED
        {
            get { return GetAttributeValue(ERROR_PROOFING_DISABLEDAttribute); }
            set { SetAttributeValue(ERROR_PROOFING_DISABLEDAttribute, value); }
        }
        public bool POWER_SAVING_SHUTDOWN1
        {
            get { return GetAttributeValue(POWER_SAVING_SHUTDOWN1Attribute); }
            set { SetAttributeValue(POWER_SAVING_SHUTDOWN1Attribute, value); }
        }
        public bool POWER_SAVING_SHUTDOWN2
        {
            get { return GetAttributeValue(POWER_SAVING_SHUTDOWN2Attribute); }
            set { SetAttributeValue(POWER_SAVING_SHUTDOWN2Attribute, value); }
        }
        public bool TOOLLIFE_NEARLY_EXPIRED
        {
            get { return GetAttributeValue(TOOLLIFE_NEARLY_EXPIREDAttribute); }
            set { SetAttributeValue(TOOLLIFE_NEARLY_EXPIREDAttribute, value); }
        }
        public bool PEAK_VIBRATION_WARNING
        {
            get { return GetAttributeValue(PEAK_VIBRATION_WARNINGAttribute); }
            set { SetAttributeValue(PEAK_VIBRATION_WARNINGAttribute, value); }
        }
        public bool FEEDRATE
        {
            get { return GetAttributeValue(FEEDRATEAttribute); }
            set { SetAttributeValue(FEEDRATEAttribute, value); }
        }
        public bool STATION_OVER_CYCLE
        {
            get { return GetAttributeValue(STATION_OVER_CYCLEAttribute); }
            set { SetAttributeValue(STATION_OVER_CYCLEAttribute, value); }
        }
        public bool RETRY
        {
            get { return GetAttributeValue(RETRYAttribute); }
            set { SetAttributeValue(RETRYAttribute, value); }
        }
        public bool QUARANTINE
        {
            get { return GetAttributeValue(QUARANTINEAttribute); }
            set { SetAttributeValue(QUARANTINEAttribute, value); }
        }
        public bool TOOL_LIFE_CHANGE
        {
            get { return GetAttributeValue(TOOL_LIFE_CHANGEAttribute); }
            set { SetAttributeValue(TOOL_LIFE_CHANGEAttribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_0
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_0Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_0Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_1
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_1Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_1Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_2
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_2Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_2Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_3
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_3Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_3Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_4
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_4Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_4Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_5
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_5Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_5Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_6
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_6Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_6Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_7
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_7Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_7Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_8
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_8Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_8Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_9
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_9Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_9Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_10
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_10Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_10Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_11
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_11Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_11Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_12
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_12Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_12Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_13
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_13Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_13Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_14
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_14Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_14Attribute, value); }
        }
        public bool ALERT_NOTIFIC_BIT_15
        {
            get { return GetAttributeValue(ALERT_NOTIFIC_BIT_15Attribute); }
            set { SetAttributeValue(ALERT_NOTIFIC_BIT_15Attribute, value); }
        }
        public int WARNING_WORD3
        {
            get { return GetAttributeValue(WARNING_WORD3Attribute); }
            set { SetAttributeValue(WARNING_WORD3Attribute, value); }
        }
        public string PLC_CHECKSUM
        {
            get { return GetAttributeValue(PLC_CHECKSUMAttribute); }
            set { SetAttributeValue(PLC_CHECKSUMAttribute, value); }
        }
        public int WORD_22
        {
            get { return GetAttributeValue(WORD_22Attribute); }
            set { SetAttributeValue(WORD_22Attribute, value); }
        }
        public int WORD_23
        {
            get { return GetAttributeValue(WORD_23Attribute); }
            set { SetAttributeValue(WORD_23Attribute, value); }
        }
        public int WORD_24
        {
            get { return GetAttributeValue(WORD_24Attribute); }
            set { SetAttributeValue(WORD_24Attribute, value); }
        }
        public int WORD_25
        {
            get { return GetAttributeValue(WORD_25Attribute); }
            set { SetAttributeValue(WORD_25Attribute, value); }
        }
        public int WORD_26
        {
            get { return GetAttributeValue(WORD_26Attribute); }
            set { SetAttributeValue(WORD_26Attribute, value); }
        }
        public int WORD_27
        {
            get { return GetAttributeValue(WORD_27Attribute); }
            set { SetAttributeValue(WORD_27Attribute, value); }
        }
        public int WORD_28
        {
            get { return GetAttributeValue(WORD_28Attribute); }
            set { SetAttributeValue(WORD_28Attribute, value); }
        }
        public int WORD_29
        {
            get { return GetAttributeValue(WORD_29Attribute); }
            set { SetAttributeValue(WORD_29Attribute, value); }
        }
        public int WORD_30
        {
            get { return GetAttributeValue(WORD_30Attribute); }
            set { SetAttributeValue(WORD_30Attribute, value); }
        }
        public int WORD_31
        {
            get { return GetAttributeValue(WORD_31Attribute); }
            set { SetAttributeValue(WORD_31Attribute, value); }
        }
        public int WORD_32
        {
            get { return GetAttributeValue(WORD_32Attribute); }
            set { SetAttributeValue(WORD_32Attribute, value); }
        }
        public int WORD_33
        {
            get { return GetAttributeValue(WORD_33Attribute); }
            set { SetAttributeValue(WORD_33Attribute, value); }
        }
        public int WORD_34
        {
            get { return GetAttributeValue(WORD_34Attribute); }
            set { SetAttributeValue(WORD_34Attribute, value); }
        }
        public int WORD_35
        {
            get { return GetAttributeValue(WORD_35Attribute); }
            set { SetAttributeValue(WORD_35Attribute, value); }
        }
        public int WORD_36
        {
            get { return GetAttributeValue(WORD_36Attribute); }
            set { SetAttributeValue(WORD_36Attribute, value); }
        }
        public int WORD_37
        {
            get { return GetAttributeValue(WORD_37Attribute); }
            set { SetAttributeValue(WORD_37Attribute, value); }
        }
        public int WORD_38
        {
            get { return GetAttributeValue(WORD_38Attribute); }
            set { SetAttributeValue(WORD_38Attribute, value); }
        }
        public int WORD_39
        {
            get { return GetAttributeValue(WORD_39Attribute); }
            set { SetAttributeValue(WORD_39Attribute, value); }
        }
        public int WORD_40
        {
            get { return GetAttributeValue(WORD_40Attribute); }
            set { SetAttributeValue(WORD_40Attribute, value); }
        }
        public bool CWWB1
        {
            get { return GetAttributeValue(CWWB1Attribute); }
            set { SetAttributeValue(CWWB1Attribute, value); }
        }
        public bool CWWB2
        {
            get { return GetAttributeValue(CWWB2Attribute); }
            set { SetAttributeValue(CWWB2Attribute, value); }
        }
        public bool CWWB3
        {
            get { return GetAttributeValue(CWWB3Attribute); }
            set { SetAttributeValue(CWWB3Attribute, value); }
        }
        public bool CWWB4
        {
            get { return GetAttributeValue(CWWB4Attribute); }
            set { SetAttributeValue(CWWB4Attribute, value); }
        }
        public bool CWWB5
        {
            get { return GetAttributeValue(CWWB5Attribute); }
            set { SetAttributeValue(CWWB5Attribute, value); }
        }
        public bool CWWB6
        {
            get { return GetAttributeValue(CWWB6Attribute); }
            set { SetAttributeValue(CWWB6Attribute, value); }
        }
        public bool CWWB7
        {
            get { return GetAttributeValue(CWWB7Attribute); }
            set { SetAttributeValue(CWWB7Attribute, value); }
        }
        public bool CWWB8
        {
            get { return GetAttributeValue(CWWB8Attribute); }
            set { SetAttributeValue(CWWB8Attribute, value); }
        }
        public bool CWWB9
        {
            get { return GetAttributeValue(CWWB9Attribute); }
            set { SetAttributeValue(CWWB9Attribute, value); }
        }
        public bool CWWB10
        {
            get { return GetAttributeValue(CWWB10Attribute); }
            set { SetAttributeValue(CWWB10Attribute, value); }
        }
        public bool CWWB11
        {
            get { return GetAttributeValue(CWWB11Attribute); }
            set { SetAttributeValue(CWWB11Attribute, value); }
        }
        public bool CWWB12
        {
            get { return GetAttributeValue(CWWB12Attribute); }
            set { SetAttributeValue(CWWB12Attribute, value); }
        }
        public bool CWWB13
        {
            get { return GetAttributeValue(CWWB13Attribute); }
            set { SetAttributeValue(CWWB13Attribute, value); }
        }
        public bool CWWB14
        {
            get { return GetAttributeValue(CWWB14Attribute); }
            set { SetAttributeValue(CWWB14Attribute, value); }
        }
        public bool CWWB15
        {
            get { return GetAttributeValue(CWWB15Attribute); }
            set { SetAttributeValue(CWWB15Attribute, value); }
        }
        public bool CWWB16
        {
            get { return GetAttributeValue(CWWB16Attribute); }
            set { SetAttributeValue(CWWB16Attribute, value); }
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
