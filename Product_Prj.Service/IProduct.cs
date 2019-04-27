using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Product_Prj.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
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

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Warehouse_Prj.Service.ContractType".

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
        public string CategoryID { get; set; }
    }
}
