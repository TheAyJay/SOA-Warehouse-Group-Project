using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Warehouse_Prj.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProduct
    {

        public Product GetProduct(int id)
        {
            var product = new Product();
            product.ProductID = id;
            product.UPC = "fake UPC from the service layer";
            product.ProductName = "fake product name from service layer";
            product.Quantity = "fake quantity";
            product.UnitPrice = 50.0m;
            return product;
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
            else if (string.IsNullOrEmpty(product.UPC))
            {
                message = "UPC cannot be empty";
                result = false;
            }
            // Product name connot be empty
            else if (string.IsNullOrEmpty(product.ProductName))
            {
                message = "Product name connot be empty";
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
                message = "Product updated successfully";
                result = true;
            }

            return result;
        }
    }
}
