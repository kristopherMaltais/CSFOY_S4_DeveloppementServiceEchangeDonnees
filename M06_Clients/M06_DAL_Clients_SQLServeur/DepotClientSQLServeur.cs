using M06_CasUtilisation_Clients;
using M06_DAL_Clients_SQLServeur.DTO;

namespace M06_DAL_Clients_SQLServeur
{
    public class DepotClientSQLServeur : IDepotClients
    {
        // ** Champs ** //
        private ApplicationDBContext m_DbContext;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public DepotClientSQLServeur(ApplicationDBContext p_dbContext)
        {
            // Préconditions
            if (p_dbContext is null)
            {
                throw new ArgumentNullException(nameof(p_dbContext), "le dbContext ne peut pas être null");
            }

            this.m_DbContext = p_dbContext;
        }

        // ** Méthodes ** //
        public void CreerClient(Client p_client)
        {
            // Préconditions
            if (p_client is null)
            {
                throw new ArgumentNullException(nameof(p_client), "La municipalité ne peut pas être null");
            }

            ClientSQLServeurDTO nouveauClient = new ClientSQLServeurDTO(p_client);
            this.m_DbContext.Add(nouveauClient);
            this.m_DbContext.SaveChanges();
            this.m_DbContext.ChangeTracker.Clear();
        }
    }
}