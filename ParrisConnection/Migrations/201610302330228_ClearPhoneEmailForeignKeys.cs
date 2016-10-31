namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClearPhoneEmailForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmailTypes", "Id", "dbo.Emails");
            DropForeignKey("dbo.PhoneTypes", "Id", "dbo.Phones");
            DropIndex("dbo.EmailTypes", new[] { "Id" });
            DropIndex("dbo.PhoneTypes", new[] { "Id" });
            DropPrimaryKey("dbo.EmailTypes");
            DropPrimaryKey("dbo.PhoneTypes");
            AlterColumn("dbo.EmailTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PhoneTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.EmailTypes", "Id");
            AddPrimaryKey("dbo.PhoneTypes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PhoneTypes");
            DropPrimaryKey("dbo.EmailTypes");
            AlterColumn("dbo.PhoneTypes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.EmailTypes", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PhoneTypes", "Id");
            AddPrimaryKey("dbo.EmailTypes", "Id");
            CreateIndex("dbo.PhoneTypes", "Id");
            CreateIndex("dbo.EmailTypes", "Id");
            AddForeignKey("dbo.PhoneTypes", "Id", "dbo.Phones", "Id");
            AddForeignKey("dbo.EmailTypes", "Id", "dbo.Emails", "Id");
        }
    }
}
