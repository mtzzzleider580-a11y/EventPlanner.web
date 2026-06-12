using System;
using System.Collections.Generic;
using EventPlanner.Web.Data;
using EventPlanner.Web.Models;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace EventPlanner.Web.Controllers
{
    public class EquipoController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            EquipoDAO dao = new EquipoDAO();
            return View(dao.Listar());
        }

        [HttpGet]
        public ActionResult Crear()
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            EventoDAO daoEvento = new EventoDAO();
            ViewBag.Eventos = daoEvento.Listar();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Equipo equipo)
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            EventoDAO daoEvento = new EventoDAO();
            ViewBag.Eventos = daoEvento.Listar();

            if (equipo.CantidadMinima <= 0 || equipo.CantidadMaxima <= 0 || equipo.CantidadMinima > equipo.CantidadMaxima)
            {
                ViewBag.Mensaje = "Verifique las cantidades: mínima > 0, máxima > 0 y mínima ≤ máxima.";
                return View(equipo);
            }

            EquipoDAO dao = new EquipoDAO();
            bool resultado = dao.Registrar(equipo);

            if (resultado)
            {
                TempData["Mensaje"] = "Equipo registrado correctamente";
                return RedirectToAction("Index");
            }

            ViewBag.Mensaje = "No fue posible registrar el equipo";
            return View(equipo);
        }

        [HttpGet]
        public ActionResult Editar(int? id)
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            if (!id.HasValue || id.Value == 0)
                return RedirectToAction("Index");

            EventoDAO daoEvento = new EventoDAO();
            ViewBag.Eventos = daoEvento.Listar();

            EquipoDAO dao = new EquipoDAO();
            var equipo = dao.ObtenerPorId(id.Value);

            if (equipo == null)
                return RedirectToAction("Index");

            return View(equipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Equipo equipo)
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            EventoDAO daoEvento = new EventoDAO();
            ViewBag.Eventos = daoEvento.Listar();

            if (equipo.CantidadMinima <= 0 || equipo.CantidadMaxima <= 0 || equipo.CantidadMinima > equipo.CantidadMaxima)
            {
                ViewBag.Mensaje = "Verifique las cantidades: mínima > 0, máxima > 0 y mínima ≤ máxima.";
                return View(equipo);
            }

            EquipoDAO dao = new EquipoDAO();
            bool resultado = dao.Editar(equipo);

            if (resultado)
            {
                TempData["Mensaje"] = "Equipo actualizado correctamente";
                return RedirectToAction("Index");
            }

            ViewBag.Mensaje = "No fue posible actualizar el equipo";
            return View(equipo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id = 0)
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            if (id == 0)
                return RedirectToAction("Index");

            EquipoDAO dao = new EquipoDAO();
            dao.Eliminar(id);

            TempData["Mensaje"] = "Equipo eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}