using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Warehouse_Prj.Logic;
using Warehouse_Prj.BDO;

namespace Product_Prj.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProduct
    {
        // Getting the product from the business logic layer 
        Product_Logic product_Logic = new Product_Logic();

        public Product GetProductByID(int id)
        {
            var product_BDO = product_Logic.Get_Product_By_ID(id);
            var product = new Product();
            
            // Translating productBDO to productDTO
            TranslateProductBDOToProductDTO(product_BDO, product);

            return product;
        }

        public bool UpdateProductByID(Product product)
        {
            var result = true;

            // Checking to see if price is valid 
            if (product.UnitPrice <= 0)
            {
                
                result = false;
            }

            // UPC cannot be empty 
            else if (product.UPC <= 0)
            {
                
                result = false;
            }

            // Product name cannot be empty
            else if (string.IsNullOrEmpty(product.ProductName))
            {
                
                result = false;
            }

            // categoryID cannot be empty 
            else if (string.IsNullOrEmpty(product.CategoryID))
            {
                
                result = false;
            }

            else
            {
                // TODO: call business logic layer to update product
                Product_BDO product_BDO = new Product_BDO();
                TranslateProductDTOToProductBDO(product, product_BDO);

                
                return product_Logic.Update_Product_By_ID(ref product_BDO);
               
            }

            return result;
        }

        // Translation method from ProductBDO to ProductDTO
        private void TranslateProductBDOToProductDTO(
            Product_BDO product_BDO, Product product)
        {
            product.ProductID = product_BDO.Product_ID;
            product.ProductName = product_BDO.Product_Name;
            product.CategoryID = product_BDO.Category_Name;
            product.UPC = product_BDO.Product_UPC;
            product.UnitPrice = product_BDO.Product_Price;

        }

        // Translation method from ProductDTO to ProductBDO 
        private void TranslateProductDTOToProductBDO(
            Product product,
            Product_BDO product_BDO)
        {
            product_BDO.Product_ID = product.ProductID;
            product_BDO.Product_Name = product.ProductName;
            product_BDO.Category_Name = product.CategoryID;
            product_BDO.Product_UPC = product.UPC;
            product_BDO.Product_Price = product.UnitPrice;

        }

    }
}
