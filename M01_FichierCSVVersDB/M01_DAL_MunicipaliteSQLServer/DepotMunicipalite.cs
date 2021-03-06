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
            // Préconditions
            if(p_dbContext is null)
            {
                throw new ArgumentNullException(nameof(p_dbContext), "le dbContext ne peut pas être null");
            }

            this.m_DbContext = p_dbContext;
        }

        // ** méthodes ** //
        public void AjouterMunicipalite(Municipalite p_municipaliteAAjouter)
        {
            // Préconditions
            if(p_municipaliteAAjouter is null)
            {
                throw new ArgumentNullException(nameof(p_municipaliteAAjouter), "La municipalité ne peut pas être null");
            }

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
            // Préconditions
            if (p_municipaliteADesactiver is null)
            {
                throw new ArgumentNullException(nameof(p_municipaliteADesactiver), "La municipalité ne peut pas être null");
            }

            Municipalite municipaliteADesactiver = ChercherMunicipaliteParCodeGeographique(p_municipaliteADesactiver.CodeGeographique);

            if (municipaliteADesactiver.EstActif)
            {
                municipaliteADesactiver.EstActif = false;
                this.MAJMunicipalite(municipaliteADesactiver);
            }
            
        }
        public IEnumerable<Municipalite> ListerMunicipaliteActives()
        {
            List<Municipalite> listeMunicipaliteActives = this.m_DbContext.Municipalites.Where(municipalite => municipalite.EstActif == '1').Select(municipalite => municipalite.VersEntite()).ToList();
            return listeMunicipaliteActives;
        }
        public Dictionary<int, Municipalite> ListerMunicipalite()
        {
            Dictionary<int, Municipalite> listeMunicipaliteActives = this.m_DbContext.Municipalites.ToDictionary(municipalite => municipalite.CodeGeographique, municipalite => municipalite.VersEntite());
            return listeMunicipaliteActives;
        }
        public void MAJMunicipalite(Municipalite p_municipaliteAMettreAJour)
        {
            // Préconditions
            if (p_municipaliteAMettreAJour is null)
            {
                throw new ArgumentNullException(nameof(p_municipaliteAMettreAJour), "La municipalité ne peut pas être null");
            }

            MunicipaliteDTO nouvelleMunicipalite = new MunicipaliteDTO(p_municipaliteAMettreAJour);
            this.m_DbContext.Update(nouvelleMunicipalite);
            this.m_DbContext.SaveChanges();
            this.m_DbContext.ChangeTracker.Clear();
        }
    }
}
