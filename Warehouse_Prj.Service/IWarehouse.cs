using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Warehouse_Prj.Service
{
    /// <summary>
    /// MSCS 6931 Topics in Math Sts, & Comp Sci
    /// Service Oriented Architecture (SOA)
    /// Spring 2019
    /// Eyad Aldawod, Omar Waller, Andrew Jacobson
    /// 
    /// Description: Interface for Warehouse service. This file contains Operation Contract and Data Contract.
    /// </summary>
    [ServiceContract]
    public interface IWarehouse
    {
        [OperationContract]
        Warehouse GetWarehouse(int id);

        [OperationContract]
        Warehouse GetWarehouseByName(string warehouse_Name);

        [OperationContract]
        List<Warehouse> GetAllWarehouses();

        [OperationContract]
        bool UpdateWarehouse(Warehouse warehouse, ref string message);

        [OperationContract]
        bool CreateWarehouse(Warehouse warehouse, ref string message);

    }

    [DataContract]
    public class Warehouse
    {
        [DataMember]
        public int WarehouseID { get; set; }
        [DataMember]
        public string WarehouseName { get; set; }
        [DataMember]
        public string WarehouseAddressStreet { get; set; }

        [DataMember]
        public string WarehouseAddressCity { get; set; }

        [DataMember]
        public string WarehouseAddressState { get; set; }

        [DataMember]
        public string WarehouseAddressZipcode { get; set; }


    }


}
