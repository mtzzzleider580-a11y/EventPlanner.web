
using EventPlanner.Web.Data;
using EventPlanner.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Web.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Registro()
        {
            ProgramaFormacionDAO daoPrograma = new ProgramaFormacionDAO();

            ViewBag.Programas = daoPrograma.Listar();

            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            usuario.Rol = "APRENDIZ";

            usuario.FechaRegistro = DateTime.Now;

            UsuarioDAO dao = new UsuarioDAO();

            if (dao.ExisteCorreo(usuario.Correo))
            {
                ViewBag.Mensaje =
                    "Ya existe un usuario registrado con este correo";

                ProgramaFormacionDAO DaoPrograma =
                    new ProgramaFormacionDAO();

                ViewBag.Programas =
                    DaoPrograma.Listar();
                return View();
            }

            if (dao.ExisteDocumento(usuario.NumeroDocumento))
            {
                ViewBag.TipoMensaje = "error";

                ViewBag.Mensaje =
                    "Ya existe un usuario registrado con este número de documento";

                ProgramaFormacionDAO daPrograma =
                    new ProgramaFormacionDAO();

                ViewBag.Programas = daPrograma.Listar();

                return View();
            }

            bool registrado = dao.Registrar(usuario);

            ProgramaFormacionDAO daoPrograma = new ProgramaFormacionDAO();

            ViewBag.Programas = daoPrograma.Listar();

            if (registrado)
            {
                ViewBag.Mensaje = "Usuario registrado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al registrar usuario";
            }

            return View();
        }


       
        // LOGIN
        

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel modelo)
        {
            UsuarioDAO dao = new UsuarioDAO();

            Usuario usuario = dao.Login(
                modelo.Correo,
                modelo.Contrasena
            );

            if (usuario != null)
            {
                if (usuario.Rol != "APRENDIZ")
                {
                    ViewBag.Mensaje =
                    "Este usuario no se reconoce como aprendiz.";

                    return View();
                }

                Session["NombreUsuario"] = usuario.NombreCompleto;
                Session["IdUsuario"] = usuario.idUsuario;
                Session["Rol"] = usuario.Rol;

                return RedirectToAction("Menu", "Menu");
            }

            ViewBag.Mensaje =
            "Correo o contraseña incorrectos";

            return View();
        }
    }
}
// prueba de commit para verificar la funcionalidad del SP-1 en el SP-2
