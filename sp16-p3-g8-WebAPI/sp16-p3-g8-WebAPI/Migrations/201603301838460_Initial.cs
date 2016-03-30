namespace sp16_p3_g8_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.movies",
                c => new
                    {
                        moviesId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        releaseDate = c.Int(nullable: false),
                        rating = c.Int(nullable: false),
                        description = c.String(),
                        genre = c.String(),
                        actors = c.String(),
                    })
                .PrimaryKey(t => t.moviesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.movies");
        }
    }
}
