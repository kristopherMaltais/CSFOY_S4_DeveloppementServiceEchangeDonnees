using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M03_ServicesSOAP
{
    public class MunicipaliteSOAPDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public int CodeGeographique { get; set; }
        public string NomMunicipalite { get; set; }
        public string AdresseCourriel { get; set; }
        public string AdresseWeb { get; set; }
        public DateTime? DateProchaineElection { get; set; }
        public bool Actif { get; set; }

        // ** Constructeur ** //
        public MunicipaliteSOAPDTO()
        {
            ;
        }
        public MunicipaliteSOAPDTO(int p_codeGeographique, string p_nomMunicipalite, string p_adresseCourriel, string p_adresseWeb, DateTime? p_dateProchaineElection, bool p_actif)
        {
            this.CodeGeographique = p_codeGeographique;
            this.NomMunicipalite = p_nomMunicipalite;
            this.AdresseCourriel = p_adresseCourriel;
            this.AdresseWeb = p_adresseWeb;
            this.DateProchaineElection = p_dateProchaineElection;
            this.Actif = p_actif;
        }

        // ** Methodes ** //
    }
}
