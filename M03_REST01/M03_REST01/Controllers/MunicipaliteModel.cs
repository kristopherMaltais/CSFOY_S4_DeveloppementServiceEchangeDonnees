using M03_REST01.SERVICE_Municipalite;

namespace M03_REST01.Controllers
{
    public class MunicipaliteModel
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public int MunicipaliteId { get; set; }
        public string NomMunicipalite { get; set; }
        public string AdresseCourriel { get; set; }
        public string AdresseWeb { get; set; }
        public DateTime? DateProchaineElection { get; set; }
        public bool Actif { get; set; 
        }

        // ** Constructeurs ** //
        public MunicipaliteModel()
        {
            ;
        }
        public MunicipaliteModel(Municipalite p_municipalite)
        {
            this.MunicipaliteId = p_municipalite.CodeGeographique;
            this.NomMunicipalite = p_municipalite.NomMunicipalite;
            this.AdresseCourriel = p_municipalite.AdresseCourriel;
            this.AdresseWeb = p_municipalite.AdresseWeb;
            this.DateProchaineElection = p_municipalite.DateProchaineElection;
            this.Actif = p_municipalite.EstActif;
        }

        // ** Méthodes ** //
        public Municipalite VersIdentite()
        {
            return new Municipalite(this.MunicipaliteId, this.NomMunicipalite, this.AdresseCourriel, this.AdresseWeb, this.DateProchaineElection, this.Actif);
        }
    }
}
