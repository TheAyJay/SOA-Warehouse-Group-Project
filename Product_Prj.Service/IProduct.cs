using Category_Prj.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Product_Prj.Service
{
    /// <summary>
    /// MSCS 6931 Topics in Math Sts, & Comp Sci
    /// Service Oriented Architecture (SOA)
    /// Spring 2019
    /// Eyad Aldawod, Omar Waller, Andrew Jacobson
    /// 
    /// Description: Interface for Product service. This file contains Operation Contract and Data Contract.
    /// </summary>
    
    [ServiceContract]
    public interface IProduct
    {

        [OperationContract]
        Product GetProductByID(int id);

        [OperationContract]
        Product GetProductByUPC(long upc);

        [OperationContract]
        bool UpdateProductByID(Product product);

        [OperationContract]
        bool Create_Product(Product product, ref string message);

    }

 
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public long UPC { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public int CategoryRefID { get; set; }
    }
}
