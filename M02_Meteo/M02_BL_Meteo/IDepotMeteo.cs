using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M02_DAL_ImportMeteo_REST;

namespace M02_BL_Meteo
{
    public interface IDepotMeteo
    {
        public ICollection<Ville> RechercherMeteoCoordonnees(float p_latitude, float p_longitude);
        public ICollection<Meteo> RechercherMeteoNomVille(string p_nomVille);
    }
}
