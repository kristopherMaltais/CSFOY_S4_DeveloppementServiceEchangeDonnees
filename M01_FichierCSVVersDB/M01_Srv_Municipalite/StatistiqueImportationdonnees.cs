using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_Srv_Municipalite
{
    public class StatistiqueImportationdonnees
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public int NombreEnregistrementsAjoutes { get; set; }
        public int NombreenregistrementsModifies { get; set; }  
        public int NombreEnregistrementsDesactives { get; set; }

        // ** Constructeurs ** //

        // ** Méthodes ** //
        public override string ToString()
        {
            return $"Nombre enregistrement ajouté: {this.NombreEnregistrementsAjoutes}   Nombre enregistrement modifié: {this.NombreenregistrementsModifies}    Nombre enregistrement désactivé: {this.NombreEnregistrementsDesactives}";
        }
    }
}
