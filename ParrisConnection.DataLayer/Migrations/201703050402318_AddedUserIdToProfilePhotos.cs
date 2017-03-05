namespace ParrisConnection.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdToProfilePhotos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfilePhotoes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfilePhotoes", "UserId");
        }
    }
}
