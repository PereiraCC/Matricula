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
    public class ActionsBDPeriodos
    {
        Conection con = new Conection();
        SqlConnection connection;

        public ActionsBDPeriodos()
        {
            connection = con.getConnection();
        }

        public List<string> getAnnos()
        {
            List<string> annos = new List<string>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarAnnos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                annos.Add(reader["Numero_Anno"].ToString());
            }
            reader.Close();

            return annos;
        }

        public List<AnnosM> getAnnos2()
        {
            List<AnnosM> annos = new List<AnnosM>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarAnnos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                AnnosM temp = new AnnosM();
                temp.Codigo_Anno = reader["IdAnno"].ToString();
                temp.Numero_Anno = reader["Numero_Anno"].ToString();
                annos.Add(temp);
            }
            reader.Close();

            return annos;
        }

        public List<PeriodosM> getPeriodos()
        {
            List<PeriodosM> periodos = new List<PeriodosM>();
            List<AnnosM> annos = getAnnos2();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarPeriodos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PeriodosM temp = new PeriodosM();
                temp.Codigo_Periodo = reader["idPeriodo"].ToString();
                temp.Nombre_Periodo = reader["nombre"].ToString();
                temp.Nombre_Anno = obtenerUnAnno(annos, reader["idAnno"].ToString());

                periodos.Add(temp);
            }
            reader.Close();

            return periodos;
        }

        public PeriodosM getUnPeriodo(string id)
        {
            List<AnnosM> annos = getAnnos2();
            int identificador = Int32.Parse(id);
            PeriodosM periodo = new PeriodosM();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarUnPeriodo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", identificador));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                periodo.Codigo_Periodo = reader["idPeriodo"].ToString();
                periodo.Nombre_Periodo = reader["nombre"].ToString();
                periodo.Nombre_Anno = obtenerUnAnno(annos, reader["idAnno"].ToString());
            }
            reader.Close();

            return periodo;
        }

        public string verificarCodigoPeriodo(string codigo)
        {
            string cantidad = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("VerificarCodigoPeriodo", connection);
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

        public string registrarPeriodo(PeriodosM data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("RegistrarPeriodo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", data.Codigo_Periodo));
            cmd.Parameters.Add(new SqlParameter("@nombre", data.Nombre_Periodo));
            cmd.Parameters.Add(new SqlParameter("@numeroAnno", data.Nombre_Anno));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }

        public string obtenerUnAnno(List<AnnosM> annos , string id)
        {
            string dato = "";
            
            foreach(AnnosM anno in annos)
            {
                if (anno.Codigo_Anno.Equals(id))
                {
                    dato = anno.Numero_Anno;
                }
            }

            return dato;
        }

        public string modificarPeriodo(PeriodosM data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ModificarPeriodo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", data.Codigo_Periodo));
            cmd.Parameters.Add(new SqlParameter("@nombre", data.Nombre_Periodo));
            cmd.Parameters.Add(new SqlParameter("@numeroAnno", data.Nombre_Anno));

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
