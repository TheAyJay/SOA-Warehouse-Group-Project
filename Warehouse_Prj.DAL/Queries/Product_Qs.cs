///
/// Project: MSCS 6931 SOA Group Project
/// Created: 4/18/2019
/// Description: Data Access Layer class for queries to the database for Products
///
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
        /// <summary>
        /// MSCS 701-702 Topics in Math Sts, & Comp Sci
        /// Service Oriented Architecture (SOA)
        /// Spring 2019
        /// Omar Waller, Andrew Jacobson
        /// 
        /// Description: This class contains queries to the Products table in the database configured in the app.config file. .
      
        /// </summary>

        //Given a Product object, add to Products table
        //Returns a boolean
        public bool Create(DataModel.Product product_in, ref string msg)
        {
            var ret = true;

            using (var context = new DataModel.WarehouseContext())
            {
                // Create and save a new Product
                var newProduct = new DataModel.Product();

                newProduct.Product_Name = product_in.Product_Name;
                newProduct.Product_Price = product_in.Product_Price;
                newProduct.Product_UPC = product_in.Product_UPC;
                newProduct.Category = product_in.Category;

                //Add the Product
                context.Products.Add(newProduct);

                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if (execution_result != 1)
                {
                    msg = "Product was not created";
                    ret = false;
                }
                else
                {
                    msg = "Product created";
                }
            }

            return ret;
        }

        //Given a Product object, update the Products table on Product_ID
        //Returns a boolean
        public bool Update(DataModel.Product product_in, ref string msg)
        {
            var ret = true;

            using (var context = new DataModel.WarehouseContext())
            {
                // Get and update Product
                var product = context.Products.SingleOrDefault(p => p.Product_ID == product_in.Product_ID);
                if (product != null)
                {
                    product.Product_Name = product_in.Product_Name;
                    product.Product_Price = product_in.Product_Price;
                    product.Product_UPC = product_in.Product_UPC;
                    product.Category = product_in.Category;

                    //Apply change
                    context.Products.Attach(product);
                    context.Entry(product).State = System.Data.Entity.EntityState.Modified;

                    //Check execution of transaction - we expect 1 change to have occurred
                    var execution_result = context.SaveChanges();
                    if (execution_result != 1)
                    {
                        msg = "Product was not updated";
                        ret = false;
                    }
                    else
                    {
                        msg = "Product updated";
                    }
                }
                else
                {
                    msg = "No product found with the provided ID";
                    ret = false;
                }
            }

            return ret;
        }

        //Given a UPC code, delete Product from Products table
        //Returns a boolean
        public bool Delete_Product_By_UPC(long product_UPC, ref string msg)
        {
            var ret = true;

            using (var context = new DataModel.WarehouseContext())
            {
                // Delete Product from the database using product UPC
                DataModel.Product product = new DataModel.Product { Product_UPC = product_UPC };
                context.Products.Attach(product);
                context.Products.Remove(product);

                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if(execution_result != 1)
                {
                    msg = "Product was not deleted";
                    ret = false;
                }
                else
                {
                    msg = "Product deleted";
                }
            }

            return ret;
        }

        //Given an ID, delete Product from Products table
        //Returns a boolean
        public bool Delete_Product_By_ID(int product_ID, ref string msg)
        {
            var ret = true;

            using (var context = new DataModel.WarehouseContext())
            {
                // Delete Product from the database using product ID
                var product = new DataModel.Product { Product_ID = product_ID };
                context.Products.Attach(product);
                context.Products.Remove(product);

                //Check execution of transaction - we expect 1 change to have occurred
                var execution_result = context.SaveChanges();
                if (execution_result != 1)
                {
                    msg = "Product was not deleted";
                    ret = false;
                }
                else
                {
                    msg = "Product deleted";
                }
            }

            return ret;
        }


        //Given a UPC code, get Product from Products table
        //Returns Product object
        public DataModel.Product Get_Product_By_UPC(long product_UPC)
        {
            //Create Product object
            DataModel.Product product = new DataModel.Product();
            product = null;

            using (var context = new DataModel.WarehouseContext())
            {
                try
                {
                    // Get Product from database
                    var product_Qs = context.Products.SingleOrDefault(p => p.Product_UPC == product_UPC);
                    if (product_Qs != null)
                    {
                        product.Product_ID = product_Qs.Product_ID;
                        product.Product_Name = product_Qs.Product_Name;
                        product.Product_Price = product_Qs.Product_Price;
                        product.Product_UPC = product_Qs.Product_UPC;

                        return product;
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("No item found", ex);
                }

            }

            return product;
        }

        //Given an ID, get Product from Products table
        //Returns Product object
        public DataModel.Product Get_Product_By_ID(int product_ID)
        {
            //Create Product object
            DataModel.Product product = new DataModel.Product();
            
            using (var context = new DataModel.WarehouseContext())
            {
                try
                {
                    // Get Product from database
                    var product_Qs = context.Products.SingleOrDefault(p => p.Product_ID == product_ID);
                    if (product_Qs != null)
                    {
                        product.Product_ID = product_Qs.Product_ID;
                        product.Product_Name = product_Qs.Product_Name;
                        product.Product_Price = product_Qs.Product_Price;
                        product.Product_UPC = product_Qs.Product_UPC;

                        return product;
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("No item found", ex);
                }

            }

            return product;
        }

        //TODO
        public List<DataModel.Product> Get_All_Products_By_Warehouse_ID(ref string msg)
        {
            List<DataModel.Product> product_list = new List<DataModel.Product>();
            
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
