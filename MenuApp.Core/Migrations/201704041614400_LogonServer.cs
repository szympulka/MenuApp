namespace MenuWeb.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class LogonServer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logons", "Region", c => c.String());
            AlterColumn("dbo.Logons", "Latitude", c => c.Long(nullable: false));
            AlterColumn("dbo.Logons", "LongLatitude", c => c.Long(nullable: false));
            DropColumn("dbo.Logons", "MetroCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logons", "MetroCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Logons", "LongLatitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Logons", "Latitude", c => c.Double(nullable: false));
            DropColumn("dbo.Logons", "Region");
        }
    }
}
