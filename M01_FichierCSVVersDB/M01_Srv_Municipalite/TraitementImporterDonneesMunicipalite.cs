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
            IEnumerable<Municipalite> municipaliteAImporter = this.DepotCSV.LireMunicipalite();
            Dictionary<int, Municipalite> municipalitePresenteDB = this.DepotBD.ListerMunicipalite();

            foreach (Municipalite municipalite in municipaliteAImporter)
            {
                Municipalite municipaliteTrouvee = municipalitePresenteDB.Where(m => m.Value.CodeGeographique == municipalite.CodeGeographique).Select(m => m.Value).SingleOrDefault();

                if(municipaliteTrouvee is not null)
                {
                    if(municipalite.NomMunicipalite != municipaliteTrouvee.NomMunicipalite || municipalite.AdresseCourriel != municipaliteTrouvee.AdresseCourriel || municipalite.AdresseWeb != municipaliteTrouvee.AdresseWeb || municipalite.DateProchaineElection != municipaliteTrouvee.DateProchaineElection || municipalite.EstActif != municipaliteTrouvee.EstActif)
                    {
                        this.DepotBD.MAJMunicipalite(municipalite);
                        this.Statistiques.IncrementerNombreenregistrementsModifies();
                    }
                }
                else
                {
                    this.DepotBD.AjouterMunicipalite(municipalite);
                    this.Statistiques.IncrementerNombreEnregistrementsAjoutes();
                }
            }

            return this.Statistiques;

        }
    }
}
