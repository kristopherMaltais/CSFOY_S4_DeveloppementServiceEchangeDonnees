namespace M03_REST01.SERVICE_Municipalite
{
    public class ManipulationMunicipalites
    {

        // ** Champs ** //
        private IDepotMunicipalite m_depotMunicipalite;

        // ** Propriétés ** //

        // ** Constructeur ** //
        public ManipulationMunicipalites(IDepotMunicipalite p_depotMunicipalite)
        {
            this.m_depotMunicipalite = p_depotMunicipalite;
        }

        // ** Méthodes ** //
        public IEnumerable<Municipalite> ListerMunicipalites()
        {
            Dictionary<int, Municipalite> municipalites =  this.m_depotMunicipalite.ListerMunicipalite();
            return municipalites.Select(municipalite => municipalite.Value); 
        }
        public Municipalite ObtenirMunicipalite(int p_codeGeographique)
        {
            return this.m_depotMunicipalite.ChercherMunicipaliteParCodeGeographique(p_codeGeographique);
        }
        public void SupprimerMunicipalite(int p_codeGeographique)
        {
            // Précondition
            if(p_codeGeographique < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(p_codeGeographique), "identifiant ne peut pas être négatif");
            }

            this.m_depotMunicipalite.DesactiverMunicipalite(this.ObtenirMunicipalite(p_codeGeographique));
        }
        public void AjouterMunicipalite(Municipalite p_municipalite)
        {
            // Précondition
            if(p_municipalite is null)
            {
                throw new ArgumentNullException(nameof(p_municipalite), "La municipalite ne peut pas être null");
            }
            this.m_depotMunicipalite.AjouterMunicipalite(p_municipalite);
        }
        public void MAJMunicipalite(Municipalite p_municipalite)
        {
            // Précondition
            if(p_municipalite is null)
            {
                throw new ArgumentNullException(nameof(p_municipalite), "La municipalite ne peut pas être null");
            }

            this.m_depotMunicipalite.MAJMunicipalite(p_municipalite);
        }
    }
}
