namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLinksStringLengthContstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Links", "Url", c => c.String(maxLength: 255));
            AlterColumn("dbo.Links", "Type", c => c.String(maxLength: 50));
            AlterColumn("dbo.Links", "CssClass", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Links", "CssClass", c => c.String());
            AlterColumn("dbo.Links", "Type", c => c.String());
            AlterColumn("dbo.Links", "Url", c => c.String());
        }
    }
}
