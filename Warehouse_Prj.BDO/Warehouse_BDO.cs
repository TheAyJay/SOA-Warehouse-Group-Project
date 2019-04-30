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
    /// Description: Business Domain Object class for Warehouse object.
    /// </summary>
    public class Warehouse_BDO
    {
        public int Warehouse_ID { get; set; }        
        public string Warehouse_Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

    }
}
