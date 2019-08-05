using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HereosBank.Models
{
    public class Agence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgence { get; set; }
        public string Nom { get; set; }
        public string AdresseAgence { get; set; }

        public Agence()
        {

        }
        public Agence(string nom,string adresseAgence)
        {
            
            Nom = nom;
            AdresseAgence = adresseAgence;
        }
    }
}