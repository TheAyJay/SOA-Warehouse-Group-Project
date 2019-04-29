using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Prj.DAL;

namespace Warehouse_Prj.DAL.CRUD
{
    public class Inventory_Qs
    {
        /// <summary>
        /// MSCS 701-702 Topics in Math Sts, & Comp Sci
        /// Service Oriented Architecture (SOA)
        /// Spring 2019
        /// Omar Waller
        /// 
        /// Description: This class contains CRUD and Get queries to the Inventory table in the Warehouse database configured 
        /// in the app.config file.
        /// </summary>

        // This method creates a Inventory record in the Warehouse database and returns true if the operation was successful.
        public bool Create(DataModel.Inventory inventory, ref string msg) {

            using (var context = new DataModel.WarehouseContext())
            {
                // Create and save a new Products
                DataModel.Inventory newInventory = new DataModel.Inventory();
                bool success = false;

                newInventory.Product_Quantity = inventory.Product_Quantity;
                newInventory.Inventory_ID = inventory.Inventory_ID;
                newInventory.Product_ID = inventory.Product_ID;
                newInventory.Warehouse_ID = inventory.Warehouse_ID;

                context.Inventories.Add(newInventory);
                
                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if (execution_result != 1)
                {
                    msg = "Inventory not created in DB - DAL";
                    
                }
                else
                {
                    msg = "Inventory object successfully created.";
                    success = true;
                }
                
                return success;
            }
        }


        //This method returns a list of warehouses given a UPC number.
        public List<DataModel.Inventory> Get_Inventories_By_Warehouse_Name(string warehouse_name , ref string msg)
        {
            List<DataModel.Inventory> inventory_list = new List<DataModel.Inventory>();

            using (var context = new DataModel.WarehouseContext())
            {

                try
                {

                    var inventories = context.Inventories.Where(i => i.WarehouseID.Warehouse_Name == warehouse_name);

                    if (inventories != null)
                    {
                        inventory_list = inventories.ToList();

                        msg = "Inventories found - DAL";

                        return inventory_list;
                    }
                    else
                    {
                        msg = "Warehouse not found";
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("No item found", ex);
                }


            }

            return inventory_list;
        }
    }
}
