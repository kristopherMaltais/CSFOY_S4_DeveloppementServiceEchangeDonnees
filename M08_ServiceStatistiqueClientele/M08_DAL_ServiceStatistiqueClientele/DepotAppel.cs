using M08_Application.Entite;
using M08_BL_ServiceStatistiqueClientele;

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
        public Statistiques ObtenirStatistiques()
        {
            List<Appel> appels = this.ObtenirAppels();

            int nombreAppel = appels.Count;
            int nombreAgent = appels.DistinctBy( appels => appels.IdentifiantAgent).Count();


            List<Appel> appelsTerminee = appels.Where(appel => appel.FinAppel is not null).ToList();
            float tempsTotalAppel = 0f;

            foreach (Appel appel in appelsTerminee)
            {
                TimeSpan duree = (TimeSpan)(appel.DebutAppel - appel.FinAppel);
                tempsTotalAppel += (float)duree.TotalMinutes;
            }

            float tempsMoyenAppel = appelsTerminee.Count == 0 ? 0 : tempsTotalAppel / appelsTerminee.Count;

            return new Statistiques(nombreAppel, tempsMoyenAppel, nombreAgent);
        }
    }
}