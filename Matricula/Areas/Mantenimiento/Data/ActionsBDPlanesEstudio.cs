using Matricula.Areas.Users.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Mantenimiento.Data
{
    public class ActionsBDPlanesEstudio
    {
        Conection con = new Conection();
        SqlConnection connection;
        ActionsBDCarreras ActionsBDCarreras = new ActionsBDCarreras();

        public ActionsBDPlanesEstudio()
        {
            connection = con.getConnection();
        }

        public List<string> getCarreras()
        {
            List<string> carreras = new List<string>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarCarreras", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                carreras.Add(reader["nombre"].ToString());
            }
            reader.Close();

            return carreras;
        }

        public List<string> getMateriasXCarrera(string nombreCarrera)
        {
            List<string> carreras = new List<string>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarMateriasXCarrera", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombreCarrera", nombreCarrera));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                carreras.Add(reader["nombre"].ToString());
            }
            reader.Close();

            return carreras;
        }
    }
}
