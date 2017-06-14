namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_error : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Connection_id");
            AlterColumn("dbo.Connection_id", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Connection_id", "Parent_Id");
            CreateIndex("dbo.Connection_id", "Parent_Id");
            AddForeignKey("dbo.Connection_id", "Parent_Id", "dbo.Parents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connection_id", "Parent_Id", "dbo.Parents");
            DropIndex("dbo.Connection_id", new[] { "Parent_Id" });
            DropPrimaryKey("dbo.Connection_id");
            AlterColumn("dbo.Connection_id", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Connection_id", "Id");
        }
    }
}
