using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace Serviciodeingles
{
    public class cargasql : Icargasql
    {
        public void guardar_datos(string email, string nombre, string contraseña)
        {
            string Conexion = "Data Source=DESKTOP-9LE8C8C;Initial Catalog=Ingles;Integrated Security=True;";
            using (SqlConnection data = new SqlConnection(Conexion))
            {
                string query = "INSERT INTO dbo.Usuario(usuario, users, contraseña)" + "VALUES(@usuario, @users, @contraseña);";
                using (SqlCommand cmd = new SqlCommand(query, data))
                {
                    cmd.Parameters.AddWithValue("@usuario", email);
                    cmd.Parameters.AddWithValue("@users", nombre);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);

                    data.Open();
                    cmd.ExecuteNonQuery(); // Ejecutar la consulta y realizar la inserción en la base de datos
                }
            }
        }
        
    }
}