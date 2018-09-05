namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomersUserIdToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UserId", c => c.String());
            AlterColumn("dbo.PaymentInformation", "ExpirationMonth", c => c.Int(nullable: false));
            AlterColumn("dbo.PaymentInformation", "ExpirationYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PaymentInformation", "ExpirationYear", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.PaymentInformation", "ExpirationMonth", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Customers", "UserId", c => c.Int(nullable: false));
        }
    }
}
