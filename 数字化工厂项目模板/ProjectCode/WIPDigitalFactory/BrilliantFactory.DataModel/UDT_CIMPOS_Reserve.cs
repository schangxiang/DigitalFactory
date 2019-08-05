using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_CIMPOS_Reserve")]
    public class UDT_CIMPOS_Reserve : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<Int64> TRANSACTION_COUNTERAttribute = new Attribute<Int64>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
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

    }
}
