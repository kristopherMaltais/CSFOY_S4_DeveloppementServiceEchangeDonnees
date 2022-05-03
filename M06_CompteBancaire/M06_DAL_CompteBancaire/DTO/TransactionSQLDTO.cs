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
        public string TransactionID { get; set; }

        [Column("COMPTEIDENTIFIANT")]
        public string CompteID { get; set; }

        [Column("TYPETRANSACTION")]
        public string TypeTransaction { get; set; }

        // ** Constructeurs ** //
        public TransactionSQLDTO()
        {
            ;
        }
        public TransactionSQLDTO(Transaction p_transactionAConvertir)
        {
            this.TransactionID = p_transactionAConvertir.TransactionID.ToString();
            this.CompteID = p_transactionAConvertir.CompteID.ToString();
            this.TypeTransaction = p_transactionAConvertir.TypeTransaction;
        }

        // ** Méthodes ** //
        public Transaction VersEntite()
        {
            return new Transaction(Guid.Parse(this.TransactionID), Guid.Parse(this.CompteID), this.TypeTransaction);
        }
    }
}
