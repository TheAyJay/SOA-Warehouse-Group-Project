using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse_Prj.DAL
{
    public class Warehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Warehouse_ID { get; set; }

        [MaxLength(500)]
        public string Warehouse_Name { get; set; }

        [MaxLength(500)]
        public string Street { get; set; }

        [MaxLength(500)]
        public string City { get; set; }

        [MaxLength(500)]
        public string State { get; set; }

        [MaxLength(500)]
        public string Zipcode { get; set; }

    }
}
