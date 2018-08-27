namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageLocationAndSaleFlagToProductModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Orders", name: "Customer_Id", newName: "CustomerId");
            AddColumn("dbo.Product", "ImageFilePath", c => c.String(nullable: false));
            AddColumn("dbo.Product", "OnSale", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            AlterColumn("dbo.Orders", "CustomerId", c => c.Int());
            DropColumn("dbo.Product", "OnSale");
            DropColumn("dbo.Product", "ImageFilePath");
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
