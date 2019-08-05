//using BrilliantFactory.Interfaces.Types;
using BrilliantFactory.Managers;

using Proficy.Platform.Core.ProficySystem.Types;
using Proficy.Platform.Services.Production.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Managers
{
    public class WorkResponseManager
    {
        internal ServiceDirectoryManager ServiceDirectoryManager { get; set; }
        internal PersonnelManager PersonnelManager { get; set; }
        internal EquipmentManager EquipmentManager { get; set; }
        internal MaterialDefinitionManager MaterialDefinitionManager { get; set; }
        private SegmentResponseAttributes SegRespAtt { get; set; }

        public WorkResponseManager(ServiceDirectoryManager serviceDirectoryManager, PersonnelManager personnelManager,
            EquipmentManager equipmentManager, MaterialDefinitionManager materialDefinitionManager)
        {
            this.ServiceDirectoryManager = serviceDirectoryManager;
            this.PersonnelManager = personnelManager;
            this.EquipmentManager = equipmentManager;
            this.MaterialDefinitionManager = materialDefinitionManager;
        }
       

        #region Outbound Interface      

        //public string GetOperationAttributes(Guid SegmentResponseId, string materialLotId,string PersonS95Id,string quantityCompleted,string startTime,string endTime, out  string s95Id, out string site)
        //{
        //    string errorMessage;
        //    string xml = string.Empty;
        //   // bool AllSNCompleted;
        //    WorkOrder workOrder;
        //    site = string.Empty;
        //    s95Id = string.Empty;

        //    SegRespAtt = this.ServiceDirectoryManager.IProductionRuntime.ReadSegmentResponseAttributes(SegmentResponseId, SegmentResponseDetailLevel.IncludeMaterialActuals | SegmentResponseDetailLevel.AttributesOnly);
        //    this.LoadWorkRequest(SegRespAtt.WorkRequest, SegmentResponseId, materialLotId,PersonS95Id,quantityCompleted, out workOrder);           
           
        //        s95Id = workOrder.S95Id;
        //        site = workOrder.Site;
        //        xml = GetWorkOrderMessage(workOrder, PersonS95Id,quantityCompleted, startTime, endTime, out errorMessage);
           
        //    return xml;
        //}

        //public string GetWorkOrderMessage(WorkOrder workOrder, string PersonS95Id, string quantityCompleted, string startTime, string endTime, out string errorMessage)
        //{
        //  string workCenter = workOrder.workCenter;
        //    try
        //    {
        //        var publishedDate = DateTime.Now;
        //        publishedDate = publishedDate.AddTicks(-(publishedDate.Ticks % TimeSpan.TicksPerSecond));


               //   var productionPerformance = new ProductionPerformanceType()
               // {
               //     ID = new IdentifierType()
               //     {
               //       //  Value = workOrder.S95Id
               //       Value = new Random().Next().ToString()
               //     },
               //     PublishedDate = new PublishedDateType()
               //     {
               //         Value = publishedDate
               //     }
               // };

               // var productionResponse = new ProductionResponseType
               // {
               //     ID = new IdentifierType()
               //     {
               //         Value = workOrder.S95Id
               //     },
               //     Location = new LocationType()
               //     {
               //         EquipmentID = new EquipmentIDType()
               //         {
               //             Value = workOrder.Site
               //         },
               //         EquipmentElementLevel = new EquipmentElementLevelType()
               //         {
               //             Value = EquipmentElementLevel1EnumerationType.Area
               //         }
               //     }

               // };
               // productionPerformance.ProductionResponse.Add(productionResponse);

               // var SegmentResponse = new SegmentResponseType()
               // {
               //     ID = new IdentifierType()
               //     {
               //         Value = SegRespAtt.S95Id
               //     },
               //     Description = new DescriptionTypeCollection
               //             {
               //                 new DescriptionType()
               //                 {
               //                     Value = SegRespAtt.Description
               //                 }
               //             },
               //  Location = new LocationType()
               //  {
               //     EquipmentID = new EquipmentIDType()
               //     {
               //         Value = workCenter
               //     },
               //     EquipmentElementLevel = new EquipmentElementLevelType()
               //     {
               //         Value = EquipmentElementLevel1EnumerationType.WorkCenter
               //     }
               //  },
               //  ActualStartTime = new ActualStartTimeType()
               //  {
               //      Value = SegRespAtt.StartTime
               //  },
               //  ActualEndTime = new ActualEndTimeType()
               //  {
               //      Value = SegRespAtt.EndTime
               //  },
                 
               //     MaterialProducedActual =  MaterialProducedActualTypeCollection.FromArray
               //         (
               //             workOrder.MaterialsProduced.Select(materialProduced => 
               //                 this.GetMaterialProducedActual(materialProduced.MaterialDefinition, materialProduced.MaterialDefinitionSerialized, materialProduced.MaterialDefinitionPrimaryUnitOfMeasure, materialProduced.SerialNumber, materialProduced.Quantity)).ToArray()
               //         ),

               //         MaterialConsumedActual = MaterialConsumedActualTypeCollection.FromArray
               //         (
               //             workOrder.MaterialsConsumed.Select(materialConsumed => this.GetMaterialConsumedActual(materialConsumed.MaterialDefinition, materialConsumed.MaterialDefinitionSerialized, materialConsumed.MaterialDefinitionPrimaryUnitOfMeasure, materialConsumed.MaterialLotS95Id, materialConsumed.Quantity)).ToArray()
               //         )
               // };

               // productionResponse.SegmentResponse.Add(SegmentResponse);


               //var MaterialProducedActual =  MaterialProducedActualTypeCollection.FromArray
               //         (
               //             workOrder.MaterialsProduced.Select(materialProduced => this.GetMaterialProducedActual(materialProduced.MaterialDefinition, materialProduced.MaterialDefinitionSerialized, materialProduced.MaterialDefinitionPrimaryUnitOfMeasure, materialProduced.SerialNumber, materialProduced.Quantity)).ToArray()
               //         );

               //var MaterialConsumedActual = MaterialConsumedActualTypeCollection.FromArray
               // (
               //     workOrder.MaterialsConsumed.Select(materialConsumed => this.GetMaterialConsumedActual(materialConsumed.MaterialDefinition, materialConsumed.MaterialDefinitionSerialized, materialConsumed.MaterialDefinitionPrimaryUnitOfMeasure, materialConsumed.MaterialLotS95Id, materialConsumed.Quantity)).ToArray()
               // );

        //        string message =
        //                        "<?xml version='1.0' encoding='utf-8'?>"+
        //                        "<ProductionPerformance xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:Extended='http://www.wbf.org/xml/B2MML-V0401-AllExtensions' xmlns='http://www.wbf.org/xml/B2MML-V0401'>"+
        //                        "<ID>" + new Random().Next().ToString() + "</ID><PublishedDate>" + publishedDate + "</PublishedDate>" +
        //                            "<ProductionResponse>"+
        //                            "<ID>"+workOrder.S95Id+"</ID>"+
        //                            "<Location>"+
        //                            "<EquipmentID>" + workOrder.Site+ "</EquipmentID>" +
        //                            "<EquipmentElementLevel>"+EquipmentElementLevel1EnumerationType.Area+"</EquipmentElementLevel>"+
        //                            "</Location><SegmentResponse><ID>" + SegRespAtt.S95Id + "</ID>" +
        //                            "<Description><![CDATA[" + SegRespAtt.Description + "]]></Description><Location>" +
        //                            "<EquipmentID>" + workCenter + "</EquipmentID>" +
        //                            "<EquipmentElementLevel>" + EquipmentElementLevel1EnumerationType.WorkCenter + "</EquipmentElementLevel>" +
        //                            "</Location><ActualStartTime>" + startTime + "</ActualStartTime>" +
        //                            "<ActualEndTime>" + endTime+ "</ActualEndTime>" +
        //                            "<MaterialProducedActual>"+
        //                            "<MaterialDefinitionID>"+workOrder.MaterialsProduced.FirstOrDefault().MaterialDefinition.DisplayName+"</MaterialDefinitionID>"+
        //                            "<MaterialLotID>"+workOrder.MaterialsProduced.FirstOrDefault().SerialNumber+"</MaterialLotID>"+
        //                            "<Quantity><QuantityString>" + quantityCompleted+ "</QuantityString>" +
        //                            "<DataType xsi:nil='true' /><UnitOfMeasure />"+
        //                            "<Key>ProducedLot</Key></Quantity></MaterialProducedActual>"+
        //                            "</SegmentResponse></ProductionResponse>"+
        //                        "</ProductionPerformance>";

              



        //        errorMessage = null;

        //       // return productionPerformance.B2MMLDocument;
        //        return message;
        //    }
        //    catch (Exception exception)
        //    {
        //        errorMessage = exception.Message;

        //        return null;
        //    }
        //}
      
        //public void LoadWorkRequest(DirectoryResource workRequest,Guid lotOpSegmentResponseId, string materialLotId,string PersonS95Id,string quantityCompleted,out WorkOrder workOrder)
        //{
        //   // AllSNCompleted = true;
        //    workOrder = null;
        //    if (workRequest == null)
        //        return;

        //    var s95Id = workRequest.DisplayName;
        //    var description = workRequest.Description;

        //    var workRequestAttributes = this.ServiceDirectoryManager.IProductionRuntime.ReadWorkRequestAttributes(workRequest);
        //    var creationDate = workRequestAttributes.CreationDate;

        //    var masterSegment = this.ServiceDirectoryManager.IProductionRuntime.ReadSegmentRequirement(workRequestAttributes.MasterSegment, SegmentRequirementDetailLevel.IncludeParameters | SegmentRequirementDetailLevel.IncludeEquipmentRequirements);

        //    var productionLine = masterSegment.Equipment[ProcessSegments.MasterSegment.EquipmentRequirements.ProductionLine].SpecifiedResource;
        //    var site = this.ServiceDirectoryManager.IEquipment.GetEquipmentParent(productionLine);

        //    var shopOrders = this.ServiceDirectoryManager.IExecutionManagement.QueryShopOrders(this.PersonnelManager.IntegrationPerson.DisplayName, new ShopOrderSearchCriteria() { Name = workRequest.DisplayName, NameSet = true });
        //    if (shopOrders.AsEnumerable().Count() < 1)
        //        return;
           
        //    var shopOrder = shopOrders.AsEnumerable().Single();
        //    var producedMaterialS95Id = (string)shopOrder[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.ShopOrder.ProducedMaterial];
        //    var startDate = shopOrder[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.ShopOrder.StartTime] is DateTime ? (DateTime)shopOrder[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.ShopOrder.StartTime] : (DateTime?)null;
        //    var endDate = shopOrder[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.ShopOrder.EndTime] is DateTime ? (DateTime)shopOrder[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.ShopOrder.EndTime] : (DateTime?)null;

        //    var shopOrdersegmentResponseId = (Guid)shopOrder[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.ShopOrder.Id];
                        
        //   // DataTable _lotOperations = null;
        //    List<Guid> lotOperationIds = new List<Guid>();
        //    var materialsConsumed = new List<WorkOrder.MaterialConsumed>();
        //    var operations = this.ServiceDirectoryManager.IExecutionManagement.QueryOperations(PersonS95Id, new OperationSearchCriteria() { ShopOrderId = shopOrdersegmentResponseId, ShopOrderIdSet = true, OperationName = SegRespAtt.S95Id, OperationNameSet = true });
        //    var lotOperationBOM = this.ServiceDirectoryManager.IExecutionManagement.GetMaterialBill(lotOpSegmentResponseId,true);
        //            if (lotOperationBOM != null && lotOperationBOM.Any())
        //            {
        //                foreach (var materialConsumed in lotOperationBOM.AsEnumerable())
        //                {
        //                    var _materialLotId = materialConsumed.ActualMaterialLotS95Id;

        //                    var materialDefinitionS95Id = materialConsumed.ActualMaterialDefinitionS95Id;
        //                    if (!(string.IsNullOrEmpty(materialDefinitionS95Id)))
        //                    {
        //                        var materialDefinition = this.MaterialDefinitionManager.GetMaterialDefinitionFromDB(materialDefinitionS95Id);
        //                        if (materialDefinition == null)
        //                            return;
        //                        var materialDefinitionProperties = this.ServiceDirectoryManager.IMaterial.ReadMaterialValuesByName(materialDefinition, new string[]
        //                {
        //                    MaterialClasses.Item.Properties.PrimaryUnitOfMeasure,                            
        //                });

        //                        var materialDefinitionPrimaryUnitOfMeasure = Convert.ToString(materialDefinitionProperties[MaterialClasses.Item.Properties.PrimaryUnitOfMeasure].ObjectValue);
        //                        var quantity = materialConsumed.ActualQuantity;
        //                        materialsConsumed.Add(new WorkOrder.MaterialConsumed(_materialLotId, materialDefinition, materialDefinitionPrimaryUnitOfMeasure, quantity));
        //                    }

                           
        //                }

                        
        //        }

            

        //    //Get produced lots           
        //    var producedLots = 
        //        this.ServiceDirectoryManager.IExecutionManagement.QueryProducedLots(this.PersonnelManager.IntegrationPerson.DisplayName,
        //        new ProducedLotSearchCriteria() { 
        //            ShopOrderId = shopOrdersegmentResponseId, 
        //            ShopOrderIdSet = true });




        //    //var producedLotOps =
        //    //    this.ServiceDirectoryManager.IExecutionManagement.QueryLotOperations(this.PersonnelManager.IntegrationPerson.DisplayName,
        //    //    new LotOperationSearchCriteria
        //    //    {
        //    //        ShopOrderId = shopOrdersegmentResponseId,
        //    //        ShopOrderIdSet = true
        //    //    });



        //    var materialsProduced = new List<WorkOrder.MaterialProduced>();
        //    foreach (var materialProduced in producedLots.AsEnumerable())
        //    {
        //        var _materialLotId = (Guid)materialProduced[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.Lot.MaterialLotId];

        //        if (String.Equals(_materialLotId.ToString(), materialLotId))
        //        {

        //            var materialDefinitionS95Id = (string)materialProduced[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.Lot.ProducedMaterial];
        //            var materialDefinition = this.MaterialDefinitionManager.GetMaterialDefinitionFromDB(materialDefinitionS95Id);
        //            if (materialDefinition == null)
        //                return;

        //            var materialDefinitionProperties = this.ServiceDirectoryManager.IMaterial.ReadMaterialValuesByName(materialDefinition, new string[]
        //                {
        //                    MaterialClasses.Item.Properties.PrimaryUnitOfMeasure,                            
        //                });

        //            var materialDefinitionPrimaryUnitOfMeasure = Convert.ToString(materialDefinitionProperties[MaterialClasses.Item.Properties.PrimaryUnitOfMeasure].ObjectValue);
        //            var serialNumber = (string)materialProduced[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.Lot.SerialNumber];

                    
        //            //var quantity = Convert.ToDouble(materialProduced[BrilliantFactory.Interfaces.Types.ExecutionColumnNames.Lot.Quantity]);

        //            var quantity = Convert.ToDouble(quantityCompleted);


                    
        //            materialsProduced.Add(new WorkOrder.MaterialProduced(_materialLotId, materialDefinition, materialDefinitionPrimaryUnitOfMeasure, serialNumber, quantity));
        //        }
        //    }

        //    //update quantity with correct value
        //    ProducedLotAttributes[] produced_lots = this.ServiceDirectoryManager.IExecutionManagement.GetOperationLotsAttributes(lotOperationIds.ToArray());
        //    foreach (ProducedLotAttributes producedLot in produced_lots)
        //    {
        //       var qty =  this.ServiceDirectoryManager.IExecutionManagement.GetLotOperationExtensionAttribute(producedLot.LotOperationId.Value, "QuantityCompleted");                
        //       materialsProduced.Where(x => x.SerialNumber == producedLot.SerialNumber).First().Quantity = Convert.ToDouble(qty);
        //    }
            
        //    //get workcenter
        //    var operation = operations.AsEnumerable().Single();
        //    string workCenter = operation["WorkCenter"].ToString();

        //    var workCenterAddress = this.EquipmentManager.GetDepartment(workCenter);

        //    var workCenterParent = this.ServiceDirectoryManager.IEquipment.GetEquipmentParent(workCenterAddress);

        //    var workCenterParentName = workCenterParent.DisplayName;

        //    workOrder = new WorkOrder(site.DisplayName, s95Id, description, workCenterParentName, materialsProduced, materialsConsumed);
        //}

        //private MaterialProducedActualType GetMaterialProducedActual(DirectoryResource materialDefinition, bool materialDefinitionSerialized, string materialDefinitionPrimaryUnitOfMeasure, string serialNumber, double quantity)
        //{
        //    return new MaterialProducedActualType()
        //    {
        //        MaterialDefinitionID = new MaterialDefinitionIDTypeCollection
        //                {
        //                    new MaterialDefinitionIDType()
        //                    {
        //                        Value = materialDefinition.DisplayName
        //                    }
        //                },
        //        MaterialLotID = new MaterialLotIDTypeCollection
        //                {
        //                    new MaterialLotIDType()
        //                    {
        //                        Value = serialNumber
        //                    }
        //                },
        //        Quantity = new QuantityValueTypeCollection()
        //                {
        //                    this.GetQuantity(quantity, materialDefinitionPrimaryUnitOfMeasure, "ProducedLot")
        //                }
               
        //    };
        //}
        //private MaterialConsumedActualType GetMaterialConsumedActual(DirectoryResource materialDefinition, bool materialDefinitionSerialized, string materialDefinitionPrimaryUnitOfMeasure, string serialNumber, double quantity)
        //{
        //    return new MaterialConsumedActualType()
        //    {
        //        MaterialDefinitionID = new MaterialDefinitionIDTypeCollection
        //                {
        //                    new MaterialDefinitionIDType()
        //                    {
        //                        Value = materialDefinition.DisplayName
        //                    }
        //                },
        //        MaterialLotID = new MaterialLotIDTypeCollection
        //                {
        //                    new MaterialLotIDType()
        //                    {
        //                        Value = serialNumber
        //                    }
        //                },
        //        Quantity = new QuantityValueTypeCollection()
        //                {
        //                    this.GetQuantity(quantity, materialDefinitionPrimaryUnitOfMeasure, "ConsumedLot")
        //                }

        //    };
        //}

        //private QuantityValueType GetQuantity(double quantity, string uoM, string key)
        //{
        //    return this.GetQuantity(quantity.ToString(CultureInfo.InvariantCulture), uoM, key);
        //}

        //private QuantityValueType GetQuantity(string quantity, string uoM, string key)
        //{
        //    return new QuantityValueType
        //    {
        //        QuantityString = new QuantityStringType()
        //        {
        //            Value = quantity
        //        },
        //        UnitOfMeasure = new UnitOfMeasureType()
        //        {
        //            Value = uoM
        //        },
        //        Key = new IdentifierType()
        //        {
        //            Value = key
        //        }
        //    };
        //}
        //private MaterialProducedActualPropertyType GetMaterialProducedActualProperty(string id, DateTime? value)
        //{
        //    return value == null ? this.GetMaterialProducedActualProperty(id, (string)null) : this.GetMaterialProducedActualProperty(id, value.Value);
        //}

        //private MaterialProducedActualPropertyType GetMaterialProducedActualProperty(string id, DateTime value)
        //{
        //    return this.GetMaterialProducedActualProperty(id, value.ToString("o", CultureInfo.InvariantCulture));
        //}

        //private MaterialProducedActualPropertyType GetMaterialProducedActualProperty(string id, string value)
        //{
        //    return new MaterialProducedActualPropertyType()
        //    {
        //        ID = new IdentifierType()
        //        {
        //            Value = id
        //        },
        //        Value = new ValueTypeCollection
        //                {
        //                    new Proficy.OpenEnterprise.Types.ValueType()
        //                    {
        //                        ValueString = new ValueStringType()
        //                        {
        //                            Value = value
        //                        }
        //                    }
        //                }
        //    };
        //}


        #endregion

      
        public class WorkOrder
        {
            internal string Site { get; private set; }
            internal string S95Id { get; private set; }
            internal string Description { get; private set; }
            internal string workCenter { get; private set; }
           
            internal IEnumerable<MaterialProduced> MaterialsProduced { get; private set; }
            internal IEnumerable<MaterialConsumed> MaterialsConsumed { get; private set; }
            //internal IEnumerable<Operation> Operations { get; private set; }

            internal WorkOrder(string site, string s95Id, string description, string workCenter, IEnumerable<MaterialProduced> materialsProduced, IEnumerable<MaterialConsumed> materialsConsumed)
            {
                this.Site = site;
                this.S95Id = s95Id;
                this.Description = description;               
                this.MaterialsProduced = materialsProduced;
                this.MaterialsConsumed = materialsConsumed;
                this.workCenter = workCenter;
                //this.Operations = operations;
            }

            //internal class Operation
            //{
            //	internal string OperationId { get; private set; }
            //	internal string Description { get; private set; }
            //	internal DateTime? StartTime { get; private set; }
            //	internal DateTime? EndTime { get; private set; }
            //	internal IEnumerable<LotOperation> LotOperations { get; private set; }
            //	//public IEnumerable<BillOfMaterialItemAttributes> MaterialsConsumed { get; private set; }

            //	internal Operation(string operationId, string description, DateTime? startTime, DateTime? endTime, IEnumerable<LotOperation> lotOperations/*, IEnumerable<BillOfMaterialItemAttributes> materialsConsumed*/)
            //	{
            //		this.OperationId = operationId;
            //		this.Description = description;
            //		this.StartTime = startTime;
            //		this.EndTime = endTime;
            //		this.LotOperations = lotOperations;
            //	}

            //	//internal class MaterialConsumed
            //	//{
            //	//	internal string MaterialDefinitionS95Id { get; private set; }
            //	//	internal string SerialNumber { get; private set; }
            //	//	internal double Quantity { get; private set; }

            //	//	internal MaterialConsumed(string materialDefinitionS95Id, string serialNumber, double quantity)
            //	//	{
            //	//		this.MaterialDefinitionS95Id = materialDefinitionS95Id;
            //	//		this.SerialNumber = serialNumber;
            //	//		this.Quantity = quantity;
            //	//	}
            //	//}

            //	internal class LotOperation
            //	{
            //		internal MaterialProduced MaterialProduced { get; private set; }
            //		internal double Quantity { get; private set; }
            //		internal DateTime? StartTime { get; private set; }
            //		internal DateTime? EndTime { get; private set; }

            //		internal LotOperation(MaterialProduced materialProduced, double quantity, DateTime? startTime, DateTime? endTime)
            //		{
            //			this.MaterialProduced = materialProduced;
            //			this.Quantity = quantity;
            //			this.StartTime = startTime;
            //			this.EndTime = endTime;
            //		}
            //	}
            //}

            internal class MaterialProduced
            {
                internal Guid MaterialLotId { get; private set; }
                internal DirectoryResource MaterialDefinition { get; private set; }
                internal string MaterialDefinitionPrimaryUnitOfMeasure { get; private set; }
                internal bool MaterialDefinitionSerialized { get; private set; }
                internal string SerialNumber { get; private set; }
                internal double Quantity { get; set; }

                internal MaterialProduced(Guid materialLotId, DirectoryResource materialDefinition, string materialDefinitionPrimaryUnitOfMeasure, string serialNumber, double quantity)
                {
                    this.MaterialLotId = materialLotId;
                    this.MaterialDefinition = materialDefinition;
                    this.MaterialDefinitionPrimaryUnitOfMeasure = materialDefinitionPrimaryUnitOfMeasure;
                    
                    this.SerialNumber = serialNumber;
                    this.Quantity = quantity;
                }
            }

            internal class MaterialConsumed
            {
                internal string MaterialLotS95Id { get; private set; }
                internal DirectoryResource MaterialDefinition { get; private set; }
                internal string MaterialDefinitionPrimaryUnitOfMeasure { get; private set; }
                internal bool MaterialDefinitionSerialized { get; private set; }
               
                internal double Quantity { get; private set; }

                internal MaterialConsumed(string materialLotS95Id, DirectoryResource materialDefinition, string materialDefinitionPrimaryUnitOfMeasure,  double quantity)
                {
                    this.MaterialLotS95Id = materialLotS95Id;
                    this.MaterialDefinition = materialDefinition;
                    this.MaterialDefinitionPrimaryUnitOfMeasure = materialDefinitionPrimaryUnitOfMeasure;

                    
                    this.Quantity = quantity;
                }
            }
        }
    }
}
