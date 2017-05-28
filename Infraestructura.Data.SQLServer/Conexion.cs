using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Infraestructura.Data.SQLServer
{
    public class Conexion
    {
        SqlConnection conexion;

        public SqlConnection Conectar()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
            return conexion;
        }
    }
}
