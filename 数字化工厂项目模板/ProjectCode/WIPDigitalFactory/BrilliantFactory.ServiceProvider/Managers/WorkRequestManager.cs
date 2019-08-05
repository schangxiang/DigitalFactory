using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Proficy.Platform.Core.ProficySystem.Types;
using Proficy.Platform.Core.DOR.Interfaces;
using System.Diagnostics;
using Proficy.Platform.Services.Database.Interfaces;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Text.RegularExpressions;

using Proficy.PFM.Solutions.DocMgmt.Interfaces.Helpers;
using System.Data;
using Proficy.Platform.Services.Equipment.Interfaces;
using Proficy.Platform.Services.Production.Interfaces;
using BrilliantFactory.Interfaces.Model;
using BrilliantFactory.ServiceProvider.Models;
using BrilliantFactory.Interfaces.Types;
//using Proficy.OpenEnterprise.Types;
using Proficy.Platform.Core.Dms.Dmfc;
using BrilliantFactory.DataModel;
using Proficy.PFM.Solutions.Route.Interfaces;
using Proficy.Platform.Core.ProficySystem.MobileObject;


namespace BrilliantFactory.Managers
{
    public class WorkRequestManager
    {
        internal ServiceDirectoryManager ServiceDirectoryManager { get; set; }
        internal DatabaseManager DatabaseManager { get; set; }
        internal MaterialDefinitionManager MaterialDefinitionManager { get; set; }
        internal PersonnelManager PersonnelManager { get; set; }
        internal EquipmentManager EquipmentManager { get; set; }


        private SessionFactory sessionFactory { get; set; }

        public WorkRequestManager(ServiceDirectoryManager serviceDirectoryManager, DatabaseManager databaseManager,
            MaterialDefinitionManager materialDefManager, PersonnelManager perManager, EquipmentManager EQManager)
        {
            this.ServiceDirectoryManager = serviceDirectoryManager;
            this.DatabaseManager = databaseManager;
            this.MaterialDefinitionManager = materialDefManager;
            this.PersonnelManager = perManager;
            this.EquipmentManager = EQManager;

        }

        #region Process Input XML

        public InboundDetails processMessage(string Message)
        {
            InboundDetails output = new InboundDetails();
            string ErrorMessage = "Success";
            //WorkOrder workOrder;

            string site, S95Id = string.Empty;

            if (Message != null || Message != string.Empty)
            {
                try
                {
                    //Parse the message for each pending shop order
                    //ErrorMessage = ParseMessage(Message, out workOrder);
                    site = "zsy";// workOrder.Site;
                    S95Id = "zsy";// workOrder.S95Id;

                    //Get Route name 
                    // var RouteName = workOrder.ProductionLine.DisplayName + "-" + workOrder.ProducedMaterial.DisplayName;
                    Debug.WriteLine("Scheduling modifications");

                    var workRequest = this.GetWorkRequest(S95Id);
                    if (workRequest == null)
                        ErrorMessage = "createShopOrder(workOrder)";
                    else
                    {


                        ErrorMessage = "Shop order: " + S95Id + " already exists";
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;

                }

            }

            //build return value
            output.ErrorMessage = ErrorMessage;
            if (ErrorMessage == "Success")
                output.ErrorCode = 0;
            else
                output.ErrorCode = -1;
            output.MainData = S95Id;

            return output;

        }


        public void ProcessTestResult(string Message)
        {


        }

        //public string ParseMessage(string message, out WorkOrder workOrder)
        //{
        //    workOrder = null;
        //    var productionSchedule = ProductionScheduleType.FromB2MMLDocument(message);


        //    Contract.Requires(productionSchedule.ProductionRequest.Count() == 1, "Support one production request per file");
        //    var productionRequest = productionSchedule.ProductionRequest.Single();

        //    //Contract.Requires(productionRequest.Location != null && productionRequest.Location.EquipmentID != null && !string.IsNullOrWhiteSpace(productionRequest.Location.EquipmentID.Value), "Location is required for production request");
        //    //var site = productionRequest.Location.EquipmentID.Value;

        //    ////var prodline = GetProductioinLine(site);

        //    //Contract.Requires(productionRequest.ID != null && !string.IsNullOrWhiteSpace(productionRequest.ID.Value), "ID is required for production request");
        //    //var s95Id = productionRequest.ID.Value;

        //    //Contract.Requires(productionRequest.Description != null && productionRequest.Description.Count() > 0, "Description is required for production request");
        //    //Contract.Requires(productionRequest.Description.Count() == 1, "Support one description per master segment");
        //    //var description = productionRequest.Description.Single().Value;

        //    //Contract.Requires(productionRequest.SegmentRequirement != null, "Segment requirements are required for production request");
        //    //Contract.Requires(productionRequest.SegmentRequirement.All(segment => segment.ID != null && !string.IsNullOrWhiteSpace(segment.ID.Value)), "ID is required for segment requirement");
        //    //var masterSegments = productionRequest.SegmentRequirement.Where(segment => Regex.IsMatch(segment.ID.Value, "^0+$"));
        //    //Contract.Requires(masterSegments.Count() > 0, "Master segment required for production request");
        //    //Contract.Requires(masterSegments.Count() == 1, "Support one segment requirement per production request");
        //    //var masterSegment = masterSegments.Single();



        //    //Contract.Requires(masterSegment.MaterialProducedRequirement != null && masterSegment.MaterialProducedRequirement.Count() > 0, "Material produced is required for master segment");
        //    //Contract.Requires(masterSegment.MaterialProducedRequirement.Count() == 1, "Support one material produced per master segment");
        //    //var materialProduced = masterSegment.MaterialProducedRequirement.Single();

        //    //Contract.Requires(materialProduced.MaterialDefinitionID != null && materialProduced.MaterialDefinitionID.Count() > 0, "Material definition is required for material produced");
        //    //Contract.Requires(materialProduced.MaterialDefinitionID.Count() == 1, "Support one material definition per material produced");
        //    //if (materialProduced == null)
        //    //{
        //    //    return "Material definition not supplied";
        //    //}
        //    //var materialProducedId = materialProduced.MaterialDefinitionID.Single();
        //    //Contract.Requires(!string.IsNullOrWhiteSpace(materialProducedId.Value), "Material definition is required for material produced");
        //    //var producedMaterialS95Id = materialProducedId.Value;
        //    //var producedMaterial = this.MaterialDefinitionManager.GetMaterialDefinitionFromDB(producedMaterialS95Id);
        //    //Contract.Requires(producedMaterial != null, string.Format("Produced material not found (name = {0})", producedMaterial));
        //    ////var prodline = GetProductioinLine(site,producedMaterial);




        //    //Contract.Requires(masterSegment.EarliestStartTime != null, "EarliestStartTime is required for master segment");
        //    //var earliestStartTime = masterSegment.EarliestStartTime.Value == DateTime.MinValue ? (DateTime?)null : masterSegment.EarliestStartTime.Value;

        //    //Contract.Requires(masterSegment.LatestEndTime != null, "LatestEndTime is required for master segment");
        //    //var latestEndTime = masterSegment.LatestEndTime.Value == DateTime.MinValue ? (DateTime?)null : masterSegment.LatestEndTime.Value;


        //    //var siteResource = EquipmentManager.GetDepartment(site);
        //    //var siteParent = this.ServiceDirectoryManager.IEquipment.GetEquipmentParent(siteResource);

        //    //var timeZoneValue = this.ServiceDirectoryManager.IEquipment.GetPropertyDetails(siteParent, "TimezoneName");

        //    ////Convert received times to UTC
        //    //earliestStartTime = BFHelper.ConvertTimeZoneToUTC(earliestStartTime.Value, timeZoneValue.Value.ToString());
        //    //latestEndTime = BFHelper.ConvertTimeZoneToUTC(latestEndTime.Value, timeZoneValue.Value.ToString());

        //    //var producedMaterial_IsSerializedPart = (bool)this.ServiceDirectoryManager.IMaterial.ReadMaterialValue(producedMaterial, MaterialClasses.PfM_ProducedMaterial.Properties.IsSerializedPart).ObjectValue;

        //    //Contract.Requires(materialProduced.Quantity != null && materialProduced.Quantity.Count() > 0, "Quantity is required for material produced");
        //    //Contract.Requires(materialProduced.Quantity.Count() == 1, "Support one quantity per material produced");
        //    //var materialProducedQuantity = materialProduced.Quantity.Single();

        //    //Contract.Requires(materialProducedQuantity.QuantityString != null && !string.IsNullOrWhiteSpace(materialProducedQuantity.QuantityString.Value), "Quantity is required for material produced");
        //    //int quantity;
        //    //var quantityCorrect = int.TryParse(materialProducedQuantity.QuantityString.Value, out quantity);
        //    //Contract.Requires(quantityCorrect && quantity > 0, "Invalid material produced quantity");

        //    //var uoM = materialProducedQuantity.UnitOfMeasure == null ? null : materialProducedQuantity.UnitOfMeasure.Value;

        //    //Contract.Requires(materialProduced.MaterialProducedRequirementProperty != null, "Properties are required for produced material");
        //    //Contract.Requires(materialProduced.MaterialProducedRequirementProperty.All(p => p.ID != null && !string.IsNullOrWhiteSpace(p.ID.Value)), "ID is required for each MaterialProducedRequirementProperty");
        //    //Contract.Requires(materialProduced.MaterialProducedRequirementProperty.All(p => p.Value != null && p.Value.Count() > 0), "Value is required for each MaterialProducedRequirementProperty");
        //    //var parameters = materialProduced.MaterialProducedRequirementProperty.Select(mprp => new WorkOrder.Parameter(mprp.ID.Value, mprp.Value.Count() == 1 ? (object)mprp.Value.Single().ValueString.Value : mprp.Value.Select(v => v.ValueString.Value).ToArray())).ToArray();


        //    var operations = new List<WorkOrder.Operation>();
        //    Debug.WriteLine("Reading operations");

        //    foreach (var operationSegmentRequirement in productionRequest.SegmentRequirement.Except(Enumerable.Repeat(masterSegment, 1)))
        //    {
        //        var operationId = operationSegmentRequirement.ID.Value;
        //        Contract.Requires(!string.IsNullOrWhiteSpace(operationId), "Invalid operation id");

        //        Contract.Requires(operationSegmentRequirement.Description != null && operationSegmentRequirement.Description.Count() > 0, "Description is required for operation segment");
        //        Contract.Requires(operationSegmentRequirement.Description.Count() == 1, "Support one description per operation segment");
        //        var operationDescription = operationSegmentRequirement.Description.Single().Value;

        //        Contract.Requires(operationSegmentRequirement.EarliestStartTime != null, "EarliestStartTime is required for operation segment");
        //        var operationEarliestStartTime = operationSegmentRequirement.EarliestStartTime.Value;

        //        Contract.Requires(operationSegmentRequirement.LatestEndTime != null, "LatestEndTime is required for operation segment");
        //        var operationLatestEndTime = operationSegmentRequirement.LatestEndTime.Value;

        //        var operationPersonnelRequirements = new List<WorkOrder.Operation.PersonnelRequirement>();
        //        Debug.WriteLine("Reading operation personnel requirements");

        //        foreach (var operationPersonnelRequirementNode in operationSegmentRequirement.PersonnelRequirement)
        //        {
        //            Contract.Requires(operationPersonnelRequirementNode.PersonID != null && operationPersonnelRequirementNode.PersonID.Count() > 0, "PersonID is required for operation personnel requirement");
        //            Contract.Requires(operationPersonnelRequirementNode.PersonID.Count() == 1, "Support one PersonID per operation personnel requirement");
        //            var operationPersonnelRequirement = operationPersonnelRequirementNode.PersonID.Single();

        //            Contract.Requires(operationPersonnelRequirement.Value != null, "Invalid value for operation personnel requirement");
        //            var operationPersonnelRequirementPersonId = operationPersonnelRequirement.Value;
        //            var operationPersonnelRequirementPerson = this.PersonnelManager.GetResource(operationPersonnelRequirementPersonId);
        //            Contract.Requires(operationPersonnelRequirementPerson != null, string.Format("Personnel resource {0} not found", operationPersonnelRequirementPersonId));

        //            Contract.Requires(operationPersonnelRequirementNode.Quantity != null && operationPersonnelRequirementNode.Quantity.Count() > 0, "Quantity is required for operation personnel requirement");
        //            Contract.Requires(operationPersonnelRequirementNode.Quantity.Count() == 1, "Support one Quantity per operation personnel requirement");
        //            var operationPersonnelRequirementQuantityNode = operationPersonnelRequirementNode.Quantity.Single();

        //            Contract.Requires(operationPersonnelRequirementQuantityNode.QuantityString != null && operationPersonnelRequirementQuantityNode.QuantityString.Value != null, "Quantity is required for operation personnel requirement");
        //            double operationPersonnelRequirementQuantity;
        //            var operationPersonnelRequirementQuantityCorrect = double.TryParse(operationPersonnelRequirementQuantityNode.QuantityString.Value, out operationPersonnelRequirementQuantity);
        //            Contract.Requires(operationPersonnelRequirementQuantityCorrect && operationPersonnelRequirementQuantity > 0, "Invalid operation personnel requirement quantity");

        //            Contract.Requires(operationPersonnelRequirementNode.PersonnelRequirementProperty != null, "Properties are required for operation personnel requirement");
        //            Contract.Requires(operationPersonnelRequirementNode.PersonnelRequirementProperty.All(p => p.ID != null && !string.IsNullOrWhiteSpace(p.ID.Value)), "ID is required for each operation personnel requirement property");
        //            Contract.Requires(operationPersonnelRequirementNode.PersonnelRequirementProperty.All(prp => prp.Value != null && prp.Value.Count() >= 1), "Value is required for operation personnel requirement property");
        //            Contract.Requires(operationPersonnelRequirementNode.PersonnelRequirementProperty.All(prp => prp.Value.Count() == 1), "One value supported for required for operation personnel requirement property");
        //            var operationPersonnelRequirementParameters = operationPersonnelRequirementNode.PersonnelRequirementProperty.Select(prp => new WorkOrder.Parameter(prp.ID.Value, prp.Value.Single().ValueString.Value));

        //            var personnelRequirement = new WorkOrder.Operation.PersonnelRequirement(operationPersonnelRequirementPersonId, operationPersonnelRequirementQuantity, operationPersonnelRequirementPerson, operationPersonnelRequirementParameters.ToArray());

        //            foreach (var predefinedParameter in WorkOrder.Operation.PersonnelRequirement.PredefinedParameters.GetAll())
        //                Contract.Requires(personnelRequirement.GetParameter(predefinedParameter) != null, string.Format("Required operation personnel requirement parameter {0} not found", predefinedParameter));

        //            Contract.Requires(personnelRequirement.ResourceSequence > 0, "Invalid personnel requirement resource sequence");

        //            operationPersonnelRequirements.Add(personnelRequirement);
        //        }

        //        var operationEquipmentRequirements = new List<WorkOrder.Operation.EquipmentRequirement>();
        //        Debug.WriteLine("Reading operation equipment requirements");

        //        foreach (var operationEquipmentRequirementNode in operationSegmentRequirement.EquipmentRequirement)
        //        {
        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentID != null && operationEquipmentRequirementNode.EquipmentID.Count() > 0, "EquipmentID is required for operation equipment requirement");
        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentID.Count() == 1, "Support one EquipmentID per operation equipment requirement");
        //            var operationEquipmentRequirement = operationEquipmentRequirementNode.EquipmentID.Single();

        //            Contract.Requires(operationEquipmentRequirement.Value != null, "Invalid value for operation equipment requirement");
        //            var operationEquipmentRequirementEquipmentId = operationEquipmentRequirement.Value;
        //            var operationEquipmentRequirementEquipment = this.EquipmentManager.GetDepartment(operationEquipmentRequirementEquipmentId);
        //            Contract.Requires(operationEquipmentRequirementEquipment != null, string.Format("Department {0} not found", operationEquipmentRequirementEquipmentId));

        //            Contract.Requires(operationEquipmentRequirementNode.Quantity != null && operationEquipmentRequirementNode.Quantity.Count() > 0, "Quantity is required for operation equipment requirement");
        //            Contract.Requires(operationEquipmentRequirementNode.Quantity.Count() == 1, "Support one Quantity per operation equipment requirement");
        //            var operationEquipmentRequirementQuantityNode = operationEquipmentRequirementNode.Quantity.Single();

        //            Contract.Requires(operationEquipmentRequirementQuantityNode.QuantityString != null && operationEquipmentRequirementQuantityNode.QuantityString.Value != null, "Quantity is required for operation equipment requirement");
        //            double operationEquipmentRequirementQuantity;
        //            var operationEquipmentRequirementQuantityCorrect = double.TryParse(operationEquipmentRequirementQuantityNode.QuantityString.Value, out operationEquipmentRequirementQuantity);
        //            Contract.Requires(operationEquipmentRequirementQuantityCorrect && operationEquipmentRequirementQuantity > 0, "Invalid operation equipment requirement quantity");

        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentRequirementProperty != null, "Properties are required for operation equipment requirement");
        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentRequirementProperty.All(p => p.ID != null && !string.IsNullOrWhiteSpace(p.ID.Value)), "ID is required for each operation equipment requirement property");
        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentRequirementProperty.All(prp => prp.Value != null && prp.Value.Count() >= 1), "Value is required for operation equipment requirement property");
        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentRequirementProperty.All(prp => prp.Value.Count() == 1), "One value supported for required for operation equipment requirement property");
        //            var operationEquipmentRequirementParameters = operationEquipmentRequirementNode.EquipmentRequirementProperty.Select(prp => new WorkOrder.Parameter(prp.ID.Value, prp.Value.Single().ValueString.Value));

        //            var equipmentRequirement = new WorkOrder.Operation.EquipmentRequirement(operationEquipmentRequirementEquipmentId, operationEquipmentRequirementQuantity, operationEquipmentRequirementEquipment, operationEquipmentRequirementParameters.ToArray());

        //            foreach (var predefinedParameter in WorkOrder.Operation.EquipmentRequirement.PredefinedParameters.GetAll())
        //                Contract.Requires(equipmentRequirement.GetParameter(predefinedParameter) != null, string.Format("Required operation equipment requirement parameter {0} not found", predefinedParameter));

        //            Contract.Requires(equipmentRequirement.ResourceSequence > 0, "Invalid equipment requirement resource sequence");

        //            operationEquipmentRequirements.Add(equipmentRequirement);
        //        }

        //        var operationMaterialConsumedRequirements = new List<WorkOrder.Operation.MaterialConsumedRequirement>();
        //        Debug.WriteLine("Reading operation material consumed requirements");

        //        foreach (var operationMaterialConsumedRequirementNode in operationSegmentRequirement.MaterialConsumedRequirement)
        //        {
        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialDefinitionID != null && operationMaterialConsumedRequirementNode.MaterialDefinitionID.Count() > 0, "MaterialDefinitionID is required for operation material consumed requirement");
        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialDefinitionID.Count() == 1, "Support one MaterialDefinitionID per operation material consumed requirement");
        //            var operationMaterialConsumedRequirement = operationMaterialConsumedRequirementNode.MaterialDefinitionID.Single();

        //            Contract.Requires(operationMaterialConsumedRequirement.Value != null, "Invalid value for operation material consumed requirement");
        //            var operationMaterialConsumedRequirementMaterialId = operationMaterialConsumedRequirement.Value;

        //            Contract.Requires(operationMaterialConsumedRequirementNode.Quantity != null && operationMaterialConsumedRequirementNode.Quantity.Count() > 0, "Quantity is required for operation material consumed requirement");
        //            Contract.Requires(operationMaterialConsumedRequirementNode.Quantity.Count() == 1, "Support one Quantity per operation material consumed requirement");
        //            var operationEquipmentRequirementQuantityNode = operationMaterialConsumedRequirementNode.Quantity.Single();

        //            Contract.Requires(operationEquipmentRequirementQuantityNode.QuantityString != null && operationEquipmentRequirementQuantityNode.QuantityString.Value != null, "Quantity is required for operation material consumed requirement");
        //            double operationMaterialConsumedRequirementQuantity;
        //            var operationMaterialConsumedRequirementQuantityCorrect = double.TryParse(operationEquipmentRequirementQuantityNode.QuantityString.Value, out operationMaterialConsumedRequirementQuantity);
        //            Contract.Requires(operationMaterialConsumedRequirementQuantityCorrect && operationMaterialConsumedRequirementQuantity > 0, "Invalid operation material consumed requirement quantity");

        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialConsumedRequirementProperty != null, "Properties are required for operation material consumed");
        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialConsumedRequirementProperty.All(p => p.ID != null && !string.IsNullOrWhiteSpace(p.ID.Value)), "ID is required for each operation material consumed property");
        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialConsumedRequirementProperty.All(prp => prp.Value != null && prp.Value.Count() >= 1), "Value is required for operation material consumed property");
        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialConsumedRequirementProperty.All(prp => prp.Value.Count() == 1), "One value supported for required for operation material consumed property");
        //            var operationMaterialConsumedRequirementParameters = operationMaterialConsumedRequirementNode.MaterialConsumedRequirementProperty.Select(prp => new WorkOrder.Parameter(prp.ID.Value, prp.Value.Single().ValueString.Value));

        //            var materialConsumedRequirement = new WorkOrder.Operation.MaterialConsumedRequirement(operationMaterialConsumedRequirementMaterialId, operationMaterialConsumedRequirementQuantity, operationMaterialConsumedRequirementParameters.ToArray());

        //            foreach (var predefinedParameter in WorkOrder.Operation.MaterialConsumedRequirement.PredefinedParameters.GetAll())
        //                Contract.Requires(materialConsumedRequirement.GetParameter(predefinedParameter) != null, string.Format("Required operation material consumed requirement parameter {0} not found", predefinedParameter));

        //            Contract.Requires(materialConsumedRequirement.ItemSequence > 0, "Incorrect material consumed Item Sequence");

        //            operationMaterialConsumedRequirements.Add(materialConsumedRequirement);
        //        }

        //        var operation = new WorkOrder.Operation(operationId, operationDescription, operationEarliestStartTime, operationLatestEndTime, operationPersonnelRequirements.ToArray(), operationEquipmentRequirements.ToArray(), operationMaterialConsumedRequirements.ToArray());

        //        Contract.Requires(operation.EquipmentRequirements.Count() == 1, "One equipment requirement is required for each operation");
        //        Contract.Requires(operation.PersonnelRequirements.Count() <= 1, "Support one personnel requirement for each operation");

        //        operations.Add(operation);
        //    }

        //    // workOrder = new WorkOrder(site, s95Id, description, earliestStartTime, latestEndTime, producedMaterial, prodline, producedMaterial_IsSerializedPart, quantity, uoM, parameters.ToArray(), operations.ToArray());            
        //    var dStart = DateTime.Parse("2010-01-16 12:00:00");
        //    var dEnd = DateTime.Parse("2010-01-17 12:00:00");
        //    //var producedMaterial = this.MaterialDefinitionManager.GetMaterialDefinitionFromDB("F00001");
        //    var siteResource = EquipmentManager.GetDepartment("CN02");

        //    DirectoryResource materialRC = ServiceDirectoryManager.IDirectorySearch.Search2(
        //        StandardBranches.GetBranchAddresses(ServiceDirectoryManager.ILocalDirectory, StandardBranches.MaterialHintPath).Select(address => new DirectoryResource(address)).ToArray(),
        //        new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
        //        new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
        //        false,
        //        "F00001",//"Fast Elevator F1",
        //        "",
        //        true,
        //        1
        //        ).Results.FirstOrDefault();

        //    workOrder = new WorkOrder("CN02", "CJLR00001", "CJLR00001 Test", dStart, dEnd, materialRC, siteResource, true, 4, null, null, null);

        //    return "success";
        //}


        //public string ParseMessage(string message, out WorkOrder workOrder)
        //{
        //    workOrder = null;
        //    var productionSchedule = ProductionScheduleType.FromB2MMLDocument(message);


        //    Contract.Requires(productionSchedule.ProductionRequest.Count() == 1, "Support one production request per file");
        //    var productionRequest = productionSchedule.ProductionRequest.Single();

        //    Contract.Requires(productionRequest.Location != null && productionRequest.Location.EquipmentID != null && !string.IsNullOrWhiteSpace(productionRequest.Location.EquipmentID.Value), "Location is required for production request");

        //    var site = productionRequest.Location.EquipmentID.Value;
        //    //var prodline = GetProductioinLine(site);

        //    Contract.Requires(productionRequest.ID != null && !string.IsNullOrWhiteSpace(productionRequest.ID.Value), "ID is required for production request");
        //    var s95Id = productionRequest.ID.Value;

        //    Contract.Requires(productionRequest.Description != null && productionRequest.Description.Count() > 0, "Description is required for production request");
        //    Contract.Requires(productionRequest.Description.Count() == 1, "Support one description per master segment");
        //    var description = productionRequest.Description.Single().Value;

        //    Contract.Requires(productionRequest.SegmentRequirement != null, "Segment requirements are required for production request");
        //    Contract.Requires(productionRequest.SegmentRequirement.All(segment => segment.ID != null && !string.IsNullOrWhiteSpace(segment.ID.Value)), "ID is required for segment requirement");
        //    var masterSegments = productionRequest.SegmentRequirement.Where(segment => Regex.IsMatch(segment.ID.Value, "^0+$"));
        //    Contract.Requires(masterSegments.Count() > 0, "Master segment required for production request");
        //    Contract.Requires(masterSegments.Count() == 1, "Support one segment requirement per production request");
        //    var masterSegment = masterSegments.Single();



        //    Contract.Requires(masterSegment.MaterialProducedRequirement != null && masterSegment.MaterialProducedRequirement.Count() > 0, "Material produced is required for master segment");
        //    Contract.Requires(masterSegment.MaterialProducedRequirement.Count() == 1, "Support one material produced per master segment");
        //    var materialProduced = masterSegment.MaterialProducedRequirement.Single();

        //    Contract.Requires(materialProduced.MaterialDefinitionID != null && materialProduced.MaterialDefinitionID.Count() > 0, "Material definition is required for material produced");
        //    Contract.Requires(materialProduced.MaterialDefinitionID.Count() == 1, "Support one material definition per material produced");
        //    if (materialProduced == null)
        //    {
        //        return "Material definition not supplied";
        //    }
        //    var materialProducedId = materialProduced.MaterialDefinitionID.Single();
        //    Contract.Requires(!string.IsNullOrWhiteSpace(materialProducedId.Value), "Material definition is required for material produced");
        //    var producedMaterialS95Id = materialProducedId.Value;
        //    var producedMaterial = this.MaterialDefinitionManager.GetMaterialDefinitionFromDB(producedMaterialS95Id);
        //    Contract.Requires(producedMaterial != null, string.Format("Produced material not found (name = {0})", producedMaterial));
        //    //var prodline = GetProductioinLine(site,producedMaterial);




        //    Contract.Requires(masterSegment.EarliestStartTime != null, "EarliestStartTime is required for master segment");
        //    var earliestStartTime = masterSegment.EarliestStartTime.Value == DateTime.MinValue ? (DateTime?)null : masterSegment.EarliestStartTime.Value;

        //    Contract.Requires(masterSegment.LatestEndTime != null, "LatestEndTime is required for master segment");
        //    var latestEndTime = masterSegment.LatestEndTime.Value == DateTime.MinValue ? (DateTime?)null : masterSegment.LatestEndTime.Value;


        //    //var siteResource = EquipmentManager.GetDepartment(site);
        //    var siteResource = EquipmentManager.GetProductionLine(site);
        //    var siteParent = this.ServiceDirectoryManager.IEquipment.GetEquipmentParent(siteResource);

        //    var timeZoneValue = this.ServiceDirectoryManager.IEquipment.GetPropertyDetails(siteParent, "TimezoneName");

        //    //Convert received times to UTC
        //    earliestStartTime = BFHelper.ConvertTimeZoneToUTC(earliestStartTime.Value, timeZoneValue.Value.ToString());
        //    latestEndTime = BFHelper.ConvertTimeZoneToUTC(latestEndTime.Value, timeZoneValue.Value.ToString());

        //    var producedMaterial_IsSerializedPart = (bool)this.ServiceDirectoryManager.IMaterial.ReadMaterialValue(producedMaterial, MaterialClasses.PfM_ProducedMaterial.Properties.IsSerializedPart).ObjectValue;

        //    Contract.Requires(materialProduced.Quantity != null && materialProduced.Quantity.Count() > 0, "Quantity is required for material produced");
        //    Contract.Requires(materialProduced.Quantity.Count() == 1, "Support one quantity per material produced");
        //    var materialProducedQuantity = materialProduced.Quantity.Single();

        //    Contract.Requires(materialProducedQuantity.QuantityString != null && !string.IsNullOrWhiteSpace(materialProducedQuantity.QuantityString.Value), "Quantity is required for material produced");
        //    int quantity;
        //    var quantityCorrect = int.TryParse(materialProducedQuantity.QuantityString.Value, out quantity);
        //    Contract.Requires(quantityCorrect && quantity > 0, "Invalid material produced quantity");

        //    var uoM = materialProducedQuantity.UnitOfMeasure == null ? null : materialProducedQuantity.UnitOfMeasure.Value;

        //    Contract.Requires(materialProduced.MaterialProducedRequirementProperty != null, "Properties are required for produced material");
        //    Contract.Requires(materialProduced.MaterialProducedRequirementProperty.All(p => p.ID != null && !string.IsNullOrWhiteSpace(p.ID.Value)), "ID is required for each MaterialProducedRequirementProperty");
        //    Contract.Requires(materialProduced.MaterialProducedRequirementProperty.All(p => p.Value != null && p.Value.Count() > 0), "Value is required for each MaterialProducedRequirementProperty");
        //    var parameters = materialProduced.MaterialProducedRequirementProperty.Select(mprp => new WorkOrder.Parameter(mprp.ID.Value, mprp.Value.Count() == 1 ? (object)mprp.Value.Single().ValueString.Value : mprp.Value.Select(v => v.ValueString.Value).ToArray())).ToArray();


        //    var operations = new List<WorkOrder.Operation>();
        //    Debug.WriteLine("Reading operations");

        //    foreach (var operationSegmentRequirement in productionRequest.SegmentRequirement.Except(Enumerable.Repeat(masterSegment, 1)))
        //    {
        //        var operationId = operationSegmentRequirement.ID.Value;
        //        Contract.Requires(!string.IsNullOrWhiteSpace(operationId), "Invalid operation id");

        //        Contract.Requires(operationSegmentRequirement.Description != null && operationSegmentRequirement.Description.Count() > 0, "Description is required for operation segment");
        //        Contract.Requires(operationSegmentRequirement.Description.Count() == 1, "Support one description per operation segment");
        //        var operationDescription = operationSegmentRequirement.Description.Single().Value;

        //        Contract.Requires(operationSegmentRequirement.EarliestStartTime != null, "EarliestStartTime is required for operation segment");
        //        var operationEarliestStartTime = operationSegmentRequirement.EarliestStartTime.Value;

        //        Contract.Requires(operationSegmentRequirement.LatestEndTime != null, "LatestEndTime is required for operation segment");
        //        var operationLatestEndTime = operationSegmentRequirement.LatestEndTime.Value;

        //        var operationPersonnelRequirements = new List<WorkOrder.Operation.PersonnelRequirement>();
        //        Debug.WriteLine("Reading operation personnel requirements");

        //        foreach (var operationPersonnelRequirementNode in operationSegmentRequirement.PersonnelRequirement)
        //        {
        //            Contract.Requires(operationPersonnelRequirementNode.PersonID != null && operationPersonnelRequirementNode.PersonID.Count() > 0, "PersonID is required for operation personnel requirement");
        //            Contract.Requires(operationPersonnelRequirementNode.PersonID.Count() == 1, "Support one PersonID per operation personnel requirement");
        //            var operationPersonnelRequirement = operationPersonnelRequirementNode.PersonID.Single();

        //            Contract.Requires(operationPersonnelRequirement.Value != null, "Invalid value for operation personnel requirement");
        //            var operationPersonnelRequirementPersonId = operationPersonnelRequirement.Value;
        //            var operationPersonnelRequirementPerson = this.PersonnelManager.GetResource(operationPersonnelRequirementPersonId);
        //            Contract.Requires(operationPersonnelRequirementPerson != null, string.Format("Personnel resource {0} not found", operationPersonnelRequirementPersonId));

        //            Contract.Requires(operationPersonnelRequirementNode.Quantity != null && operationPersonnelRequirementNode.Quantity.Count() > 0, "Quantity is required for operation personnel requirement");
        //            Contract.Requires(operationPersonnelRequirementNode.Quantity.Count() == 1, "Support one Quantity per operation personnel requirement");
        //            var operationPersonnelRequirementQuantityNode = operationPersonnelRequirementNode.Quantity.Single();

        //            Contract.Requires(operationPersonnelRequirementQuantityNode.QuantityString != null && operationPersonnelRequirementQuantityNode.QuantityString.Value != null, "Quantity is required for operation personnel requirement");
        //            double operationPersonnelRequirementQuantity;
        //            var operationPersonnelRequirementQuantityCorrect = double.TryParse(operationPersonnelRequirementQuantityNode.QuantityString.Value, out operationPersonnelRequirementQuantity);
        //            Contract.Requires(operationPersonnelRequirementQuantityCorrect && operationPersonnelRequirementQuantity > 0, "Invalid operation personnel requirement quantity");

        //            Contract.Requires(operationPersonnelRequirementNode.PersonnelRequirementProperty != null, "Properties are required for operation personnel requirement");
        //            Contract.Requires(operationPersonnelRequirementNode.PersonnelRequirementProperty.All(p => p.ID != null && !string.IsNullOrWhiteSpace(p.ID.Value)), "ID is required for each operation personnel requirement property");
        //            Contract.Requires(operationPersonnelRequirementNode.PersonnelRequirementProperty.All(prp => prp.Value != null && prp.Value.Count() >= 1), "Value is required for operation personnel requirement property");
        //            Contract.Requires(operationPersonnelRequirementNode.PersonnelRequirementProperty.All(prp => prp.Value.Count() == 1), "One value supported for required for operation personnel requirement property");
        //            var operationPersonnelRequirementParameters = operationPersonnelRequirementNode.PersonnelRequirementProperty.Select(prp => new WorkOrder.Parameter(prp.ID.Value, prp.Value.Single().ValueString.Value));

        //            var personnelRequirement = new WorkOrder.Operation.PersonnelRequirement(operationPersonnelRequirementPersonId, operationPersonnelRequirementQuantity, operationPersonnelRequirementPerson, operationPersonnelRequirementParameters.ToArray());

        //            foreach (var predefinedParameter in WorkOrder.Operation.PersonnelRequirement.PredefinedParameters.GetAll())
        //                Contract.Requires(personnelRequirement.GetParameter(predefinedParameter) != null, string.Format("Required operation personnel requirement parameter {0} not found", predefinedParameter));

        //            Contract.Requires(personnelRequirement.ResourceSequence > 0, "Invalid personnel requirement resource sequence");

        //            operationPersonnelRequirements.Add(personnelRequirement);
        //        }

        //        var operationEquipmentRequirements = new List<WorkOrder.Operation.EquipmentRequirement>();
        //        Debug.WriteLine("Reading operation equipment requirements");

        //        foreach (var operationEquipmentRequirementNode in operationSegmentRequirement.EquipmentRequirement)
        //        {
        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentID != null && operationEquipmentRequirementNode.EquipmentID.Count() > 0, "EquipmentID is required for operation equipment requirement");
        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentID.Count() == 1, "Support one EquipmentID per operation equipment requirement");
        //            var operationEquipmentRequirement = operationEquipmentRequirementNode.EquipmentID.Single();

        //            Contract.Requires(operationEquipmentRequirement.Value != null, "Invalid value for operation equipment requirement");
        //            var operationEquipmentRequirementEquipmentId = operationEquipmentRequirement.Value;
        //            var operationEquipmentRequirementEquipment = this.EquipmentManager.GetDepartment(operationEquipmentRequirementEquipmentId);
        //            Contract.Requires(operationEquipmentRequirementEquipment != null, string.Format("Department {0} not found", operationEquipmentRequirementEquipmentId));

        //            Contract.Requires(operationEquipmentRequirementNode.Quantity != null && operationEquipmentRequirementNode.Quantity.Count() > 0, "Quantity is required for operation equipment requirement");
        //            Contract.Requires(operationEquipmentRequirementNode.Quantity.Count() == 1, "Support one Quantity per operation equipment requirement");
        //            var operationEquipmentRequirementQuantityNode = operationEquipmentRequirementNode.Quantity.Single();

        //            Contract.Requires(operationEquipmentRequirementQuantityNode.QuantityString != null && operationEquipmentRequirementQuantityNode.QuantityString.Value != null, "Quantity is required for operation equipment requirement");
        //            double operationEquipmentRequirementQuantity;
        //            var operationEquipmentRequirementQuantityCorrect = double.TryParse(operationEquipmentRequirementQuantityNode.QuantityString.Value, out operationEquipmentRequirementQuantity);
        //            Contract.Requires(operationEquipmentRequirementQuantityCorrect && operationEquipmentRequirementQuantity > 0, "Invalid operation equipment requirement quantity");

        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentRequirementProperty != null, "Properties are required for operation equipment requirement");
        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentRequirementProperty.All(p => p.ID != null && !string.IsNullOrWhiteSpace(p.ID.Value)), "ID is required for each operation equipment requirement property");
        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentRequirementProperty.All(prp => prp.Value != null && prp.Value.Count() >= 1), "Value is required for operation equipment requirement property");
        //            Contract.Requires(operationEquipmentRequirementNode.EquipmentRequirementProperty.All(prp => prp.Value.Count() == 1), "One value supported for required for operation equipment requirement property");
        //            var operationEquipmentRequirementParameters = operationEquipmentRequirementNode.EquipmentRequirementProperty.Select(prp => new WorkOrder.Parameter(prp.ID.Value, prp.Value.Single().ValueString.Value));

        //            var equipmentRequirement = new WorkOrder.Operation.EquipmentRequirement(operationEquipmentRequirementEquipmentId, operationEquipmentRequirementQuantity, operationEquipmentRequirementEquipment, operationEquipmentRequirementParameters.ToArray());

        //            foreach (var predefinedParameter in WorkOrder.Operation.EquipmentRequirement.PredefinedParameters.GetAll())
        //                Contract.Requires(equipmentRequirement.GetParameter(predefinedParameter) != null, string.Format("Required operation equipment requirement parameter {0} not found", predefinedParameter));

        //            Contract.Requires(equipmentRequirement.ResourceSequence > 0, "Invalid equipment requirement resource sequence");

        //            operationEquipmentRequirements.Add(equipmentRequirement);
        //        }

        //        var operationMaterialConsumedRequirements = new List<WorkOrder.Operation.MaterialConsumedRequirement>();
        //        Debug.WriteLine("Reading operation material consumed requirements");

        //        foreach (var operationMaterialConsumedRequirementNode in operationSegmentRequirement.MaterialConsumedRequirement)
        //        {
        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialDefinitionID != null && operationMaterialConsumedRequirementNode.MaterialDefinitionID.Count() > 0, "MaterialDefinitionID is required for operation material consumed requirement");
        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialDefinitionID.Count() == 1, "Support one MaterialDefinitionID per operation material consumed requirement");
        //            var operationMaterialConsumedRequirement = operationMaterialConsumedRequirementNode.MaterialDefinitionID.Single();

        //            Contract.Requires(operationMaterialConsumedRequirement.Value != null, "Invalid value for operation material consumed requirement");
        //            var operationMaterialConsumedRequirementMaterialId = operationMaterialConsumedRequirement.Value;

        //            Contract.Requires(operationMaterialConsumedRequirementNode.Quantity != null && operationMaterialConsumedRequirementNode.Quantity.Count() > 0, "Quantity is required for operation material consumed requirement");
        //            Contract.Requires(operationMaterialConsumedRequirementNode.Quantity.Count() == 1, "Support one Quantity per operation material consumed requirement");
        //            var operationEquipmentRequirementQuantityNode = operationMaterialConsumedRequirementNode.Quantity.Single();

        //            Contract.Requires(operationEquipmentRequirementQuantityNode.QuantityString != null && operationEquipmentRequirementQuantityNode.QuantityString.Value != null, "Quantity is required for operation material consumed requirement");
        //            double operationMaterialConsumedRequirementQuantity;
        //            var operationMaterialConsumedRequirementQuantityCorrect = double.TryParse(operationEquipmentRequirementQuantityNode.QuantityString.Value, out operationMaterialConsumedRequirementQuantity);
        //            Contract.Requires(operationMaterialConsumedRequirementQuantityCorrect && operationMaterialConsumedRequirementQuantity > 0, "Invalid operation material consumed requirement quantity");

        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialConsumedRequirementProperty != null, "Properties are required for operation material consumed");
        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialConsumedRequirementProperty.All(p => p.ID != null && !string.IsNullOrWhiteSpace(p.ID.Value)), "ID is required for each operation material consumed property");
        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialConsumedRequirementProperty.All(prp => prp.Value != null && prp.Value.Count() >= 1), "Value is required for operation material consumed property");
        //            Contract.Requires(operationMaterialConsumedRequirementNode.MaterialConsumedRequirementProperty.All(prp => prp.Value.Count() == 1), "One value supported for required for operation material consumed property");
        //            var operationMaterialConsumedRequirementParameters = operationMaterialConsumedRequirementNode.MaterialConsumedRequirementProperty.Select(prp => new WorkOrder.Parameter(prp.ID.Value, prp.Value.Single().ValueString.Value));

        //            var materialConsumedRequirement = new WorkOrder.Operation.MaterialConsumedRequirement(operationMaterialConsumedRequirementMaterialId, operationMaterialConsumedRequirementQuantity, operationMaterialConsumedRequirementParameters.ToArray());

        //            foreach (var predefinedParameter in WorkOrder.Operation.MaterialConsumedRequirement.PredefinedParameters.GetAll())
        //                Contract.Requires(materialConsumedRequirement.GetParameter(predefinedParameter) != null, string.Format("Required operation material consumed requirement parameter {0} not found", predefinedParameter));

        //            Contract.Requires(materialConsumedRequirement.ItemSequence > 0, "Incorrect material consumed Item Sequence");

        //            operationMaterialConsumedRequirements.Add(materialConsumedRequirement);
        //        }

        //        var operation = new WorkOrder.Operation(operationId, operationDescription, operationEarliestStartTime, operationLatestEndTime, operationPersonnelRequirements.ToArray(), operationEquipmentRequirements.ToArray(), operationMaterialConsumedRequirements.ToArray());

        //        Contract.Requires(operation.EquipmentRequirements.Count() == 1, "One equipment requirement is required for each operation");
        //        Contract.Requires(operation.PersonnelRequirements.Count() <= 1, "Support one personnel requirement for each operation");

        //        operations.Add(operation);
        //    }
           
        //    // workOrder = new WorkOrder(site, s95Id, description, earliestStartTime, latestEndTime, producedMaterial, prodline, producedMaterial_IsSerializedPart, quantity, uoM, parameters.ToArray(), operations.ToArray());            
        //    workOrder = new WorkOrder(site, s95Id, description, earliestStartTime, latestEndTime, producedMaterial, siteResource, producedMaterial_IsSerializedPart, quantity, uoM, parameters.ToArray(), operations.ToArray());

        //    return "success";
        //}

        #endregion

        #region Create ShopOrder - Inbound Interface

        //public string createShopOrder(WorkOrder workOrder)
        //{
        //    string outputMessage = "Success";

        //    try
        //    {

        //        Guid rout_id = Guid.Parse("B01A4660-7C5B-4CB7-A728-15522856D9D6");

        //        Debug.WriteLine("Using route {0} revision {1} for produced material {2} and produced material class {3}");

        //        var routeRevisionId = rout_id;

        //        var routeRevision = this.ServiceDirectoryManager.IRouteConfiguration.ReadRouteRevision(routeRevisionId, RouteRevisionDetailLevel.IncludeParameters | RouteRevisionDetailLevel.IncludeSegments);

        //        Contract.Requires(workOrder.Operations.Count() >= 1, string.Format("No operations found in the work order creation request (s95id = {0})", workOrder.S95Id));


        //        var operationSegments = new List<RouteSegmentAttributes>();
        //        //Add the route segments
        //        foreach (var operation in routeRevision.Segments)
        //        {
        //            operationSegments.Add(operation);
        //        }

        //        IEnumerable<Guid> segmentIds = new List<Guid>();
        //        segmentIds = operationSegments.SelectMany(opSegment => Enumerable.Repeat(opSegment.Id, 1).Concat(opSegment.Segments.Select(stepSegment => stepSegment.Id))).ToArray();
              


        //        Debug.WriteLine(string.Format("Executing: Work request not found, creating from route"));

        //        IEnumerable<string> serialNumbers = null;
        //        serialNumbers = this.GetSerialNumbersToAssign(workOrder, null, Convert.ToInt32(workOrder.Quantity)).ToArray();
        //        Debug.WriteLine(string.Format("Serial numbers generated: {0}", string.Join(", ", serialNumbers)));
                
        //        var segmentResponseId = this.ServiceDirectoryManager.IExecutionManagement.CreateShopOrderAndAssignSerialNumbers(this.PersonnelManager.IntegrationPerson, workOrder.S95Id, workOrder.Description, workOrder.ProducedMaterial, (int)workOrder.Quantity, 0, rout_id, Guid.Empty, segmentIds,serialNumbers);
        //        DirectoryResource workreqDR = this.GetWorkRequest(workOrder.S95Id);
        //        this.ServiceDirectoryManager.IProductionRuntime.SetWorkRequestScheduledTimes(workreqDR, workOrder.EarliestStartTime, workOrder.LatestEndTime);

        //        foreach (var item in serialNumbers)
        //        {
        //            outputMessage = outputMessage + item.ToString() ;
        //        }


        //        var shopOrderOperations = this.ServiceDirectoryManager.IExecutionManagement.QueryOperations(this.PersonnelManager.IntegrationPerson.DisplayName, new OperationSearchCriteria() { ShopOrderId = segmentResponseId, ShopOrderIdSet = true });
        //        outputMessage = outputMessage + this.PersonnelManager.IntegrationPerson.DisplayName;
        //        foreach (var operation in workOrder.Operations)
        //        {
        //            var shopOrderOperation = shopOrderOperations.AsEnumerable().FirstOrDefault(o => string.Equals(operation.OperationId, (string)o[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.Operation.Name], StringComparison.InvariantCultureIgnoreCase));
        //            // Guard.Precondition(shopOrderOperation != null, string.Format("Operation not found in a newly created shop order (shop order id = {0}, operation = {1})", workOrder.S95Id, operation.OperationId));
        //            if (shopOrderOperation == null)
        //            {
        //                //Operation not found in route, create the operation
        //                var shopOrderOperationSegmentResponseId = CreateShopOrderOperation(workOrder, segmentResponseId, operation);
        //            }
        //            else
        //            {
        //                outputMessage = outputMessage + operation;
        //                var shopOrderOperationSegmentResponseId = (Guid)shopOrderOperation[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.Operation.Id];

        //                this.UpdateShopOrderOperationSegmentRequirement(workOrder, operation, shopOrderOperationSegmentResponseId, true);


        //                this.CreateShopOrderOperationBOM(operation, shopOrderOperationSegmentResponseId);
        //            }
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        outputMessage =outputMessage+ ex.Message;
        //    }


        //    return outputMessage;

        //}


        public string createShopOrder(WorkOrder workOrder)
        {
            string outputMessage = "Success";

            RouteRevisionQueryCriteria routeRevisionCriteria = null;

            Debug.WriteLine(string.Format("Work request not found, creating from route"));
            try
            {
                ////check if shopOrder had to be created from route
                //DirectoryResource site = GetSite(workOrder.Site);
                //int isOpFromRoute = (this.ServiceDirectoryManager.IEquipment.ReadEquipmentValue(site, "IsOperationsFromRoute")).IntValue(CultureInfo.CurrentCulture);
                ////this.ServiceDirectoryManager.IEquipment.ReadPropertyAttribute(site, "", "");
                //if (isOpFromRoute == 0)
                //{
                //    //From Master Template route and ERP Operations\BOM
                //    routeRevisionCriteria = new RouteRevisionQueryCriteria()
                //    {
                //        ProducedMaterialClassEquals = this.MaterialDefinitionManager.GetMaterialClass("PartFamily_MAke"),
                //        //ProductionLineEquals = workOrder.ProductionLine,
                //        StatusEquals = new int[] { RouteRevisionStatusAttributes.Released.Id }
                //    };


                //}

                //else
                //{
                //    routeRevisionCriteria = new RouteRevisionQueryCriteria()
                //    {
                //        ProducedMaterialEquals = workOrder.ProducedMaterial,
                //        ProductionLineEquals = workOrder.ProductionLine,
                //        StatusEquals = new int[] { RouteRevisionStatusAttributes.Released.Id }
                //    };
                //}


                routeRevisionCriteria = new RouteRevisionQueryCriteria()
                    {
                        ProducedMaterialEquals = workOrder.ProducedMaterial,
                        ProductionLineEquals = workOrder.ProductionLine,
                        StatusEquals = new int[] { RouteRevisionStatusAttributes.Released.Id }
                    };
                var routeRevisions = this.ServiceDirectoryManager.IRouteConfiguration.QueryRouteRevisions(routeRevisionCriteria);

                if (routeRevisions.RouteRevisions.Count == 0)
                {
                    outputMessage = "No route Revisions";
                    return outputMessage;
                }

                // var routeRevisionData = routeRevisions.RouteRevisions.OrderBy(r => r.LastModifiedOn).LastOrDefault();

                //TODO: Remove 
                //var routeRevisionCollection = routeRevisions.RouteRevisions.Where(route => 
                //    route.Status.Name == "Released" && 
                //    route.EffectiveDate <= workOrder.EarliestStartTime
                //    && route.ProductionLineS95Id==workOrder.ProductionLine.DisplayName);

                var routeRevisionCollection = routeRevisions.RouteRevisions.Where(route =>
                    route.Status.Name == "Released" &&
                    route.EffectiveDate <= workOrder.EarliestStartTime);

                RouteRevisionCollection tempRouteRevsions = new RouteRevisionCollection();

                foreach (var currentRouteRevision in routeRevisionCollection)
                {

                    //upjd update 获取Route对应的产线
                    //var currentProductionLine = EquipmentManager.GetProductionLine(currentRouteRevision.ProductionLineS95Id);
                    //var currentPlant = ServiceDirectoryManager.IEquipment.GetEquipmentParent(currentProductionLine);

                    //if (currentPlant.DisplayName == workOrder.ProductionLine.DisplayName)
                    tempRouteRevsions.Add(currentRouteRevision);
                    
                }


                var routeRevisionData = tempRouteRevsions.OrderByDescending(route => route.EffectiveDate).OrderByDescending(route => route.LastModifiedOn).FirstOrDefault();



                if (routeRevisionData == null)
                {
                    
                    ServiceDirectoryManager.ILog.Error(string.Format(workOrder.EarliestStartTime.ToString()));
                    throw new Exception("No route found for Work Order Start Date");
                    
                }


                Debug.WriteLine(string.Format("Using route {0} revision {1} for produced material {2} and produced material class {3}", routeRevisionData.RouteName, DocumentRevisionHelper.ConvertRevisionStringToInt(routeRevisionData.RevisionName), routeRevisionData.ProducedMaterialS95Id, routeRevisionData.ProducedMaterialClassS95Id));

                var routeRevisionId = routeRevisionData.RevisionId;

                var routeRevision = this.ServiceDirectoryManager.IRouteConfiguration.ReadRouteRevision(routeRevisionId, RouteRevisionDetailLevel.IncludeParameters | RouteRevisionDetailLevel.IncludeSegments);

                Contract.Requires(workOrder.Operations.Count() >= 1, string.Format("No operations found in the work order creation request (s95id = {0})", workOrder.S95Id));


                var operationSegments = new List<RouteSegmentAttributes>();
                foreach (var operation in routeRevision.Segments)
                {
                    operationSegments.Add(operation);
                }
                //if (isOpFromRoute == 0)
                //{
                //    //Match any segments in the route if any
                //    foreach (var operation in workOrder.Operations)
                //    {
                //        var operationSegment = routeRevision.Segments.FirstOrDefault(segment => string.Equals(segment.Name, operation.OperationId, StringComparison.InvariantCultureIgnoreCase));

                //        if (operationSegment != null)
                //            operationSegments.Add(operationSegment);
                //    }
                //}
                //else
                //{
                //    //Add the route segments
                //    foreach (var operation in routeRevision.Segments)
                //    {
                //        operationSegments.Add(operation);
                //    }

                //}


                IEnumerable<Guid> segmentIds = new List<Guid>();
                segmentIds = operationSegments.SelectMany(opSegment => Enumerable.Repeat(opSegment.Id, 1).Concat(opSegment.Segments.Select(stepSegment => stepSegment.Id))).ToArray();
                //if (isOpFromRoute == 0)
                //{

                //    segmentIds = operationSegments.SelectMany(OpSegment => Enumerable.Repeat(OpSegment.Id, 1));
                //}
                //else
                //{
                //    segmentIds = operationSegments.SelectMany(opSegment => Enumerable.Repeat(opSegment.Id, 1).Concat(opSegment.Segments.Select(stepSegment => stepSegment.Id))).ToArray();
                //}





                Debug.WriteLine(string.Format("Executing: Work request not found, creating from route"));

                IEnumerable<string> serialNumbers = null;
                if (workOrder.ProducedMaterial_IsSerializedPart)
                {
                    serialNumbers = this.GetSerialNumbersToAssign(workOrder, null, Convert.ToInt32(workOrder.Quantity)).ToArray();
                    Debug.WriteLine(string.Format("Serial numbers generated: {0}", string.Join(", ", serialNumbers)));
                }
                else
                    serialNumbers = null;



                var segmentResponseId = this.ServiceDirectoryManager.IExecutionManagement.CreateShopOrderAndAssignSerialNumbers(this.PersonnelManager.IntegrationPerson, workOrder.S95Id, workOrder.Description, workOrder.ProducedMaterial, (int)workOrder.Quantity, 0, routeRevisionId, Guid.Empty, segmentIds, serialNumbers);
                DirectoryResource workreqDR = this.GetWorkRequest(workOrder.S95Id);
                this.ServiceDirectoryManager.IProductionRuntime.SetWorkRequestScheduledTimes(workreqDR, workOrder.EarliestStartTime, workOrder.LatestEndTime);

              
                //var shopOrderOperations = this.ServiceDirectoryManager.IExecutionManagement.QueryOperations(this.PersonnelManager.IntegrationPerson.DisplayName, new OperationSearchCriteria() { ShopOrderId = segmentResponseId, ShopOrderIdSet = true });

                //foreach (var operation in workOrder.Operations)
                //{
                //    var shopOrderOperation = shopOrderOperations.AsEnumerable().FirstOrDefault(o => string.Equals(operation.OperationId, (string)o[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.Operation.Name], StringComparison.InvariantCultureIgnoreCase));
                //    // Guard.Precondition(shopOrderOperation != null, string.Format("Operation not found in a newly created shop order (shop order id = {0}, operation = {1})", workOrder.S95Id, operation.OperationId));
                //    if (shopOrderOperation == null)
                //    {
                //        //Operation not found in route, create the operation
                //        var shopOrderOperationSegmentResponseId = CreateShopOrderOperation(workOrder, segmentResponseId, operation);
                //    }
                //    else
                //    {

                //        var shopOrderOperationSegmentResponseId = (Guid)shopOrderOperation[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.Operation.Id];

                //        this.UpdateShopOrderOperationSegmentRequirement(workOrder, operation, shopOrderOperationSegmentResponseId, true);


                //        this.CreateShopOrderOperationBOM(operation, shopOrderOperationSegmentResponseId);
                //    }
                //}

                //// Shop Order will be release manually
                ////  Debug.WriteLine(string.Format("Releasing shop order"));
                ////  this.ServiceDirectoryManager.IExecutionManagement.ReleaseShopOrderToProduction(this.PersonnelManager.IntegrationPerson, new Guid[] { segmentResponseId });


            }
            catch (Exception ex)
            {
                outputMessage = ex.Message;
            }


            return outputMessage;

        }
    
        private Guid CreateShopOrderOperation(WorkOrder workOrder, Guid segmentResponseId, WorkOrder.Operation operation)
        {
            Debug.WriteLine(string.Format("Operation {0} not found in shop order, creating from message", operation.OperationId));


            Debug.WriteLine(string.Format("Executing: Operation {0} not found in shop order, creating from message", operation.OperationId));

            var shopOrderOperationSegmentResponseId = this.ServiceDirectoryManager.IExecutionManagement.AddOperationToShopOrder(segmentResponseId, operation.OperationId, operation.Description, 0);

            this.UpdateShopOrderOperationSegmentRequirement(workOrder, operation, shopOrderOperationSegmentResponseId, true);

            this.CreateShopOrderOperationBOM(operation, shopOrderOperationSegmentResponseId);

            Debug.WriteLine(string.Format("To do: when receive new operation priority from ERP, might need to clear IsAvailable for some operations"));
            return shopOrderOperationSegmentResponseId;

        }

        private void UpdateShopOrderOperationSegmentRequirement(WorkOrder workOrder, WorkOrder.Operation operation, Guid segmentResponseId, bool newlyCreatedOperation)
        {
            var segmentResponse = this.ServiceDirectoryManager.IProductionRuntime.ReadSegmentResponseAttributes(segmentResponseId, SegmentResponseDetailLevel.AttributesOnly);

            var segmentRequirement = this.ServiceDirectoryManager.IProductionRuntime.ReadSegmentRequirement(segmentResponse.RequirementId, SegmentRequirementDetailLevel.IncludeEquipmentRequirements | SegmentRequirementDetailLevel.IncludePersonnelRequirements | SegmentRequirementDetailLevel.IncludeParameters);

            var equipmentRequirement = segmentRequirement.Equipment.FirstOrDefault(er => er.S95Id == ProcessSegments.OperationSegment.EquipmentRequirements.WorkCenter.Name);
            this.ServiceDirectoryManager.IProductionRuntime.UpdateEquipmentRequirement(equipmentRequirement.Id, new EquipmentRequirementAttributes() { Equipment = operation.WorkCenter.Equipment.Address, Quantity = operation.WorkCenter.Quantity });
            this.ServiceDirectoryManager.IProductionRuntime.SetSegmentRequirementOrder(segmentResponse.RequirementId, Convert.ToInt32(operation.OperationId));
        }

        private void CreateShopOrderOperationBOM(WorkOrder.Operation operation, Guid segmentResponseId)
        {
            var requirementName = 1;
            Guid materialLotId = Guid.Empty;
            var segmentResponse = this.ServiceDirectoryManager.IProductionRuntime.ReadSegmentResponseAttributes(segmentResponseId, SegmentResponseDetailLevel.AttributesOnly);
            var lotOperations = this.ServiceDirectoryManager.IExecutionManagement.QueryLotOperations("Admin", new LotOperationSearchCriteria() { ShopOrderOperationId = segmentResponseId, ShopOrderOperationIdSet = true });

            foreach (var materialConsumed in operation.MaterialConsumedRequirements)
            {
                var material = this.MaterialDefinitionManager.GetMaterialDefinitionFromDB(materialConsumed.MaterialId);
                if (material == null)
                    material = this.ServiceDirectoryManager.IMaterial.CreateMaterialDefinitionCallMethod(materialConsumed.MaterialId, "");

                this.ServiceDirectoryManager.IMaterial.AddClass(material, this.MaterialDefinitionManager.BOMItemMaterialClass);
                var materialConsumedRequirementId = this.ServiceDirectoryManager.IExecutionManagement.AddOperationBillOfMaterialItem(segmentResponseId, requirementName.ToString().PadLeft(3, '0'), "", material, materialConsumed.Quantity, "");

                requirementName++;
            }
        }

        private IEnumerable<string> GetSerialNumbers(DataTable producedLots)
        {
            return producedLots.AsEnumerable().Select(producedLot => (string)producedLot[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.Lot.SerialNumber]).ToArray();
        }

        private IEnumerable<string> GetSerialNumbersToAssign(WorkOrder workOrder, DataTable producedLots, int count)
        {
            var serialNumbers = producedLots == null ? Enumerable.Empty<string>() : this.GetSerialNumbers(producedLots);

            var producedLotNumber = 0;
            for (var i = 0; i < count; i++)
            {
                string serialNumber;
                do
                {
                    serialNumber = workOrder.GetSerialNumber(producedLotNumber);
                    producedLotNumber++;
                }
                while (serialNumbers.Contains(serialNumber));

                yield return serialNumber;
            }
        }


        public DirectoryResource GetSite(string site)
        {
            DirectoryResource Area = this.ServiceDirectoryManager.IDirectorySearch.Search2(
              StandardBranches.GetBranchAddresses(this.ServiceDirectoryManager.ILocalDirectory, StandardBranches.EquipmentHintPath).Select(address => new DirectoryResource(address)).ToArray(),
              new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
              new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
              false,
              site,
              "",
              true,
              1
              ).Results.FirstOrDefault();

            return this.ServiceDirectoryManager.IEquipment.GetEquipmentParent(Area);


        }

        public DirectoryResource GetWorkRequest(string s95Id)
        {
            return this.ServiceDirectoryManager.IDirectorySearch.Search2(
                StandardBranches.GetBranchAddresses(this.ServiceDirectoryManager.ILocalDirectory, StandardBranches.WorkRequestsHintPath).Select(address => new DirectoryResource(address)).ToArray(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                false,
                s95Id,
                "",
                true,
                1
                ).Results.FirstOrDefault();
        }

        #endregion

        #region Release ShopOrder

        public void ReleaseShopOrder(Guid segmentResponseId)
        {
            // Shop Order will be release manually
            Debug.WriteLine(string.Format("Releasing shop order"));
            this.ServiceDirectoryManager.IExecutionManagement.ReleaseShopOrderToProduction(this.PersonnelManager.IntegrationPerson, new Guid[] { segmentResponseId });

        }


        #endregion


    }
}
