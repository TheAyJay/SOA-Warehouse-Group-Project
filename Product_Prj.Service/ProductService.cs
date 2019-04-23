using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
// Adding references of the logic layer to the service layer
using Warehouse_Prj.Logic;
using Warehouse_Prj.BDO;

namespace Warehouse_Prj.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProduct
    {
        // Getting the product from the business logic layer 
        Product_Logic product_Logic = new Product_Logic();

        public Product GetProduct(int id)
        {
            var product_BDO = product_Logic.Get_Product_By_ID(id);
            var product = new Product();
            
            // Translating productBDO to productDTO
            TranslateProductBDOToProductDTO(product_BDO, product);

            return product;
            

            //product.ProductID = id;
            //product.UPC = "fake UPC from the service layer";
            //product.ProductName = "fake product name from service layer";
            //product.Quantity = "fake quantity";
            //product.CategoryID = "fake categoryID from service layer";
            //product.UnitPrice = 50.0m;
            //return product;
        }

        public bool UpdateProduct(Product product, ref string message)
        {
            var result = true;

            // Checking to see if price is valid 
            if (product.UnitPrice <= 0)
            {
                message = "Price connot be less than or equal to zero!";
                result = false;
            }

            // UPC cannot be empty 
            else if (product.UPC <= 0)
            {
                message = "Please enter a valid UPC value";
                result = false;
            }

            // Product name connot be empty
            else if (string.IsNullOrEmpty(product.ProductName))
            {
                message = "Product name connot be empty";
                result = false;
            }

            // categoryID cannot be empty 
            else if (string.IsNullOrEmpty(product.CategoryID))
            {
                message = "CategoryID cannot be empty";
                result = false;
            }

            // Quantity cannot be empty 
            else if (string.IsNullOrEmpty(product.Quantity))
            {
                message = "Quantity connot be empty";
                result = false;
            }

            else
            {
                // TODO: call business logic layer to update product
                var product_BDO = new Product_BDO();
                TranslateProductDTOToProductBDO(product, product_BDO);
                // NOTE: for some reason product_BDO requireed to add ref otherwise it would give an error
                return product_Logic.Update_Product(ref product_BDO, ref message);
               // message = "Product updated successfully";
               // result = true;
            }

            return result;
        }

        // Translation method from ProductBDO to ProductDTO
        private void TranslateProductBDOToProductDTO(
            Product_BDO product_BDO,
            Product product)
        {
            product.ProductID = product_BDO.Product_ID;
            product.ProductName = product_BDO.Product_Name;
            product.UPC = product_BDO.Product_UPC;
            //product.Quantity = product_BDO.Quantity;
            product.UnitPrice = product_BDO.Product_Price;

        }

        // Translation method from ProductDTO to ProductBDO 
        private void TranslateProductDTOToProductBDO(
            Product product,
            Product_BDO product_BDO)
        {
            product_BDO.Product_ID = product.ProductID;
            product_BDO.Product_Name = product.ProductName;
            product_BDO.Product_UPC = product.UPC;
            //product_BDO.Quantity = product.Quantity;
            product_BDO.Product_Price = product.UnitPrice;

        }

    }
}
