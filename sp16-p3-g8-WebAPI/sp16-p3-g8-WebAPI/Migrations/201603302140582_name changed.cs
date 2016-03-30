namespace sp16_p3_g8_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namechanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "releaseDate", c => c.Int(nullable: false));
        }
    }
}
