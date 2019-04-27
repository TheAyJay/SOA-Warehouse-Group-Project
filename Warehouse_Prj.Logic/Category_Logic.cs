///
/// Project: MSCS 6931 SOA Group Project
/// Created: 4/19/2019
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
    public class Category_Logic
    {
        Product_DAO product_DAO = new Product_DAO();

        //Returns a Product given an ID
        public Product_BDO Get_Product_By_ID(int product_ID)
        {
            return product_DAO.Get_Product_By_ID(product_ID);    
        }

        //Returns a Product given a UPC code
        public Product_BDO Get_Product_By_UPC(long product_UPC)
        {
            return product_DAO.Get_Product_By_UPC(product_UPC);
        }

        //Given a Product_BDO, returns true/false depending on the success of the update
        public bool Update_Product_By_ID(ref Product_BDO product_BDO)
        {
            var product = Get_Product_By_ID(product_BDO.Product_ID);
            if(product == null)
            {
                
                return false;
            }
            else
            {
                
                return product_DAO.Update_Product_By_ID(ref product_BDO);
            }
        }

        //Given a Product_BDO, returns true/false depending on the success of the create
        public bool Create_Product(ref Product_BDO product_BDO, ref string message)
        {
            var product = Get_Product_By_UPC(product_BDO.Product_UPC);
            if(product != null)
            {
                message = "Product already exists!";
                return false;
            }
            else
            {
                message = "Product created";
                return product_DAO.Create_Product(ref product_BDO, ref message);
            }
        }

        //Given a Product ID, returns true/false depending on the success of the delete
        public bool Delete_Product_By_ID(int product_ID, ref string message)
        {
            return product_DAO.Delete_Product_By_ID(product_ID, ref message);
        }

        //Given a Product UPC, returns true/false depending on the success of the delete
        public bool Delete_Product_By_UPC(long product_UPC, ref string message)
        {
            return product_DAO.Delete_Product_By_UPC(product_UPC, ref message);
        }
    }
}
