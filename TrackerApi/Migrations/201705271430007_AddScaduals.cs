namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScaduals : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Children", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Children", new[] { "Location_Id" });
            CreateTable(
                "dbo.LocationSchaduals",
                c => new
                    {
                        Location_Key = c.Int(nullable: false),
                        Child_Key = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        isSat = c.Boolean(nullable: false),
                        isSun = c.Boolean(nullable: false),
                        isMon = c.Boolean(nullable: false),
                        isTue = c.Boolean(nullable: false),
                        isWed = c.Boolean(nullable: false),
                        isThe = c.Boolean(nullable: false),
                        isFri = c.Boolean(nullable: false),
                        isRepeated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Location_Key, t.Child_Key })
                .ForeignKey("dbo.Children", t => t.Child_Key, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.Location_Key, cascadeDelete: true)
                .Index(t => t.Location_Key)
                .Index(t => t.Child_Key);
            
            AlterColumn("dbo.Locations", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.LocationHistories", "Name", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Children", "Location_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Children", "Location_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.LocationSchaduals", "Location_Key", "dbo.Locations");
            DropForeignKey("dbo.LocationSchaduals", "Child_Key", "dbo.Children");
            DropIndex("dbo.LocationSchaduals", new[] { "Child_Key" });
            DropIndex("dbo.LocationSchaduals", new[] { "Location_Key" });
            AlterColumn("dbo.LocationHistories", "Name", c => c.String());
            AlterColumn("dbo.Locations", "Name", c => c.String());
            DropTable("dbo.LocationSchaduals");
            CreateIndex("dbo.Children", "Location_Id");
            AddForeignKey("dbo.Children", "Location_Id", "dbo.Locations", "Id", cascadeDelete: true);
        }
    }
}
