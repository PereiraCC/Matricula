using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace Matricula.Areas.Users.Data
{
    public class ActionsBD
    {
        Conection con = new Conection();
        SqlConnection connection;

        public ActionsBD()
        {
            connection = con.getConnection();
        }

        public ArrayList getRoles()
        {
            ArrayList roles = new ArrayList();
            connection.Open();
            SqlCommand cmd = new SqlCommand("ConsultarRoles", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                roles.Add(reader["Nombre"]);
            }
            reader.Close();

            return roles;
        }
    }
}
