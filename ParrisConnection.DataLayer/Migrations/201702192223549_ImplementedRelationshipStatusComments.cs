namespace ParrisConnection.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImplementedRelationshipStatusComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Status_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Status_Id");
            AddForeignKey("dbo.Comments", "Status_Id", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Status_Id", "dbo.Status");
            DropIndex("dbo.Comments", new[] { "Status_Id" });
            DropColumn("dbo.Comments", "Status_Id");
        }
    }
}
