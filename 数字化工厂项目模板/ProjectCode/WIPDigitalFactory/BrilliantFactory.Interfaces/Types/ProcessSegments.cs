using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BrilliantFactory.Interfaces.Types
{
    public static class ProcessSegments
    {
        public static class MasterSegment
        {
            public const string Name = "PW - Work Order Master Segment";

            public static class Properties
            {
                public static string MaterialRevision { get { return MasterSegment.GetFullyQualifiedPropertyName("Material Revision"); } }
                public static string OrganizationCode { get { return MasterSegment.GetFullyQualifiedPropertyName("Organization Code"); } }
                public static string SubInventory { get { return MasterSegment.GetFullyQualifiedPropertyName("SubInventory"); } }
                public static string Locator { get { return MasterSegment.GetFullyQualifiedPropertyName("Locator"); } }
                public static string WorkOrderType { get { return MasterSegment.GetFullyQualifiedPropertyName("Work Order Type"); } }
                public static string BOM { get { return MasterSegment.GetFullyQualifiedPropertyName("BOM"); } }
                public static string BOMRevision { get { return MasterSegment.GetFullyQualifiedPropertyName("BOM Revision"); } }
                public static string Project { get { return MasterSegment.GetFullyQualifiedPropertyName("Project"); } }

                public static bool GetOrganizationCode(string organizationCodeString, out int organizationCode, out string errorMessage)
                {
                    if (string.IsNullOrWhiteSpace(organizationCodeString))
                    {
                        organizationCode = new int();
                        errorMessage = "Please select organization code";
                        return false;
                    }

                    var organizationCodes = Regex.Matches(organizationCodeString, @"\d+");

                    if (organizationCodes.Count < 1)
                    {
                        organizationCode = new int();
                        errorMessage = "Selected organization code does not contain any number";
                        return false;
                    }

                    if (organizationCodes.Count > 1)
                    {
                        organizationCode = new int();
                        errorMessage = "Selected organization code contains more than one number";
                        return false;
                    }

                    if (!int.TryParse(organizationCodes[0].Value, out organizationCode))
                    {
                        errorMessage = "Selected organization code contains an invalid number";
                        return false;
                    }

                    errorMessage = null;
                    return true;
                }

                public static string GetFullyQualifiedPropertyName(string propertyName)
                {
                    return MasterSegment.GetFullyQualifiedPropertyName(propertyName);
                }
            }

            internal static string GetFullyQualifiedPropertyName(string propertyName)
            {
                return ProcessSegments.GetFullyQualifiedPropertyName(Name, propertyName);
            }

            public static class EquipmentRequirements
            {
                public static string ProductionLine { get { return "Production Line"; } }
            }
        }

        public static class OperationSegment
        {
            public const string Name = "PW - Operation";

            public static class Properties
            {
                public static string Comment { get { return GetFullyQualifiedPropertyName("Comment"); } }
                public static string SetupTime { get { return GetFullyQualifiedPropertyName("Setup Time"); } }
                public static string QueueTime { get { return GetFullyQualifiedPropertyName("Queue Time"); } }

                internal static string GetFullyQualifiedPropertyName(string propertyName)
                {
                    return OperationSegment.GetFullyQualifiedPropertyName(OperationSegment.Name, propertyName);
                }
            }

            public static class EquipmentRequirements
            {
                public class WorkCenter
                {
                    public static string Name { get { return "Work Center"; } }

                    public class Properties
                    {
                    }
                }
            }


            internal static string GetFullyQualifiedPropertyName(string processSegmentName, string propertyName)
            {
                return ProcessSegments.GetFullyQualifiedPropertyName(processSegmentName, propertyName);
            }
        }

        private static string GetFullyQualifiedPropertyName(string className, string propertyName)
        {
            return string.Format("{0}.{1}", className, propertyName);
        }
    }
}
