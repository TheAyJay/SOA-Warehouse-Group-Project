using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Warehouse_Prj.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WarehouseService : IWarehouse
    {
        public Warehouse GetWarehouse(int id)
        {
            // TODO: call business logic to retrieve warehouse
            var warehouse = new Warehouse();
            warehouse.WarehouseID = id;
            warehouse.WarehouseName = "fake warehouse name from service layer";
            warehouse.WarehouseAddressStreet = "fake one from service layer";
            warehouse.WarehouseAddressCity = "fake one from service layer";
            warehouse.WarehouseAddressState = "fake one from service layer";
            warehouse.WarehouseAddressZipcode = "fake one from service layer";
            return warehouse;
        }


        public bool UpdateWarehouse(Warehouse warehouse, ref string message)
        {
            var result = true;

            // Warehouse name cannot be empty
            if (string.IsNullOrEmpty(warehouse.WarehouseName))
            {
                message = "Warehouse name cannot be empty";
                result = false;
            }
            else if (string.IsNullOrEmpty(warehouse.WarehouseAddressStreet))
            {
                message = "Warehouse street address cannot be empty";
                result = false;
            }

            else if (string.IsNullOrEmpty(warehouse.WarehouseAddressCity))
            {
                message = "Warehouse city address cannot be empty";
                result = false;
            }

            else if (string.IsNullOrEmpty(warehouse.WarehouseAddressState))
            {
                message = "Warehouse state address cannot be empty";
                result = false;
            }

            else if (string.IsNullOrEmpty(warehouse.WarehouseAddressZipcode))
            {
                message = "Warehouse Zipcode cannot be empty";
                result = false;
            }

            return result;
        }

    }
}
