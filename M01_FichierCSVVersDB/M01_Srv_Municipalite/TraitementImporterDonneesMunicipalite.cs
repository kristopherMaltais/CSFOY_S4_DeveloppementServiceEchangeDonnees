using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_Srv_Municipalite
{
    public class TraitementImporterDonneesMunicipalite
    {
        // ** champs ** //

        // ** Propriétés ** //
        public IDepotImportationMunicipalite DepotCSV { get; set; }
        public IDepotMunicipalite DepotBD { get; set; }
        public StatistiqueImportationdonnees Statistiques { get; set; }

        // ** Constructeurs ** //
        public TraitementImporterDonneesMunicipalite(IDepotImportationMunicipalite p_depotCSV, IDepotMunicipalite p_depotBD)
        {
            // préconditions
            if(p_depotCSV is null)
            {
                throw new ArgumentNullException(nameof(p_depotCSV), "Le dépot CSV ne peut pas être null");
            }
            if (p_depotBD is null)
            {
                throw new ArgumentNullException(nameof(p_depotCSV), "Le dépot CSV ne peut pas être null");
            }

            this.DepotCSV = p_depotCSV;
            this.DepotBD = p_depotBD;
            this.Statistiques = new StatistiqueImportationdonnees();
        }


        // ** Méthodes ** //
        public StatistiqueImportationdonnees Executer()
        {
            Dictionary<int, Municipalite> municipaliteSource = this.DepotCSV.ListerMunicipalite();
            Dictionary<int, Municipalite> municipaliteDestination = this.DepotBD.ListerMunicipalite();

            foreach (KeyValuePair<int, Municipalite> municipalite in municipaliteSource)
            {
                if(municipaliteDestination.ContainsKey(municipalite.Key))
                {
                    Municipalite municipaliteAComparer = municipaliteDestination.Where(m => m.Value.CodeGeographique == municipalite.Value.CodeGeographique).Select(m => m.Value).SingleOrDefault();
                    if(!municipalite.Value.ComparerMunicipalite(municipaliteAComparer))
                    {
                        this.DepotBD.MAJMunicipalite(municipalite.Value);
                        this.Statistiques.IncrementerNombreenregistrementsModifies();
                    }
                }
                else
                {
                    this.DepotBD.AjouterMunicipalite(municipalite.Value);
                    this.Statistiques.IncrementerNombreEnregistrementsAjoutes();
                }
            }

            foreach(KeyValuePair<int, Municipalite> municipalite in municipaliteDestination)
            {
                if(!municipaliteSource.ContainsKey(municipalite.Key))
                {
                    this.DepotBD.DesactiverMunicipalite(municipalite.Value);
                    this.Statistiques.IncrementerNombreEnregistrementsDesactives();
                }
            }

            return this.Statistiques;
        }
    }
}
