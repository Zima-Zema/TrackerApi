namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelationParentLocations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "FullAddress", c => c.String());
            AddColumn("dbo.Locations", "Parent_key", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "Parent_key");
            AddForeignKey("dbo.Locations", "Parent_key", "dbo.Parents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "Parent_key", "dbo.Parents");
            DropIndex("dbo.Locations", new[] { "Parent_key" });
            DropColumn("dbo.Locations", "Parent_key");
            DropColumn("dbo.Locations", "FullAddress");
        }
    }
}
