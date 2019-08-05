using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_CIMPOS_Cycle")]
    public class UDT_CIMPOS_Cycle : ObjectType
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
        public DateTime SYSTIME
        {
            get { return GetAttributeValue(SYSTIMEAttribute); }
            set { SetAttributeValue(SYSTIMEAttribute, value); }
        }

    }
}
