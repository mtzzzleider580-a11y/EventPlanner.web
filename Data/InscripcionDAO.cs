using EventPlanner.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventPlanner.Web.Data
{
    public class InscripcionDAO
    {
        public bool Registrar(Inscripcion inscripcion)
        {
            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"
                    INSERT INTO Inscripcion
                    (
                        idUsuario,
                        idEvento,
                        FechaInscripcion
                    )
                    VALUES
                    (
                        @idUsuario,
                        @idEvento,
                        @FechaInscripcion
                    )";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@idUsuario", inscripcion.idUsuario);
                    cmd.Parameters.AddWithValue("@idEvento", inscripcion.idEvento);
                    cmd.Parameters.AddWithValue("@FechaInscripcion", inscripcion.FechaInscripcion);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}