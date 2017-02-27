namespace ParrisConnection.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdToStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Status", "UserId");
        }
    }
}
