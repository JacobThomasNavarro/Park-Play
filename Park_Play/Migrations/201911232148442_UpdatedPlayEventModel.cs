namespace Park_Play.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPlayEventModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayEvents", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PlayEvents", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayEvents", "EndTime");
            DropColumn("dbo.PlayEvents", "StartDate");
        }
    }
}
