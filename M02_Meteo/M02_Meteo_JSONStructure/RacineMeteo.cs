using M02_BL_Meteo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M02_Meteo_JSONStructure
{
    public class RacineMeteo
    {
        private consolided m_consolided = new consolided();

        public consolided Consolided { get { return m_consolided; } set { this.m_consolided = value; } }
    }
}
