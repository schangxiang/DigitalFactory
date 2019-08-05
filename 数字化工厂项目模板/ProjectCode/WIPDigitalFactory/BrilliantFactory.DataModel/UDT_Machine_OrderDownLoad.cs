using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_Machine_OrderDownLoad")]
    public class UDT_Machine_OrderDownLoad : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> RPARTNUMAttribute = new Attribute<string>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> PARTNUMAttribute = new Attribute<string>();
        public static Attribute<int> QUANTITYAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> SAPORDAttribute = new Attribute<string>();
        public static Attribute<bool> ORDSTATAttribute = new Attribute<bool>();
        public static Attribute<int> ORDPROCAttribute = new Attribute<int>();
        public static Attribute<DateTime> SYSTIMEAttribute = new Attribute<DateTime>();
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
        public string RPARTNUM
        {
            get { return GetAttributeValue(RPARTNUMAttribute); }
            set { SetAttributeValue(RPARTNUMAttribute, value); }
        }
        public string PARTNUM
        {
            get { return GetAttributeValue(PARTNUMAttribute); }
            set { SetAttributeValue(PARTNUMAttribute, value); }
        }
        public int QUANTITY
        {
            get { return GetAttributeValue(QUANTITYAttribute); }
            set { SetAttributeValue(QUANTITYAttribute, value); }
        }
        public string SAPORD
        {
            get { return GetAttributeValue(SAPORDAttribute); }
            set { SetAttributeValue(SAPORDAttribute, value); }
        }
        public bool ORDSTAT
        {
            get { return GetAttributeValue(ORDSTATAttribute); }
            set { SetAttributeValue(ORDSTATAttribute, value); }
        }
        public int ORDPROC
        {
            get { return GetAttributeValue(ORDPROCAttribute); }
            set { SetAttributeValue(ORDPROCAttribute, value); }
        }
        public DateTime SYSTIME
        {
            get { return GetAttributeValue(SYSTIMEAttribute); }
            set { SetAttributeValue(SYSTIMEAttribute, value); }
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
