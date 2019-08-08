using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HereosBank.Models
{
    public class Compte
    {
        [Key]
        [Display(Name ="Numéro de compte")]
        public string NumCompte { get; set; }
        public float Solde { get; set; }
        [Display(Name = "Date de création")]

        public DateTime DateCreation { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public Compte()
        {
            Transactions = new List<Transaction>();
        }
        public Compte(string numCompte, float solde, DateTime dateCreation, List<Transaction> transactions)
        {
            NumCompte = numCompte;
            Solde = solde;
            DateCreation = dateCreation;
            Transactions = transactions;
        }
    }
}