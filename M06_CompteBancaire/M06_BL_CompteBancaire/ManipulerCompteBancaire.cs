namespace M06_BL_CompteBancaire
{
    public class ManipulerCompteBancaire
    {
        // ** champs ** //
        private IDepot m_depotCompteBancaire;

        // ** propriétés ** //

        // ** constructeurs ** //
        public ManipulerCompteBancaire(IDepot p_depot)
        {
            this.m_depotCompteBancaire = p_depot;
        }

        // ** Méthodes ** //
        public void CreerCompte(Compte p_compteACreer)
        {
            this.m_depotCompteBancaire.CreerCompte(p_compteACreer);

        }
        public void CreerTransaction(Transaction p_transactionACreer)
        {
           this.m_depotCompteBancaire.CreerTransaction(p_transactionACreer);
        }
        public void ModifierCompte(Compte p_compteAModifier)
        {
           this.m_depotCompteBancaire.ModifierCompte(p_compteAModifier);

        }
        public Compte ObtenirCompte(Guid p_identifiantCompte)
        {
            return this.m_depotCompteBancaire.ObtenirCompte(p_identifiantCompte);
        }
        public IEnumerable<Compte> ObtenirComptes()
        {
            return this.m_depotCompteBancaire.ObtenirComptes();

        }
        public Transaction ObtenirTransaction(Guid p_identifiantTransaction)
        {
            return this.m_depotCompteBancaire.ObtenirTransaction(p_identifiantTransaction);
        }
        public IEnumerable<Transaction> ObtenirTransactions()
        {
            return this.m_depotCompteBancaire.ObtenirTransactions();
        }

    }
}