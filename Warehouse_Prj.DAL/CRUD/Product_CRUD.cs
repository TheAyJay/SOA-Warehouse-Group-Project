using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Prj.DAL;

namespace Warehouse_Prj.DAL.CRUD
{
    class Product_CRUD
    {
        public void Create(DataModel.Product product_in) {

            using (var context = new DataModel.WarehouseContext())
            {
                // Create and save a new Products

                var newProduct = new DataModel.Product();

                newProduct.Product_ID = product_in.Product_ID;
                newProduct.Product_Name = product_in.Product_Name;
                newProduct.Product_Price = product_in.Product_Price;
                newProduct.Product_UPC = product_in.Product_UPC;

                context.Products.Add(newProduct);
                context.SaveChanges();
            }
        }

        public void Update(DataModel.Product product_in)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Get and update product

                var product = context.Products.SingleOrDefault(p => p.Product_ID == product_in.Product_ID);
                if(product != null)
                {
                    product.Product_Name = product_in.Product_Name;
                    product.Product_Price = product_in.Product_Price;
                    product.Product_UPC = product_in.Product_UPC;
                    
                }
                context.SaveChanges();
            }
        }

        public void Delete(int product_in)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Delete the product using product ID

                var product = new DataModel.Product { Product_ID = product_in };
                context.Products.Attach(product);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
