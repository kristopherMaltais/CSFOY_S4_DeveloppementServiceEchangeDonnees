using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace M05_Services
{
    [ServiceContract]
    public interface IOperation
    {
        [OperationContract]
        float Addition(float p_nombre1, float p_nombre2);

        [OperationContract]
        float Soustraction(float p_nombre);

        [OperationContract]
        float Multiplication(float p_nombre);

        [OperationContract]
        float Division(float p_nombre);

        [OperationContract]
        float RacineCarre(float p_nombre);
    }
}
