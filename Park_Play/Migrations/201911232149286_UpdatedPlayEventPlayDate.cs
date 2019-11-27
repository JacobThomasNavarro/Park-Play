namespace Park_Play.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPlayEventPlayDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayEvents", "PlayDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PlayEvents", "StartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlayEvents", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PlayEvents", "PlayDate");
        }
    }
}
