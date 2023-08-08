using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Serviciodeingles
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "Iverificar" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface Iverificar
    {
        [OperationContract]
        bool verificar_datos(string email, string contraseña);
    }
}
