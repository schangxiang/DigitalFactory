using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_CIMPOS_Diagnostics")]
    public class UDT_CIMPOS_Diagnostics : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<Int64> TRANSACTION_COUNTERAttribute = new Attribute<Int64>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> PART_UNIQUE_SERIAL_NOAttribute = new Attribute<string>();
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
        public DateTime SYSTIME
        {
            get { return GetAttributeValue(SYSTIMEAttribute); }
            set { SetAttributeValue(SYSTIMEAttribute, value); }
        }

    }
}
