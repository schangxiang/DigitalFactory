using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WIP_Models
{
    public class ResourceMenu
    {
        public String menuID { get; set; }
        public String menuDispSequence { get; set; }
        public String menuLevel { get; set; }
        public String menuName { get; set; }
        public String url { get; set; }
        public String icon { get; set; }
        public String color { get; set; }
        public List<ResourceMenu> children { get; set; }

    }
}
