namespace MenuWeb.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Likes = c.Int(nullable: false),
                        Content = c.String(),
                        Author = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        IdRecipe = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.IdRecipe, cascadeDelete: true)
                .Index(t => t.IdRecipe);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        ShortDescription = c.String(),
                        Category = c.String(nullable: false),
                        CategoryOfFood = c.String(),
                        PreparationTime = c.Int(),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        RecipeLikes = c.Int(nullable: false),
                        RecipeDisLikes = c.Int(nullable: false),
                        Author = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        HardLevel = c.String(),
                        Views = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DateQuestion = c.DateTime(nullable: false, storeType: "date"),
                        Question = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IP = c.String(),
                        CuntryName = c.String(),
                        CountryCode = c.String(),
                        RegionName = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        TimeZone = c.String(),
                        Latitude = c.Double(nullable: false),
                        LongLatitude = c.Single(nullable: false),
                        MetroCode = c.Int(nullable: false),
                        FullDate = c.DateTime(nullable: false),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Error = c.String(),
                        DateLog = c.DateTime(nullable: false),
                        ErrorPlace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Newsletters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeLikes",
                c => new
                    {
                        IdRecipe = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.IdRecipe, t.UserName });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        DateCreateAccount = c.DateTime(nullable: false, storeType: "date"),
                        DateOfChangePassword = c.DateTime(storeType: "date"),
                        Role = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        VerificationToken = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComponentRecipes",
                c => new
                    {
                        Component_Id = c.Int(nullable: false),
                        Recipe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Component_Id, t.Recipe_Id })
                .ForeignKey("dbo.Components", t => t.Component_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id, cascadeDelete: true)
                .Index(t => t.Component_Id)
                .Index(t => t.Recipe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComponentRecipes", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.ComponentRecipes", "Component_Id", "dbo.Components");
            DropForeignKey("dbo.Comments", "IdRecipe", "dbo.Recipes");
            DropIndex("dbo.ComponentRecipes", new[] { "Recipe_Id" });
            DropIndex("dbo.ComponentRecipes", new[] { "Component_Id" });
            DropIndex("dbo.Comments", new[] { "IdRecipe" });
            DropTable("dbo.ComponentRecipes");
            DropTable("dbo.Users");
            DropTable("dbo.RecipeLikes");
            DropTable("dbo.Newsletters");
            DropTable("dbo.Logs");
            DropTable("dbo.Logons");
            DropTable("dbo.Contacts");
            DropTable("dbo.Components");
            DropTable("dbo.Recipes");
            DropTable("dbo.Comments");
        }
    }
}
