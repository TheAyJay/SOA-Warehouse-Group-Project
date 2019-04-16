using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Prj.BDO;
using Warehouse_Prj.DAL;


namespace Warehouse_Prj.Logic
{
    public class Product_Logic
    {
        Product product = new Product();

        public void Get_Product_By_Product_ID(int product_ID)
        {
            //return product.GetProduct(product_ID);

            
        }

        //public bool Update_Product(Product_BDO product,  ref string message)
        //{
            //var prod = Get_Product_By_Product_ID(product.Product_ID);
            //if(prod == null)
            //{
                //message = "Product not in database.";
                //return false;
            //}
            //else
            //{
                //message = "Product updated.";
                //return product_DAO.UpdateProduct(product,ref message);
            //}

        //}


    }
}
