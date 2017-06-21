namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removehistory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LocationHistories", "Child_Id", "dbo.Children");
            DropIndex("dbo.LocationHistories", new[] { "Child_Id" });
            DropTable("dbo.LocationHistories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LocationHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Date = c.DateTime(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        Log = c.Double(nullable: false),
                        Lat = c.Double(nullable: false),
                        viewFlag = c.Boolean(nullable: false),
                        Child_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.LocationHistories", "Child_Id");
            AddForeignKey("dbo.LocationHistories", "Child_Id", "dbo.Children", "Id", cascadeDelete: true);
        }
    }
}
