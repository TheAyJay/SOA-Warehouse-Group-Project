using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Warehouse_Prj.BDO
{
    public class Inventory_BDO
    {
        public int ID { get; set; }
        public int Quantity { get; set; }

        public int Products_ID { get; set; }

        public int Warehouse_ID { get; set; }

        public virtual Warehouse_BDO Warehouse {get; set;}

    }
}
