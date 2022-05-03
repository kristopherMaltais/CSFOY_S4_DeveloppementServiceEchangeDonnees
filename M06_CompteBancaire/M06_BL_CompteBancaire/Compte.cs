using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_BL_CompteBancaire
{
    public class Compte
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public Guid CompteID { get; set; }
        public string TypeCompte { get; set; }

        // ** Constructeurs ** //
        public Compte()
        {
            ;
        }
        public Compte(string p_typeCompte)
        {
            this.CompteID = Guid.NewGuid();
            this.TypeCompte = p_typeCompte;
        }

        public Compte(Guid p_compteID, string p_typeCompte)
        {
            this.CompteID = p_compteID;
            this.TypeCompte = p_typeCompte;
        }

        // ** Méthodes ** //
    }
}
