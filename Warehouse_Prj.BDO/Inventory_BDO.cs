﻿using System;
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

        public virtual Product_BDO Products { get; set; }

        public Warehouse_BDO Warehouse { get; set; }

    }
}