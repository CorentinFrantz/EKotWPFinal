using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetC.Models
{
    public class FAQ
    {
        public int idQuestion { get; set; }
        public String libQuestion { get; set; }
        public String lienExterne { get; set; }

        public FAQ(int idQuestion, String libQuestion, String lienExterne)
        {
            this.idQuestion = idQuestion;
            this.libQuestion = libQuestion;
            this.lienExterne = lienExterne;
        }

    }
}
