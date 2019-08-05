using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HereosBank.Models
{
    public class Privilege
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Profile { get; set; }
        
        public virtual List<Utilisateur> Utilisateurs { get; set; }
        
        public Privilege()
        {
            Utilisateurs = new List<Utilisateur>();
        }
        public Privilege(string profile, List<Utilisateur> utilisateurs)
        {
           
            Profile = profile;
            Utilisateurs = utilisateurs;
        }
    }
}