///
/// Project: MSCS 6931 SOA Group Project
/// Created: 4/19/2019
/// Description: Data Access Object class for Warehouses
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
    public class Warehouse_DAO
    {
        //Given an ID, fetch Warehouse from Warehouses table
        //Returns a Warehouse_BDO object
        public Warehouse_BDO Get_Warehouse_By_ID(int warehouse_ID)
        {
            //Create Warehouse_BDO object
            Warehouse_BDO warehouse_BDO = null;

            //Create new DTO for Warehouse query result
            DataModel.Warehouse warehouse_DTO_Result = new DataModel.Warehouse();

            //Call Warehouse_Qs.Get_Warehouse_By_ID
            Warehouse_Qs warehouse_Query = new Warehouse_Qs();
            warehouse_DTO_Result = warehouse_Query.Get_Warehouse_By_ID(warehouse_ID);

            //If Warehouse is found, tranlsate to BDO object
            if (warehouse_DTO_Result != null)
            {
                warehouse_BDO.Warehouse_ID = warehouse_DTO_Result.Warehouse_ID;
                warehouse_BDO.Warehouse_Name = warehouse_DTO_Result.Warehouse_Name;
                warehouse_BDO.Street = warehouse_DTO_Result.Street;
                warehouse_BDO.City = warehouse_DTO_Result.City;
            }

            return warehouse_BDO;
        }

        //Given a Warehouse_BDO object, add to Warehouses table
        //Returns a boolean
        public bool Create_Warehouse(ref Warehouse_BDO warehouse_BDO, ref string message)
        {
            var ret = false;

            //Create new DTO object for Warehouse query
            DataModel.Warehouse warehouse_DTO = new DataModel.Warehouse();

            //Translate BDO to DTO for Warehouse_Qs
            warehouse_DTO.Warehouse_ID = warehouse_BDO.Warehouse_ID;
            warehouse_DTO.Warehouse_Name = warehouse_BDO.Warehouse_Name;
            warehouse_DTO.Street = warehouse_BDO.Street;
            warehouse_DTO.City = warehouse_BDO.City;
            warehouse_DTO.State = warehouse_BDO.State;
            warehouse_DTO.Zipcode = warehouse_BDO.Zipcode;

            //Call Warehouse_Qs.Create
            Warehouse_Qs warehouse_Create_Query = new Warehouse_Qs();
            ret = warehouse_Create_Query.Create(warehouse_DTO, ref message);

            return ret;
        }

        //Given a Warehouse_BDO object, update the Warehouses table on Warehouse_ID
        //Returns a boolean
        public bool Update_Warehouse(ref Warehouse_BDO warehouse_BDO, ref string message)
        {
            var ret = false;

            //Create new DTO object for Warehouse query
            DataModel.Warehouse warehouse_DTO = new DataModel.Warehouse();

            //Translate BDO to DTO for Warehouse_Qs
            warehouse_DTO.Warehouse_ID = warehouse_BDO.Warehouse_ID;
            warehouse_DTO.Warehouse_Name = warehouse_BDO.Warehouse_Name;
            warehouse_DTO.Street = warehouse_BDO.Street;
            warehouse_DTO.City = warehouse_BDO.City;
            warehouse_DTO.State = warehouse_BDO.State;
            warehouse_DTO.Zipcode = warehouse_BDO.Zipcode;

            //Call Warehouse_Qs.Update
            Warehouse_Qs warehouse_Update_Query = new Warehouse_Qs();
            ret = warehouse_Update_Query.Update(warehouse_DTO, ref message);

            return ret;
        }

        //Given an ID, delete Warehouse from Warehouses table
        //Returns a boolean
        public bool Delete_Warehouse_By_ID(int warehouse_ID, ref string message)
        {
            var ret = false;

            //Call Warehouse_Qs.Delete_Warehouse_By_ID
            Warehouse_Qs warehouse_Query = new Warehouse_Qs();
            ret = warehouse_Query.Delete_Warehouse_By_ID(warehouse_ID, ref message);

            return ret;
        }
    }
}
