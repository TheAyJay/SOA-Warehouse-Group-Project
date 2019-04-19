///
/// Project: MSCS 6931 SOA Group Project
/// Created: 4/19/2019
/// Programmer: Andrew Jacobson
/// Description: Business logic class for Products
///
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
        Product_DAO product_DAO = new Product_DAO();

        public Product_BDO Get_Product_By_ID(int product_ID, ref string message)
        {
            return product_DAO.Get_Product_By_ID(product_ID, ref message);    
        }

        public bool Update_Product(ref Product_BDO product_BDO,  ref string message)
        {
            var product = Get_Product_By_ID(product_BDO.Product_ID, ref message);
            if(product == null)
            {
                message = "Product not in database";
                return false;
            }
            else
            {
                message = "Product updated";
                return product_DAO.Update_Product(ref product_BDO, ref message);
            }
        }
    }
}
