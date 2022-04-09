using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M02_BL_Meteo
{
    public class Meteo
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public float min_temp { get; private set; }
        public float max_temp { get; private set; }
        public float the_temp { get; private set; }

        // ** constructeurs ** //
        public Meteo(float p_tempMin, float p_tempMax, float p_temp)
        {
            this.min_temp = p_tempMin;
            this.max_temp = p_tempMax;
            this.the_temp = p_temp;
        }

        // ** Méthodes ** //
        public override string ToString()
        {
            return $"température min: {this.min_temp}   température max: {this.max_temp}   température: {this.the_temp}";
        }
    }
}
