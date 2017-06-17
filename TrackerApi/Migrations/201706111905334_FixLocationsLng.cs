namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixLocationsLng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Lng", c => c.Double(nullable: false));
            DropColumn("dbo.Locations", "Log");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Log", c => c.Double(nullable: false));
            DropColumn("dbo.Locations", "Lng");
        }
    }
}
