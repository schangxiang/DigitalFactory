using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_CIMPOS_Notification")]
    public class UDT_CIMPOS_Notification : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<Int64> TRANSACTION_COUNTERAttribute = new Attribute<Int64>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
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

    }
}
