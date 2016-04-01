namespace sp16_p3_g8WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.String());
        }
    }
}
