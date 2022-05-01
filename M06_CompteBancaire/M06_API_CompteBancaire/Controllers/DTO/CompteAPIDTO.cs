using M06_BL_CompteBancaire;

namespace M06_API_CompteBancaire.Controllers.DTO
{
    public class CompteAPIDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public Guid CompteID { get; set; }
        public string TypeCompte { get; set; }

        // ** Constructeurs ** //
        public CompteAPIDTO()
        {
            ;
        }
        public CompteAPIDTO(Compte p_compte)
        {
           this.CompteID = p_compte.CompteID;
           this.TypeCompte = p_compte.TypeCompte;
        }

        // ** Méthodes ** //
        public Compte VersIdentite()
        {
            return new Compte(this.CompteID, this.TypeCompte);
        }
    }
}
