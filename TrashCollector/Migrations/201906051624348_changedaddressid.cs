namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedaddressid : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "AddressID" });
            DropIndex("dbo.Employees", new[] { "AddressID" });
            CreateIndex("dbo.Customers", "AddressId");
            CreateIndex("dbo.Employees", "AddressId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "AddressId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            CreateIndex("dbo.Employees", "AddressID");
            CreateIndex("dbo.Customers", "AddressID");
        }
    }
}
