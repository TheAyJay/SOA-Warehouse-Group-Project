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
    public class Category_Logic
    {
        
        Category_Qs category_query = new Category_Qs();
        DataModel.Category category_dto = new DataModel.Category();
        Category_BDO category_BDO = new Category_BDO();

        public List<Category_BDO> GetCategory_BDOs()
        {
            List<Category_BDO> category_BDOs = new List<Category_BDO>();
            List<DataModel.Category> category_dtos = new List<DataModel.Category>();

            category_dtos = category_query.Get_All_Categories();

            foreach(DataModel.Category c in category_dtos)
            {
                Translate_DTO_to_BDO(category_BDO, c);
                category_BDOs.Add(category_BDO);                
            }

            return category_BDOs.ToList();

        }

        //Returns a Category given an ID
        public Category_BDO Get_Category_By_ID(int category_ID)
        {
            category_dto = category_query.Get_Category_By_ID(category_ID);

            Translate_DTO_to_BDO(category_BDO, category_dto);

            return category_BDO;
        }


        //Given a Category BDO, returns true/false depending on the success of the update
        public bool Update_Category_By_ID(Category_BDO category_)
        {
            var category = Get_Category_By_ID(category_.Category_ID);
            if(category == null)
            {                
                return false;
            }
            else
            {
                Translate_BDO_to_DTO(category_, category_dto);
                category_query.Update_Category_By_ID(category_dto);
                return category_query.Update_Category_By_ID(category_dto);
            }
        }

        //Given a Category BDO, returns true/false depending on the success of the create
        public bool Create_Category(Category_BDO category_BDO)
        {
            Translate_BDO_to_DTO(category_BDO, category_dto);
            return category_query.Create(category_dto);
        }

        //Given a Category ID, returns true/false depending on the success of the delete
        public bool Delete_Category_By_ID(int category_id)
        {
            return category_query.Delete_Category_By_ID(category_id);
        }

        //Translate BDO to data model object
        private void Translate_BDO_to_DTO(Category_BDO category_BDO, DataModel.Category category_dto)
        {
            category_dto.Category_ID = category_BDO.Category_ID;
            category_dto.Category_Name = category_BDO.Category_Name;
            category_dto.Category_Description = category_BDO.Category_Description;
        }
        
        //Translate data model object to BDO.
        private void Translate_DTO_to_BDO(Category_BDO category_BDO, DataModel.Category category_dto)
        {
            category_BDO.Category_ID = category_dto.Category_ID;
            category_BDO.Category_Name = category_dto.Category_Name;
            category_BDO.Category_Description = category_dto.Category_Description;
        }
    }
}
