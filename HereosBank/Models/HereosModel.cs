namespace HereosBank.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HereosModel : IdentityDbContext<Utilisateur>
    {
        // Your context has been configured to use a 'HereosModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HereosBank.Models.HereosModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HereosModel' 
        // connection string in the application configuration file.
        public HereosModel()
            : base("name=HereosModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Agence> Agences { get; set; }
        public virtual DbSet<Compte> Comptes { get; set; }
        public virtual DbSet<Utilisateur> Users { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}