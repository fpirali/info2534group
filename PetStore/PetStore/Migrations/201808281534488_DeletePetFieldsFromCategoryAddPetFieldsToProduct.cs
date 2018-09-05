namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePetFieldsFromCategoryAddPetFieldsToProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "PetId", "dbo.Pets");
            DropIndex("dbo.Categories", new[] { "PetId" });
            AddColumn("dbo.Product", "PetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "PetId");
            AddForeignKey("dbo.Product", "PetId", "dbo.Pets", "Id", cascadeDelete: true);
            DropColumn("dbo.Categories", "PetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "PetId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Product", "PetId", "dbo.Pets");
            DropIndex("dbo.Product", new[] { "PetId" });
            DropColumn("dbo.Product", "PetId");
            CreateIndex("dbo.Categories", "PetId");
            AddForeignKey("dbo.Categories", "PetId", "dbo.Pets", "Id", cascadeDelete: true);
        }
    }
}
