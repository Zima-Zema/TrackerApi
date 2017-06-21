namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addhistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocationHistories",
                c => new
                    {
                        locationId = c.Int(nullable: false, identity: true),
                        serviceProvider = c.String(),
                        debug = c.Boolean(nullable: false),
                        time = c.Double(),
                        accuracy = c.Double(),
                        speed = c.Double(),
                        longitude = c.Double(),
                        latitude = c.Double(),
                        altitude = c.Double(),
                        altitudeAccuracy = c.Double(),
                        bearing = c.Double(),
                        timestamp = c.Double(),
                        coords_latitude = c.Double(),
                        coords_longitude = c.Double(),
                        coords_altitude = c.Double(),
                        coords_speed = c.Double(),
                        coords_accuracy = c.Double(),
                        coords_altitudeAccuracy = c.Double(),
                        coords_heading = c.Double(),
                        viewFlag = c.Boolean(nullable: false),
                        Child_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.locationId)
                .ForeignKey("dbo.Children", t => t.Child_Id, cascadeDelete: true)
                .Index(t => t.Child_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocationHistories", "Child_Id", "dbo.Children");
            DropIndex("dbo.LocationHistories", new[] { "Child_Id" });
            DropTable("dbo.LocationHistories");
        }
    }
}
