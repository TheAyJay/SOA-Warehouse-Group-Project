using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Prj.DAL;

namespace Warehouse_Prj.DAL.CRUD
{
    class Incentory_Qs
    {
        public void Create(DataModel.Category category) {

            using (var context = new DataModel.WarehouseContext())
            {
                // Create and save a new Products

                var newCategory = new DataModel.Category();

                newCategory.Category_Description = category.Category_Description;
                newCategory.Category_Name = category.Category_Name;

                context.Categories.Add(newCategory);
                context.SaveChanges();
            }
        }

        public void Update(DataModel.Category category)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Get and update product

                var cat = context.Categories.SingleOrDefault(c => c.Category_ID == category.Category_ID);
                if(cat != null)
                {
                    cat.Category_Name = category.Category_Name;
                    cat.Category_Description = category.Category_Description;                    
                }
                context.SaveChanges();
            }
        }

        public void Delete(int category_id)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Delete the product using product ID

                var category = new DataModel.Category { Category_ID = category_id };
                context.Categories.Attach(category);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        //public List<DataModel.Warehouse> Get_Warehouses_By_Product_UPC(DataModel.Product product, ref string msg)
        //{
        //    List<DataModel.Warehouse> warehouse_list = null;
        //    using (var context = new DataModel.WarehouseContext())
        //    {
        //        var warehouses = context.Inventories.Where(i => i.Products.Product_UPC == product.Product_UPC)
        //            .Select(w=> new DataModel.Inventory { warehouse_ = DataModel.Inventory.} );

        //        if (warehouses != null)
        //        {
        //            warehouse_list = warehouses.ToList();

        //            msg = "Warehouses found";

        //            return warehouse_list;
        //        }
        //        else
        //        {
        //            msg = "Warehouse not found";
        //        }

        //    }

        //    return warehouse_list;
        //}
    }
}
