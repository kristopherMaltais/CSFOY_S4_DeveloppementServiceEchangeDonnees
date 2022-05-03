namespace M06_API_CompteBancaire.Controllers.DTO
{
    public class EnveloppeDTO
    {
        // ** Champs ** //

        // ** Propriété ** //
        public string Action { get; set; }
        public string Contenu { get; set; }
        public Guid ActionId { get; set; }
        public CompteAPIDTO Compte { get; set; }
        public TransactionAPIDTO Transaction { get; set; }


        // ** Constructeur ** //
        public EnveloppeDTO(CompteAPIDTO p_compte, string p_action)
        {
            this.Action = p_action;
            this.Contenu = "compte";
            this.ActionId = Guid.NewGuid();
            this.Compte = p_compte;
            this.Transaction = null;
            
           
        }
        public EnveloppeDTO(TransactionAPIDTO p_transaction, string p_action)
        {
            this.Action = p_action;
            this.Contenu = "transaction";
            this.ActionId = Guid.NewGuid();
            this.Transaction = p_transaction;
            this.Compte = null;
        }

        // ** méthodes ** //
    }
}
