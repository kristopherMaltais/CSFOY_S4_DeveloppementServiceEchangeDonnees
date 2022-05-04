using M06_BL_CompteBancaire;
using M06_DAL_CompteBancaire.DTO;
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
            // Préconditions
            if (p_compteACreer is null)
            {
                throw new ArgumentNullException(nameof(p_compteACreer), "Le compte ne peut pas être null");
            }

            CompteSQLDTO nouveauCompte = new CompteSQLDTO(p_compteACreer);
            this.m_DbContext.Add(nouveauCompte);
            this.m_DbContext.SaveChanges();
            this.m_DbContext.ChangeTracker.Clear();
            Console.WriteLine("test");
        }
        public void CreerTransaction(Transaction p_transactionACreer)
        {
            // Préconditions
            if (p_transactionACreer is null)
            {
                throw new ArgumentNullException(nameof(p_transactionACreer), "La transaction ne peut pas être null");
            }

            TransactionSQLDTO nouvelleTransaction = new TransactionSQLDTO(p_transactionACreer);
            this.m_DbContext.Add(nouvelleTransaction);
            this.m_DbContext.SaveChanges();
            this.m_DbContext.ChangeTracker.Clear();
        }
        public void ModifierCompte(Compte p_compteAModifier)
        {
            // Préconditions
            if (p_compteAModifier is null)
            {
                throw new ArgumentNullException(nameof(p_compteAModifier), "Le compte ne peut pas être null");
            }

            CompteSQLDTO compteAModifier = new CompteSQLDTO(p_compteAModifier);
            Console.WriteLine(compteAModifier.CompteID.ToString());
            this.m_DbContext.Update(compteAModifier);
            this.m_DbContext.SaveChanges();
            this.m_DbContext.ChangeTracker.Clear();
        }
        public Compte? ObtenirCompte(Guid p_identifiantCompte)
        {
            return this.m_DbContext.Comptes.Where(compte => compte.CompteID == p_identifiantCompte.ToString()).SingleOrDefault()?.VersEntite();
        }
        public IEnumerable<Compte> ObtenirComptes()
        {
            List<Compte> comptes = this.m_DbContext.Comptes.Select(compte => compte.VersEntite()).ToList();
            return comptes;
        }
        public Transaction? ObtenirTransaction(Guid p_identifiantTransaction)
        {
            return this.m_DbContext.Transactions.Where(transaction => transaction.TransactionID == p_identifiantTransaction.ToString()).SingleOrDefault()?.VersEntite();
        }
        public IEnumerable<Transaction> ObtenirTransactions()
        {
            List<Transaction> transactions = this.m_DbContext.Transactions.Select(transaction => transaction.VersEntite()).ToList();
            return transactions;
        }
    }
}
