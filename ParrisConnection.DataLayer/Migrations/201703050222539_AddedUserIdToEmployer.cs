namespace ParrisConnection.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdToEmployer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employers", "UserId");
        }
    }
}
