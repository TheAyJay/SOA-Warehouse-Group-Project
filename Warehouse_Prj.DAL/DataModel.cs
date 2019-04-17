using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Warehouse_Prj.DAL
{
    class DataModel
    {
        static void Main(string[] args)
        {

            using (var context = new WarehouseContext())
            {
                // Create and save a new Students
                Console.WriteLine("Adding new students");

                var p = new Product
                {
                    Product_ID = 12,
                    Product_Name = "Chips",
                    Product_UPC = 125565,
                    Product_Price = 12.0m


                };

                context.Products.Add(p);
                //context.SaveChanges();
            }
        }
        public class Category
        {
            public int Category_ID { get; set; }
            public string Category_Name { get; set; }
            public string Category_Description { get; set; }

            public virtual ICollection<Product> Products { get; set; }


        }

        public class Product
        {
            public int Product_ID { get; set; }
            public string Product_Name { get; set; }
            public long Product_UPC { get; set; }
            public decimal Product_Price { get; set; }

            public virtual Category Category { get; set; }
        }

        public class Warehouse
        {
            public int Warehouse_ID { get; set; }
            public string Warehouse_Name { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zipcode { get; set; }

            public virtual ICollection<Product> Products { get; set; }

        }

        public class Shipment
        {
            public int Shipment_ID { get; set; }
            public int Product_Quantity { get; set; }
            public string Current_Location { get; set; }
            public DateTime Sent_Timestamp { get; set; }
            public DateTime Received_Timestamp { get; set; }

            public virtual Product Product { get; set; }
            public virtual Warehouse Warehouse { get; set; }

        }

        public class WarehouseContext : DbContext
        {
            public virtual DbSet<Category> Categories { get; set; }
            public virtual DbSet<Product> Products { get; set; }
            public virtual DbSet<Warehouse> Warehouses { get; set; }
            public virtual DbSet<Shipment> Shipments { get; set; }
        }


    }
}
