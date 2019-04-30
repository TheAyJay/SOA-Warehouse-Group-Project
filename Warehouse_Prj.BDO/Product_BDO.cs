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
    /// Description: Business Domain Object class for Product object.
    /// </summary>
    public class Product_BDO
    {
        public int Product_ID { get; set; }        
        public string Product_Name { get; set; }
        public long Product_UPC { get; set; }
        public decimal Product_Price { get; set; }
        public int CategoryRefID { get; set; }
    }
}
