using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Interfaces.Types
{
    public static class ExecutionColumnNames
    {
        public static class ShopOrder
        {
            public static string Id { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.Common.Id; } }
            public static string Status { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.Common.Status; } }

            public static string ProducedMaterial { get { return "ProducedMaterial"; } }
            public static string Quantity { get { return "Quantity"; } }
            public static string StartTime { get { return "StartTime"; } }
            public static string EndTime { get { return "EndTime"; } }
        }

        public static class Operation
        {
            public static string Id { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.Common.Id; } }
            public static string Name { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.Operation.Name; } }

            public static string Priority { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.Operation.Priority; } }

            public static string StartTime { get { return "StartTime"; } }
            public static string EndTime { get { return "EndTime"; } }
        }

        public static class LotOperation
        {
            public static string Id { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.Common.Id; } }

            public static string IsAvailable { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.LotOperation.IsAvailable; } }

            public static string ShopOrderName { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.LotOperation.ShopOrder; } }

            public static string OperationName { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.LotOperation.Name; } }
            public static string OperationDescription { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.LotOperation.Description; } }

            public static string MaterialDefinitionS95Id { get { return "ProducedMaterial"; } }
            public static string SerialNumber { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.LotOperation.SerialNumber; } }
        }

        public static class Step
        {
            public static string Id { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.Common.Id; } }
        }

        public static class Lot
        {
            public static string Id { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.Common.Id; } }

            public static string MaterialLotId { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.Lot.MaterialLotId; } }

            public static string Status { get { return Proficy.PFM.Solutions.Route.Interfaces.ExecutionColumnNames.Common.Status; } }
            public static string Quantity { get { return "Quantity"; } }
            public static string QuantityAvailable { get { return "QuantityAvailable"; } }
            public static string ProducedMaterial { get { return "ProducedMaterial"; } }
            public static string SerialNumber { get { return "SerialNumber"; } }
        }
    }
}
