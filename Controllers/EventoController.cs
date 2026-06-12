using EventPlanner.Web.Data;
using EventPlanner.Web.Models;
using System;
using System.Web.Mvc;

namespace EventPlanner.Web.Controllers
{
    public class EventoController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            EventoDAO dao = new EventoDAO();
            return View(dao.Listar());
        }

        [HttpGet]
        public ActionResult Crear()
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            TipoEventoDAO daoTipo = new TipoEventoDAO();
            ViewBag.TiposEvento = daoTipo.Listar();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Evento evento)
        {
            TipoEventoDAO daoTipo = new TipoEventoDAO();
            ViewBag.TiposEvento = daoTipo.Listar();

            if (evento.HoraFin <= evento.HoraInicio)
            {
                ViewBag.Mensaje = "La hora final debe ser mayor que la hora inicial";
                return View(evento);
            }

            EventoDAO dao = new EventoDAO();
            bool resultado = dao.Registrar(evento);

            if (resultado)
            {
                TempData["Mensaje"] = "Evento registrado correctamente";
                return RedirectToAction("Index");
            }

            ViewBag.Mensaje = "No fue posible registrar el evento";
            return View(evento);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            EventoDAO dao = new EventoDAO();
            TipoEventoDAO daoTipo = new TipoEventoDAO();
            ViewBag.TiposEvento = daoTipo.Listar();

            Evento evento = dao.ObtenerPorId(id);
            return View(evento);
        }

        [HttpPost]
        public ActionResult Editar(Evento evento)
        {
            TipoEventoDAO daoTipo = new TipoEventoDAO();
            ViewBag.TiposEvento = daoTipo.Listar();

            if (evento.HoraFin <= evento.HoraInicio)
            {
                ViewBag.Mensaje = "La hora final debe ser mayor que la hora inicial";
                return View(evento);
            }

            EventoDAO dao = new EventoDAO();
            bool resultado = dao.Editar(evento);

            if (resultado)
            {
                TempData["Mensaje"] = "Evento actualizado correctamente";
                return RedirectToAction("Index");
            }

            ViewBag.Mensaje = "No fue posible actualizar el evento";
            return View(evento);
        }

        public ActionResult CambiarEstado(int id)
        {
            EventoDAO dao = new EventoDAO();
            dao.CambiarEstado(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id = 0)
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            if (id == 0)
                return RedirectToAction("Index");

            EventoDAO dao = new EventoDAO();
            dao.Eliminar(id);

            TempData["Mensaje"] = "Evento eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}