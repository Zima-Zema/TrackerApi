namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixHosting : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Locations", "FullAddress", c => c.String());
            //AddColumn("dbo.Locations", "Lng", c => c.Double(nullable: false));
            //AddColumn("dbo.Locations", "Parent_key", c => c.Int(nullable: false));
            //CreateIndex("dbo.Locations", "Parent_key");
            //AddForeignKey("dbo.Locations", "Parent_key", "dbo.Parents", "Id", cascadeDelete: true);
            //DropColumn("dbo.Locations", "Log");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Log", c => c.Double(nullable: false));
            DropForeignKey("dbo.Locations", "Parent_key", "dbo.Parents");
            DropIndex("dbo.Locations", new[] { "Parent_key" });
            DropColumn("dbo.Locations", "Parent_key");
            DropColumn("dbo.Locations", "Lng");
            DropColumn("dbo.Locations", "FullAddress");
        }
    }
}
