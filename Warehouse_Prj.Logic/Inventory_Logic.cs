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
using Warehouse_Prj.DAL.CRUD;

namespace Warehouse_Prj.Logic
{
    public class Inventory_Logic
    {
        
        Inventory_Qs inventory_query = new Inventory_Qs();
        DataModel.Inventory inventory_dto = new DataModel.Inventory();
        Inventory_BDO inventory_BDO = new Inventory_BDO();

        public List<Inventory_BDO> GetInventory_BDOs()
        {
            List<Inventory_BDO> inventory_BDOs = new List<Inventory_BDO>();
            List<DataModel.Inventory> inventory_dtos = new List<DataModel.Inventory>();

            inventory_dtos = inventory_query.Get_All_Inventories();

            foreach(DataModel.Inventory c in inventory_dtos)
            {
                Inventory_BDO inventory_BDO_ = new Inventory_BDO();
                Translate_DTO_to_BDO(inventory_BDO_, c);
                inventory_BDOs.Add(inventory_BDO_);                
            }

            return inventory_BDOs;

        }

        //Returns a Inventory given an ID
        public Inventory_BDO Get_Inventory_By_ID(int inventory_ID)
        {
            inventory_dto = inventory_query.Get_Inventory_By_ID(inventory_ID);

            Translate_DTO_to_BDO(inventory_BDO, inventory_dto);

            return inventory_BDO;
        }


        //Given a Inventory BDO, returns true/false depending on the success of the update
        public bool Update_Inventory_By_ID(Inventory_BDO inventory_)
        {
            var inventory = Get_Inventory_By_ID(inventory_.Inventory_ID);
            if(inventory == null)
            {                
                return false;
            }
            else
            {
                Translate_BDO_to_DTO(inventory_, inventory_dto);
                inventory_query.Update_Inventory_By_ID(inventory_dto);
                return inventory_query.Update_Inventory_By_ID(inventory_dto);
            }
        }

        //Given a Inventory BDO, returns true/false depending on the success of the create
        public bool Create_Inventory(Inventory_BDO inventory_BDO)
        {
            Translate_BDO_to_DTO(inventory_BDO, inventory_dto);
            return inventory_query.Create(inventory_dto);
        }

        //Given a Inventory ID, returns true/false depending on the success of the delete
        public bool Delete_Inventory_By_ID(int inventory_id)
        {
            return inventory_query.Delete_Inventory_By_ID(inventory_id);
        }

        //Translate BDO to data model object
        private void Translate_BDO_to_DTO(Inventory_BDO inventory_BDO, DataModel.Inventory inventory_dto)
        {
            inventory_dto.Inventory_ID = inventory_BDO.ID;
            inventory_dto.Product_ID = inventory_BDO.Products_ID;
            inventory_dto.Product_Quantity = inventory_BDO.Quantity;
            inventory_dto.Warehouse_ID = inventory_BDO.Warehouse_ID;
        }
        
        //Translate data model object to BDO.
        private void Translate_DTO_to_BDO(Inventory_BDO inventory_BDO, DataModel.Inventory inventory_dto)
        {
            inventory_BDO.ID = inventory_dto.Inventory_ID;
            inventory_BDO.Products_ID = inventory_dto.Product_ID;
            inventory_BDO.Quantity = inventory_dto.Product_Quantity;
            inventory_BDO.Warehouse_ID = inventory_dto.Warehouse_ID;
        }
    }
}
