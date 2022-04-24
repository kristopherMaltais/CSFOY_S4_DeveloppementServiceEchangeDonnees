using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_CasUtilisation_Clients
{
    public class Client
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public Guid Identifiant { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Courriel { get; set; }
        public string NumeroTelephone { get; set; }

        // ** Constructeur ** //
        public Client(Guid p_identifiant, string p_prenom, string p_nom, string p_courriel, string p_numeroTelephone)
        {
            this.Identifiant = p_identifiant;
            this.Prenom = p_prenom;
            this.Nom = p_nom;
            this.Courriel = p_courriel;
            this.NumeroTelephone = p_numeroTelephone;
        }

        // ** methodes ** //

        public override string ToString()
        {
            return $"Id: {this.Identifiant} -- Prenom: {this.Prenom} -- Nom: {this.Nom} -- Courriel {this.Courriel} -- tel: {this.NumeroTelephone}";
        }
    }
}
