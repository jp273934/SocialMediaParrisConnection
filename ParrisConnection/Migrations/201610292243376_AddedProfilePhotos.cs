namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProfilePhotos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfilePhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProfilePhotoes");
        }
    }
}
