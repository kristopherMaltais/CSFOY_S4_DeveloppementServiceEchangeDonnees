using M08_Application.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M08_BL_ServiceStatistiqueClientele
{
    public  class Statistiques
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public int NombreAppel { get; private set; }
        public float TempsAppelMoyen { get; private set; }
        public int NombreAgent { get; private set; }

        // ** Constructeurs ** //
        public Statistiques(int p_nombreAppel, float p_tempsAppelMoyen, int p_nombreAgent)
        {
            this.NombreAgent = p_nombreAgent;
            this.NombreAppel = p_nombreAppel;
            this.TempsAppelMoyen = p_tempsAppelMoyen;
        }

        // ** Méthodes ** //

    }
}
