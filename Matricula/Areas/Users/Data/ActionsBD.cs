using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using Matricula.Areas.Users.Models;

namespace Matricula.Areas.Users.Data
{
    public class ActionsBD
    {
        Conection con = new Conection();
        SqlConnection connection;

        public ActionsBD()
        {
            connection = con.getConnection();
        }

        public ArrayList getRoles()
        {
            ArrayList roles = new ArrayList();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarRoles", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                roles.Add(reader["Nombre"]);
            }
            reader.Close();

            return roles;
        }

        public ArrayList getCarreras()
        {
            ArrayList carreras = new ArrayList();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarCarreras", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                carreras.Add(reader["nombre"]);
            }
            reader.Close();

            return carreras;
        }

        public string verificarCorreo(string correo)
        {
            string cantidad = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("verificarCorreo", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@correo", correo));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cantidad = reader[0].ToString();
            }
            reader.Close();

            return cantidad;
        }

        public string registrarPersona(InputModelRegister input)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("RegistrarPersona", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cedula", input.Identificacion));
            cmd.Parameters.Add(new SqlParameter("@nombre", input.Nombre));
            cmd.Parameters.Add(new SqlParameter("@pApellido", input.PrimerApellido));
            cmd.Parameters.Add(new SqlParameter("@sApellido", input.SegundoApellido));
            cmd.Parameters.Add(new SqlParameter("@fecha", input.FechaNacimiento));
            cmd.Parameters.Add(new SqlParameter("@email", input.CorreoElectronico));
            cmd.Parameters.Add(new SqlParameter("@telefono", input.Telefono));
            cmd.Parameters.Add(new SqlParameter("@direccion", input.Direccion));
            cmd.Parameters.Add(new SqlParameter("@pass", input.Password));
            cmd.Parameters.Add(new SqlParameter("@nomRol", input.Rol));

            if (input.Rol.Equals("Admin"))
            {
                cmd.Parameters.Add(new SqlParameter("@nombreC", "NULL"));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@nombreC", input.Carrera));
            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estado = reader[0].ToString();
            }
            reader.Close();

            return estado;
        }

        public List<InputModelRegister> getUsuarios()
        {
            ArrayList roles = new ArrayList();
            roles = getRoles();
            List<InputModelRegister> personas = new List<InputModelRegister>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarPersonas", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                InputModelRegister temp = new InputModelRegister();
                temp.Identificacion = reader["Cedula"].ToString();
                temp.Nombre = reader["Nombre"].ToString();
                temp.PrimerApellido = reader["Primer_Apellido"].ToString();
                temp.SegundoApellido = reader["Segundo_Apellido"].ToString();
                temp.FechaNacimiento = reader["Fecha_Nacimiento"].ToString();
                temp.CorreoElectronico = reader["Correo_Electronico"].ToString();
                temp.Telefono = reader["Telefono"].ToString();
                temp.Direccion = reader["Direccion"].ToString();
                temp.Password = "No disponible";

                if (Int32.Parse(reader["idRol"].ToString()) == 1)
                {
                    temp.Rol = roles[0].ToString();
                }
                else if (Int32.Parse(reader["idRol"].ToString()) == 2)
                {
                    temp.Rol = roles[1].ToString();
                }
                else if (Int32.Parse(reader["idRol"].ToString()) == 3)
                {
                    temp.Rol = roles[2].ToString();
                }

                if (temp.Rol.Equals("Admin"))
                {
                    temp.Carrera = "No disponible";
                }
                else
                {
                    temp.Carrera = reader["NombreCarrera"].ToString();
                }
                personas.Add(temp);
            }
            reader.Close();

            return personas;
        }

        public InputModelRegister getUn_Usuario(string id)
        {
            int identificador = Int32.Parse(id);
            ArrayList roles = new ArrayList();
            roles = getRoles();
            InputModelRegister persona = new InputModelRegister();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarUnUsuario", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cedula", identificador));
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

        public List<InputModelRegister> getUn_Usuario2(string nombre)
        {
            ArrayList roles = new ArrayList();
            roles = getRoles();
            List<InputModelRegister> personas = new List<InputModelRegister>();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ConsultarUnUsuario2", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                InputModelRegister persona = new InputModelRegister();
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

                personas.Add(persona);

            }
            reader.Close();

            return personas;
        }

        public string modificarPersona(InputModelRegister input)
        {
            string estado = "";
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ModificarPersona", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@identificacion", input.Identificacion));
            cmd.Parameters.Add(new SqlParameter("@nombre", input.Nombre));
            cmd.Parameters.Add(new SqlParameter("@pApellido", input.PrimerApellido));
            cmd.Parameters.Add(new SqlParameter("@sApellido", input.SegundoApellido));
            cmd.Parameters.Add(new SqlParameter("@fecha", input.FechaNacimiento));
            cmd.Parameters.Add(new SqlParameter("@telefono", input.Telefono));
            cmd.Parameters.Add(new SqlParameter("@direccion", input.Direccion));

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
