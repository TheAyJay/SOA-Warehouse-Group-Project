using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Prj.DAL
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_ID { get; set; }

        [MaxLength(500)]
        public string Product_Name { get; set; }

        [MaxLength(500)]
        public string Product_UPC { get; set; }

        [Required]
        public decimal Product_Price { get; set; }

        [MaxLength(500)]
        public string Category_Name { get; set; }


    }
}
