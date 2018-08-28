namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillingInfoToCustomerFleshOutOrderAndDeleteTransaction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Transaction_ID", "dbo.Transaction");
            DropIndex("dbo.Product", new[] { "Transaction_ID" });
            AddColumn("dbo.Customers", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CustomerPhone", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "CustomerEmail", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingFirstName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingLastName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingAddress1", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingAddress2", c => c.String());
            AddColumn("dbo.Customers", "ShippingCity", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingState", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ShippingPostalCode", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingFirstName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingLastName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingAddress1", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingAddress2", c => c.String());
            AddColumn("dbo.Customers", "BillingCity", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingState", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "BillingPostalCode", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Product", "CategoryId");
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "TransactionId");
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "Address1");
            DropColumn("dbo.Customers", "Address2");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "PostalCode");
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Product", "Transaction_ID");
            DropTable("dbo.Transaction");
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
            
            AddColumn("dbo.Product", "Transaction_ID", c => c.Int());
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "PostalCode", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Address2", c => c.String());
            AddColumn("dbo.Customers", "Address1", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "TransactionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropColumn("dbo.Orders", "IsPaidFor");
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Customers", "BillingPostalCode");
            DropColumn("dbo.Customers", "BillingState");
            DropColumn("dbo.Customers", "BillingCity");
            DropColumn("dbo.Customers", "BillingAddress2");
            DropColumn("dbo.Customers", "BillingAddress1");
            DropColumn("dbo.Customers", "BillingLastName");
            DropColumn("dbo.Customers", "BillingFirstName");
            DropColumn("dbo.Customers", "ShippingPostalCode");
            DropColumn("dbo.Customers", "ShippingState");
            DropColumn("dbo.Customers", "ShippingCity");
            DropColumn("dbo.Customers", "ShippingAddress2");
            DropColumn("dbo.Customers", "ShippingAddress1");
            DropColumn("dbo.Customers", "ShippingLastName");
            DropColumn("dbo.Customers", "ShippingFirstName");
            DropColumn("dbo.Customers", "CustomerEmail");
            DropColumn("dbo.Customers", "CustomerPhone");
            DropColumn("dbo.Customers", "OrderId");
            CreateIndex("dbo.Product", "Transaction_ID");
            AddForeignKey("dbo.Product", "Transaction_ID", "dbo.Transaction", "ID");
        }
    }
}
