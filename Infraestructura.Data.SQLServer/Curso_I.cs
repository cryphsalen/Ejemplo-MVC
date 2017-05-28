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
    public class Curso_I
    {
        SqlConnection conexion;
        SqlDataReader dr;
        SqlCommand cmd;
        String errores;

        Conexion cn = new Conexion();

        public IEnumerable<Curso> ListarCursos()
        {
            List<Curso> lista = new List<Curso>();

            try
            {
                conexion = cn.Conectar();
                cmd = new SqlCommand("PR_LISTAR_CURSOS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                dr = null;

                conexion.Open();
                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Curso objeto = new Curso();

                    objeto.codigo = Convert.ToInt32(dr["codigo"]);
                    objeto.nombre = Convert.ToString(dr["nombre"]);
                    objeto.correo = Convert.ToString(dr["correo"]);
                    objeto.credito = Convert.ToInt32(dr["credito"]);

                    lista.Add(objeto);
                }

                dr.Close();
            }
            catch(Exception ex)
            {
                errores = ex.Message;
            }
            finally{
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                conexion.Dispose();
                cmd.Dispose();
            }

            return lista;
        }

        public Boolean RegistrarCurso (Curso objeto)
        {
            try
            {
                conexion = cn.Conectar();
                cmd = new SqlCommand("PR_REGISTRAR_CURSO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100));
                cmd.Parameters["@Nombre"].Direction = ParameterDirection.Input;
                cmd.Parameters["@Nombre"].Value = objeto.nombre;

                cmd.Parameters.Add(new SqlParameter("@Correo", SqlDbType.VarChar, 100));
                cmd.Parameters["@Correo"].Direction = ParameterDirection.Input;
                cmd.Parameters["@Correo"].Value = objeto.correo;

                cmd.Parameters.Add(new SqlParameter("@NumCreditos", SqlDbType.Int, 100));
                cmd.Parameters["@NumCreditos"].Direction = ParameterDirection.Input;
                cmd.Parameters["@NumCreditos"].Value = objeto.credito;

                conexion.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex) 
            {
                errores = ex.Message;
                return false;
            }
            finally {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

                // Se Libera Memoria
                conexion = null;
                cmd = null;
                cn = null;
            }
        }

    }
}
