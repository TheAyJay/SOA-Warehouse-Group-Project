///
/// Project: MSCS 6931 SOA Group Project
/// Created: 4/19/2019
/// Programmer: Andrew Jacobson
/// Description: Data Access Object class for the Product object
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Prj.BDO;
using Warehouse_Prj.DAL.CRUD;

namespace Warehouse_Prj.DAL
{
    public class Product_DAO
    {
        public Product_BDO Get_Product_By_ID(int product_ID, ref string message)
        {
            //Create Product_BDO object
            Product_BDO product_BDO = null;

            //Create new DTO object for Product query result
            DataModel.Product product_DTO_Result = new DataModel.Product();

            //Call Product_Qs.Get_Product_By_ID
            Product_Qs product_Query = new Product_Qs();
            product_DTO_Result = product_Query.Get_Product_By_ID(product_ID, ref message);

            if(product_DTO_Result != null)
            {
                product_BDO.Product_ID = product_DTO_Result.Product_ID;
                product_BDO.Product_Name = product_DTO_Result.Product_Name;
                product_BDO.Product_Price = product_DTO_Result.Product_Price;
                product_BDO.Product_UPC = product_DTO_Result.Product_UPC;
            }

            return product_BDO;
        }

        public bool Update_Product(ref Product_BDO product_BDO, ref string message)
        { 
            var ret = false;

            //Create new DTO object for Product query
            DataModel.Product product_DTO = new DataModel.Product();

            //Translate BDO to DTO for Product_Qs
            product_DTO.Product_ID = product_BDO.Product_ID;
            product_DTO.Product_Name = product_BDO.Product_Name;
            product_DTO.Product_UPC = product_BDO.Product_UPC;

            //Call Product_Qs.Update
            Product_Qs product_Update_Query = new Product_Qs();
            ret = product_Update_Query.Update(product_DTO, ref message);

            return ret;
        }
    }
}
