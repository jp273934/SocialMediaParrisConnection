namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedJobTitleToEmployment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employers", "JobTitle", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employers", "JobTitle");
        }
    }
}
