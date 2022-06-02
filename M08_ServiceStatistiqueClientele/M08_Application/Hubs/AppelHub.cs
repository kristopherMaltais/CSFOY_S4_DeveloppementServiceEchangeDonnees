using M08_Application.Entite;
using M08_BL_ServiceStatistiqueClientele;
using Microsoft.AspNetCore.SignalR;

namespace M08_Application.Hubs
{
    public class AppelHub : Hub
    {
        // ** Champs ** //
        private IDepot m_depotAppel;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public AppelHub(IDepot p_depotAppel)
        {
            this.m_depotAppel = p_depotAppel;
        }

        // ** Méthodes ** //
        public async override Task OnConnectedAsync()
        {
            Statistiques statistique = this.m_depotAppel.ObtenirStatistiques();
            await Clients.Caller.SendAsync("afficherStatistique", statistique);
            await base.OnConnectedAsync();
        }
    }
}
