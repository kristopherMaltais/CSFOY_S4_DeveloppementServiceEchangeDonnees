using M03_REST01.Entite;

namespace M03_REST01.SERVICE_Municipalite
{
    public interface IDepotMunicipalite
    {
        public Municipalite ChercherMunicipaliteParCodeGeographique(int p_codeGeographique);
        public IEnumerable<Municipalite> ListerMunicipaliteActives();
        public void DesactiverMunicipalite(Municipalite p_municipaliteADesactiver);
        public void AjouterMunicipalite(Municipalite p_municipaliteAAjouter);
        public void MAJMunicipalite(Municipalite p_municipaliteAMettreAJour);
        public Dictionary<int, Municipalite> ListerMunicipalite();
        public ClefAPI ObtenirClefAPI();
    }
}
