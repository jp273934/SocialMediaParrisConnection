namespace ParrisConnection.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCssClassFromLinks : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Links", "CssClass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Links", "CssClass", c => c.String(maxLength: 50));
        }
    }
}
