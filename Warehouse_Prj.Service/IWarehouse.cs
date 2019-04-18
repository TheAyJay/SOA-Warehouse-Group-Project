using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Warehouse_Prj.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWarehouse
    {
        [OperationContract]
        Warehouse GetWarehouse(int id);

        [OperationContract]
        bool UpdateWarehouse(Warehouse warehouse, ref string message);

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Warehouse_Prj.Service.ContractType".
    [DataContract]
    public class Warehouse
    {
        [DataMember]
        public int WarehouseID { get; set; }
        [DataMember]
        public string WarehouseName { get; set; }
        [DataMember]
        public string WarehouseAddress { get; set; }

    }


}
