using M07_TraitementCommande_producteur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M07_TraitementCommande_FIlMessage
{
    public class ActionCourriel : IAction
    {
        public void Executer(Commande p_commandeATraiter)
        {
            Console.WriteLine(p_commandeATraiter.ToString());
        }
    }
}
