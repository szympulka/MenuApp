namespace MenuWeb.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Logons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logons", "Browser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logons", "Browser");
        }
    }
}
