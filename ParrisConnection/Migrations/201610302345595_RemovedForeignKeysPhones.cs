namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedForeignKeysPhones : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhoneTypes", "Id", "dbo.Phones");
            DropIndex("dbo.PhoneTypes", new[] { "Id" });
            DropPrimaryKey("dbo.PhoneTypes");
            AddColumn("dbo.Phones", "PhoneType", c => c.String());
            AlterColumn("dbo.PhoneTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PhoneTypes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PhoneTypes");
            AlterColumn("dbo.PhoneTypes", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Phones", "PhoneType");
            AddPrimaryKey("dbo.PhoneTypes", "Id");
            CreateIndex("dbo.PhoneTypes", "Id");
            AddForeignKey("dbo.PhoneTypes", "Id", "dbo.Phones", "Id");
        }
    }
}
