using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Warehouse_Prj.BDO
{
    public class Shipment_BDO
    {
        public int Shipment_ID { get; set; }        
        public int Product_ID { get; set; }
        public int Product_Quantity { get; set; }
        public int Warehouse_ID { get; set; }
        public string Current_Location { get; set; }
        public DateTime Sent_Timestamp { get; set; }
        public DateTime Received_Timestamp { get; set; }

    }
}
