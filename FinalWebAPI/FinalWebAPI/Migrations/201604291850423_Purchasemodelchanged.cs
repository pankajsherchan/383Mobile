namespace FinalWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchasemodelchanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseTicketLineItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseTicketId = c.Int(nullable: false),
                        TicketCount = c.Int(nullable: false),
                        TicketType = c.String(),
                        TicketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseTickets", t => t.PurchaseTicketId, cascadeDelete: true)
                .Index(t => t.PurchaseTicketId);
            
            CreateTable(
                "dbo.PurchaseTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShowtimeId = c.Int(nullable: false),
                        TicketCount = c.Int(nullable: false),
                        PurchaseDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Showtimes", t => t.ShowtimeId, cascadeDelete: true)
                .Index(t => t.ShowtimeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseTicketLineItems", "PurchaseTicketId", "dbo.PurchaseTickets");
            DropForeignKey("dbo.PurchaseTickets", "ShowtimeId", "dbo.Showtimes");
            DropIndex("dbo.PurchaseTickets", new[] { "ShowtimeId" });
            DropIndex("dbo.PurchaseTicketLineItems", new[] { "PurchaseTicketId" });
            DropTable("dbo.PurchaseTickets");
            DropTable("dbo.PurchaseTicketLineItems");
        }
    }
}
