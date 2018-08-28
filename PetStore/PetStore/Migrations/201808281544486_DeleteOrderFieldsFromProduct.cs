namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteOrderFieldsFromProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "OrderId", "dbo.Orders");
            DropIndex("dbo.Product", new[] { "OrderId" });
            RenameColumn(table: "dbo.Product", name: "OrderId", newName: "Order_Id");
            AlterColumn("dbo.Product", "Order_Id", c => c.Int());
            CreateIndex("dbo.Product", "Order_Id");
            AddForeignKey("dbo.Product", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Product", new[] { "Order_Id" });
            AlterColumn("dbo.Product", "Order_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Product", name: "Order_Id", newName: "OrderId");
            CreateIndex("dbo.Product", "OrderId");
            AddForeignKey("dbo.Product", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
