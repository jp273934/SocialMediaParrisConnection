namespace ParrisConnection.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdToEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emails", "UserId");
        }
    }
}
