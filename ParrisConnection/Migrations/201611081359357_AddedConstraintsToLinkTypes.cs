namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedConstraintsToLinkTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LinkTypes", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.LinkTypes", "CssClass", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LinkTypes", "CssClass", c => c.String());
            AlterColumn("dbo.LinkTypes", "Name", c => c.String());
        }
    }
}
