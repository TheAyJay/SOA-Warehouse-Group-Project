using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Warehouse_Prj.BDO
{
    /// <summary>
    /// MSCS 6931 Topics in Math Sts, & Comp Sci
    /// Service Oriented Architecture (SOA)
    /// Spring 2019
    /// Omar Waller, Andrew Jacobson
    /// 
    /// Description: Business Domain Object class for Inventory object.
    /// </summary>
    public class Inventory_BDO
    {
        public int ID { get; set; }
        public int Quantity { get; set; }

        public int Products_ID { get; set; }

        public int Warehouse_ID { get; set; }

        public virtual Warehouse_BDO Warehouse {get; set;}

    }
}
