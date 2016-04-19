namespace FinalWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchatarpatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Year", c => c.String());
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "Director", c => c.String());
            AddColumn("dbo.Movies", "Actors", c => c.String());
            AddColumn("dbo.Movies", "Plot", c => c.String());
            AddColumn("dbo.Movies", "Language", c => c.String());
            AddColumn("dbo.Movies", "Awards", c => c.String());
            AddColumn("dbo.Movies", "imdbRating", c => c.String());
            DropColumn("dbo.Movies", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "imdbRating");
            DropColumn("dbo.Movies", "Awards");
            DropColumn("dbo.Movies", "Language");
            DropColumn("dbo.Movies", "Plot");
            DropColumn("dbo.Movies", "Actors");
            DropColumn("dbo.Movies", "Director");
            DropColumn("dbo.Movies", "Genre");
            DropColumn("dbo.Movies", "Year");
        }
    }
}
