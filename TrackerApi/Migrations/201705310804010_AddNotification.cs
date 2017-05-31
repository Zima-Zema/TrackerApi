namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DangerNotifies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lng = c.Double(nullable: false),
                        Lat = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Desc = c.String(),
                        Child_key = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Children", t => t.Child_key, cascadeDelete: true)
                .Index(t => t.Child_key);
            
            CreateTable(
                "dbo.SpeedNotifies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lng = c.Double(nullable: false),
                        Lat = c.Double(nullable: false),
                        Value = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Child_key = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Children", t => t.Child_key, cascadeDelete: true)
                .Index(t => t.Child_key);
            
            AddColumn("dbo.Children", "viewFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parents", "viewFlag", c => c.Boolean(nullable: false));
            AlterColumn("dbo.LocationHistories", "Log", c => c.Double(nullable: false));
            AlterColumn("dbo.LocationHistories", "Lat", c => c.Double(nullable: false));
            AlterColumn("dbo.Locations", "Log", c => c.Double(nullable: false));
            AlterColumn("dbo.Locations", "Lat", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpeedNotifies", "Child_key", "dbo.Children");
            DropForeignKey("dbo.DangerNotifies", "Child_key", "dbo.Children");
            DropIndex("dbo.SpeedNotifies", new[] { "Child_key" });
            DropIndex("dbo.DangerNotifies", new[] { "Child_key" });
            AlterColumn("dbo.Locations", "Lat", c => c.Int(nullable: false));
            AlterColumn("dbo.Locations", "Log", c => c.Int(nullable: false));
            AlterColumn("dbo.LocationHistories", "Lat", c => c.Int(nullable: false));
            AlterColumn("dbo.LocationHistories", "Log", c => c.Int(nullable: false));
            DropColumn("dbo.Parents", "viewFlag");
            DropColumn("dbo.Children", "viewFlag");
            DropTable("dbo.SpeedNotifies");
            DropTable("dbo.DangerNotifies");
        }
    }
}
