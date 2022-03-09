using System;

namespace M01_Srv_Municipalite
{
    public class Municipalite
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public int CodeGeographique { get; set; }
        public string NomMunicipalite { get; set; }
        public string AdresseCourriel { get; set; }
        public string AdresseWeb { get; set; }
        public DateTime? DateProchaineElection { get; set; }
        public bool EstActif { get; set; }

        // ** Constructeurs ** //
        public Municipalite(int p_codeGeographique, string p_nomMunicipalite, string p_adresseCourriel, string p_adresseWeb, DateTime? p_dateProchaineElectection, bool p_estActif = true)
        {
            this.CodeGeographique = p_codeGeographique;
            this.NomMunicipalite = p_nomMunicipalite;
            this.AdresseCourriel = p_adresseCourriel;
            this.AdresseWeb = p_adresseWeb;
            this.DateProchaineElection = p_dateProchaineElectection;
            this.EstActif = p_estActif;
        }

        // ** Méthodes ** //

        public override string ToString()
        {
            return $"{this.CodeGeographique}   {this.NomMunicipalite}   {this.AdresseCourriel}   {this.AdresseWeb}   {this.DateProchaineElection}   {this.EstActif}";
        }
    }
}