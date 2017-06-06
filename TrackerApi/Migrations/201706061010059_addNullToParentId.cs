namespace TrackerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullToParentId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Children", "Parent_Id", "dbo.Parents");
            DropIndex("dbo.Children", new[] { "Parent_Id" });
            AlterColumn("dbo.Children", "Parent_Id", c => c.Int());
            CreateIndex("dbo.Children", "Parent_Id");
            AddForeignKey("dbo.Children", "Parent_Id", "dbo.Parents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Children", "Parent_Id", "dbo.Parents");
            DropIndex("dbo.Children", new[] { "Parent_Id" });
            AlterColumn("dbo.Children", "Parent_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Children", "Parent_Id");
            AddForeignKey("dbo.Children", "Parent_Id", "dbo.Parents", "Id", cascadeDelete: true);
        }
    }
}
