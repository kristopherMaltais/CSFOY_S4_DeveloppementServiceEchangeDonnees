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
        }


        // ** Méthodes ** //
        public StatistiqueImportationdonnees Executer()
        {
            throw new NotImplementedException();
        }
    }
}
