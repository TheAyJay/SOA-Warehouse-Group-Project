using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Warehouse_Prj.DAL
{
    /// <summary>
    /// MSCS 6931 Topics in Math Sts, & Comp Sci
    /// Service Oriented Architecture (SOA)
    /// Spring 2019
    /// Omar Waller, Andrew Jacobson
    /// 
    /// Description: This class contains the data model for the Warehouse context. This is a code first
    /// implementation.
    /// </summary>
    public class DataModel
    {
        static void Main(string[] args)
        {
            
            
        }
        public class Category
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Category_ID { get; set; }
            public string Category_Name { get; set; }
            public string Category_Description { get; set; } 
        }

        public class Product
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Product_ID { get; set; }
            public string Product_Name { get; set; }
            public long Product_UPC { get; set; }
            public decimal Product_Price { get; set; }
                        
            [ForeignKey("ProductCategory")]
            public int CategoryRefID { get; set; }
            public virtual Category ProductCategory { get; set; }
        }

        public class Warehouse
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Warehouse_ID { get; set; }
            
            public string Warehouse_Name { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zipcode { get; set; }


            [NotMapped]
            public virtual ICollection<Warehouse> Warehouses { get; set; }
        }

        public class Inventory
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Inventory_ID { get; set; }

            public int Product_Quantity { get; set; }

            [ForeignKey("ProductID")]
            public int Product_ID { get; set; }
            public virtual Product ProductID { get; set; }

            [ForeignKey("WarehouseID")]
            public int Warehouse_ID { get; set; }
            public virtual Warehouse WarehouseID { get; set; }
        }

        public class WarehouseContext : DbContext
        {
            public WarehouseContext() : base("WarehouseContext")
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<WarehouseContext, Warehouse_Prj.DAL.Migrations.Configuration>());
            }
            public virtual DbSet<Category> Categories { get; set; }
            public virtual DbSet<Product> Products { get; set; }
            public virtual DbSet<Warehouse> Warehouses { get; set; }
            public virtual DbSet<Inventory> Inventories { get; set; }
        }

  
    }
}
