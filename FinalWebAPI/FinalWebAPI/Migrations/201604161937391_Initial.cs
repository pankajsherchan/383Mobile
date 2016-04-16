namespace FinalWebAPI.Migrations
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
                        Rating = c.Int(nullable: false),
                        Duration = c.String(),
                        Cast = c.String(),
                        ReleaseDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Screens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScreenNumber = c.String(),
                        SeatCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.Showtimes", "ScreenId", "dbo.Screens");
            DropForeignKey("dbo.Showtimes", "MovieId", "dbo.Movies");
            DropIndex("dbo.Showtimes", new[] { "MovieId" });
            DropIndex("dbo.Showtimes", new[] { "ScreenId" });
            DropTable("dbo.Users");
            DropTable("dbo.Showtimes");
            DropTable("dbo.Screens");
            DropTable("dbo.Movies");
        }
    }
}
