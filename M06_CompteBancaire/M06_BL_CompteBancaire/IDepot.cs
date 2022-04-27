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
        public void Modificier(Compte p_compteAModifier);
        public IEnumerable<Compte> ObtenirTransactions();
        public Compte ObtenirTransaction(Guid p_identifiantTransaction);
        public void CreerTransaction(Compte p_transactionACreer);

    }
}
