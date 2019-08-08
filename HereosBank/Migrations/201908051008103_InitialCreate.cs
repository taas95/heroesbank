namespace HereosBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agences",
                c => new
                    {
                        IdAgence = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        AdresseAgence = c.String(),
                    })
                .PrimaryKey(t => t.IdAgence);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Sexe = c.String(maxLength: 50),
                        DateNaissance = c.DateTime(nullable: false),
                        NumCarte = c.String(),
                        Adresse = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comptes",
                c => new
                    {
                        NumCompte = c.String(nullable: false, maxLength: 128),
                        Solde = c.Single(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumCompte)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTransaction = c.DateTime(nullable: false),
                        TypeTransaction = c.String(),
                        Montant = c.Single(nullable: false),
                        UserId = c.Int(nullable: false),
                        NumeroCompte = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comptes", t => t.NumeroCompte)
                .ForeignKey("dbo.Utilisateurs", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.NumeroCompte);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        NumeroCarte = c.String(),
                        Sexe = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        Email = c.String(),
                        Mdp = c.String(),
                        PrivilegeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Privileges", t => t.PrivilegeId, cascadeDelete: true)
                .Index(t => t.PrivilegeId);
            
            CreateTable(
                "dbo.Privileges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Profile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "UserId", "dbo.Utilisateurs");
            DropForeignKey("dbo.Utilisateurs", "PrivilegeId", "dbo.Privileges");
            DropForeignKey("dbo.Transactions", "NumeroCompte", "dbo.Comptes");
            DropForeignKey("dbo.Comptes", "ClientId", "dbo.Client");
            DropIndex("dbo.Utilisateurs", new[] { "PrivilegeId" });
            DropIndex("dbo.Transactions", new[] { "NumeroCompte" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.Comptes", new[] { "ClientId" });
            DropTable("dbo.Privileges");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Transactions");
            DropTable("dbo.Comptes");
            DropTable("dbo.Client");
            DropTable("dbo.Agences");
        }
    }
}
