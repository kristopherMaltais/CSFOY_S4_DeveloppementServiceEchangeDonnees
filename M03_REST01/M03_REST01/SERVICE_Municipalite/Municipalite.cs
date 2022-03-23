namespace M03_REST01.SERVICE_Municipalite
{
    public class Municipalite
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public int CodeGeographique { get; set; }
        public string? NomMunicipalite { get; set; }
        public string? AdresseCourriel { get; set; }
        public string? AdresseWeb { get; set; }
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
        public bool ComparerMunicipalite(Municipalite p_municipaliteAComparer)
        {
            // Precondition
            if (p_municipaliteAComparer is null)
            {
                throw new ArgumentNullException(nameof(p_municipaliteAComparer), "La municipalite ne peut pas être null");
            }

            bool estMunicipaliteIdentique = true;

            if (this.NomMunicipalite != p_municipaliteAComparer.NomMunicipalite)
            {
                estMunicipaliteIdentique = false;
            }
            else if (this.AdresseCourriel != p_municipaliteAComparer.AdresseCourriel)
            {
                estMunicipaliteIdentique = false;
            }
            else if (this.AdresseWeb != p_municipaliteAComparer.AdresseWeb)
            {
                estMunicipaliteIdentique = false;
            }
            else if (this.DateProchaineElection != p_municipaliteAComparer.DateProchaineElection)
            {
                estMunicipaliteIdentique = false;
            }
            else if (this.EstActif != p_municipaliteAComparer.EstActif)
            {
                estMunicipaliteIdentique = false;
            }

            return estMunicipaliteIdentique;
        }
        public override string ToString()
        {
            return $"{this.CodeGeographique}   {this.NomMunicipalite}   {this.AdresseCourriel}   {this.AdresseWeb}   {this.DateProchaineElection}   {this.EstActif}";
        }
    }
}
