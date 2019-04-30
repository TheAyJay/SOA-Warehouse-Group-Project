using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Category_Prj.Service
{
    /// <summary>
    /// MSCS 6931 Topics in Math Sts, & Comp Sci
    /// Service Oriented Architecture (SOA)
    /// Spring 2019
    /// Omar Waller
    /// 
    /// Description: Interface for Category service. This file contains Operation Contract and Data Contract.
    /// </summary>

    [ServiceContract]
    public interface ICategory
    {
        [OperationContract]
        Category Get_Category_By_ID(int category_id);

        [OperationContract]
        bool Update_Category_By_ID(Category category_);

        [OperationContract]
        bool Create_Category(Category category);

        [OperationContract]
        List<Category> GetCategories();
        
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
