namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarkdownFieldToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Markdown", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Markdown");
        }
    }
}
