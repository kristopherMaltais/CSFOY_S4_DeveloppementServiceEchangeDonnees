namespace M06_CasUtilisation_Clients
{
    public class ManipulationClient
    {
        // ** Champs ** //
        private IDepotClients m_clients;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public ManipulationClient(IDepotClients m_depotClients)
        {
            m_clients = m_depotClients;
        }

        // ** Méthodes ** //
        public void Creer(Client p_client)
        {
            m_clients.CreerClient(p_client);
        }
    }
}