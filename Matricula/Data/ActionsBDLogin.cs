using Matricula.Areas.Users.Data;
using Matricula.Areas.Users.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Data
{
    public class ActionsBDLogin
    {
        Conection con = new Conection();
        SqlConnection connection;

        public ActionsBDLogin()
        {
            connection = con.getConnection();
        }

        public string inicioSesion(string correo, string pass)
        {
            string cantidad = "";
            connection.Open();
            SqlCommand cmd = new SqlCommand("InicioSesion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@correo", correo));
            cmd.Parameters.Add(new SqlParameter("@pass", pass));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cantidad = reader[0].ToString();
            }
            reader.Close();

            return cantidad;
        }

        public InputModelRegister getUn_Usuario3(string correo)
        {
            ArrayList roles = new ArrayList();
            ActionsBD actionsBD = new ActionsBD();
            roles = actionsBD.getRoles();
            InputModelRegister persona = new InputModelRegister();
            //connection.Open();
            SqlCommand cmd = new SqlCommand("ConsultarUnUsuario3", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@correo", correo));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                persona.Identificacion = reader["Cedula"].ToString();
                persona.Nombre = reader["Nombre"].ToString();
                persona.PrimerApellido = reader["Primer_Apellido"].ToString();
                persona.SegundoApellido = reader["Segundo_Apellido"].ToString();
                persona.FechaNacimiento = reader["Fecha_Nacimiento"].ToString();
                persona.CorreoElectronico = reader["Correo_Electronico"].ToString();
                persona.Telefono = reader["Telefono"].ToString();
                persona.Direccion = reader["Direccion"].ToString();
                persona.Password = "No disponible";

                if (Int32.Parse(reader["idRol"].ToString()) == 1)
                {
                    persona.Rol = roles[0].ToString();
                }
                else if (Int32.Parse(reader["idRol"].ToString()) == 2)
                {
                    persona.Rol = roles[1].ToString();
                }
                else if (Int32.Parse(reader["idRol"].ToString()) == 3)
                {
                    persona.Rol = roles[2].ToString();
                }

                if (persona.Rol.Equals("Admin"))
                {
                    persona.Carrera = "No disponible";
                }
                else
                {
                    persona.Carrera = reader["NombreCarrera"].ToString();
                }
            }
            reader.Close();

            return persona;
        }
    }
}
