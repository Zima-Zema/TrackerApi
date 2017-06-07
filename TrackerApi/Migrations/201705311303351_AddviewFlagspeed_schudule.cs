namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddviewFlagspeed_schudule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationSchaduals", "viewFlag", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocationSchaduals", "viewFlag");
        }
    }
}
