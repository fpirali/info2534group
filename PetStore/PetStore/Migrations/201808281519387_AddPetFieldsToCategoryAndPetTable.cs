namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPetFieldsToCategoryAndPetTable : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Categories", "PetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "PetId");
            AddForeignKey("dbo.Categories", "PetId", "dbo.Pets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "PetId", "dbo.Pets");
            DropIndex("dbo.Categories", new[] { "PetId" });
            DropColumn("dbo.Categories", "PetId");
            DropTable("dbo.Pets");
        }
    }
}
