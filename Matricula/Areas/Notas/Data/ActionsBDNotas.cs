using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Users.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Notas.Data
{
    public class ActionsBDNotas
    {
        Conection con = new Conection();
        SqlConnection connection;
        ActionsBDRequesitos ActionsBDRequesitos = new ActionsBDRequesitos();
        ActionsBDCo_Requesitos ActionsBDCo_Requesitos = new ActionsBDCo_Requesitos();
        ActionsBDHorarios ActionsBDHorarios = new ActionsBDHorarios();
        ActionsBDCarreras ActionsBDCarreras = new ActionsBDCarreras();

        public ActionsBDNotas()
        {
            connection = con.getConnection();
        }

        public List<MateriasM> getMateriasxCarrera(string nombreCarrera)
        {
            List<RequesitosM> requesitos = ActionsBDRequesitos.getRequesitos();
            List<Co_RequesitosM> co_requesitos = ActionsBDCo_Requesitos.getCo_Requesitos();
            List<MateriasM> materias = new List<MateriasM>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarMateriasXCarrera2", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombreCarrera", nombreCarrera));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MateriasM temp = new MateriasM();
                temp.Codigo_Materia = reader["idMateria"].ToString();
                temp.Nombre = reader["nombre"].ToString();
                temp.Descripcion = reader["descripcion"].ToString();
                temp.Creditos = reader["creditos"].ToString();
                temp.Nombre_Requesito = obtenerNombreRequesitos(requesitos, reader["idRequesito"].ToString());
                temp.NombreCo_Requesito = obtenerNombreCo_Requesitos(co_requesitos, reader["idCo_Requesito"].ToString());

                materias.Add(temp);
            }
            reader.Close();

            return materias;
        }

        public string obtenerNombreRequesitos(List<RequesitosM> requesitos, string codigo)
        {
            string nombre = "";
            foreach (RequesitosM req in requesitos)
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

        public string obtenerNombreHorario(List<HorariosM> horarios, string codigo)
        {
            string nombre = "";
            foreach (HorariosM hor in horarios)
            {
                if (hor.Codigo_Horario.Equals(codigo))
                {
                    nombre = hor.Dia + " " + hor.Hora_Inicial + " " + hor.Hora_Final;
                }
            }

            return nombre;
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

        public MateriasM getUnaMateria(string id)
        {
            List<RequesitosM> requesitos = ActionsBDRequesitos.getRequesitos();
            List<Co_RequesitosM> co_requesitos = ActionsBDCo_Requesitos.getCo_Requesitos();
            List<HorariosM> horarios = ActionsBDHorarios.getHorarios();
            List<CarrerasM> carreras = ActionsBDCarreras.getCarreras();
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
                Materia.Nombre_Carrera = obtenerNombreCarrera(carreras, reader["idCarrera"].ToString());
                Materia.Nombre_Requesito = obtenerNombreRequesitos(requesitos, reader["idRequesito"].ToString());
                Materia.NombreCo_Requesito = obtenerNombreCo_Requesitos(co_requesitos, reader["idCo_Requesito"].ToString());
                Materia.NombreHorario = obtenerNombreHorario(horarios, reader["idHorario"].ToString());
                Materia.Cupo = reader["cupo"].ToString();
                Materia.Costo = "₡" + reader["costo"].ToString().Substring(0, reader["costo"].ToString().Length - 5);
            }
            reader.Close();

            return Materia;
        }
    }
}
