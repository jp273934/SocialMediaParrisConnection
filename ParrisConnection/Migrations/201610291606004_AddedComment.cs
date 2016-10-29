namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedComment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "PostComment", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "PostComment", c => c.String());
        }
    }
}
