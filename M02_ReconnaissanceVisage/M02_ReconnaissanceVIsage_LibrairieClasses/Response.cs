using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M02_ReconnaissanceVIsage_LibrairieClasses
{
    public class Response
    {

        // ** Champs ** //

        // ** Propriétés ** //
        public bool success { get; set; }
        public Face[] predictions { get; set; }

        // ** Constructeurs ** //

        // ** Méthodes ** //
    }
}
