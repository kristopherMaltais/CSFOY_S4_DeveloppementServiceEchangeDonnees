using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace M03_ServicesSOAP
{
    [ServiceContract]
    public interface IMunicipaliteService
    {
        [OperationContract]
        public MunicipaliteSOAPDTO ChercherMunicipaliteParCodeGeographique(int p_codeGeographique);

        [OperationContract]
        public IEnumerable<MunicipaliteSOAPDTO> ListerMunicipalites();

        [OperationContract]
        public void DesactiverMunicipalite(MunicipaliteSOAPDTO p_municipaliteADesactiver);

        [OperationContract]
        public void AjouterMunicipalite(MunicipaliteSOAPDTO p_municipaliteAAjouter);

        [OperationContract]
        public void MAJMunicipalite(MunicipaliteSOAPDTO p_municipaliteAMettreAJour);
       
    }
}
