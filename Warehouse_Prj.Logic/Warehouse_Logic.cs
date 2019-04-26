///
/// Project: MSCS 6931 SOA Group Project
/// Created: 4/19/2019
/// Description: Business logic class for Warehouse
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
    public class Warehouse_Logic
    {
        Warehouse_DAO warehouse_DAO = new Warehouse_DAO();

        //Returns a Warehouse given an ID
        public Warehouse_BDO Get_Warehouse_By_ID(int warehouse_ID)
        {
            return warehouse_DAO.Get_Warehouse_By_ID(warehouse_ID);
        }

        //Returns all Warehouses in db
        public List<Warehouse_BDO> Get_All_Warehouses()
        {
            return warehouse_DAO.GetWarehouses();
        }

        //Returns a Warehouse given a name
        public Warehouse_BDO Get_Warehouse_By_Name(string warehouse_Name)
        {
            return warehouse_DAO.Get_Warehouse_By_Name(warehouse_Name);
        }

        //Given a Warehouse_BDO, returns true/false depending on the success of the create
        public bool Create_Warehouse(ref Warehouse_BDO warehouse_BDO, ref string message)
        {
            var warehouse = Get_Warehouse_By_Name(warehouse_BDO.Warehouse_Name);
            if (warehouse != null)
            {
                message = "Warehouse exists already!";
                return false;
            }
            else
            {
                return warehouse_DAO.Create_Warehouse(ref warehouse_BDO, ref message);
            }
        }

        //Given a Warehouse_BDO, returns true/false depending on the success of the update
        public bool Update_Warehouse(ref Warehouse_BDO warehouse_BDO, ref string message)
        {
            var warehouse = Get_Warehouse_By_ID(warehouse_BDO.Warehouse_ID);
            if(warehouse == null)
            {
                message = "Warehouse not in database";
                return false;
            }
            else
            {
                message = "Warehouse updated";
                return warehouse_DAO.Update_Warehouse(ref warehouse_BDO, ref message);
            }
        }

        //Given a Warehouse ID, returns true/false depending on the success of the delete
        public bool Delete_Warehouse_By_ID(int warehouse_ID, ref string message)
        {
            return warehouse_DAO.Delete_Warehouse_By_ID(warehouse_ID, ref message);
        }
    }
}
