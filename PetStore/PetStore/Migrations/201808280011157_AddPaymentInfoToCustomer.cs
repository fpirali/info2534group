namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillingInfoToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CardNumber", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Customers", "ExpirationMonth", c => c.String(nullable: false, maxLength: 2));
            AddColumn("dbo.Customers", "ExpirationYear", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.Customers", "CardPin", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CardPin");
            DropColumn("dbo.Customers", "ExpirationYear");
            DropColumn("dbo.Customers", "ExpirationMonth");
            DropColumn("dbo.Customers", "CardNumber");
        }
    }
}
