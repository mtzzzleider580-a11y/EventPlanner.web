using EventPlanner.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Web.Controllers
{
    public class EventoController : Controller
    {

        public ActionResult Disponibles()
        {
            EventoDAO dao = new EventoDAO();

            var lista = dao.ListarDisponibles();

            return View(lista);
        }

    }
}