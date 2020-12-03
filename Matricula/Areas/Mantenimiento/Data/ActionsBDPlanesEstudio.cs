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

        public string verificarCodigoPlan(string codigo)
        {
            string cantidad = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("VerificarCodigoPlan", connection);
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

        public string registrarPlan(PlanesEstudioM data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("RegistrarPlan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", data.Codigo_Plan));
            cmd.Parameters.Add(new SqlParameter("@nombre", data.Nombre_Plan));
            cmd.Parameters.Add(new SqlParameter("@descrip", data.Descripcion_Plan));
            cmd.Parameters.Add(new SqlParameter("@nombreCarrera", data.Nombre_Carrera));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }

        public List<PlanesEstudioM> getPlanes()
        {
            List<CarrerasM> carreras = ActionsBDCarreras.getCarreras();
            List<PlanesEstudioM> planes = new List<PlanesEstudioM>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarPlanes", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PlanesEstudioM temp = new PlanesEstudioM();
                temp.Codigo_Plan = reader["idPlan"].ToString();
                temp.Nombre_Plan = reader["nombre"].ToString();
                temp.Descripcion_Plan = reader["descripcion"].ToString();
                temp.Nombre_Carrera = obtenerNombreCarrera(carreras, reader["idCarrera"].ToString());

                planes.Add(temp);
            }
            reader.Close();

            return planes;
        }

        public PlanesEstudioM getUnPlan(string id)
        {
            List<CarrerasM> carreras = ActionsBDCarreras.getCarreras();
            int identificador = Int32.Parse(id);
            PlanesEstudioM Plan = new PlanesEstudioM();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarUnPlan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", identificador));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Plan.Codigo_Plan = reader["idPlan"].ToString();
                Plan.Nombre_Plan = reader["nombre"].ToString();
                Plan.Descripcion_Plan = reader["descripcion"].ToString();
                Plan.Nombre_Carrera = obtenerNombreCarrera(carreras, reader["idCarrera"].ToString());
                
            }
            reader.Close();

            return Plan;
        }

        public string modificarPlan(PlanesEstudioM data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ModificarPlan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", data.Codigo_Plan));
            cmd.Parameters.Add(new SqlParameter("@nombre", data.Nombre_Plan));
            cmd.Parameters.Add(new SqlParameter("@descrip", data.Descripcion_Plan));
            cmd.Parameters.Add(new SqlParameter("@nombreCarrera", data.Nombre_Carrera));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }

        public string obtenerNombreCarrera(List<CarrerasM> carreras, string codigo)
        {
            string nombre = "";
            foreach (CarrerasM req in carreras)
            {
                if (req.Codigo_Carrera.Equals(codigo))
                {
                    nombre = req.Nombre_Carrera;
                }
            }

            return nombre;
        }
    }
}
