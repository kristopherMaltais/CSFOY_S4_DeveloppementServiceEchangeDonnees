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
        public string NomClient { get; set; }
        public Guid Reference { get; set; }
        public List<Article> Articles { get; set; }

        // ** Constructeurs ** //
        public Commande()
        {
            ;
        }
        public Commande(string p_nomClient, List<Article> p_articles)
        {
            this.NomClient = p_nomClient;
            this.Articles = p_articles;
            this.Reference = Guid.NewGuid();
        }

        // ** Méthodes ** //
        public override string ToString()
        {
            StringBuilder texte = new StringBuilder();
            texte.Append($"Nom: {this.NomClient} --- Guid: {this.Reference}");
            texte.AppendLine();
            //foreach(Article article in this.Articles)
            //{
            //    texte.Append($"Guid: {article.Reference} --- Nom: {article.Nom} --- Prix: {article.Prix}");
            //}

            return texte.ToString();
        }
    }
}
