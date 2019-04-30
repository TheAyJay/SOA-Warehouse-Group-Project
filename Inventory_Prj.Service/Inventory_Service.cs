using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Warehouse_Prj.BDO;
using Warehouse_Prj.Logic;

namespace Inventory_Prj.Service
{
    /// <summary>
    /// MSCS 6931 Topics in Math Sts, & Comp Sci
    /// Service Oriented Architecture (SOA)
    /// Spring 2019
    /// Omar Waller
    /// 
    /// Description: Discoverable inventory service class that implements IInventory_Service.
    /// </summary>

    public class Inventory_Service : IInventory_Service
    {
        Inventory_Logic inventory_Logic = new Inventory_Logic();
        public bool Create_Inventory(Inventory inventory, ref string msg)
        {
            Inventory_BDO inventory_bdo = new Inventory_BDO();
            Translate_DTO_to_BDO(inventory, inventory_bdo);
            return inventory_Logic.Create_Inventory(inventory_bdo, ref msg);
        }

        public List<Inventory> Get_Inventories_By_Warehouse_Name(string Warehouse_Name, ref string msg)
        {
            List<Inventory> inventories = new List<Inventory>();

            List < Inventory_BDO > inventory_BDOs = inventory_Logic.Get_Inventory_By_Warehouse_Name(Warehouse_Name, ref msg);

            foreach(Inventory_BDO i in inventory_BDOs)
            {
                Inventory Inv = new Inventory();
                Translate_BDO_to_DTO(Inv, i);
                inventories.Add(Inv);
            }

            return inventories;

        }

        private void Translate_DTO_to_BDO(Inventory inventory, Inventory_BDO inventory_BDO)
        {
            inventory_BDO.ID = inventory.Inventory_ID;
            inventory_BDO.Products_ID = inventory.Product_ID;
            inventory_BDO.Quantity = inventory.Product_Quantity;
            inventory_BDO.Warehouse_ID = inventory.Warehouse_ID;

        }

        private void Translate_BDO_to_DTO(Inventory inventory, Inventory_BDO inventory_BDO)
        {
            inventory.Inventory_ID = inventory_BDO.ID;
            inventory.Product_ID = inventory_BDO.Products_ID;
            inventory.Product_Quantity = inventory_BDO.Quantity;
            inventory.Warehouse_ID = inventory_BDO.Warehouse_ID;

        }


    }
}
