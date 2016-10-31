namespace ParrisConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertPhoneTyesAgain : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PhoneTypes(Id, Type) VALUES(1, 'Home')");
            Sql("INSERT INTO PhoneTypes(Id, Type) VALUES(2, 'Work')");
            Sql("INSERT INTO PhoneTypes(Id, Type) VALUES(3, 'Mobile')");
        }
        
        public override void Down()
        {
        }
    }
}
