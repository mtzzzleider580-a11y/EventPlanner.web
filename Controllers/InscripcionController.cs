using EventPlanner.Web.Data;
using EventPlanner.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Web.Controllers
{
    public class InscripcionController : Controller
    {

        public ActionResult Registrar(int id)
        {
            Inscripcion inscripcion = new Inscripcion();

            inscripcion.idUsuario =
                Convert.ToInt32(Session["IdUsuario"]);

            inscripcion.idEvento = id;

            inscripcion.FechaInscripcion =
                DateTime.Now;

            InscripcionDAO dao =
                new InscripcionDAO();

            bool registrado =
                dao.Registrar(inscripcion);

            if (registrado)
            {
                TempData["Mensaje"] =
                    "Inscripción realizada correctamente";
            }

            return RedirectToAction(
                "Disponibles",
                "Evento");

        }
    }
}