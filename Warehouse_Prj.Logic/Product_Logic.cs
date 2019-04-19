﻿///
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

        //Returns a Product given an ID
        public Product_BDO Get_Product_By_ID(int product_ID, ref string message)
        {
            return product_DAO.Get_Product_By_ID(product_ID, ref message);    
        }

        //Returns a Product given a UPC code
        public Product_BDO Get_Product_By_UPC(long product_UPC, ref string message)
        {
            return product_DAO.Get_Product_By_UPC(product_UPC, ref message);
        }

        //Given a Product BDO, returns true/false depending on the success of the update
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

        //Given a Product BDO, returns true/false depending on the success of the create
        public bool Create_Product(ref Product_BDO product_BDO, ref string message)
        {
            return product_DAO.Create_Product(ref product_BDO, ref message);
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
