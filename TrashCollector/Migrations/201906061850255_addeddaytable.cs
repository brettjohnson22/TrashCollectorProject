namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddaytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        value = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.value);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Days");
        }
    }
}
