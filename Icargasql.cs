using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Serviciodeingles
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "Icargasql" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface Icargasql
    {
        [OperationContract]
        void guardar_datos(string email, string nombre, string contraseña);
       
        
    }
}
