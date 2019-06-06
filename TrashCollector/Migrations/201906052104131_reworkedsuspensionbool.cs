namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reworkedsuspensionbool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SuspensionSceduled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "ActiveSuspension", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSuspended");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSuspended", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "ActiveSuspension");
            DropColumn("dbo.Customers", "SuspensionSceduled");
        }
    }
}
