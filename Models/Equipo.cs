using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanner.Web.Models
{
    public class Equipo
    {
        public int idEquipo { get; set; }

        public int idEvento { get; set; }

        public string NombreEquipo { get; set; }

        public int CantidadMinima { get; set; }

        public int CantidadMaxima { get; set; }

        // Propiedad auxiliar para mostrar el nombre del evento en las vistas
        public string NombreEvento { get; set; }
    }
}