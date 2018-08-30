namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillingAddressShippingAddressPaymentAndPetsTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Transaction_ID", "dbo.Transaction");
            DropIndex("dbo.Product", new[] { "Transaction_ID" });
            CreateTable(
                "dbo.BillingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillingAddress1 = c.String(nullable: false),
                        BillingAddress2 = c.String(),
                        BillingCity = c.String(nullable: false),
                        BillingState = c.String(nullable: false),
                        BillingPostalCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentInformation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false, maxLength: 20),
                        ExpirationMonth = c.String(nullable: false, maxLength: 2),
                        ExpirationYear = c.String(nullable: false, maxLength: 4),
                        CardPin = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShippingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShippingAddress1 = c.String(nullable: false),
                        ShippingAddress2 = c.String(),
                        ShippingCity = c.String(nullable: false),
                        ShippingState = c.String(nullable: false),
                        ShippingPostalCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CustomerPhone", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "CustomerEmail", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "PaymentId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "BillingAddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "ShippingAddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "BillingAddressIsDifferent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "PaymentInformation_Id", c => c.Int());
            AddColumn("dbo.Orders", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "ItemPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OrderTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Product", "Markdown", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Product", "PetId", c => c.Int(nullable: true));
            AddColumn("dbo.Product", "Order_Id", c => c.Int());
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.Customers", "BillingAddressId");
            CreateIndex("dbo.Customers", "ShippingAddressId");
            CreateIndex("dbo.Customers", "PaymentInformation_Id");
            CreateIndex("dbo.Product", "PetId");
            CreateIndex("dbo.Product", "Order_Id");
            AddForeignKey("dbo.Customers", "BillingAddressId", "dbo.BillingAddresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "PetId", "dbo.Pets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Customers", "PaymentInformation_Id", "dbo.PaymentInformation", "Id");
            AddForeignKey("dbo.Customers", "ShippingAddressId", "dbo.ShippingAddresses", "Id", cascadeDelete: true);
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
            DropForeignKey("dbo.Customers", "ShippingAddressId", "dbo.ShippingAddresses");
            DropForeignKey("dbo.Customers", "PaymentInformation_Id", "dbo.PaymentInformation");
            DropForeignKey("dbo.Product", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Product", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Customers", "BillingAddressId", "dbo.BillingAddresses");
            DropIndex("dbo.Product", new[] { "Order_Id" });
            DropIndex("dbo.Product", new[] { "PetId" });
            DropIndex("dbo.Customers", new[] { "PaymentInformation_Id" });
            DropIndex("dbo.Customers", new[] { "ShippingAddressId" });
            DropIndex("dbo.Customers", new[] { "BillingAddressId" });
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Product", "Order_Id");
            DropColumn("dbo.Product", "PetId");
            DropColumn("dbo.Product", "Markdown");
            DropColumn("dbo.Orders", "OrderTotal");
            DropColumn("dbo.Orders", "ItemPrice");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "ProductId");
            DropColumn("dbo.Customers", "PaymentInformation_Id");
            DropColumn("dbo.Customers", "BillingAddressIsDifferent");
            DropColumn("dbo.Customers", "ShippingAddressId");
            DropColumn("dbo.Customers", "BillingAddressId");
            DropColumn("dbo.Customers", "PaymentId");
            DropColumn("dbo.Customers", "CustomerEmail");
            DropColumn("dbo.Customers", "CustomerPhone");
            DropColumn("dbo.Customers", "OrderId");
            DropTable("dbo.ShippingAddresses");
            DropTable("dbo.PaymentInformation");
            DropTable("dbo.Pets");
            DropTable("dbo.BillingAddresses");
            CreateIndex("dbo.Product", "Transaction_ID");
            AddForeignKey("dbo.Product", "Transaction_ID", "dbo.Transaction", "ID");
        }
    }
}
