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
        public int NombreEnregistrementsAjoutes { get; private set; }
        public int NombreenregistrementsModifies { get; private set; }  
        public int NombreEnregistrementsDesactives { get; private set; }

        // ** Constructeurs ** //

        // ** Méthodes ** //
        public void IncrementerNombreEnregistrementsAjoutes()
        {
            this.NombreEnregistrementsAjoutes++;
        }
        public void IncrementerNombreenregistrementsModifies()
        {
            this.NombreenregistrementsModifies++;
        }
        public void IncrementerNombreEnregistrementsDesactives()
        {
            this.NombreEnregistrementsDesactives++;
        }

        public override string ToString()
        {
            return $"Nombre enregistrement ajouté: {this.NombreEnregistrementsAjoutes}   Nombre enregistrement modifié: {this.NombreenregistrementsModifies}    Nombre enregistrement désactivé: {this.NombreEnregistrementsDesactives}";
        }
    }
}
