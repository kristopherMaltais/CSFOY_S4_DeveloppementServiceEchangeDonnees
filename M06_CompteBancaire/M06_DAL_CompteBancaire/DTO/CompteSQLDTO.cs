using M06_BL_CompteBancaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_DAL_CompteBancaire.DTO
{
    public class CompteSQLDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public Guid CompteID { get; set; }
        public string TypeCompte { get; set; }

        // ** Constructeurs ** //
        public CompteSQLDTO(Compte p_compteAConvertir)
        {
            this.CompteID = p_compteAConvertir.CompteID;
            this.TypeCompte = p_compteAConvertir.TypeCompte;
        }

        // ** Méthodes ** //
        public Compte VersEntite()
        {
            return new Compte(this.CompteID, this.TypeCompte);
        }

    }
}
