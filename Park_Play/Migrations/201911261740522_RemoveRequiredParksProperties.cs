namespace Park_Play.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredParksProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parks", "streetAddress", c => c.String());
            AlterColumn("dbo.Parks", "city", c => c.String());
            AlterColumn("dbo.Parks", "stateCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parks", "stateCode", c => c.String(nullable: false));
            AlterColumn("dbo.Parks", "city", c => c.String(nullable: false));
            AlterColumn("dbo.Parks", "streetAddress", c => c.String(nullable: false));
        }
    }
}
