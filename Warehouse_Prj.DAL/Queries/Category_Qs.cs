using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Prj.DAL;

namespace Warehouse_Prj.DAL.CRUD
{
    public class Category_Qs
    {
        /// <summary>
        /// MSCS 701-702 Topics in Math Sts, & Comp Sci
        /// Service Oriented Architecture (SOA)
        /// Spring 2019
        /// Omar Waller
        /// 
        /// Description: This class contains CRUD and Get queries to the Category table in the Warehouse database configured 
        /// in the app.config file.
        /// </summary>
        DataModel.Category category_dmo = new DataModel.Category();

        // This method creates a Category record in the Warehouse database and returns true if the operation was successful.
        public bool Create(DataModel.Category category) {

            using (var context = new DataModel.WarehouseContext())
            {
                // Create and save a new Category

                DataModel.Category newCategory = new DataModel.Category();
                bool success = false;

                newCategory.Category_Description = category.Category_Description;
                newCategory.Category_Name = category.Category_Name;

                context.Categories.Add(newCategory);

                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if (execution_result == 1)
                {
                    return true;
                }
               
                return success;
            }
        }

        // This method updates a Category record in the Warehouse database and returns true if the operation was successful.
        public bool Update_Category_By_ID(DataModel.Category category)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Get and update Category
                bool success = false;
                var cat = context.Categories.SingleOrDefault(c => c.Category_ID == category.Category_ID);
                if(cat != null)
                {
                    cat.Category_Name = category.Category_Name;
                    cat.Category_Description = category.Category_Description;

                    //Apply change
                    context.Categories.Attach(cat);
                    context.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                    
                }

                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if (execution_result != 1)
                {                    
                    success = false;
                }
               
                return success;
            }
        }

        // This method deletes a Category record in the Warehouse database and returns true if the operation was successful.
        public bool Delete_Category_By_ID(int category_id)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Delete the category using category ID
                bool success = false;
                DataModel.Category category = new DataModel.Category { Category_ID = category_id };
                context.Categories.Attach(category);
                context.Categories.Remove(category);
                

                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if (execution_result != 1)
                {
                    
                    success = false;
                }
             
                return success;
            }
        }

        // This method retrieves a Category record in the Warehouse database using the category ID.
        public DataModel.Category Get_Category_By_ID(int category_id)
        {
            DataModel.Category category = new DataModel.Category();
            
            using (var context = new DataModel.WarehouseContext())
            {
                // Get product
                var cat = context.Categories.SingleOrDefault(c => c.Category_ID == category_id);
                if (cat != null)
                {
                    category.Category_ID = cat.Category_ID;
                    category.Category_Name = cat.Category_Name;
                    category.Category_Description = cat.Category_Description;

                    return category;
                }

            }

            return category;
        }

        public List<DataModel.Category> Get_All_Categories()
        {
            List<DataModel.Category> all_categories = new List<DataModel.Category>();

            using (var context = new DataModel.WarehouseContext())
            {
                // Get product
                var all_cat = context.Categories;
                if (all_cat != null)
                {
                    all_categories = all_cat.ToList();

                    return all_categories;
                }

            }


            return all_categories;
        }
    }
}
