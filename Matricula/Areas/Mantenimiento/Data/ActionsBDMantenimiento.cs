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
    public class ActionsBDMantenimiento
    {
        Conection con = new Conection();
        SqlConnection connection;

        public ActionsBDMantenimiento()
        {
            connection = con.getConnection();
        }

        public string verificarCodigoCo_Requesito(string codigo)
        {
            string cantidad = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("VerificarCodigoCo_Requesito", connection);
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

        public string registrarCo_Requesito(Co_RequesitosM data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("RegistarCoRequesitos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", data.Codigo_CoRequesito));
            cmd.Parameters.Add(new SqlParameter("@nombre", data.Nombre));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }

        public List<Co_RequesitosM> getCo_Requesitos()
        {
            List<Co_RequesitosM> co_Requesitos = new List<Co_RequesitosM>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarCo_Requesitos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Co_RequesitosM temp = new Co_RequesitosM();
                temp.Codigo_CoRequesito = reader["idCo_Requesito"].ToString();
                temp.Nombre = reader["nombre"].ToString();

                co_Requesitos.Add(temp);
            }
            reader.Close();

            return co_Requesitos;
        }

        public Co_RequesitosM getUnCo_Requesito(string id)
        {
            int identificador = Int32.Parse(id);
            Co_RequesitosM co_Requesito = new Co_RequesitosM();
            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarUnCo_Requesito", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", identificador));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                co_Requesito.Codigo_CoRequesito = reader["idCo_Requesito"].ToString();
                co_Requesito.Nombre = reader["nombre"].ToString();
               
            }
            reader.Close();

            return co_Requesito;
        }

        public string modificarCo_Requesito(Co_RequesitosM input)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ModificarCo_Requesito", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", input.Codigo_CoRequesito));
            cmd.Parameters.Add(new SqlParameter("@nombre", input.Nombre));

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
