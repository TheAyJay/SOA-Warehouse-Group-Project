namespace Warehouse_Prj.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Category_ID = c.Int(nullable: false, identity: true),
                        Category_Name = c.String(),
                        Category_Description = c.String(),
                    })
                .PrimaryKey(t => t.Category_ID);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Inventory_ID = c.Int(nullable: false, identity: true),
                        Product_Quantity = c.Int(nullable: false),
                        Products_Product_ID = c.Int(),
                        Warehouse_Warehouse_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Inventory_ID)
                .ForeignKey("dbo.Products", t => t.Products_Product_ID)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Warehouse_ID)
                .Index(t => t.Products_Product_ID)
                .Index(t => t.Warehouse_Warehouse_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Product_ID = c.Int(nullable: false, identity: true),
                        Product_Name = c.String(),
                        Product_UPC = c.Long(nullable: false),
                        Product_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Product_ID)
                .ForeignKey("dbo.Categories", t => t.Category_Category_ID)
                .Index(t => t.Category_Category_ID);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Warehouse_ID = c.Int(nullable: false, identity: true),
                        Warehouse_Name = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                    })
                .PrimaryKey(t => t.Warehouse_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "Warehouse_Warehouse_ID", "dbo.Warehouses");
            DropForeignKey("dbo.Inventories", "Products_Product_ID", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_Category_ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Category_ID" });
            DropIndex("dbo.Inventories", new[] { "Warehouse_Warehouse_ID" });
            DropIndex("dbo.Inventories", new[] { "Products_Product_ID" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.Products");
            DropTable("dbo.Inventories");
            DropTable("dbo.Categories");
        }
    }
}
