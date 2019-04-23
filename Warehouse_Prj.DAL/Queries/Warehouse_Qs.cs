using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Prj.DAL;

namespace Warehouse_Prj.DAL.CRUD
{
    public class Warehouse_Qs
    {
        /// <summary>
        /// MSCS 701-702 Topics in Math Sts, & Comp Sci
        /// Service Oriented Architecture (SOA)
        /// Spring 2019
        /// Omar Waller, Andrew Jacobson
        /// 
        /// Description: This class contains CRUD and Get queries to the Warehouse table in the Warehouse database configured 
        /// in the app.config file.
        /// </summary>

        //Given a Warehouse object, add to Warehouses table
        //Returns a boolean
        public bool Create(DataModel.Warehouse warehouse_in, ref string msg)
        {
            var ret = true;

            using (var context = new DataModel.WarehouseContext())
            {
                // Create and save a new Warehouse
                var newWarehouse = new DataModel.Warehouse();

                newWarehouse.Warehouse_ID = warehouse_in.Warehouse_ID;
                newWarehouse.Warehouse_Name = warehouse_in.Warehouse_Name;
                newWarehouse.Street = warehouse_in.Street;
                newWarehouse.City = warehouse_in.City;
                newWarehouse.State = warehouse_in.State;
                newWarehouse.Zipcode = warehouse_in.Zipcode;

                //Add the Warehouse
                context.Warehouses.Add(newWarehouse);

                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if(execution_result != 1)
                {
                    msg = "Warehouse was not added";
                    ret = false;
                }
                else
                {
                    msg = "Warehouse added";
                }
            }

            return ret;
        }

        //Given a Warehouse object, update the Warehouses table on Warehouse_ID
        //Returns a boolean
        public bool Update(DataModel.Warehouse warehouse_in, ref string msg)
        {
            var ret = true;

            using (var context = new DataModel.WarehouseContext())
            {
                // Get and update Warehouse
                var warehouse = context.Warehouses.First(w => w.Warehouse_ID == warehouse_in.Warehouse_ID);
                if(warehouse != null)
                {
                    warehouse.Warehouse_Name = warehouse.Warehouse_Name;
                    warehouse.Street = warehouse.Street;
                    warehouse.City = warehouse.City;
                    warehouse.State = warehouse.State;
                    warehouse.Zipcode = warehouse.Zipcode;

                    //Apply change
                    context.Warehouses.Attach(warehouse);
                    context.Entry(warehouse).State = System.Data.Entity.EntityState.Modified;

                    //Check execution of transaction - we expect 1 change to have occurred
                    var execution_result = context.SaveChanges();
                    if(execution_result != 1)
                    {
                        msg = "Warehouse was not updated";
                        ret = false;
                    }
                    else
                    {
                        msg = "Warehouse updated";
                    }
                }
                else
                {
                    msg = "No Warehouse found with the provided ID";
                    ret = false;
                }
            }

            return ret;
        }

        //Given an ID, delete Warehouse from Warehouses
        //Returns a boolean
        public bool Delete_Warehouse_By_ID(int warehouse_id, ref string msg)
        {
            var ret = true;

            using (var context = new DataModel.WarehouseContext())
            {
                // Delete Warehouse from the database using warehouse ID
                var warehouse = new DataModel.Warehouse { Warehouse_ID = warehouse_id };
                context.Warehouses.Attach(warehouse);
                context.Warehouses.Remove(warehouse);

                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if(execution_result != 1)
                {
                    msg = "Warehouse was not deleted";
                    ret = false;
                }
                else
                {
                    msg = "Warehouse deleted";
                }
            }

            return ret;
        }

        //Given an ID, delete Warehouse from Warehouses table
        //Returns a boolean
        public DataModel.Warehouse Get_Warehouse_By_ID(int warehouse_ID)
        {
            //Create Warehouse object
            DataModel.Warehouse warehouse = new DataModel.Warehouse();
            warehouse = null;

            using(var context = new DataModel.WarehouseContext())
            {
                //Get Warehouse from database
                var warehouse_Qs = context.Warehouses.SingleOrDefault(w => w.Warehouse_ID == warehouse_ID);

                //Translate query result to Warehouse object
                if(warehouse_Qs != null)
                {
                    warehouse.Warehouse_ID = warehouse_Qs.Warehouse_ID;
                    warehouse.Warehouse_Name = warehouse_Qs.Warehouse_Name;
                    warehouse.Street = warehouse_Qs.Street;
                    warehouse.City = warehouse_Qs.City;
                    warehouse.State = warehouse_Qs.State;
                    warehouse.Zipcode = warehouse_Qs.Zipcode;

                    return warehouse;
                }
            }

            return warehouse;
        }

        //Return a list of all Warehouses in the database.
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