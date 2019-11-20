namespace Park_Play.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parks",
                c => new
                    {
                        ParkId = c.Int(nullable: false, identity: true),
                        parkName = c.String(nullable: false),
                        streetAddress = c.String(nullable: false),
                        city = c.String(nullable: false),
                        stateCode = c.String(nullable: false),
                        zipCode = c.Int(nullable: false),
                        contactNumber = c.Double(nullable: false),
                        lat = c.Single(nullable: false),
                        lng = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ParkId);
            
            CreateTable(
                "dbo.ParkSports",
                c => new
                    {
                        ParkSportId = c.Int(nullable: false, identity: true),
                        ParkId = c.Int(nullable: false),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParkSportId)
                .ForeignKey("dbo.Parks", t => t.ParkId, cascadeDelete: true)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .Index(t => t.ParkId)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        SportId = c.Int(nullable: false, identity: true),
                        sportName = c.String(),
                    })
                .PrimaryKey(t => t.SportId);
            
            CreateTable(
                "dbo.PlayEvents",
                c => new
                    {
                        PlayEventId = c.Int(nullable: false, identity: true),
                        skillLevel = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        numberOfPlayers = c.Int(nullable: false),
                        ParkId = c.Int(nullable: false),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayEventId)
                .ForeignKey("dbo.Parks", t => t.ParkId, cascadeDelete: true)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .Index(t => t.ParkId)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SkillSportUsers",
                c => new
                    {
                        SkillSportUserId = c.Int(nullable: false, identity: true),
                        skillLevel = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillSportUserId)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        firstName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        emailAddress = c.String(nullable: false),
                        streetAddress = c.String(nullable: false),
                        city = c.String(nullable: false),
                        stateCode = c.String(nullable: false),
                        zipCode = c.Int(nullable: false),
                        phoneNumber = c.String(nullable: false),
                        profilePicture = c.Binary(),
                        lat = c.Single(nullable: false),
                        lng = c.Single(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPlayEvents",
                c => new
                    {
                        UserPlayEventId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PlayEventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserPlayEventId)
                .ForeignKey("dbo.PlayEvents", t => t.PlayEventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PlayEventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPlayEvents", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPlayEvents", "PlayEventId", "dbo.PlayEvents");
            DropForeignKey("dbo.SkillSportUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SkillSportUsers", "SportId", "dbo.Sports");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PlayEvents", "SportId", "dbo.Sports");
            DropForeignKey("dbo.PlayEvents", "ParkId", "dbo.Parks");
            DropForeignKey("dbo.ParkSports", "SportId", "dbo.Sports");
            DropForeignKey("dbo.ParkSports", "ParkId", "dbo.Parks");
            DropIndex("dbo.UserPlayEvents", new[] { "PlayEventId" });
            DropIndex("dbo.UserPlayEvents", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "ApplicationId" });
            DropIndex("dbo.SkillSportUsers", new[] { "SportId" });
            DropIndex("dbo.SkillSportUsers", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PlayEvents", new[] { "SportId" });
            DropIndex("dbo.PlayEvents", new[] { "ParkId" });
            DropIndex("dbo.ParkSports", new[] { "SportId" });
            DropIndex("dbo.ParkSports", new[] { "ParkId" });
            DropTable("dbo.UserPlayEvents");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.SkillSportUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PlayEvents");
            DropTable("dbo.Sports");
            DropTable("dbo.ParkSports");
            DropTable("dbo.Parks");
        }
    }
}
