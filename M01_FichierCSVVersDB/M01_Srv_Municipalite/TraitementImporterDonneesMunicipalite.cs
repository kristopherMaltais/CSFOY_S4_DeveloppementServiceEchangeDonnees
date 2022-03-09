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
        public IDepotImportationMunicipalite DepotCSV { get; set; }
        public IDepotMunicipalite DepotBD { get; set; }


        // ** Propriétés ** //

        // ** Constructeurs ** //
        public TraitementImporterDonneesMunicipalite(IDepotImportationMunicipalite p_depotCSV, IDepotMunicipalite p_deptoBD)
        {
            this.DepotCSV = p_depotCSV;
            this.DepotBD = p_deptoBD;
        }


        // ** Méthodes ** //
        public StatistiqueImportationdonnees Executer()
        {
            throw new NotImplementedException();
        }
    }
}
