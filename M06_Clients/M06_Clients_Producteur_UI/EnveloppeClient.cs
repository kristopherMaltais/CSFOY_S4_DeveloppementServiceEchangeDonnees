using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_Clients_Producteur_UI
{
    internal class EnveloppeClient
    {
        // ** Champs ** //
        
        // ** Propriété ** //
        public string Action { get; set; }
        public Guid ActionId { get; set; }
        public MessageClient Client { get; set; }
        
        // ** Constructeur ** //
        public EnveloppeClient(MessageClient p_client)
        {
            this.Action = "create";
            this.ActionId = Guid.NewGuid();
            this.Client = p_client;
        }

        // ** méthodes ** //
    }
}
