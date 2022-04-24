using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_Clients_Producteur_UI
{
    public class MessageClient
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string courriel { get; set; }
        public string NumeroTelephone {get; set; }

        // ** Constructeurs ** //
        public MessageClient(string p_prenom, string p_nom, string p_courriel, string p_numeroTelephone)
        {
            this.Prenom = p_prenom;
            this.Nom = p_nom;
            this.courriel = p_courriel;
            this.NumeroTelephone = p_numeroTelephone;
        }

        // ** Méthodes ** //
    }
}
