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
        // ** Champs ** //

        // ** Propriétés ** //
        [Key]
        [Column("CODEGEOGRAPHIQUE")]
        public int CodeGeographique { get; set; }

        [Column("NOMMUNICIPALITE")]
        public string NomMunicipalite { get; set; }

        [Column("ADRESSECOURRIEL")]
        public string? AdresseCourriel { get; set; }

        [Column("ADRESSEWEB")]
        public string? AdresseWeb { get; set; }

        [Column("DATEPROCHAINEELECTION")]
        public DateTime? DateProchaineElection { get; set; }

        [Column("ESTACTIF")]
        public char EstActif { get; set; }

        // ** Constructeurs ** //
        public MunicipaliteDTO()
        {
            ;
        }
        public MunicipaliteDTO(Municipalite p_municipalite)
        {
            char estActifConverti = p_municipalite.EstActif ? '1' : '0';

            this.CodeGeographique = p_municipalite.CodeGeographique;
            this.NomMunicipalite = p_municipalite.NomMunicipalite;
            this.AdresseCourriel = p_municipalite.AdresseCourriel;
            this.AdresseWeb = p_municipalite.AdresseWeb;
            this.DateProchaineElection = p_municipalite.DateProchaineElection;
            this.EstActif = estActifConverti;

        }

        // ** Méthodes ** //
        public Municipalite VersEntite()
        {
            return new Municipalite(this.CodeGeographique, this.NomMunicipalite, this.AdresseCourriel, this.AdresseWeb, this.DateProchaineElection);
        }

    }
}