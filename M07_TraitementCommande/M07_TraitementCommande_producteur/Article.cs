using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M07_TraitementCommande_producteur
{
    public class Article
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public Guid Reference { get; private set; }
        public string Nom { get; private set; }
        public decimal Prix { get; private set; }
        public int Quantite { get; private set; }

        // ** Constructeurs ** //
        public Article(string p_nom, decimal p_prix, int p_quantite)
        {
            this.Nom = p_nom;
            this.Prix = p_prix;
            this.Quantite = p_quantite;
            this.Reference = Guid.NewGuid();
        }

        // ** Méthodes ** //
    }
}
