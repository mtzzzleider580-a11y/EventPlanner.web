using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanner.Web.Models
{
    public class Inscripcion
    {

        public int idInscripcion { get; set; }

        public int idUsuario { get; set; }

        public int idEvento { get; set; }

        public int? idEquipo { get; set; }

        public DateTime FechaInscripcion { get; set; }
    }
}