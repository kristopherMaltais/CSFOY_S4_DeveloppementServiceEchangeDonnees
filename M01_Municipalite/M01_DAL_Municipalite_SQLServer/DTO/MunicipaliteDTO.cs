using M01_Srv_Municipalite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_DAL_Municipalite_SQLServer.DTO
{
    [Table("MUNICIPALITE")]
    public class MunicipaliteDTO
    {
        [Key]
        [Column("CODEGEOGRAPHIQUE")]
        public int CodeGeographique { get; set; }

        [Column("NOMMUNICIPALITE")]
        public string NomMunicipalite { get; set; }
        
        [Column("ADRESSECOURRIEL")]
        public string AdresseCourriel { get; set; }

        [Column("ADRESSEWEB")]
        public string AdresseWeb { get; set; }

        [Column("DATEPROCHAINEELECTION")]
        public DateTime? DateProchaineElection { get; set; }

        [Column("ESTACTIF")]
        public bool EstActif { get; set; }

        public MunicipaliteDTO()
        {
            ;
        }

        public MunicipaliteDTO(int p_codeGeographique, string p_nomMunicipalite, string p_adresseCourriel, string p_adresseWeb, DateTime? p_dateProchaineElection = null, bool p_estActif)
        {
            this.CodeGeographique = p_codeGeographique;
            this.NomMunicipalite = p_nomMunicipalite;
            this.AdresseCourriel = p_adresseCourriel;
            this.AdresseWeb = p_adresseWeb;
            this.DateProchaineElection = p_dateProchaineElection;
            this.EstActif = p_estActif;

        }

        public Municipalite VersEntite()
        {
            return new Municipalite(this.CodeGeographique, this.NomMunicipalite, this.AdresseCourriel, this.AdresseWeb, this.DateProchaineElection, this.EstActif);
        }

    }
}
