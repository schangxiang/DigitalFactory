using Proficy.Platform.Core.Dms.Dmfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.DataModel
{
    [Persistent(Table = "UDT_Machine_EOL_PartsOfPallet")]
    public class UDT_Machine_EOL_PartsOfPallet : ObjectType
    {
        [PrimaryKey(0)]
        public static Attribute<Guid> IDAttribute = new Attribute<Guid>();
        public static Attribute<int> FACILITYIDAttribute = new Attribute<int>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> MACHINEIDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 12)]
        public static Attribute<string> DATETIME_PAttribute = new Attribute<string>();
        [AttributeColumn(Length = 20)]
        public static Attribute<string> PALLETIDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART1IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART2IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART3IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART4IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART5IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART6IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART7IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART8IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART9IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART10IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART11IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART12IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART13IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART14IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART15IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART16IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART17IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART18IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART19IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART20IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART21IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART22IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART23IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART24IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART25IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART26IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART27IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART28IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART29IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART30IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART31IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART32IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART33IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART34IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART35IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART36IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART37IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART38IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART39IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART40IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART41IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART42IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART43IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART44IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART45IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART46IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART47IDAttribute = new Attribute<string>();
        [AttributeColumn(Length = 36)]
        public static Attribute<string> PPART48IDAttribute = new Attribute<string>();
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
        public string MACHINEID
        {
            get { return GetAttributeValue(MACHINEIDAttribute); }
            set { SetAttributeValue(MACHINEIDAttribute, value); }
        }
        public string DATETIME_P
        {
            get { return GetAttributeValue(DATETIME_PAttribute); }
            set { SetAttributeValue(DATETIME_PAttribute, value); }
        }
        public string PALLETID
        {
            get { return GetAttributeValue(PALLETIDAttribute); }
            set { SetAttributeValue(PALLETIDAttribute, value); }
        }
        public string PPART1ID
        {
            get { return GetAttributeValue(PPART1IDAttribute); }
            set { SetAttributeValue(PPART1IDAttribute, value); }
        }
        public string PPART2ID
        {
            get { return GetAttributeValue(PPART2IDAttribute); }
            set { SetAttributeValue(PPART2IDAttribute, value); }
        }
        public string PPART3ID
        {
            get { return GetAttributeValue(PPART3IDAttribute); }
            set { SetAttributeValue(PPART3IDAttribute, value); }
        }
        public string PPART4ID
        {
            get { return GetAttributeValue(PPART4IDAttribute); }
            set { SetAttributeValue(PPART4IDAttribute, value); }
        }
        public string PPART5ID
        {
            get { return GetAttributeValue(PPART5IDAttribute); }
            set { SetAttributeValue(PPART5IDAttribute, value); }
        }
        public string PPART6ID
        {
            get { return GetAttributeValue(PPART6IDAttribute); }
            set { SetAttributeValue(PPART6IDAttribute, value); }
        }
        public string PPART7ID
        {
            get { return GetAttributeValue(PPART7IDAttribute); }
            set { SetAttributeValue(PPART7IDAttribute, value); }
        }
        public string PPART8ID
        {
            get { return GetAttributeValue(PPART8IDAttribute); }
            set { SetAttributeValue(PPART8IDAttribute, value); }
        }
        public string PPART9ID
        {
            get { return GetAttributeValue(PPART9IDAttribute); }
            set { SetAttributeValue(PPART9IDAttribute, value); }
        }
        public string PPART10ID
        {
            get { return GetAttributeValue(PPART10IDAttribute); }
            set { SetAttributeValue(PPART10IDAttribute, value); }
        }
        public string PPART11ID
        {
            get { return GetAttributeValue(PPART11IDAttribute); }
            set { SetAttributeValue(PPART11IDAttribute, value); }
        }
        public string PPART12ID
        {
            get { return GetAttributeValue(PPART12IDAttribute); }
            set { SetAttributeValue(PPART12IDAttribute, value); }
        }
        public string PPART13ID
        {
            get { return GetAttributeValue(PPART13IDAttribute); }
            set { SetAttributeValue(PPART13IDAttribute, value); }
        }
        public string PPART14ID
        {
            get { return GetAttributeValue(PPART14IDAttribute); }
            set { SetAttributeValue(PPART14IDAttribute, value); }
        }
        public string PPART15ID
        {
            get { return GetAttributeValue(PPART15IDAttribute); }
            set { SetAttributeValue(PPART15IDAttribute, value); }
        }
        public string PPART16ID
        {
            get { return GetAttributeValue(PPART16IDAttribute); }
            set { SetAttributeValue(PPART16IDAttribute, value); }
        }
        public string PPART17ID
        {
            get { return GetAttributeValue(PPART17IDAttribute); }
            set { SetAttributeValue(PPART17IDAttribute, value); }
        }
        public string PPART18ID
        {
            get { return GetAttributeValue(PPART18IDAttribute); }
            set { SetAttributeValue(PPART18IDAttribute, value); }
        }
        public string PPART19ID
        {
            get { return GetAttributeValue(PPART19IDAttribute); }
            set { SetAttributeValue(PPART19IDAttribute, value); }
        }
        public string PPART20ID
        {
            get { return GetAttributeValue(PPART20IDAttribute); }
            set { SetAttributeValue(PPART20IDAttribute, value); }
        }
        public string PPART21ID
        {
            get { return GetAttributeValue(PPART21IDAttribute); }
            set { SetAttributeValue(PPART21IDAttribute, value); }
        }
        public string PPART22ID
        {
            get { return GetAttributeValue(PPART22IDAttribute); }
            set { SetAttributeValue(PPART22IDAttribute, value); }
        }
        public string PPART23ID
        {
            get { return GetAttributeValue(PPART23IDAttribute); }
            set { SetAttributeValue(PPART23IDAttribute, value); }
        }
        public string PPART24ID
        {
            get { return GetAttributeValue(PPART24IDAttribute); }
            set { SetAttributeValue(PPART24IDAttribute, value); }
        }
        public string PPART25ID
        {
            get { return GetAttributeValue(PPART25IDAttribute); }
            set { SetAttributeValue(PPART25IDAttribute, value); }
        }
        public string PPART26ID
        {
            get { return GetAttributeValue(PPART26IDAttribute); }
            set { SetAttributeValue(PPART26IDAttribute, value); }
        }
        public string PPART27ID
        {
            get { return GetAttributeValue(PPART27IDAttribute); }
            set { SetAttributeValue(PPART27IDAttribute, value); }
        }
        public string PPART28ID
        {
            get { return GetAttributeValue(PPART28IDAttribute); }
            set { SetAttributeValue(PPART28IDAttribute, value); }
        }
        public string PPART29ID
        {
            get { return GetAttributeValue(PPART29IDAttribute); }
            set { SetAttributeValue(PPART29IDAttribute, value); }
        }
        public string PPART30ID
        {
            get { return GetAttributeValue(PPART30IDAttribute); }
            set { SetAttributeValue(PPART30IDAttribute, value); }
        }
        public string PPART31ID
        {
            get { return GetAttributeValue(PPART31IDAttribute); }
            set { SetAttributeValue(PPART31IDAttribute, value); }
        }
        public string PPART32ID
        {
            get { return GetAttributeValue(PPART32IDAttribute); }
            set { SetAttributeValue(PPART32IDAttribute, value); }
        }
        public string PPART33ID
        {
            get { return GetAttributeValue(PPART33IDAttribute); }
            set { SetAttributeValue(PPART33IDAttribute, value); }
        }
        public string PPART34ID
        {
            get { return GetAttributeValue(PPART34IDAttribute); }
            set { SetAttributeValue(PPART34IDAttribute, value); }
        }
        public string PPART35ID
        {
            get { return GetAttributeValue(PPART35IDAttribute); }
            set { SetAttributeValue(PPART35IDAttribute, value); }
        }
        public string PPART36ID
        {
            get { return GetAttributeValue(PPART36IDAttribute); }
            set { SetAttributeValue(PPART36IDAttribute, value); }
        }
        public string PPART37ID
        {
            get { return GetAttributeValue(PPART37IDAttribute); }
            set { SetAttributeValue(PPART37IDAttribute, value); }
        }
        public string PPART38ID
        {
            get { return GetAttributeValue(PPART38IDAttribute); }
            set { SetAttributeValue(PPART38IDAttribute, value); }
        }
        public string PPART39ID
        {
            get { return GetAttributeValue(PPART39IDAttribute); }
            set { SetAttributeValue(PPART39IDAttribute, value); }
        }
        public string PPART40ID
        {
            get { return GetAttributeValue(PPART40IDAttribute); }
            set { SetAttributeValue(PPART40IDAttribute, value); }
        }
        public string PPART41ID
        {
            get { return GetAttributeValue(PPART41IDAttribute); }
            set { SetAttributeValue(PPART41IDAttribute, value); }
        }
        public string PPART42ID
        {
            get { return GetAttributeValue(PPART42IDAttribute); }
            set { SetAttributeValue(PPART42IDAttribute, value); }
        }
        public string PPART43ID
        {
            get { return GetAttributeValue(PPART43IDAttribute); }
            set { SetAttributeValue(PPART43IDAttribute, value); }
        }
        public string PPART44ID
        {
            get { return GetAttributeValue(PPART44IDAttribute); }
            set { SetAttributeValue(PPART44IDAttribute, value); }
        }
        public string PPART45ID
        {
            get { return GetAttributeValue(PPART45IDAttribute); }
            set { SetAttributeValue(PPART45IDAttribute, value); }
        }
        public string PPART46ID
        {
            get { return GetAttributeValue(PPART46IDAttribute); }
            set { SetAttributeValue(PPART46IDAttribute, value); }
        }
        public string PPART47ID
        {
            get { return GetAttributeValue(PPART47IDAttribute); }
            set { SetAttributeValue(PPART47IDAttribute, value); }
        }
        public string PPART48ID
        {
            get { return GetAttributeValue(PPART48IDAttribute); }
            set { SetAttributeValue(PPART48IDAttribute, value); }
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
