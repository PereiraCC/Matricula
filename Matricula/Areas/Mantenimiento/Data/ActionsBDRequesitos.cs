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
    public class ActionsBDRequesitos
    {
        Conection con = new Conection();
        SqlConnection connection;

        public ActionsBDRequesitos()
        {
            connection = con.getConnection();
        }

        public string verificarCodigoRequesito(string codigo)
        {
            string cantidad = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("VerificarCodigoRequesito", connection);
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

        public string registrarRequesito(RequesitosM data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("RegistrarRequesito", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", data.Codigo_Requesito));
            cmd.Parameters.Add(new SqlParameter("@nombre", data.Nombre_Requesito));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }

        public List<RequesitosM> getRequesitos()
        {
            List<RequesitosM> Requesitos = new List<RequesitosM>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarRequesito", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                RequesitosM temp = new RequesitosM();
                temp.Codigo_Requesito = reader["idRequesito"].ToString();
                temp.Nombre_Requesito = reader["nombre"].ToString();

                Requesitos.Add(temp);
            }
            reader.Close();

            return Requesitos;
        }

        public RequesitosM getUnRequesito(string id)
        {
            int identificador = Int32.Parse(id);
            RequesitosM Requesito = new RequesitosM();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarUnRequesito", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", identificador));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Requesito.Codigo_Requesito = reader["idRequesito"].ToString();
                Requesito.Nombre_Requesito = reader["nombre"].ToString();

            }
            reader.Close();

            return Requesito;
        }

        public string modificarRequesito(RequesitosM input)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ModificarRequesito", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", input.Codigo_Requesito));
            cmd.Parameters.Add(new SqlParameter("@nombre", input.Nombre_Requesito));

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
