using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetC.Models
{
    public class Admin
    {
        public int idadministrateur { get; set; }
        public String motDePasse { get; set; }

        public Admin(int idadministrateur, String motDePasse)
        {
            this.idadministrateur = idadministrateur;
            this.motDePasse = motDePasse;
        }

        public Admin() { }
    }
}
