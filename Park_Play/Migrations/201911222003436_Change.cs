namespace Park_Play.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sports", "Park_ParkId", "dbo.Parks");
            DropIndex("dbo.Sports", new[] { "Park_ParkId" });
            DropColumn("dbo.Sports", "Park_ParkId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sports", "Park_ParkId", c => c.Int());
            CreateIndex("dbo.Sports", "Park_ParkId");
            AddForeignKey("dbo.Sports", "Park_ParkId", "dbo.Parks", "ParkId");
        }
    }
}
