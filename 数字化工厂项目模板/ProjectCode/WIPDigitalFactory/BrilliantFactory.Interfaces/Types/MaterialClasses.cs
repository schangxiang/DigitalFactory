using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Interfaces.Types
{
    public class MaterialClasses
    {

        public static class Item
        {
            public const string Name = "";

            public static class Properties
            {
                public static string Site { get { return Item.GetFullyQualifiedPropertyName("Site"); } }
                public static string PrimaryUnitOfMeasure { get { return Item.GetFullyQualifiedPropertyName("UOM"); } }
                public static string Serialized { get { return Item.GetFullyQualifiedPropertyName("Serialized"); } }
                public static string Revision { get { return Item.GetFullyQualifiedPropertyName("Revision"); } }
                public static string ManuallySetIsSerializedPart { get { return Item.GetFullyQualifiedPropertyName("Manually Set IsSerializedPart"); } }
            }

            private static string GetFullyQualifiedPropertyName(string propertyName)
            {
                return MaterialClasses.GetFullyQualifiedPropertyName(Name, propertyName);
            }
        }
        public static class PfM_ProducedMaterial
        {
            public const string Name = "PFM_ProducedMaterial";

            public class Properties
            {
                public static string IsSerializedPart { get { return PfM_ProducedMaterial.GetFullyQualifiedPropertyName("IsSerializedPart"); } }
            }

            private static string GetFullyQualifiedPropertyName(string propertyName)
            {
                return MaterialClasses.GetFullyQualifiedPropertyName(Name, propertyName);
            }
        }

        private static string GetFullyQualifiedPropertyName(string className, string propertyName)
        {
            return string.Format("{0}.{1}", className, propertyName);
        }

        public static class BOMItem
        {
            public const string Name = "PFM_BOMMaterial";

            public static class Properties
            {
                public static string ItemSequence { get { return BOMItem.GetFullyQualifiedPropertyName("Item Sequence"); } }
                public static string SupplyInventory { get { return BOMItem.GetFullyQualifiedPropertyName("Supply Inventory"); } }
                public static string SupplyLocator { get { return BOMItem.GetFullyQualifiedPropertyName("Supply Locator"); } }
            }

            public static string GetShortPropertyName(string fullyQualifiedPropertyName)
            {
                return MaterialClasses.GetShortPropertyName(Name, fullyQualifiedPropertyName);
            }

            private static string GetFullyQualifiedPropertyName(string propertyName)
            {
                return MaterialClasses.GetFullyQualifiedPropertyName(Name, propertyName);
            }


        }

        private static string GetShortPropertyName(string className, string fullyQualifiedPropertyName)
        {
            if (fullyQualifiedPropertyName.StartsWith(className + "."))
                return fullyQualifiedPropertyName.Remove(0, className.Length + 1);

            return fullyQualifiedPropertyName;
        }
    }
}
