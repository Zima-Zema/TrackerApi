namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editconn_id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Connection_id", "Parent_Id", "dbo.Parents");
            DropPrimaryKey("dbo.Connection_id");
            AlterColumn("dbo.Connection_id", "Con_key", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Connection_id", "Con_key");
            AddForeignKey("dbo.Connection_id", "Parent_Id", "dbo.Parents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connection_id", "Parent_Id", "dbo.Parents");
            DropPrimaryKey("dbo.Connection_id");
            AlterColumn("dbo.Connection_id", "Con_key", c => c.String());
            AddPrimaryKey("dbo.Connection_id", "Parent_Id");
            AddForeignKey("dbo.Connection_id", "Parent_Id", "dbo.Parents", "Id");
        }
    }
}
