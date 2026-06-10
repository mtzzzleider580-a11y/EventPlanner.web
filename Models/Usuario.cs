using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanner.Web.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        public int idProgramaFormacion { get; set; }

        public string TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public string Ficha { get; set; }

        public string Jornada { get; set; }

        public string Rol { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Contrasena { get; set; }

    }
}