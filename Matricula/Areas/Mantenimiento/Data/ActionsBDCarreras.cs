using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Users.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Mantenimiento.Data
{
    public class ActionsBDCarreras
    {
        Conection con = new Conection();
        SqlConnection connection;

        public ActionsBDCarreras()
        {
            connection = con.getConnection();
        }

        public string verificarCodigoCarrera(string codigo)
        {
            string cantidad = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("VerificarCodigoCarrera", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", codigo));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cantidad = reader[0].ToString();
            }
            reader.Close();

            return cantidad;
        }

        public string registrarCarrera(CarrerasM data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("RegistrarCarrera", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idCarrera", data.Codigo_Carrera));
            cmd.Parameters.Add(new SqlParameter("@nombreC", data.Nombre_Carrera));
            cmd.Parameters.Add(new SqlParameter("@descrip", data.Descripcion_Carrera));


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }
    }
}
