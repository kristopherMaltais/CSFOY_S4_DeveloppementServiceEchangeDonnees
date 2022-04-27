using M06_BL_CompteBancaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_DAL_CompteBancaire.DTO
{
    public class TransactionSQLDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public Guid TransactionID { get; set; }
        public Guid CompteID { get; set; }
        public string TypeTransaction { get; set; }

        // ** Constructeurs ** //
        public TransactionSQLDTO(Transaction p_transactionAConvertir)
        {
            this.TransactionID = p_transactionAConvertir.TransactionID;
            this.CompteID = p_transactionAConvertir.CompteID;
            this.TypeTransaction = p_transactionAConvertir.TypeTransaction;
        }

        // ** Méthodes ** //
        public Transaction VersEntite()
        {
            return new Transaction(this.TransactionID, this.CompteID, this.TypeTransaction);
        }
    }
}
