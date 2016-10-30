namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoadingStatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "StatusId", "dbo.Status");
            DropIndex("dbo.Comments", new[] { "StatusId" });
            RenameColumn(table: "dbo.Comments", name: "StatusId", newName: "Status_Id");
            AlterColumn("dbo.Comments", "Status_Id", c => c.Int());
            AlterColumn("dbo.Comments", "PostComment", c => c.String());
            CreateIndex("dbo.Comments", "Status_Id");
            AddForeignKey("dbo.Comments", "Status_Id", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Status_Id", "dbo.Status");
            DropIndex("dbo.Comments", new[] { "Status_Id" });
            AlterColumn("dbo.Comments", "PostComment", c => c.String(maxLength: 255));
            AlterColumn("dbo.Comments", "Status_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Comments", name: "Status_Id", newName: "StatusId");
            CreateIndex("dbo.Comments", "StatusId");
            AddForeignKey("dbo.Comments", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
        }
    }
}
