using M08_Application.Entite;

namespace M08_DAL_ServiceStatistiqueClientele
{
    public class DepotAppel : IDepot
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public List<Appel> Appels { get; set; }

        // ** Constructeurs ** //
        public DepotAppel()
        {
            this.Appels = new List<Appel>();
        }

        // ** Méthodes ** //
        public void CreerAppel(Appel p_appelAAjouter)
        {
            this.Appels.Add(p_appelAAjouter);
        }
        public void MAJAppel(Guid? p_identifiantAppel)
        {
            Appels.Where(appel => appel.IdentifiantAppel == p_identifiantAppel).Select(appel => appel.FinAppel = DateTime.Now);

        }
        public List<Appel> ObtenirAppels()
        {
            return this.Appels;
        }
    }
}