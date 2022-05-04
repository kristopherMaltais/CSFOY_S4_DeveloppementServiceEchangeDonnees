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
        public DateTime Date { get; set; }
        public Decimal Montant { get; set; }

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
            this.Date = p_transaction.Date;
            this.Montant = p_transaction.Montant;
        }

        // ** Méthodes ** //
        public Transaction VersEntite()
        {
            return new Transaction(this.TransactionID, this.CompteID, this.TypeTransaction, this.Date, this.Montant);
        }
    }
}
