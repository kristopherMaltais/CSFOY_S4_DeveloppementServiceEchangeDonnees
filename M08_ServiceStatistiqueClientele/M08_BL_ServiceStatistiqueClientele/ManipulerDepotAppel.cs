using M08_Application.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M08_BL_ServiceStatistiqueClientele
{
    public class ManipulerDepotAppel
    {
        // ** Champs ** //
        private IDepot m_depotAppel;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public ManipulerDepotAppel(IDepot p_depotAppel)
        {
            this.m_depotAppel = p_depotAppel;
        }

        // ** Méthodes ** //
        public void CreerAppel(Appel m_appelAAjouter)
        {
            this.m_depotAppel.CreerAppel(m_appelAAjouter);
        }
        public void MAJAppel(Guid? p_identifiantAppel)
        {
            this.m_depotAppel.MAJAppel(p_identifiantAppel);
        }
        public List<Appel> ObtenirAppels()
        {
            return this.m_depotAppel.ObtenirAppels();
        }
    }
}
