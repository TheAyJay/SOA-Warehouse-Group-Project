using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
                

                var p = new Product
                {
                    Product_ID = 12,
                    Product_Name = "Chips",
                    Product_UPC = 125565,
                    Product_Price = 12.0m


                };

                //context.Products.Add(p);
                //context.SaveChanges();
                //Console.WriteLine("Adding new products");
            }
        }
        public class Category
        {
            [Key]
            public int Category_ID { get; set; }
            public string Category_Name { get; set; }
            public string Category_Description { get; set; }

            public virtual ICollection<Product> Products { get; set; }
            
        }

        public class Product
        {
            [Key]
            public int Product_ID { get; set; }
            public string Product_Name { get; set; }
            public long Product_UPC { get; set; }
            public decimal Product_Price { get; set; }

            public virtual Category Category { get; set; }
        }

        public class Warehouse
        {
            [Key]
            public int Warehouse_ID { get; set; }
            public string Warehouse_Name { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zipcode { get; set; }

            public virtual ICollection<Product> Products { get; set; }

            [NotMapped]
            public virtual ICollection<Warehouse> Warehouses { get; set; }

        }

        public class Inventory
        {
            [Key]
            public int Inventory_ID { get; set; }
            public int Product_Quantity { get; set; }

            public virtual Product Products { get; set; }
            public virtual Warehouse Warehouse { get; set; }

        }

        public class WarehouseContext : DbContext
        {
            public WarehouseContext() : base("WarehouseContext")
            {

            }
            public virtual DbSet<Category> Categories { get; set; }
            public virtual DbSet<Product> Products { get; set; }
            public virtual DbSet<Warehouse> Warehouses { get; set; }
            public virtual DbSet<Inventory> Inventories { get; set; }
        }

  
    }
}
