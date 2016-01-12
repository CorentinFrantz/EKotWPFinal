using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetC.Model
{
    public class RendezVous
    {
        public int idRendezVous { get; set; }
        public int idPerma { get; set; }
        public string nomEtudiant { get; set; }
        public string prenomEtudiant { get; set; }
        public int telephoneEtudiant { get; set; }
        public string emailEtudiant { get; set; }
        public string probleme { get; set; }

        public RendezVous (int idPerma, string nomEtudiant, string prenomEtudiant, int telephoneEtudiant, string mailEtudiant, string probleme)
        {
            this.idPerma = idPerma;
            this.nomEtudiant = nomEtudiant;
            this.prenomEtudiant = prenomEtudiant;
            this.telephoneEtudiant = telephoneEtudiant;
            this.emailEtudiant = mailEtudiant;
            this.probleme = probleme;
        }

        public RendezVous() { }
    }
}
