namespace FinalWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modeladded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Poster", c => c.String());
            AddColumn("dbo.Showtimes", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Showtimes", "StartTime", c => c.String());
            DropColumn("dbo.Showtimes", "StartDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showtimes", "StartDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Showtimes", "StartTime");
            DropColumn("dbo.Showtimes", "StartDate");
            DropColumn("dbo.Movies", "Poster");
        }
    }
}
