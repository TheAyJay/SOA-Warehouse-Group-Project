namespace Warehouse_Prj.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed_FKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Inventories", "Products_Product_ID", "dbo.Products");
            DropForeignKey("dbo.Inventories", "Warehouse_Warehouse_ID", "dbo.Warehouses");
            DropIndex("dbo.Inventories", new[] { "Products_Product_ID" });
            DropIndex("dbo.Inventories", new[] { "Warehouse_Warehouse_ID" });
            DropIndex("dbo.Products", new[] { "Category_Category_ID" });
            RenameColumn(table: "dbo.Products", name: "Category_Category_ID", newName: "CategoryRefID");
            RenameColumn(table: "dbo.Inventories", name: "Products_Product_ID", newName: "Product_ID");
            RenameColumn(table: "dbo.Inventories", name: "Warehouse_Warehouse_ID", newName: "Warehouse_ID");
            AlterColumn("dbo.Inventories", "Product_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventories", "Warehouse_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CategoryRefID", c => c.Int(nullable: false));
            CreateIndex("dbo.Inventories", "Product_ID");
            CreateIndex("dbo.Inventories", "Warehouse_ID");
            CreateIndex("dbo.Products", "CategoryRefID");
            AddForeignKey("dbo.Products", "CategoryRefID", "dbo.Categories", "Category_ID", cascadeDelete: true);
            AddForeignKey("dbo.Inventories", "Product_ID", "dbo.Products", "Product_ID", cascadeDelete: true);
            AddForeignKey("dbo.Inventories", "Warehouse_ID", "dbo.Warehouses", "Warehouse_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "Warehouse_ID", "dbo.Warehouses");
            DropForeignKey("dbo.Inventories", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryRefID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryRefID" });
            DropIndex("dbo.Inventories", new[] { "Warehouse_ID" });
            DropIndex("dbo.Inventories", new[] { "Product_ID" });
            AlterColumn("dbo.Products", "CategoryRefID", c => c.Int());
            AlterColumn("dbo.Inventories", "Warehouse_ID", c => c.Int());
            AlterColumn("dbo.Inventories", "Product_ID", c => c.Int());
            RenameColumn(table: "dbo.Inventories", name: "Warehouse_ID", newName: "Warehouse_Warehouse_ID");
            RenameColumn(table: "dbo.Inventories", name: "Product_ID", newName: "Products_Product_ID");
            RenameColumn(table: "dbo.Products", name: "CategoryRefID", newName: "Category_Category_ID");
            CreateIndex("dbo.Products", "Category_Category_ID");
            CreateIndex("dbo.Inventories", "Warehouse_Warehouse_ID");
            CreateIndex("dbo.Inventories", "Products_Product_ID");
            AddForeignKey("dbo.Inventories", "Warehouse_Warehouse_ID", "dbo.Warehouses", "Warehouse_ID");
            AddForeignKey("dbo.Inventories", "Products_Product_ID", "dbo.Products", "Product_ID");
            AddForeignKey("dbo.Products", "Category_Category_ID", "dbo.Categories", "Category_ID");
        }
    }
}
