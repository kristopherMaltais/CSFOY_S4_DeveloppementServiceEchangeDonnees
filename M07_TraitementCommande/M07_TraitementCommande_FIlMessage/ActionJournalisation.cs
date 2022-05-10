using M07_TraitementCommande_producteur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace M07_TraitementCommande_FIlMessage
{
    public class ActionJournalisation : IAction
    {
        public void Executer(Commande p_commandeATraiter)
        {
            string message = JsonConvert.SerializeObject(p_commandeATraiter);
            File.WriteAllText($"..\\..\\..\\TransactionsEnErreur\\{this.GenererNomFichierBinaire()}.bin", message);
        }
        public string GenererNomFichierBinaire()
        {
            string dateHeure = DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_");
            string identifiantUnique = Guid.NewGuid().ToString();
            return $"{dateHeure}_{identifiantUnique}";
        }
    }
}
