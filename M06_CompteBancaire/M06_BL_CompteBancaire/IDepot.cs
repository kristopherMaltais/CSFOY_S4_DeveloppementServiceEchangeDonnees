using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_BL_CompteBancaire
{
    public interface IDepot
    {
        public IEnumerable<Compte> ObtenirComptes();
        public Compte ObtenirCompte(Guid p_identifiantCompte);
        public void CreerCompte(Compte p_compteACreer);
        public void ModifierCompte(Compte p_compteAModifier);
        public IEnumerable<Transaction> ObtenirTransactions();
        public Transaction ObtenirTransaction(Guid p_identifiantTransaction);
        public void CreerTransaction(Transaction p_transactionACreer);

    }
}
