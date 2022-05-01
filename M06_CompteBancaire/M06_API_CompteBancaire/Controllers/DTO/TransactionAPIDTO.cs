using M06_BL_CompteBancaire;

namespace M06_API_CompteBancaire.Controllers.DTO
{
    public class TransactionAPIDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public Guid TransactionID { get; set; }
        public Guid CompteID { get; set; }
        public string TypeTransaction { get; set; }

        // ** Constructeurs ** //
        public TransactionAPIDTO()
        {
            ;
        }
        public TransactionAPIDTO(Transaction p_transaction)
        {
            this.TransactionID = p_transaction.TransactionID;
            this.CompteID = p_transaction.CompteID;
            this.TypeTransaction = p_transaction.TypeTransaction;
        }

        // ** Méthodes ** //
        public Transaction VersIdentite()
        {
            return new Transaction(this.TransactionID, this.CompteID, this.TypeTransaction);
        }
    }
}
