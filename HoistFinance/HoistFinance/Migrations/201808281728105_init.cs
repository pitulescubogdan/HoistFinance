namespace HoistFinance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Index = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Visits = c.Int(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Index);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
        }
    }
}
