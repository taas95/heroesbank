using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HereosBank.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }
        [Column("Prenom")]
        public string Prenom { get; set; }
        [MaxLength(50)]
        public string Sexe { get; set; }
        public DateTime DateNaissance { get; set; }
        public string NumCarte { get; set; }
        public string Adresse { get; set; }
        public virtual List<Compte> Comptes { get; set; }

        public Client()
        {
            Comptes = new List<Compte>();
        }
        public Client(string nom,string prenom,string sexe,DateTime dateNaissance,string numCarte,string adresse)
        {
            
            Nom = nom;
            Prenom = prenom;
            Sexe = sexe;
            DateNaissance = dateNaissance;
            NumCarte = numCarte;
            Adresse = adresse;
        }
    }
}