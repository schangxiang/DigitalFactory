using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proficy.Platform.Core.ProficySystem.Types;
using System.Reflection;

namespace BrilliantFactory.ServiceProvider.Models
{
    public class WorkOrder
    {
        public string Site { get; private set; }
        public string S95Id { get; private set; }
        public string Description { get; private set; }
        public DateTime? EarliestStartTime { get; private set; }
        public DateTime? LatestEndTime { get; private set; }
        public DirectoryResource ProducedMaterial { get; private set; }
        public DirectoryResource ProductionLine { get; private set; }
        public bool ProducedMaterial_IsSerializedPart { get; private set; }
        public int Quantity { get; private set; }
        public string UoM { get; private set; }
        public IEnumerable<Operation> Operations { get; private set; }
        public IEnumerable<Parameter> Parameters { get; private set; }

        public WorkOrder(string site, string s95Id, string description, DateTime? earliestStartTime, DateTime? latestEndTime, DirectoryResource producedMaterial, DirectoryResource productionLine, bool producedMaterial_IsSerializedPart, int quantity, string uoM, IEnumerable<Parameter> parameters, IEnumerable<Operation> operations)
        {
            this.Site = site;
            this.S95Id = s95Id;
            this.Description = description;
            this.EarliestStartTime = earliestStartTime;
            this.LatestEndTime = latestEndTime;
            this.ProducedMaterial = producedMaterial;
            this.ProductionLine = productionLine;
            this.ProducedMaterial_IsSerializedPart = producedMaterial_IsSerializedPart;
            this.Quantity = quantity;
            this.UoM = uoM;

            this.Parameters = parameters;

            this.Operations = operations;
        }

        private DataType GetParameterValue<DataType>(string id)
        {
            var parameter = this.Parameters.FirstOrDefault(p => p.Id == id);
            if (parameter == null)
                throw new Exception(string.Format("Parameter {0} not found", id));
            return (DataType)Convert.ChangeType(parameter.Value, typeof(DataType));
        }

        internal class PredefinedParameters
        {
            internal const string RouteName = "ROUTING";
            internal const string RouteRevision = "ROUTINGRevision";
            internal const string RouteAlternateDesignator = "RouteAlternateDesignator";
            internal const string OracleWOStatus = "OracleWOStatus";

        }

        internal string RouteName { get { return this.GetParameterValue<string>(PredefinedParameters.RouteName); } }
        internal int RouteRevision { get { return this.GetParameterValue<int>(PredefinedParameters.RouteRevision); } }
        internal string RouteAlternateDesignator { get { return this.GetParameterValue<string>(PredefinedParameters.RouteAlternateDesignator); } }
        internal string OracleWOStatus { get { return this.GetParameterValue<string>(PredefinedParameters.OracleWOStatus); } }

        internal string GetSerialNumber(int producedLotNumber)
        {
            return string.Format("{0}-{1}", this.S95Id, producedLotNumber + 1);
        }


        //Parameter class
        public class Parameter
        {
            public string Id { get; private set; }
            public object Value { get; private set; }

            public string FullyQualifiedId { get; set; }

            public Parameter(string id, object value)
            {
                this.Id = id;
                this.Value = value;
            }
        }

        //Operation

        public class Operation
        {
            public string OperationId { get; private set; }
            public string Description { get; private set; }
            public DateTime? EarliestStartTime { get; private set; }
            public DateTime? LatestEndTime { get; private set; }
            public IEnumerable<PersonnelRequirement> PersonnelRequirements { get; private set; }
            public IEnumerable<EquipmentRequirement> EquipmentRequirements { get; private set; }
            public IEnumerable<MaterialConsumedRequirement> MaterialConsumedRequirements { get; private set; }

            public EquipmentRequirement WorkCenter { get { return this.EquipmentRequirements.Single(); } }
            public PersonnelRequirement Personnel { get { return this.PersonnelRequirements.SingleOrDefault(); } }

            public Operation(string operationId, string description, DateTime? earliestStartTime, DateTime? latestEndTime, IEnumerable<PersonnelRequirement> personnelRequirements, IEnumerable<EquipmentRequirement> equipmentRequirements, IEnumerable<MaterialConsumedRequirement> materialConsumedRequirements)
            {
                this.OperationId = operationId;
                this.Description = description;
                this.EarliestStartTime = earliestStartTime;
                this.LatestEndTime = latestEndTime;
                this.PersonnelRequirements = personnelRequirements;
                this.EquipmentRequirements = equipmentRequirements;
                this.MaterialConsumedRequirements = materialConsumedRequirements;
            }

            public class PersonnelRequirement
            {
                public string PersonId { get; private set; }
                public double Quantity { get; private set; }

                public DirectoryResource Person { get; private set; }

                public IEnumerable<Parameter> Parameters { get; private set; }

                public Parameter GetParameter(string id) { return this.Parameters.FirstOrDefault(p => p.Id == id); }
                private DataType GetParameterValue<DataType>(string id) { var parameter = this.Parameters.FirstOrDefault(p => p.Id == id); if (parameter == null) throw new Exception(string.Format("Parameter {0} not found", id)); return (DataType)Convert.ChangeType(parameter.Value, typeof(DataType)); }

                public class PredefinedParameters
                {
                    public const string ResourceSequence = "RESOURCE_SEQ_NUM";
                    public const string UsageRate = "USAGE_RATE";
                    public const string ScheduledFlag = "SCHEDULED_FLAG";
                    public const string BasisType = "BASIS_TYPE";

                    public static string[] GetAll()
                    {
                        return (from field in typeof(PredefinedParameters).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                where field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string)
                                select (string)field.GetRawConstantValue()).ToArray();
                    }
                }

                public int ResourceSequence { get { return this.GetParameterValue<int>(PredefinedParameters.ResourceSequence); } }
                public string UsageRate { get { return this.GetParameterValue<string>(PredefinedParameters.UsageRate); } }
                public string ScheduledFlag { get { return this.GetParameterValue<string>(PredefinedParameters.ScheduledFlag); } }
                public string BasisType { get { return this.GetParameterValue<string>(PredefinedParameters.BasisType); } }

                public PersonnelRequirement(string personId, double quantity, DirectoryResource person, IEnumerable<Parameter> parameters)
                {
                    this.PersonId = personId;
                    this.Quantity = quantity;

                    this.Person = person;

                    this.Parameters = parameters;
                }
            }

            public class EquipmentRequirement
            {
                public string EquipmentId { get; private set; }
                public double Quantity { get; private set; }

                public DirectoryResource Equipment { get; private set; }

                public IEnumerable<Parameter> Parameters { get; private set; }

                public Parameter GetParameter(string id) { return this.Parameters.FirstOrDefault(p => p.Id == id); }
                private DataType GetParameterValue<DataType>(string id) { var parameter = this.Parameters.FirstOrDefault(p => p.Id == id); if (parameter == null) throw new Exception(string.Format("Parameter {0} not found", id)); return (DataType)Convert.ChangeType(parameter.Value, typeof(DataType)); }

                public class PredefinedParameters
                {
                    public const string ResourceSequence = "RESOURCE_SEQ_NUM";
                    public const string UsageRate = "USAGE_RATE";
                    public const string ScheduledFlag = "SCHEDULED_FLAG";
                    public const string BasisType = "BASIS_TYPE";

                    public static string[] GetAll()
                    {
                        return (from field in typeof(PredefinedParameters).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                where field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string)
                                select (string)field.GetRawConstantValue()).ToArray();
                    }
                }

                public int ResourceSequence { get { return this.GetParameterValue<int>(PredefinedParameters.ResourceSequence); } }
                public string UsageRate { get { return this.GetParameterValue<string>(PredefinedParameters.UsageRate); } }
                public string ScheduledFlag { get { return this.GetParameterValue<string>(PredefinedParameters.ScheduledFlag); } }
                public string BasisType { get { return this.GetParameterValue<string>(PredefinedParameters.BasisType); } }

                public EquipmentRequirement(string equipmentId, double quantity, DirectoryResource equipment, IEnumerable<Parameter> parameters)
                {
                    this.EquipmentId = equipmentId;
                    this.Quantity = quantity;

                    this.Equipment = equipment;

                    this.Parameters = parameters;
                }
            }

            public class MaterialConsumedRequirement
            {
                public string MaterialId { get; private set; }
                public double Quantity { get; private set; }

                public IEnumerable<Parameter> Parameters { get; private set; }

                public Parameter GetParameter(string id) { return this.Parameters.FirstOrDefault(p => p.Id == id); }
                private DataType GetParameterValue<DataType>(string id) { var parameter = this.Parameters.FirstOrDefault(p => p.Id == id); if (parameter == null) throw new Exception(string.Format("Parameter {0} not found", id)); return (DataType)Convert.ChangeType(parameter.Value, typeof(DataType)); }

                public class PredefinedParameters
                {
                    public const string ItemSequence = "ITEM_SEQ";
                    public const string SupplyInventory = "SUPPLY_SUBINVENTORY";
                    public const string SupplyLocator = "SUPPLY_LOCATOR";

                    public static string[] GetAll()
                    {
                        return (from field in typeof(PredefinedParameters).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                where field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string)
                                select (string)field.GetRawConstantValue()).ToArray();
                    }
                }

                public int ItemSequence { get { return this.GetParameterValue<int>(PredefinedParameters.ItemSequence); } }
                public string SupplyInventory { get { return this.GetParameterValue<string>(PredefinedParameters.SupplyInventory); } }
                public string SupplyLocator { get { return this.GetParameterValue<string>(PredefinedParameters.SupplyLocator); } }

                public MaterialConsumedRequirement(string materialId, double quantity, IEnumerable<Parameter> parameters)
                {
                    this.MaterialId = materialId;
                    this.Quantity = quantity;

                    this.Parameters = parameters;
                }
            }
        }

    }
}
