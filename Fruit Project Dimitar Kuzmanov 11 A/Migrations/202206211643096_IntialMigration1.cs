namespace Fruit_Project_Dimitar_Kuzmanov_11_A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fruits", "Name", c => c.String());
            DropColumn("dbo.Fruits", "Brand");
            DropColumn("dbo.Fruits", "FruitSize");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fruits", "FruitSize", c => c.Int(nullable: false));
            AddColumn("dbo.Fruits", "Brand", c => c.String());
            DropColumn("dbo.Fruits", "Name");
        }
    }
}
