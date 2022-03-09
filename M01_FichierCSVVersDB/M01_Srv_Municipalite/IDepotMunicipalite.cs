using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_Srv_Municipalite
{
    public interface IDepotMunicipalite
    {
        public Municipalite ChercherMunicipaliteParCodeGeographique(int p_codeGeographique);
        public IEnumerable<Municipalite> ListerMunicipaliteActives();
        public void DesactiverMunicipalite(Municipalite p_municipaliteADesactiver);
        public void AjouterMunicipalite(Municipalite p_municipaliteAAjouter);
        public void MAJMunicipalite(Municipalite p_municipaliteAMettreAJour);
    }
}