using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Notas.Models;
using Matricula.Areas.Users.Data;
using Matricula.Areas.Users.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Matricula.Areas.Notas.Pages.NotasAcademicas.RegistroNotasModel;

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

        public string registrarInscripcion(NotasProfesorM data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            foreach (MateriasM materia in data.lista_MateriasInscriptas)
            {
                SqlCommand cmd = new SqlCommand("RegistrarMateriaxProfesor", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdentificacionProfesor", data.profesor.Identificacion));
                cmd.Parameters.Add(new SqlParameter("@idMateria", materia.Codigo_Materia));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    estado = reader[0].ToString();
                }
                reader.Close();

                if (estado.Equals("1"))
                {
                    break;
                }

            }

            return estado;
        }

        public List<MateriasM> getMateriasInscriptas(string idProfesor)
        {
            List<RequesitosM> requesitos = ActionsBDRequesitos.getRequesitos();
            List<Co_RequesitosM> co_requesitos = ActionsBDCo_Requesitos.getCo_Requesitos();
            List<string> codigos = new List<string>();
            List<MateriasM> materias = new List<MateriasM>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarMateriasInscriptas", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IdentificacionProfesor", idProfesor));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                codigos.Add(reader["idMateria"].ToString());
            }
            reader.Close();
            
            foreach(string dato in codigos)
            {
                materias.Add(getUnaMateria(dato));
            }

            return materias;
        }

        public List<EstudianteModel> getEstudiantesxMateria(string idMateria)
        {
            List<EstudianteModel> estudiantes = new List<EstudianteModel>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarEstudiantesxMateria", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idMateria", idMateria));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                InputModelRegister tem = new InputModelRegister();
                tem.Identificacion = reader["Cedula"].ToString();
                tem.Nombre = reader["Nombre"].ToString();
                tem.PrimerApellido = reader["Primer_Apellido"].ToString();
                tem.SegundoApellido = reader["Segundo_Apellido"].ToString();
                tem.CorreoElectronico = reader["Correo_Electronico"].ToString();
                tem.Telefono = reader["Telefono"].ToString();
                tem.Direccion = reader["Direccion"].ToString();
                tem.Carrera = reader["NombreCarrera"].ToString();

                EstudianteModel estudiante = new EstudianteModel();
                estudiante.estudiante = tem;
                estudiantes.Add(estudiante);
            }
            reader.Close();

            return estudiantes;
        }

        public string getNombreMateria(string id)
        {
            int identificador = Int32.Parse(id);
            string data = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarNombreMateria", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idMateria", identificador));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                data = reader["nombre"].ToString();
            }
            reader.Close();

            return data;
        }

        public string getidMateria(string nombreMateria)
        {
            string data = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultaridMateria", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombreMateria", nombreMateria));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                data = reader["idMateria"].ToString();
            }
            reader.Close();

            return data;
        }

        public EstudianteModel getUnEstudiante(string id)
        {
            EstudianteModel estudiante = new EstudianteModel();
            int identificador = Int32.Parse(id);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarUnEstudiante", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idEstudiante", identificador));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                InputModelRegister tem = new InputModelRegister();
                tem.Identificacion = reader["Cedula"].ToString();
                tem.Nombre = reader["Nombre"].ToString();
                tem.PrimerApellido = reader["Primer_Apellido"].ToString();
                tem.SegundoApellido = reader["Segundo_Apellido"].ToString();
                tem.CorreoElectronico = reader["Correo_Electronico"].ToString();
                tem.FechaNacimiento = reader["Fecha_Nacimiento"].ToString();
                tem.Telefono = reader["Telefono"].ToString();
                tem.Direccion = reader["Direccion"].ToString();
                tem.Carrera = reader["NombreCarrera"].ToString();

                estudiante.estudiante = tem;
            }
            reader.Close();

            return estudiante;
        }

        public string getNotaEstudiante(string idEstudiante, string nombreMateria)
        {
            string data = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarNotaEstudiante", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idEstudiante", idEstudiante));
            cmd.Parameters.Add(new SqlParameter("@nombreMateria", nombreMateria));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                data = reader["Nota"].ToString();
            }
            reader.Close();

            if (data.Equals(""))
            {
                data = "Sin Calificacion";
            }
            return data;
        }

        public string registrarNota(InputModelNotaEstudiante data)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ActualizarNotaEstudiante", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idEstudiante", data.DataUser.estudiante.Identificacion));
            cmd.Parameters.Add(new SqlParameter("@nombreMateria", data.Nombre_Materia));
            cmd.Parameters.Add(new SqlParameter("@nota", data.DataUser.Nota_Estudiante));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }

        public List<MateriasM> getMateriasEstudiante(string idEstudiante)
        {
            List<MateriasM> materias = new List<MateriasM>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarMateriasEstudiante", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idEstudiante", idEstudiante));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MateriasM temp = new MateriasM();
                temp.Codigo_Materia = reader["idMateria"].ToString();
                temp.Nombre = reader["nombre"].ToString();

                materias.Add(temp);
            }
            reader.Close();

            return materias;
        }
    }
}
