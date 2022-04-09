using M03_REST01.SERVICE_Municipalite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M03_ServicesSOAP
{
    public class MunicipaliteService : IMunicipaliteService
    {
        // ** Champs ** //
        private ManipulationMunicipalites m_manipulationMunicipalites;

        // ** Propriétés ** //

        // ** Constructeurs ** //
        public MunicipaliteService(ManipulationMunicipalites p_manipulationMunicipalites)
        {
            this.m_manipulationMunicipalites = p_manipulationMunicipalites;
        }

        // ** Méthodes ** //
        public void AjouterMunicipalite(MunicipaliteSOAPDTO p_municipaliteAAjouter)
        {
            Municipalite municipaliteAAjouter = new Municipalite(p_municipaliteAAjouter.CodeGeographique, p_municipaliteAAjouter.NomMunicipalite, p_municipaliteAAjouter.AdresseCourriel, p_municipaliteAAjouter.AdresseWeb, p_municipaliteAAjouter.DateProchaineElection, p_municipaliteAAjouter.Actif);
            this.m_manipulationMunicipalites.AjouterMunicipalite(municipaliteAAjouter);
        }
        public MunicipaliteSOAPDTO ChercherMunicipaliteParCodeGeographique(int p_codeGeographique)
        {
            Municipalite municipaliteTrouvee = this.m_manipulationMunicipalites.ObtenirMunicipalite(p_codeGeographique);

            return this.MunicipaliteVersSOAPDTO(municipaliteTrouvee);

        }
        public void DesactiverMunicipalite(MunicipaliteSOAPDTO p_municipaliteADesactiver)
        {
            this.m_manipulationMunicipalites.SupprimerMunicipalite(p_municipaliteADesactiver.CodeGeographique);
        }
        public IEnumerable<MunicipaliteSOAPDTO> ListerMunicipalites()
        {
            IEnumerable<Municipalite> municipalites =  this.m_manipulationMunicipalites.ListerMunicipalites();
            List<MunicipaliteSOAPDTO> municipalitesSOAP = new List<MunicipaliteSOAPDTO>();

            municipalitesSOAP = municipalites.Select(municipalite => this.MunicipaliteVersSOAPDTO(municipalite)).ToList();
            return municipalitesSOAP;
        }
        public void MAJMunicipalite(MunicipaliteSOAPDTO p_municipaliteAMettreAJour)
        {
            this.m_manipulationMunicipalites.MAJMunicipalite(this.MunicipaliteSOAPDTOVersEntite(p_municipaliteAMettreAJour));
        }
        public MunicipaliteSOAPDTO MunicipaliteVersSOAPDTO(Municipalite p_municipaliteAtransformer)
        {
            MunicipaliteSOAPDTO municipaliteTransformee = new MunicipaliteSOAPDTO(p_municipaliteAtransformer.CodeGeographique, p_municipaliteAtransformer.NomMunicipalite, p_municipaliteAtransformer.AdresseCourriel, p_municipaliteAtransformer.AdresseWeb, p_municipaliteAtransformer.DateProchaineElection, p_municipaliteAtransformer.EstActif);
            return municipaliteTransformee;
        }
        public Municipalite MunicipaliteSOAPDTOVersEntite(MunicipaliteSOAPDTO p_municipaliteDTO)
        {
            Municipalite municipaliteEntite = new Municipalite(p_municipaliteDTO.CodeGeographique, p_municipaliteDTO.NomMunicipalite, p_municipaliteDTO.AdresseCourriel, p_municipaliteDTO.AdresseWeb, p_municipaliteDTO.DateProchaineElection, p_municipaliteDTO.Actif);
            return municipaliteEntite;
        }

    }
}
