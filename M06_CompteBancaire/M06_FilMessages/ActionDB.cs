using M06_BL_CompteBancaire;
using M06_DAL_CompteBancaire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_FilMessages
{
    public class ActionDB : IActionMessage
    {
        public void Executer(Byte[] p_message)
        {
            ManipulerCompteBancaire manipuler = this.CreerContexteDAL();
            Enveloppe enveloppe = this.DeserialiserJson(System.Text.Encoding.Default.GetString(p_message));

            if (enveloppe is not null)
            {
                if (enveloppe.Contenu == "compte")
                {
                    if (enveloppe.Action == "creation")
                    {
                        manipuler.CreerCompte(enveloppe.Compte);
                    }

                    if (enveloppe.Action == "modification")
                    {
                        manipuler.ModifierCompte(enveloppe.Compte);
                    }
                }

                if (enveloppe.Contenu == "transaction")
                {
                    if (enveloppe.Action == "creation")
                    {
                        manipuler.CreerTransaction(enveloppe.Transaction);
                    }
                }
            }
        }
        private ManipulerCompteBancaire CreerContexteDAL()
        {
            IDepot debotCompteBancaire = new DepotCompteBancaire(DbContextGeneration.ObtenirApplicationDBContext());
            return new ManipulerCompteBancaire(debotCompteBancaire);
        }
        private Enveloppe DeserialiserJson(string p_message)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            Enveloppe enveloppe = JsonConvert.DeserializeObject<Enveloppe>(p_message, settings);
            return enveloppe;
        }
    }
}
