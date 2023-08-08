using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Serviciodeingles
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "verificar" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione verificar.svc o verificar.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class verificar : Iverificar
    {

        public bool verificar_datos(string email, string contraseña)
        {
            string Conexion = "Data Source=DESKTOP-9LE8C8C;Initial Catalog=Ingles;Integrated Security=True;";
            using (SqlConnection data = new SqlConnection(Conexion))
            {
                string query = "SELECT COUNT(*) FROM dbo.Usuario WHERE usuario = @usuario AND contraseña = @contraseña;";

                using (SqlCommand cmd = new SqlCommand(query, data))
                {
                    cmd.Parameters.AddWithValue("@usuario", email);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);

                    try
                    {
                        data.Open();
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            // El usuario existe en la base de datos, devuelve true
                            return true;
                        }
                        else
                        {
                            // El usuario no existe en la base de datos, devuelve false
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de excepciones si ocurre algún error al verificar el usuario en la base de datos
                        throw new Exception("Error al verificar el usuario en la base de datos: " + ex.Message);
                    }
                }

            }
        }
    }
}
