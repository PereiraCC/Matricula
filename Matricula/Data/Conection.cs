using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace Matricula.Areas.Users.Data
{
    public class Conection
    {
        public IConfiguration Configuration { get; }

        public Conection() { }

        public SqlConnection getConnection()
        {
            SqlConnectionStringBuilder cadena = new SqlConnectionStringBuilder();
            cadena.DataSource = "PEREIRACOTO-PC\\PEREIRASERVER";
            cadena.InitialCatalog = "Matricula";
            cadena.UserID = "sa";
            cadena.Password = "Datos.2020";
            cadena.IntegratedSecurity = false;
            string conexionBD = cadena.ToString();
            SqlConnection connection = new SqlConnection(conexionBD);
            return connection;
        }
    }
}
