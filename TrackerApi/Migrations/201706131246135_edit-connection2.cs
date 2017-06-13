namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editconnection2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Connection_id", "Con_key", c => c.String());
            DropColumn("dbo.Connection_id", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Connection_id", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Connection_id", "Con_key");
        }
    }
}
