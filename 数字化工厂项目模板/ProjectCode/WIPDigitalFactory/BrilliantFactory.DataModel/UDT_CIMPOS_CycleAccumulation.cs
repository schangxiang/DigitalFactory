using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_CIMPOS_CycleAccumulation")]
    public class UDT_CIMPOS_CycleAccumulation : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<Int64> TRANSACTION_COUNTERAttribute = new Attribute<Int64>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> PART_UNIQUE_SERIAL_NOAttribute = new Attribute<string>();
        public static Attribute<int> LAST_CYCLE_TIMEAttribute = new Attribute<int>();
        public static Attribute<int> ACCUM_CYCLE_TIME_CNTAttribute = new Attribute<int>();
        public static Attribute<int> GOOD_MACHINE_CYCLESAttribute = new Attribute<int>();
        public static Attribute<int> BAD_MACHINE_CYCLESAttribute = new Attribute<int>();
        public static Attribute<int> TOTAL_CYCLESAttribute = new Attribute<int>();
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
        public DateTime SYSTIME
        {
            get { return GetAttributeValue(SYSTIMEAttribute); }
            set { SetAttributeValue(SYSTIMEAttribute, value); }
        }

    }
}
