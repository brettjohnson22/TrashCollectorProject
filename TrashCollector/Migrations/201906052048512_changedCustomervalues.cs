namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedCustomervalues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SuspendEnd", c => c.DateTime());
            DropColumn("dbo.Customers", "EndStart");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "EndStart", c => c.DateTime());
            DropColumn("dbo.Customers", "SuspendEnd");
        }
    }
}
