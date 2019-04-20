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

                var newInventory = new DataModel.Inventory();
                bool success = false;

                newInventory.Inventory_ID = inventory.Inventory_ID;
                newInventory.Products = inventory.Products;
                newInventory.Product_Quantity = inventory.Product_Quantity;
                newInventory.Warehouse = inventory.Warehouse;
                
                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if (execution_result != 1)
                {
                    msg = "Inventory was not created";
                }
                else
                {
                    msg = "Category created";
                    success = true;
                }

                return success;
            }
        }

        // This method updates a Inventory record in the Warehouse database and returns true if the operation was successful.
        public bool Update(DataModel.Inventory inventory, ref string msg)
        {
            using (var context = new DataModel.WarehouseContext())
            {
                // Get and update product

                var inventory_ = context.Inventories.SingleOrDefault(i => i.Inventory_ID == inventory.Inventory_ID);
                bool success = false;
                if(inventory_ != null)
                {
                    inventory_.Inventory_ID = inventory.Inventory_ID;
                    inventory_.Products = inventory.Products;
                    inventory_.Product_Quantity = inventory.Product_Quantity;
                    inventory_.Warehouse = inventory.Warehouse;
                }
                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if (execution_result != 1)
                {
                    msg = "Inventory was not created";
                }
                else
                {
                    msg = "Category created";
                    success = true;
                }

                return success;
            }
        }

        // This method deletes a Inventory record in the Warehouse database and returns true if the operation was successful.
        public bool Delete(int category_id, ref string msg)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Delete the product using product ID

                var category = new DataModel.Category { Category_ID = category_id };
                bool success = false;
                context.Categories.Attach(category);
                context.Categories.Remove(category);
                context.SaveChanges();

                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if (execution_result != 1)
                {
                    msg = "Category not deleted.";
                    success = false;
                }
                else
                {
                    msg = "Category deleted.";
                }

                return success;
            }
        }

        //This method returns a list of warehouses given a UPC number.
        public List<DataModel.Inventory> Get_Warehouses_By_Product_UPC(DataModel.Product product, ref string msg)
        {
            List<DataModel.Inventory> warehouse_list = null;
            using (var context = new DataModel.WarehouseContext())
            {
                List<DataModel.Inventory> warehouses = context.Inventories.Where(i => i.Products.Product_UPC == product.Product_UPC)
                    .Select(w => new DataModel.Inventory { Warehouse = w.Warehouse }).ToList();

                if (warehouses != null)
                {
                    warehouse_list = warehouses.ToList();

                    msg = "Warehouses found";

                    return warehouse_list;
                }
                else
                {
                    msg = "Warehouse not found";
                }

            }

            return warehouse_list;
        }
    }
}
