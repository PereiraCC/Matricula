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

        public List<CarrerasM> getCarreras()
        {
            List<CarrerasM> carreras = new List<CarrerasM>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarCarreras", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CarrerasM temp = new CarrerasM();
                temp.Codigo_Carrera = reader["idCarreras"].ToString();
                temp.Nombre_Carrera = reader["nombre"].ToString();
                temp.Descripcion_Carrera = reader["descripcion"].ToString();

                carreras.Add(temp);
            }
            reader.Close();

            return carreras;
        }

        public CarrerasM getUnaCarrera(string id)
        {
            int identificador = Int32.Parse(id);
            CarrerasM carrera = new CarrerasM();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarUnaCarrera", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", identificador));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                carrera.Codigo_Carrera = reader["idCarreras"].ToString();
                carrera.Nombre_Carrera = reader["nombre"].ToString();
                carrera.Descripcion_Carrera = reader["descripcion"].ToString();

            }
            reader.Close();

            return carrera;
        }

        public string modificarCarrera(CarrerasM input)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ModificarCarrera", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", input.Codigo_Carrera));
            cmd.Parameters.Add(new SqlParameter("@nombre", input.Nombre_Carrera));
            cmd.Parameters.Add(new SqlParameter("@descripcion", input.Descripcion_Carrera));

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
