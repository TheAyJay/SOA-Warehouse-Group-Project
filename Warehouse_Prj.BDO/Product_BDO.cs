using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Prj.BDO
{
    public class Product_BDO
    {
        public int Product_ID { get; set; }        
        public string Product_Name { get; set; }
        public long Product_UPC { get; set; }
        public decimal Product_Price { get; set; }
        public Category_BDO Category { get; set; }


    }
}
