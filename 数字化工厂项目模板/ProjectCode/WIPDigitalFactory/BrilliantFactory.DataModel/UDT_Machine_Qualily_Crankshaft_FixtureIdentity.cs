using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_Machine_Qualily_Crankshaft_FixtureIdentity")]
    public class UDT_Machine_Qualily_Crankshaft_FixtureIdentity : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> OPERATIONIDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> OperationAttribute = new Attribute<string>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> EquipmentIDAttribute = new Attribute<string>();
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
        public string OPERATIONID
        {
            get { return GetAttributeValue(OPERATIONIDAttribute); }
            set { SetAttributeValue(OPERATIONIDAttribute, value); }
        }
        public string Operation
        {
            get { return GetAttributeValue(OperationAttribute); }
            set { SetAttributeValue(OperationAttribute, value); }
        }
        public string EquipmentID
        {
            get { return GetAttributeValue(EquipmentIDAttribute); }
            set { SetAttributeValue(EquipmentIDAttribute, value); }
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
