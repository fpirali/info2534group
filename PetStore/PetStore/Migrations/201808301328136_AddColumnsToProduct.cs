namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "Transaction_ID", "dbo.Transaction");
            DropIndex("dbo.Images", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "Transaction_ID" });
            AddColumn("dbo.Product", "ImageFilePath", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageID);
            
            AddColumn("dbo.Product", "Transaction_ID", c => c.Int());
            DropForeignKey("dbo.Product", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Product", "PetId", "dbo.Pets");
            DropIndex("dbo.Product", new[] { "Order_Id" });
            DropIndex("dbo.Product", new[] { "PetId" });
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Product", "Order_Id");
            DropColumn("dbo.Product", "PetId");
            DropColumn("dbo.Product", "Markdown");
            DropColumn("dbo.Product", "ImageFilePath");
            CreateIndex("dbo.Product", "Transaction_ID");
            CreateIndex("dbo.Images", "ProductID");
            AddForeignKey("dbo.Product", "Transaction_ID", "dbo.Transaction", "ID");
            AddForeignKey("dbo.Images", "ProductID", "dbo.Product", "Id", cascadeDelete: true);
        }
    }
}
