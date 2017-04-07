namespace MenuWeb.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipePhotoLinks : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Comments", newName: "RecipeComments");
            CreateTable(
                "dbo.RecipePhotoLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipePhotoLinks", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.RecipePhotoLinks", new[] { "RecipeID" });
            DropTable("dbo.RecipePhotoLinks");
            RenameTable(name: "dbo.RecipeComments", newName: "Comments");
        }
    }
}
