namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatusIdToComment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Status_Id", "dbo.Status");
            DropIndex("dbo.Comments", new[] { "Status_Id" });
            RenameColumn(table: "dbo.Comments", name: "Status_Id", newName: "StatusId");
            AlterColumn("dbo.Comments", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "StatusId");
            AddForeignKey("dbo.Comments", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "StatusId", "dbo.Status");
            DropIndex("dbo.Comments", new[] { "StatusId" });
            AlterColumn("dbo.Comments", "StatusId", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "StatusId", newName: "Status_Id");
            CreateIndex("dbo.Comments", "Status_Id");
            AddForeignKey("dbo.Comments", "Status_Id", "dbo.Status", "Id");
        }
    }
}
