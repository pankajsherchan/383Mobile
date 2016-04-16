namespace FinalWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Cast");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Cast", c => c.String());
        }
    }
}
