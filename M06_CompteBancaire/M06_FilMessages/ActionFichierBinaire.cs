using M06_BL_CompteBancaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_FilMessages
{
    public class ActionFichierBinaire : IActionMessage
    {
        public void Executer(byte[] p_message)
        {
            //string nomFichier = this.GenererNomFichierBinaire();
            File.WriteAllBytes($"..\\..\\..\\TransactionsEnErreur\\{this.GenererNomFichierBinaire()}.bin", p_message);
        }
        public string GenererNomFichierBinaire()
        {
            string dateHeure = DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_");
            string identifiantUnique = Guid.NewGuid().ToString();
            return $"{dateHeure}_{identifiantUnique}";
        }
    }
}
