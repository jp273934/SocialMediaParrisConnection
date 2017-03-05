namespace ParrisConnection.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdToPhones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phones", "UserId");
        }
    }
}
