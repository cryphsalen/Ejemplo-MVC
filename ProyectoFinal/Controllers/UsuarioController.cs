using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Core.Entities;
using Dominio.Main.Module;
using System.Collections;

namespace ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validar()
        {
            if(Request.Cookies["Usuario"] != null)
            {
                // Para eliminar la cookie ya existente, se pone la expiración con un día anterior al de hoy.
                Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(-1);
            }

            if (Request.Cookies["NombreUsuario"] != null)
            {
                // Para eliminar la cookie ya existente, se pone la expiración con un día anterior al de hoy.
                Response.Cookies["NombreUsuario"].Expires = DateTime.Now.AddDays(-1);
            }

            return View();
        }

        [HttpPost] // Enlace
        public ActionResult Validar(string user, string password)
        {
            IEnumerable<Usuario> objeto = null;
            UsuarioManager manager = new UsuarioManager();

            objeto = manager.LoginUsuario(user, password);

            if(objeto.Count() == 0)
            {
                return View();
            }
            else
            {
                // Se almacenan en la cookie los datos del usuario.
                Response.Cookies["Usuario"].Value = objeto.ElementAt(0).nombre.ToString();
                Response.Cookies["NombreUsuario"].Value = objeto.ElementAt(0).nombre_Usuario.ToString();

                // La cookie expirará al día siguiente.
                Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["NombreUsuario"].Expires = DateTime.Now.AddDays(1);

                // Redireccionamos al Controller Curso, ActionResult Index()
                return RedirectToAction("Index","Curso");
            }
        }

        
    }
}
