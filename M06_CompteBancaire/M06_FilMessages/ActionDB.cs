using M06_BL_CompteBancaire;
using M06_DAL_CompteBancaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_FilMessages
{
    public class ActionDB : IActionMessage
    {
        public void Executer(Enveloppe p_enveloppe)
        {
            ManipulerCompteBancaire manipuler = this.CreerContexteDAL();

            if (p_enveloppe is not null)
            {
                if (p_enveloppe.Contenu == "compte")
                {
                    if (p_enveloppe.Action == "creation")
                    {
                        manipuler.CreerCompte(p_enveloppe.Compte);
                    }

                    if (p_enveloppe.Action == "modification")
                    {
                        manipuler.ModifierCompte(p_enveloppe.Compte);
                    }
                }

                if (p_enveloppe.Contenu == "transaction")
                {
                    if (p_enveloppe.Action == "creation")
                    {
                        manipuler.CreerTransaction(p_enveloppe.Transaction);
                    }
                }
            }
        }
        private ManipulerCompteBancaire CreerContexteDAL()
        {
            IDepot debotCompteBancaire = new DepotCompteBancaire(DbContextGeneration.ObtenirApplicationDBContext());
            return new ManipulerCompteBancaire(debotCompteBancaire);
        }
    }
}
