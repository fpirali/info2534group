namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "PaymentInformation_Id", "dbo.PaymentInformation");
            DropIndex("dbo.Customers", new[] { "PaymentInformation_Id" });
            RenameColumn(table: "dbo.Customers", name: "PaymentInformation_Id", newName: "PaymentInformationId");
            AddColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "PaymentInformationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pets", "Description", c => c.String());
            CreateIndex("dbo.Customers", "PaymentInformationId");
            AddForeignKey("dbo.Customers", "PaymentInformationId", "dbo.PaymentInformation", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "CustomerPhone");
            DropColumn("dbo.Customers", "CustomerEmail");
            DropColumn("dbo.Customers", "PaymentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PaymentId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CustomerEmail", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "CustomerPhone", c => c.String(nullable: false));
            DropForeignKey("dbo.Customers", "PaymentInformationId", "dbo.PaymentInformation");
            DropIndex("dbo.Customers", new[] { "PaymentInformationId" });
            AlterColumn("dbo.Pets", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "PaymentInformationId", c => c.Int());
            DropColumn("dbo.Customers", "EmailAddress");
            DropColumn("dbo.Customers", "PhoneNumber");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "FirstName");
            RenameColumn(table: "dbo.Customers", name: "PaymentInformationId", newName: "PaymentInformation_Id");
            CreateIndex("dbo.Customers", "PaymentInformation_Id");
            AddForeignKey("dbo.Customers", "PaymentInformation_Id", "dbo.PaymentInformation", "Id");
        }
    }
}
