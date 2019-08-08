using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HereosBank.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name ="Date de la transaction")]
        public DateTime DateTransaction { get; set; }

        [Display(Name = "Type de la transaction")]
        public string TypeTransaction { get; set; }

        [Display(Name = "Montant")]
        public float Montant { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Utilisateur User { get; set; }

        [Display(Name = "Numéro de compte")]
        public string NumeroCompte { get; set; }
        [ForeignKey("NumeroCompte")]
        public Compte Compte { get; set; }

        public Transaction()
        {

        }
        public Transaction(DateTime date, string type, float montant)
        {

            DateTransaction = date;
            TypeTransaction = type;
            Montant = montant;
        }


    }
}