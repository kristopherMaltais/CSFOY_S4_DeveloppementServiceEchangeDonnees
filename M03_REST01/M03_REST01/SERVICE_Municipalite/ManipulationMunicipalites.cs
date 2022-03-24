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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
