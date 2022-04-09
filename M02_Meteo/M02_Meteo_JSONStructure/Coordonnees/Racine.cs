using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M02_DAL_ImportMeteo_REST
{
    public class Racine
    {
        private ICollection<Ville> m_villes = new List<Ville>();

        public ICollection<Ville> Villes { get { return m_villes; } set { this.m_villes = value; } }
    }
}
