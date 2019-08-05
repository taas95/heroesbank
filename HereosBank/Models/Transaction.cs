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
        public DateTime DateTransaction { get; set; }
        public string TypeTransaction { get; set; }
        public float Montant { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Utilisateur User { get; set; }
        public string NumeroCompte { get; set; }
        [ForeignKey("NumeroCompte")]
        public Compte Compte { get; set; }

        public Transaction()
         {

         }
        public Transaction(DateTime date,string type, float montant)
        {
           
            DateTransaction = date;
            TypeTransaction = type;
            Montant = montant;
        }

             
    }
}