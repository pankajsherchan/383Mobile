namespace FinalWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseDetailAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        type = c.String(),
                        time = c.String(),
                        InventoryCount = c.Int(nullable: false),
                        date = c.String(),
                        ScreenNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PurchaseDetails");
        }
    }
}
