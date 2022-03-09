using M01_DAL_Municipalite_SQLServer;
using M01_DAL_Municipalite_SQLServer.DTO;
using M01_Srv_Municipalite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_DAL_MunicipaliteSQLServer
{
    public class DepotMunicipalite : IDepotMunicipalite
    {
        // ** champs ** //
        private ApplicationDBContext m_DbContext;

        // ** Propriétés ** //

        // ** constructeurs ** //
        public DepotMunicipalite(ApplicationDBContext p_dbContext)
        {
            this.m_DbContext = p_dbContext;
        }

        // ** méthodes ** //
        public void AjouterMunicipalite(Municipalite p_municipaliteAAjouter)
        {
            MunicipaliteDTO nouvelleMunicipalite = new MunicipaliteDTO(p_municipaliteAAjouter);
            this.m_DbContext.Add(nouvelleMunicipalite);
            this.m_DbContext.SaveChanges();
            this.m_DbContext.ChangeTracker.Clear();
        }

        public Municipalite ChercherMunicipaliteParCodeGeographique(int p_codeGeographique)
        {
            MunicipaliteDTO municipaliteTrouvee = this.m_DbContext.Municipalites.Where(municipalite => municipalite.CodeGeographique == p_codeGeographique).FirstOrDefault();
            return municipaliteTrouvee.VersEntite();
        }

        public void DesactiverMunicipalite(Municipalite p_municipaliteADesactiver)
        {
            Municipalite municipaliteADesactiver = ChercherMunicipaliteParCodeGeographique(p_municipaliteADesactiver.CodeGeographique);

            if (municipaliteADesactiver.EstActif)
            {
                this.MAJMunicipalite(municipaliteADesactiver);
            }
            
        }

        public IEnumerable<Municipalite> ListerMunicipaliteActives()
        {
            List<Municipalite> listeMunicipaliteActives = this.m_DbContext.Municipalites.Where(municipalite => municipalite.EstActif == '1').Select(municipalite => municipalite.VersEntite()).ToList();
            return listeMunicipaliteActives;
        }

        public void MAJMunicipalite(Municipalite p_municipaliteAMettreAJour)
        {
            
        }
    }
}
