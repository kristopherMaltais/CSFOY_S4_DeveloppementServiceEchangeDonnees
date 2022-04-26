using M06_CasUtilisation_Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_Clients_Consommateur
{
    public class ClientDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Courriel { get; set; }
        public string NumeroTelephone { get; set; }

        // ** Constructeur ** //
        public ClientDTO(string p_prenom, string p_nom, string p_courriel, string p_numeroTelephone)
        {
            this.Prenom = p_prenom;
            this.Nom = p_nom;
            this.Courriel = p_courriel;
            this.NumeroTelephone = p_numeroTelephone;
        }

        // ** methodes ** //
        public Client versEntite()
        {
            Client nouveauClient = new Client(this.Prenom, this.Nom, this.Courriel, this.NumeroTelephone);
            return nouveauClient;
        }
    }
}
