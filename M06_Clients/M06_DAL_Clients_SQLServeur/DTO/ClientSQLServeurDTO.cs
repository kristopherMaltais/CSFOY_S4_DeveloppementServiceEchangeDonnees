using M06_CasUtilisation_Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_DAL_Clients_SQLServeur.DTO
{
    [Table("CLIENT")]
    public class ClientSQLServeurDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        [Key]
        [Column("IDENTIFIANT")]
        public Guid Identifiant { get; private set; }

        [Column("PRENOM")]
        public string Prenom { get; private set; }

        [Column("NOM")]
        public string Nom { get; private set; }

        [Column("COURRIEL")]
        public string Courriel { get; private set; }

        [Column("TELEPHONE")]
        public string NumeroTelephone { get; private set; }

        // ** Constructeur ** //
        public ClientSQLServeurDTO()
        {
            ;
        }
        public ClientSQLServeurDTO(Client p_client)
        {
            this.Identifiant = p_client.Identifiant;
            this.Prenom = p_client.Prenom;
            this.Nom = p_client.Nom;
            this.Courriel = p_client.Courriel;
            this.NumeroTelephone = p_client.NumeroTelephone;
        }

        // ** methodes ** //
    }
}
