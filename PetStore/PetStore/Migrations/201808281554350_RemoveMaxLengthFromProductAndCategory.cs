namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMaxLengthFromProductAndCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
