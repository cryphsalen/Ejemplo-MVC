using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using Infraestructura.Data.SQLServer;

namespace Dominio.Main.Module
{
    public class CursoManager
    {
        Curso_I cur = new Curso_I();

        public IEnumerable<Curso> ListarCursos()
        {
            return cur.ListarCursos();
        }

        public Boolean RegistrarCurso(Curso objeto)
        {
            return cur.RegistrarCurso(objeto);
        }
    }
}
