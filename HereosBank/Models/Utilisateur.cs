﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace HereosBank.Models
{
    //public class Utilisateur
    public class Utilisateur : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NumeroCarte { get; set; }
        public string Sexe { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Email { get; set; }
        public string Mdp { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
        public int PrivilegeId { get; set; }

        [ForeignKey("PrivilegeId")]
        public Privilege Privilege { get; set; }


        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Utilisateur> manager)
        //{
        //    // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Ajouter les revendications personnalisées de l’utilisateur ici
        //    return userIdentity;
        //}
        public Utilisateur()
        {
            Transactions = new List<Transaction>();
        }

        public Utilisateur(string nom, string prenom, string numCarte,string sexe,DateTime dateNaissance,string email,string mdp, List<Transaction> transactions)
        {
           
            Nom = nom;
            Prenom = prenom;
            NumeroCarte = numCarte;
            Sexe = sexe;
            DateNaissance = dateNaissance;
            Email = email;
            Mdp = mdp;
            Transactions = transactions;
            
        }
    }
}