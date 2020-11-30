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
    public class ActionsBDMaterias
    {
        Conection con = new Conection();
        SqlConnection connection;
        ActionsBDRequesitos ActionsBDRequesitos = new ActionsBDRequesitos();
        ActionsBDCo_Requesitos ActionsBDCo_Requesitos = new ActionsBDCo_Requesitos();

        public ActionsBDMaterias()
        {
            connection = con.getConnection();
        }

        public List<string> getRequesitos()
        {
            List<string> requesitos = new List<string>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarRequesito", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                requesitos.Add(reader["nombre"].ToString());
            }
            reader.Close();

            return requesitos;
        }

        public List<string> getCo_Requesitos()
        {
            List<string> co_requesitos = new List<string>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarCo_Requesitos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                co_requesitos.Add(reader["nombre"].ToString());
            }
            reader.Close();

            return co_requesitos;
        }

        public string verificarCodigoMateria(string codigo)
        {
            string cantidad = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("VerificarCodigoMateria", connection);
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

        public string registrarMateria(MateriasM data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("RegistrarMateria", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", data.Codigo_Materia));
            cmd.Parameters.Add(new SqlParameter("@nombre", data.Nombre));
            cmd.Parameters.Add(new SqlParameter("@descrip", data.Descripcion));
            cmd.Parameters.Add(new SqlParameter("@creditos", data.Creditos));
            cmd.Parameters.Add(new SqlParameter("@nombreRequesito", data.Nombre_Requesito));
            cmd.Parameters.Add(new SqlParameter("@nombreCo_Requesito", data.NombreCo_Requesito));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }

        public List<MateriasM> getMaterias()
        {
            List<RequesitosM> requesitos = ActionsBDRequesitos.getRequesitos();
            List<Co_RequesitosM> co_requesitos = ActionsBDCo_Requesitos.getCo_Requesitos();
            List<MateriasM> materias = new List<MateriasM>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarMaterias", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MateriasM temp = new MateriasM();
                temp.Codigo_Materia = reader["idMateria"].ToString();
                temp.Nombre = reader["nombre"].ToString();
                temp.Descripcion = reader["descripcion"].ToString();
                temp.Creditos = reader["creditos"].ToString();
                temp.Nombre_Requesito = obtenerNombreRequesitos(requesitos, reader["idRequesito"].ToString());
                temp.NombreCo_Requesito = obtenerNombreCo_Requesitos(co_requesitos ,reader["idCo_Requesito"].ToString());

                materias.Add(temp);
            }
            reader.Close();

            return materias;
        }

        public MateriasM getUnaMateria(string id)
        {
            List<RequesitosM> requesitos = ActionsBDRequesitos.getRequesitos();
            List<Co_RequesitosM> co_requesitos = ActionsBDCo_Requesitos.getCo_Requesitos();
            int identificador = Int32.Parse(id);
            MateriasM Materia = new MateriasM();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarUnaMateria", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", identificador));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Materia.Codigo_Materia = reader["idMateria"].ToString();
                Materia.Nombre = reader["nombre"].ToString();
                Materia.Descripcion = reader["descripcion"].ToString();
                Materia.Creditos = reader["creditos"].ToString();
                Materia.Nombre_Requesito = obtenerNombreRequesitos(requesitos, reader["idRequesito"].ToString());
                Materia.NombreCo_Requesito = obtenerNombreCo_Requesitos(co_requesitos, reader["idCo_Requesito"].ToString());
            }
            reader.Close();

            return Materia;
        }

        public string modificarMateria(MateriasM input)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ModificarMateria", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", input.Codigo_Materia));
            cmd.Parameters.Add(new SqlParameter("@nombre", input.Nombre));
            cmd.Parameters.Add(new SqlParameter("@descrip", input.Descripcion));
            cmd.Parameters.Add(new SqlParameter("@creditos", input.Creditos));
            cmd.Parameters.Add(new SqlParameter("@nombreRequesito", input.Nombre_Requesito));
            cmd.Parameters.Add(new SqlParameter("@nombreCo_Requesito", input.NombreCo_Requesito));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }

        public string obtenerNombreRequesitos(List<RequesitosM> requesitos, string codigo)
        {
            string nombre = "";
            foreach(RequesitosM req in requesitos)
            {
                if (req.Codigo_Requesito.Equals(codigo))
                {
                    nombre = req.Nombre_Requesito;
                }
            }

            return nombre;
        }

        public string obtenerNombreCo_Requesitos(List<Co_RequesitosM> co_requesitos, string codigo)
        {
            string nombre = "";
            foreach (Co_RequesitosM req in co_requesitos)
            {
                if (req.Codigo_CoRequesito.Equals(codigo))
                {
                    nombre = req.Nombre;
                }
            }

            return nombre;
        }
    }
}
