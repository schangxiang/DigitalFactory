using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Interfaces.Model
{
    public class ProductionPerformance
    {
        public string NCRId { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ShopOrder { get; set; }
        public string Plant { get; set; }
        public string Operation { get; set; }
        public string WorkCenter { get; set; }
        public string MaterialDefinition { get; set; }
        public string MaterialLot { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasure { get; set; }

    }
}
