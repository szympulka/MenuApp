namespace MenuWeb.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Logsedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "UserDateLog", c => c.DateTime(nullable: false));
            AddColumn("dbo.Logs", "FunctionArgumnets", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "FunctionArgumnets");
            DropColumn("dbo.Logs", "UserDateLog");
        }
    }
}
