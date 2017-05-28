using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SQLServer
{
    public class Usuario_I
    {
        SqlConnection conexion;
        SqlDataReader dr;
        SqlCommand cmd;
        String errores;

        Conexion cn = new Conexion();

        public IEnumerable<Usuario> LoginUsuario(string user, string password)
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                conexion = cn.Conectar();
                cmd = new SqlCommand("PR_LOGIN", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 10));
                cmd.Parameters["@Nombre"].Direction = ParameterDirection.Input;
                // se le pasa primer parámetro del método.
                cmd.Parameters["@Nombre"].Value = user;

                cmd.Parameters.Add(new SqlParameter("@Clave", SqlDbType.VarChar, 10));
                cmd.Parameters["@Clave"].Direction = ParameterDirection.Input;
                // se le pasa segundo parámetro del método.
                cmd.Parameters["@Clave"].Value = password;

                dr = null;
                conexion.Open();

                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Usuario objeto = new Usuario();
                    objeto.nombre = Convert.ToString(dr["nombre"]);
                    objeto.clave = Convert.ToString(dr["clave"]);
                    objeto.nombre_Usuario = Convert.ToString(dr["nombre_Usuario"]);

                    lista.Add(objeto);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                errores = ex.Message;
            }
            finally {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                conexion.Dispose();
                cmd.Dispose();
            }

            return lista;
        }
    }
}
