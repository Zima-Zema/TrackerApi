namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddviewFlagtoHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationHistories", "viewFlag", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocationHistories", "viewFlag");
        }
    }
}
