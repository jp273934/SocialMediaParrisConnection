namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetPhoneForeignKeys : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneTypes", "Id", "dbo.Phones");
            DropIndex("dbo.PhoneTypes", new[] { "Id" });
            DropPrimaryKey("dbo.PhoneTypes");
            AlterColumn("dbo.PhoneTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PhoneTypes", "Id");
        }
    }
}
