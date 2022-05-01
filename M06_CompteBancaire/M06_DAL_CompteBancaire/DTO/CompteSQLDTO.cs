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
    [Table("COMPTE")]
    public class CompteSQLDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        [Key]
        [Column("IDENTIFIANT")]
        public string CompteID { get; set; }

        [Column("TYPECOMPTE")]
        public string TypeCompte { get; set; }

        // ** Constructeurs ** //
        public CompteSQLDTO()
        {
            ;
        }
        public CompteSQLDTO(Compte p_compteAConvertir)
        {
            this.CompteID = p_compteAConvertir.CompteID.ToString();
            this.TypeCompte = p_compteAConvertir.TypeCompte;
        }

        // ** Méthodes ** //
        public Compte VersEntite()
        {
            return new Compte(Guid.Parse(this.CompteID), this.TypeCompte);
        }
    }
}
