using M02_BL_Meteo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M02_Meteo_JSONStructure
{
    public  class consolided
    {
        private ICollection<Meteo> m_meteo = new List<Meteo>();

        public ICollection<Meteo> Meteo { get { return m_meteo; } set { this.m_meteo = value; } }
    }
}
