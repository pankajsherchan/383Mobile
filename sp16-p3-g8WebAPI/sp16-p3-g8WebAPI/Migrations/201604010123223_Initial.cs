namespace sp16_p3_g8WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Rating = c.String(),
                        Duration = c.String(),
                        Cast = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Showtimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScreenId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Screens", t => t.ScreenId, cascadeDelete: true)
                .Index(t => t.ScreenId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Screens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScreenNumber = c.Int(nullable: false),
                        SeatCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseTicketLineItems", "PurchaseTicketId", "dbo.PurchaseTickets");
            DropForeignKey("dbo.PurchaseTickets", "ShowtimeId", "dbo.Showtimes");
            DropForeignKey("dbo.Showtimes", "ScreenId", "dbo.Screens");
            DropForeignKey("dbo.Showtimes", "MovieId", "dbo.Movies");
            DropIndex("dbo.Showtimes", new[] { "MovieId" });
            DropIndex("dbo.Showtimes", new[] { "ScreenId" });
            DropIndex("dbo.PurchaseTickets", new[] { "ShowtimeId" });
            DropIndex("dbo.PurchaseTicketLineItems", new[] { "PurchaseTicketId" });
            DropTable("dbo.Users");
            DropTable("dbo.Screens");
            DropTable("dbo.Showtimes");
            DropTable("dbo.PurchaseTickets");
            DropTable("dbo.PurchaseTicketLineItems");
            DropTable("dbo.Movies");
        }
    }
}
