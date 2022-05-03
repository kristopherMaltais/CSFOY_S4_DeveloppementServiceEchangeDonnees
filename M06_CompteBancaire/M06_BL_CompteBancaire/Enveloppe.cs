using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_BL_CompteBancaire
{
    public class Enveloppe
    {
        public string Action { get; set; }
        public string Contenu { get; set; }
        public Guid ActionId { get; set; }
        public Compte Compte { get; set; }
        public Transaction Transaction { get; set; }

        public Enveloppe()
        {
            ;
        }
    }
}
