namespace HereosBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAtuh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Utilisateur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Utilisateur_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Utilisateur_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            
            AddColumn("dbo.Utilisateurs", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilisateurs", "PasswordHash", c => c.String());
            AddColumn("dbo.Utilisateurs", "SecurityStamp", c => c.String());
            AddColumn("dbo.Utilisateurs", "PhoneNumber", c => c.String());
            AddColumn("dbo.Utilisateurs", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilisateurs", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilisateurs", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Utilisateurs", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Utilisateurs", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Utilisateurs", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.AspNetUserLogins", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.AspNetUserClaims", "Utilisateur_Id", "dbo.Utilisateurs");
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "Utilisateur_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "Utilisateur_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Utilisateur_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropColumn("dbo.Utilisateurs", "UserName");
            DropColumn("dbo.Utilisateurs", "AccessFailedCount");
            DropColumn("dbo.Utilisateurs", "LockoutEnabled");
            DropColumn("dbo.Utilisateurs", "LockoutEndDateUtc");
            DropColumn("dbo.Utilisateurs", "TwoFactorEnabled");
            DropColumn("dbo.Utilisateurs", "PhoneNumberConfirmed");
            DropColumn("dbo.Utilisateurs", "PhoneNumber");
            DropColumn("dbo.Utilisateurs", "SecurityStamp");
            DropColumn("dbo.Utilisateurs", "PasswordHash");
            DropColumn("dbo.Utilisateurs", "EmailConfirmed");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
        }
    }
}
