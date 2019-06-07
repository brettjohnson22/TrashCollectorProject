namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerbool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "weeklyDbAdd", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "weeklyDbAdd");
        }
    }
}
