namespace MenuWeb.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "StackTrace", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "StackTrace");
        }
    }
}
