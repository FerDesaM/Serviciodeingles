using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services;

namespace Serviciodeingles
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "puntajes" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione puntajes.svc o puntajes.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class puntajes : Ipuntajes
    {
        [WebMethod]
        public void guardar_puntajes(int puntaje, string email)
        {
            string Conexion = "Data Source=DESKTOP-9LE8C8C;Initial Catalog=Ingles;Integrated Security=True;";
            using (SqlConnection data = new SqlConnection(Conexion))
            {
                string query = "INSERT INTO dbo.Puntajes(puntajes, usuario) VALUES(@puntajes, @usuario);";
                using (SqlCommand cmd = new SqlCommand(query, data))
                {
                    cmd.Parameters.AddWithValue("@puntajes", puntaje);
                    cmd.Parameters.AddWithValue("@usuario", email);

                    data.Open();
                    cmd.ExecuteNonQuery(); // Ejecutar la consulta y realizar la inserción en la tabla "Puntajes"
                }
            }
        }
    }
}
