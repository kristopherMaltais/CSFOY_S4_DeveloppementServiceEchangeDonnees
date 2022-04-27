using M06_BL_CompteBancaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_DAL_CompteBancaire
{
    public class DepotCompteBancaire : IDepot
    {
        // ** Champs ** //
        private ApplicationDBContext m_DbContext;

        // ** Propriétés ** //

        // ** Constructeur ** //
        public DepotCompteBancaire(ApplicationDBContext p_dbContext)
        {
            // Préconditions
            if (p_dbContext is null)
            {
                throw new ArgumentNullException(nameof(p_dbContext), "le dbContext ne peut pas être null");
            }

            this.m_DbContext = p_dbContext;
        }

        // ** Méthodes ** //
        public void CreerCompte(Compte p_compteACreer)
        {
            throw new NotImplementedException();
        }

        public void CreerTransaction(Compte p_transactionACreer)
        {
            throw new NotImplementedException();
        }

        public void Modificier(Compte p_compteAModifier)
        {
            throw new NotImplementedException();
        }

        public Compte ObtenirCompte(Guid p_identifiantCompte)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Compte> ObtenirComptes()
        {
            throw new NotImplementedException();
        }

        public Compte ObtenirTransaction(Guid p_identifiantTransaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Compte> ObtenirTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
