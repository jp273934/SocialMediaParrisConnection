namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmailStructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "EmailType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emails", "EmailType");
        }
    }
}
