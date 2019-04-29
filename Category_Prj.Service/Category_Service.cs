using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Warehouse_Prj.BDO;
using Warehouse_Prj.Logic;

namespace Category_Prj.Service
{
    
    public class Category_Service : ICategory
    {
        Category_BDO category_BDO = new Category_BDO();        
        Category_Logic category_Logic = new Category_Logic();
        Category category = new Category();


        public bool Create_Category(Category category)
        {
            Translate_DTO_to_BDO(category, category_BDO);
            
            return category_Logic.Create_Category(category_BDO);
        }

        public List<Category> GetCategories()
        {
            List<Category_BDO> category_BDOs = category_Logic.GetCategory_BDOs();
            List<Category> categories = new List<Category>();            

            foreach (Category_BDO c in category_BDOs)
            {
                Translate_BDO_to_DTO(category, c);
                categories.Add(category);
            }
                

            return categories;
        }

        public Category Get_Category_By_ID(int category_id)
        {
            Category category = new Category();
            category_BDO = category_Logic.Get_Category_By_ID(category_id);

            Translate_BDO_to_DTO(category, category_BDO);

            return category;           
        }

        public bool Update_Category_By_ID(Category category_)
        {
            Translate_DTO_to_BDO(category_, category_BDO);
            return category_Logic.Update_Category_By_ID(category_BDO);
        }

        private void Translate_BDO_to_DTO(Category category, Category_BDO category_BDO)
        {
            category.Category_ID = category_BDO.Category_ID;
            category.Category_Name = category_BDO.Category_Name;
            category.Category_Description = category_BDO.Category_Description;
         
        }

        private void Translate_DTO_to_BDO(Category category, Category_BDO category_BDO)
        {
            category_BDO.Category_ID = category.Category_ID;
            category_BDO.Category_Name = category.Category_Name;
            category_BDO.Category_Description = category.Category_Description;

        }
    }
}
