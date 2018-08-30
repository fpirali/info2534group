namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Product", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Product", new[] { "PetId" });
            DropIndex("dbo.Product", new[] { "Order_Id" });
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
            
            AddColumn("dbo.Customers", "TransactionId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Address1", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Address2", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "PostalCode", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Product", "Transaction_ID", c => c.Int());
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.Product", "Transaction_ID");
            AddForeignKey("dbo.Product", "Transaction_ID", "dbo.Transaction", "ID");
            DropColumn("dbo.Customers", "OrderId");
            DropColumn("dbo.Customers", "CustomerPhone");
            DropColumn("dbo.Customers", "CustomerEmail");
            DropColumn("dbo.Customers", "ShippingFirstName");
            DropColumn("dbo.Customers", "ShippingLastName");
            DropColumn("dbo.Customers", "ShippingAddress1");
            DropColumn("dbo.Customers", "ShippingAddress2");
            DropColumn("dbo.Customers", "ShippingCity");
            DropColumn("dbo.Customers", "ShippingState");
            DropColumn("dbo.Customers", "ShippingPostalCode");
            DropColumn("dbo.Customers", "CardNumber");
            DropColumn("dbo.Customers", "ExpirationMonth");
            DropColumn("dbo.Customers", "ExpirationYear");
            DropColumn("dbo.Customers", "CardPin");
            DropColumn("dbo.Customers", "BillingFirstName");
            DropColumn("dbo.Customers", "BillingLastName");
            DropColumn("dbo.Customers", "BillingAddress1");
            DropColumn("dbo.Customers", "BillingAddress2");
            DropColumn("dbo.Customers", "BillingCity");
            DropColumn("dbo.Customers", "BillingState");
            DropColumn("dbo.Customers", "BillingPostalCode");
            DropColumn("dbo.Orders", "ProductId");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "ItemPrice");
            DropColumn("dbo.Orders", "OrderTotal");
            DropColumn("dbo.Product", "Markdown");
            DropColumn("dbo.Product", "PetId");
            DropColumn("dbo.Product", "Order_Id");
            DropTable("dbo.Pets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Product", "Order_Id", c => c.Int());
            AddColumn("dbo.Product", "PetId", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Markdown", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OrderTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "ItemPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "BillingPostalCode", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingState", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingCity", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingAddress2", c => c.String());
            AddColumn("dbo.Customers", "BillingAddress1", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingLastName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingFirstName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "CardPin", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.Customers", "ExpirationYear", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.Customers", "ExpirationMonth", c => c.String(nullable: false, maxLength: 2));
            AddColumn("dbo.Customers", "CardNumber", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Customers", "ShippingPostalCode", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingState", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingCity", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingAddress2", c => c.String());
            AddColumn("dbo.Customers", "ShippingAddress1", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingLastName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingFirstName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "CustomerEmail", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "CustomerPhone", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "OrderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Product", "Transaction_ID", "dbo.Transaction");
            DropIndex("dbo.Product", new[] { "Transaction_ID" });
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Product", "Transaction_ID");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Customers", "PostalCode");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Address2");
            DropColumn("dbo.Customers", "Address1");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "TransactionId");
            DropTable("dbo.Transaction");
            CreateIndex("dbo.Product", "Order_Id");
            CreateIndex("dbo.Product", "PetId");
            AddForeignKey("dbo.Product", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Product", "PetId", "dbo.Pets", "Id", cascadeDelete: true);
        }
    }
}
