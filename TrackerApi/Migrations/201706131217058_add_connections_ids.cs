namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_connections_ids : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connection_id",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Parent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Connection_id");
        }
    }
}
