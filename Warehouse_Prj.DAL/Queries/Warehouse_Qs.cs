using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Prj.DAL;

namespace Warehouse_Prj.DAL.CRUD
{
    class Warehouse_Qs
    {
        public void Create(DataModel.Warehouse warehouse) {

            using (var context = new DataModel.WarehouseContext())
            {
                // Create and save a new Products

                var newWarehouse = new DataModel.Warehouse();

                newWarehouse.Warehouse_Name = warehouse.Warehouse_Name;
                newWarehouse.Street = warehouse.Street;
                newWarehouse.City = warehouse.City;
                newWarehouse.State = warehouse.State;
                newWarehouse.Zipcode = warehouse.Zipcode;

                context.Warehouses.Add(newWarehouse);
                context.SaveChanges();
            }
        }

        public void Update(DataModel.Warehouse warehouse, ref string msg)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Get and update product

                var wse = context.Warehouses.First(w => w.Warehouse_ID == warehouse.Warehouse_ID);
                if(wse != null)
                {
                    msg = "Warehouse being updated";
                    wse.Warehouse_Name = warehouse.Warehouse_Name;
                    wse.Street = warehouse.Street;
                    wse.City = warehouse.City;
                    wse.State = warehouse.State;
                    wse.Zipcode = warehouse.Zipcode;
                    context.SaveChanges();
                }

                else
                {
                    msg = "No Warehouses found with the provided ID";
                }
                
            }
        }

        public void Delete(int warehouse_id)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Delete the warehouse using warehouse ID

                var warehouse = new DataModel.Warehouse { Warehouse_ID = warehouse_id };
                context.Warehouses.Attach(warehouse);
                context.Warehouses.Remove(warehouse);
                context.SaveChanges();
            }
        }

        public DataModel.Warehouse GetWarehouse(DataModel.Warehouse warehouse_, ref string msg)
        {
            DataModel.Warehouse Warehouse = new DataModel.Warehouse();
            Warehouse = null;
            using(var context = new DataModel.WarehouseContext())
            {
                var warehouse = context.Warehouses.SingleOrDefault(w => w.Warehouse_ID == warehouse_.Warehouse_ID);

                if(warehouse != null)
                {
                    Warehouse.Warehouse_ID = warehouse.Warehouse_ID;
                    Warehouse.Warehouse_Name = warehouse.Warehouse_Name;
                    Warehouse.Street = warehouse.Street;
                    Warehouse.State = warehouse.State;
                    Warehouse.City = warehouse.City;
                    Warehouse.State = warehouse.State;
                    Warehouse.Zipcode = warehouse.Zipcode;

                    msg = "Warehouse found";

                    return Warehouse;
                }
                else
                {
                    msg = "Warehouse not found";
                }

            }

            return Warehouse;
        }


        public List<DataModel.Warehouse> Get_All_Warehouses(ref string msg)
        {
            List<DataModel.Warehouse> warehouse_list = null;
            using (var context = new DataModel.WarehouseContext())
            {
                var warehouses = context.Warehouses;

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
