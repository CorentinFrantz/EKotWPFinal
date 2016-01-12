using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetC.Model
{
    public class Permanence
    {
        public int idPerma { get; set; }
        public string datePerma { get; set; }
        public int heureDebutPerma { get; set; }
        public int heureFinPerma { get; set; }

        public Permanence(int idPerma, string datePerma, int heureDebutPerma, int heureFinPerma)
        {
            this.idPerma = idPerma;
            this.datePerma = datePerma;
            this.heureDebutPerma = heureDebutPerma;
            this.heureFinPerma = heureFinPerma;
        }

        public Permanence() { }

        public string getHeure()
        {
            string heure = this.heureDebutPerma + " - " + this.heureFinPerma;
            return heure;
        }
    }
}
