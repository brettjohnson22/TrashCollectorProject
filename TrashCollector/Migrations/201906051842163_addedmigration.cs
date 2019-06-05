namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "PickupDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PickupDay", c => c.Int(nullable: false));
        }
    }
}
