using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M07_TraitementCommande_producteur
{
    public class GenerateurCommande
    {
        // ** Champs ** //
        private List<string> m_nomsClients;
        private List<Article> m_articles;
        private List<decimal> m_prix;
        private Random m_aleatoire;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public GenerateurCommande()
        {
            this.m_nomsClients = new List<string>() { "Bob", "Pifou", "Raphael", "Olivier", "Gabriel" };
            Article article1 = new Article("Calculatrice", 10.25m, 2);
            Article article2 = new Article("Ordinateur", 1000m, 1);
            Article article3 = new Article("Écouteur", 200m, 3);
            Article article4 = new Article("clavier", 100m, 1);
            Article article5 = new Article("Souris", 25m, 3);
            this.m_articles = new List<Article> { article1, article2, article3, article4, article5 };
            this.m_aleatoire = new Random();
        }

        // ** Méthodes ** //
        public Commande GenererCommande()
        {
            string nomClient = this.m_nomsClients[this.m_aleatoire.Next(1, 5)];
            List<Article> articles = new List<Article>();
            int nombreItem = this.m_aleatoire.Next(1, 6);

            for (int i = 0; i < nombreItem; i++)
            {
                articles.Add(this.m_articles[i]);
            }

            return new Commande(nomClient, articles);
        }
        public string GenererTypeCompte()
        {
            List<string> typeCompte = new List<string>() { "normal", "premium" };
            return typeCompte[this.m_aleatoire.Next(1, 3)];
        }
    }
}
