namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUpcomingEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
