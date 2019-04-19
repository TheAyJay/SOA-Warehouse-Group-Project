using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Prj.DAL;

namespace Warehouse_Prj.DAL.CRUD
{
    public class Product_Qs
    {
        public void Create(DataModel.Product product_in, ref string msg)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Create and save a new Product

                var newProduct = new DataModel.Product();

                newProduct.Product_ID = product_in.Product_ID;
                newProduct.Product_Name = product_in.Product_Name;
                newProduct.Product_Price = product_in.Product_Price;
                newProduct.Product_UPC = product_in.Product_UPC;

                context.Products.Add(newProduct);
                context.SaveChanges();

                msg = "Product created";
            }

        }

        public bool Update(DataModel.Product product_in, ref string msg)
        {
            using (var context = new DataModel.WarehouseContext())
            {
                // Get and update product
                var product = context.Products.SingleOrDefault(p => p.Product_ID == product_in.Product_ID);
                if (product != null)
                {
                    product.Product_Name = product_in.Product_Name;
                    product.Product_Price = product_in.Product_Price;
                    product.Product_UPC = product_in.Product_UPC;
                    context.SaveChanges();

                    msg = "Product updated";
                    return true;
                }
                else
                {
                    msg = "No product found to update";
                    return false;
                }
            }
        }

        public void Delete(DataModel.Product product_, ref string msg)
        {

            using (var context = new DataModel.WarehouseContext())
            {
                // Delete the product using product ID

                var product = new DataModel.Product { Product_ID = product_.Product_ID };
                context.Products.Attach(product);
                context.Products.Remove(product);
                context.SaveChanges();
                msg = "Product deleted";
            }
        }

        public DataModel.Product Get_Product(DataModel.Product product_DTO, ref string msg)
        {
            DataModel.Product product_ = new DataModel.Product();
            product_ = null;
            using (var context = new DataModel.WarehouseContext())
            {
                // Get product
                var product = context.Products.SingleOrDefault(p => p.Product_ID == product_DTO.Product_ID);
                if (product != null)
                {
                    msg = "Found products";
                    product.Product_ID = product_.Product_ID;
                    product.Product_Name = product_.Product_Name;
                    product.Product_Price = product_.Product_Price;
                    product.Product_UPC = product_.Product_UPC;

                    return product_;
                }

                else
                {
                    msg = "No products found";
                }
            }

            return product_;
        }

        public DataModel.Product Get_Product_By_ID(int product_ID, ref string msg)
        {
            DataModel.Product product = new DataModel.Product();
            product = null;
            using (var context = new DataModel.WarehouseContext())
            {
                // Get product
                var product_Qs = context.Products.SingleOrDefault(p => p.Product_ID == product_ID);
                if (product_Qs != null)
                {
                    msg = "Found product";
                    product_Qs.Product_ID = product.Product_ID;
                    product_Qs.Product_Name = product.Product_Name;
                    product_Qs.Product_Price = product.Product_Price;
                    product_Qs.Product_UPC = product.Product_UPC;

                    return product;
                }
                else
                {
                    msg = "No product found";
                }
            }

            return product;
        }

        public List<DataModel.Product> Get_All_Products(ref string msg)
        {
            List<DataModel.Product> product_list = new List<DataModel.Product>();
            product_list = null;
            using (var context = new DataModel.WarehouseContext())
            {
                // Get all products in DB
                var products = context.Products;
                if (products != null)
                {
                    msg = "Found products";
                    product_list = products.ToList();

                    return product_list;
                }

                else
                {
                    msg = "No products found";
                }
            }

            return product_list;
        }
    }
}
