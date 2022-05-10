using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M07_TraitementCommande_producteur
{
    public class Commande
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public string NomClient { get; private set; }
        public Guid Reference { get; private set; }
        public List<Article> Articles { get; private set; }

        // ** Constructeurs ** //
        public Commande(string p_nomClient, List<Article> p_articles)
        {
            this.NomClient = p_nomClient;
            this.Articles = p_articles;
            this.Reference = Guid.NewGuid();
        }

        // ** Méthodes ** //
    }
}
