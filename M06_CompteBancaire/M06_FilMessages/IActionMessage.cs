using M06_BL_CompteBancaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_FilMessages
{
    public interface IActionMessage
    {
        public void Executer(Enveloppe p_enveloppe);
    }
}
