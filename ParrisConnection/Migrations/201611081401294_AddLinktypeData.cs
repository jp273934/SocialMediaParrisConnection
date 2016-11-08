namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLinktypeData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO LinkTypes(Name, CssClass) VALUES ('Other', '')");
            
        }
        
        public override void Down()
        {
        }
    }
}
