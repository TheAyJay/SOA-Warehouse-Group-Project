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
    public class DataModel
    {
        static void Main(string[] args)
        {

            using (var context = new WarehouseContext())
            {
                // Create and save a new Students
                

                var w = new Warehouse
                {
                    Warehouse_ID = 1,
                    Warehouse_Name = "GA30294",
                    Street = "23 Street",
                    City = "Ellenwood",
                    State = "GA",
                    Zipcode = "30294"


                };

                //context.Warehouses.Add(w);
                //context.SaveChanges();
                //Console.WriteLine("Adding new products");
            }
        }
        public class Category
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Category_ID { get; set; }
            public string Category_Name { get; set; }
            public string Category_Description { get; set; } 

            [ForeignKey("CategoryRefID")]
            public ICollection<Product> Products { get; set; }
        }

        public class Product
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Product_ID { get; set; }
            public string Product_Name { get; set; }
            public long Product_UPC { get; set; }
            public decimal Product_Price { get; set; }

            //[ForeignKey("Category")]
            public int CategoryRefID { get; set; }
            public Category ProductCategory { get; set; }
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
            public virtual Product Products { get; set; }
            public virtual Warehouse Warehouse { get; set; }

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
