namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "viewFlag", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "viewFlag");
        }
    }
}
