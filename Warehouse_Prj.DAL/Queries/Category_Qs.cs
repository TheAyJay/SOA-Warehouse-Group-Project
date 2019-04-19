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
        public void Create(DataModel.Category category, ref string msg) {

            using (var context = new DataModel.WarehouseContext())
            {
                // Create and save a new Category

                var newCategory = new DataModel.Category();

                newCategory.Category_Description = category.Category_Description;
                newCategory.Category_Name = category.Category_Name;

                context.Categories.Add(newCategory);
                context.SaveChanges();

                msg = "Category created.";
            }
        }

        public void Update(DataModel.Category category, ref string msg)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Get and update Category

                var cat = context.Categories.SingleOrDefault(c => c.Category_ID == category.Category_ID);
                if(cat != null)
                {
                    cat.Category_Name = category.Category_Name;
                    cat.Category_Description = category.Category_Description;
                    msg = "Category updated.";
                    context.SaveChanges();
                }

                else
                {
                    msg = "Category not found.";
                }
                
            }
        }

        public void Delete(DataModel.Category category_, ref string msg)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Delete the category using category ID

                var category = new DataModel.Category { Category_ID = category_.Category_ID };
                context.Categories.Attach(category);
                context.Categories.Remove(category);
                context.SaveChanges();

                msg = "Category deleted.";
            }
        }

        public DataModel.Category Get_Product(DataModel.Category category_, ref string msg)
        {
            DataModel.Category category = new DataModel.Category();
            category = null;
            using (var context = new DataModel.WarehouseContext())
            {
                // Get product
                var cat = context.Categories.SingleOrDefault(c => c.Category_ID == category_.Category_ID);
                if (cat != null)
                {
                    msg = "Found categories";
                    category.Category_ID = cat.Category_ID;
                    category.Category_Name = cat.Category_Name;
                    category.Category_Description = cat.Category_Description;

                    return category;
                }

                else
                {
                    msg = "No products found";
                }
            }

            return category;
        }
    }
}
