using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_BL_CompteBancaire
{
    public class Transaction
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public Guid TransactionID { get; set; }
        public Guid CompteID { get; set; }
        public string TypeTransaction { get; set; }
        public DateTime Date { get; set; }
        public Decimal Montant { get; set; }

        // ** Constructeurs ** //
        public Transaction()
        {
            ;
        }
        //public Transaction(Guid p_CompteID, string p_typeTransaction)
        //{
        //    this.CompteID = p_CompteID;
        //    this.TypeTransaction = p_typeTransaction;
        //    this.TransactionID = Guid.NewGuid();
        //}
        public Transaction(Guid p_transactionId, Guid p_CompteID, string p_typeTransaction, DateTime p_date, Decimal p_montant)
        {
            this.CompteID = p_CompteID;
            this.TypeTransaction = p_typeTransaction;
            this.TransactionID = p_transactionId;
            this.Date = p_date;
            this.Montant = p_montant;
        }

        // ** Méthodes ** //
    }
}
