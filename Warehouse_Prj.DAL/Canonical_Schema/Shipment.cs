using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Warehouse_Prj.DAL
{
    public class Shipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Shipment_ID { get; set; }

        [Column("Product_ID")]
        public int Product_ID { get; set; }

        [Required]
        public int Product_Quantity { get; set; }

        [Column("Warehouse_ID")]
        public int Warehouse_ID { get; set; }

        [MaxLength(500)]
        public string Current_Location { get; set; }

        [Column("Sent_Timestamp")]
        public DateTime Sent_Timestamp { get; set; }

        [Column("Received_Timestamp")]
        public DateTime Received_Timestamp { get; set; }

    }
}
