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
    public class ActionsBDHorarios
    {
        Conection con = new Conection();
        SqlConnection connection;

        public ActionsBDHorarios()
        {
            connection = con.getConnection();
        }

        public string verificarCodigoHorario(string codigo)
        {
            string cantidad = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("VerificarCodigoHorario", connection);
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

        public string registrarHorario(HorariosM data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("RegistrarHorario", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", data.Codigo_Horario));
            cmd.Parameters.Add(new SqlParameter("@dia", data.Dia));
            cmd.Parameters.Add(new SqlParameter("@Hora_Inicial", data.Hora_Inicial));
            cmd.Parameters.Add(new SqlParameter("@Hora_Final", data.Hora_Final));
            cmd.Parameters.Add(new SqlParameter("@nombrePeriodo", data.Nombre_Periodo));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }

        public List<HorariosM> getHorarios()
        {
            List<HorariosM> horarios = new List<HorariosM>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarHorarios", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                HorariosM temp = new HorariosM();
                temp.Codigo_Horario = reader["idHorario"].ToString();
                temp.Dia = reader["Dia"].ToString();
                temp.Hora_Inicial = reader["Hora_Inicial"].ToString();
                temp.Hora_Final = reader["Hora_Final"].ToString();

                horarios.Add(temp);
            }
            reader.Close();

            return horarios;
        }

        public HorariosM getUnHorario(string id)
        {
            int identificador = Int32.Parse(id);
            HorariosM Horario = new HorariosM();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarUnHorario", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", identificador));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Horario.Codigo_Horario = reader["idHorario"].ToString();
                Horario.Dia = reader["Dia"].ToString();
                Horario.Hora_Inicial = reader["Hora_Inicial"].ToString();
                Horario.Hora_Final = reader["Hora_Final"].ToString();
                Horario.Nombre_Periodo = reader["idPeriodo"].ToString();
            }
            reader.Close();

            return Horario;
        }

        public string modificarHorario(HorariosM input)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ModificarHorario", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", input.Codigo_Horario));
            cmd.Parameters.Add(new SqlParameter("@dia", input.Dia));
            cmd.Parameters.Add(new SqlParameter("@Hora_Inicial", input.Hora_Inicial));
            cmd.Parameters.Add(new SqlParameter("@Hora_Final", input.Hora_Final));

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
