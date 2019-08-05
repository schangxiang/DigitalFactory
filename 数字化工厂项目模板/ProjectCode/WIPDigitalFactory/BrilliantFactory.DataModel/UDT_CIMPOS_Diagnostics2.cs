using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_CIMPOS_Diagnostics2")]
    public class UDT_CIMPOS_Diagnostics2 : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<Int64> TRANSACTION_COUNTERAttribute = new Attribute<Int64>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        public static Attribute<bool> CUSTOM_WARNING_0Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_1Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_2Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_3Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_4Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_5Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_6Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_7Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_8Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_9Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_10Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_11Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_12Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_13Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_14Attribute = new Attribute<bool>();
        public static Attribute<bool> CUSTOM_WARNING_15Attribute = new Attribute<bool>();


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
        public bool CUSTOM_WARNING_0
        {
            get { return GetAttributeValue(CUSTOM_WARNING_0Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_0Attribute, value); }
        }
        public bool CUSTOM_WARNING_1
        {
            get { return GetAttributeValue(CUSTOM_WARNING_1Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_1Attribute, value); }
        }
        public bool CUSTOM_WARNING_2
        {
            get { return GetAttributeValue(CUSTOM_WARNING_2Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_2Attribute, value); }
        }
        public bool CUSTOM_WARNING_3
        {
            get { return GetAttributeValue(CUSTOM_WARNING_3Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_3Attribute, value); }
        }
        public bool CUSTOM_WARNING_4
        {
            get { return GetAttributeValue(CUSTOM_WARNING_4Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_4Attribute, value); }
        }
        public bool CUSTOM_WARNING_5
        {
            get { return GetAttributeValue(CUSTOM_WARNING_5Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_5Attribute, value); }
        }
        public bool CUSTOM_WARNING_6
        {
            get { return GetAttributeValue(CUSTOM_WARNING_6Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_6Attribute, value); }
        }
        public bool CUSTOM_WARNING_7
        {
            get { return GetAttributeValue(CUSTOM_WARNING_7Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_7Attribute, value); }
        }
        public bool CUSTOM_WARNING_8
        {
            get { return GetAttributeValue(CUSTOM_WARNING_8Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_8Attribute, value); }
        }
        public bool CUSTOM_WARNING_9
        {
            get { return GetAttributeValue(CUSTOM_WARNING_9Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_9Attribute, value); }
        }
        public bool CUSTOM_WARNING_10
        {
            get { return GetAttributeValue(CUSTOM_WARNING_10Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_10Attribute, value); }
        }
        public bool CUSTOM_WARNING_11
        {
            get { return GetAttributeValue(CUSTOM_WARNING_11Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_11Attribute, value); }
        }
        public bool CUSTOM_WARNING_12
        {
            get { return GetAttributeValue(CUSTOM_WARNING_12Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_12Attribute, value); }
        }
        public bool CUSTOM_WARNING_13
        {
            get { return GetAttributeValue(CUSTOM_WARNING_13Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_13Attribute, value); }
        }
        public bool CUSTOM_WARNING_14
        {
            get { return GetAttributeValue(CUSTOM_WARNING_14Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_14Attribute, value); }
        }
        public bool CUSTOM_WARNING_15
        {
            get { return GetAttributeValue(CUSTOM_WARNING_15Attribute); }
            set { SetAttributeValue(CUSTOM_WARNING_15Attribute, value); }
        }

    }
}
