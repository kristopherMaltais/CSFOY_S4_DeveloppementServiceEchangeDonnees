using M06_BL_CompteBancaire;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_DAL_CompteBancaire.DTO
{
    [Table("COMPTETRANSACTION")]
    public class TransactionSQLDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        [Key]
        [Column("IDENTIFIANT")]
        public Guid TransactionID { get; set; }

        [Column("COMPTEIDENTIFIANT")]
        public Guid CompteID { get; set; }

        [Column("TYPETRANSACTION")]
        public string TypeTransaction { get; set; }

        // ** Constructeurs ** //
        public TransactionSQLDTO()
        {
            ;
        }
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
