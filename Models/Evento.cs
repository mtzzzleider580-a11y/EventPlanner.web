using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanner.Web.Models
{
    public class Evento
    {
        public int idEvento { get; set; }

        public int idTipoEvento { get; set; }

        public string NombreEvento { get; set; }

        public string Descripcion { get; set; }

        public string Modalidad { get; set; }

        public string Lugar { get; set; }

        public DateTime FechaEvento { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }

        public int CuposTotales { get; set; }

        public DateTime FechaInicioInscripcion { get; set; }

        public DateTime FechaFinInscripcion { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string NombreTipoEvento { get; set; }
    }
}