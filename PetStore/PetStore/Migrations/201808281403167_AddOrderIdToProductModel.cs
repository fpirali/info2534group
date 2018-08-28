namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderIdToProductModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Product", new[] { "Order_Id" });
            RenameColumn(table: "dbo.Product", name: "Order_Id", newName: "OrderId");
            AlterColumn("dbo.Product", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "OrderId");
            AddForeignKey("dbo.Product", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "OrderId", "dbo.Orders");
            DropIndex("dbo.Product", new[] { "OrderId" });
            AlterColumn("dbo.Product", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.Product", name: "OrderId", newName: "Order_Id");
            CreateIndex("dbo.Product", "Order_Id");
            AddForeignKey("dbo.Product", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
