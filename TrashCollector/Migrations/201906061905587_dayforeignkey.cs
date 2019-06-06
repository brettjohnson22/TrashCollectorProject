namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dayforeignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickUpDayID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "PickUpDayID");
            AddForeignKey("dbo.Customers", "PickUpDayID", "dbo.Days", "Value", cascadeDelete: true);
            DropColumn("dbo.Customers", "PickupDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PickupDay", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "PickUpDayID", "dbo.Days");
            DropIndex("dbo.Customers", new[] { "PickUpDayID" });
            DropColumn("dbo.Customers", "PickUpDayID");
        }
    }
}
