namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddviewFlagspeed_danger : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DangerNotifies", "viewFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.SpeedNotifies", "viewFlag", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpeedNotifies", "viewFlag");
            DropColumn("dbo.DangerNotifies", "viewFlag");
        }
    }
}
