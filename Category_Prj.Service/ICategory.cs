using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Category_Prj.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICategory
    {
        [OperationContract]
        Category Get_Category_By_ID(int category_id);

        [OperationContract]
        bool Update_Category_By_ID(Category category_);

        [OperationContract]
        bool Create_Category(Category category);
        
    }

    [DataContract]
    public class Category
    {
       
        [DataMember]
        public int Category_ID{ get; set; }

        [DataMember]
        public string Category_Name{ get; set; }

        [DataMember]
        public string Category_Description { get; set; }

    }
}
