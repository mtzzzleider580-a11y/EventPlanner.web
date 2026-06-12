using EventPlanner.Web.Data;
using System.Web.Mvc;

namespace EventPlanner.Web.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            if (Session["Rol"].ToString() != "ADMIN")
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Dashboard", "Admin");
        }

        public ActionResult Dashboard()
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuario");

            if (Session["Rol"].ToString() != "ADMIN")
                return RedirectToAction("Index", "Home");

            ViewBag.Nombre = Session["Nombre"];
            ViewBag.Rol = Session["Rol"];

            EventoDAO dao = new EventoDAO();
            var eventos = dao.Listar();

            ViewBag.TotalEventos = eventos.Count;
            ViewBag.EventosActivos = eventos.FindAll(e => e.Activo).Count;
            ViewBag.EventosInactivos = eventos.FindAll(e => !e.Activo).Count;

            return View(eventos);
        }
    }
}