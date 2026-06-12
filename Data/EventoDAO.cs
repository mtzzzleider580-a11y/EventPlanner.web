using EventPlanner.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EventPlanner.Web.Data
{
    public class EventoDAO
    {
        public List<Evento> Listar()
        {
            List<Evento> lista = new List<Evento>();

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                SELECT
                    E.*,
                    T.NombreTipoEvento
                FROM Evento E
                INNER JOIN TipoEvento T
                    ON E.idTipoEvento = T.idTipoEvento
                ORDER BY E.FechaEvento DESC";

                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Evento evento = new Evento();

                    evento.idEvento =
                        Convert.ToInt32(dr["idEvento"]);

                    evento.idTipoEvento =
                        Convert.ToInt32(dr["idTipoEvento"]);

                    evento.NombreEvento =
                        dr["NombreEvento"].ToString();

                    evento.Descripcion =
                        dr["Descripcion"].ToString();

                    evento.Modalidad =
                        dr["Modalidad"].ToString();

                    evento.Lugar =
                        dr["Lugar"].ToString();

                    evento.FechaEvento =
                        Convert.ToDateTime(dr["FechaEvento"]);

                    evento.HoraInicio =
                        (TimeSpan)dr["HoraInicio"];

                    evento.HoraFin =
                        (TimeSpan)dr["HoraFin"];

                    evento.CuposTotales =
                        Convert.ToInt32(dr["CuposTotales"]);

                    evento.FechaInicioInscripcion =
                        Convert.ToDateTime(
                            dr["FechaInicioInscripcion"]);

                    evento.FechaFinInscripcion =
                        Convert.ToDateTime(
                            dr["FechaFinInscripcion"]);

                    evento.Activo =
                        Convert.ToBoolean(dr["Activo"]);

                    evento.NombreTipoEvento =
                        dr["NombreTipoEvento"].ToString();

                    lista.Add(evento);
                }
            }

            return lista;
        }

        public bool Registrar(Evento evento)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                INSERT INTO Evento
                (
                    idTipoEvento,
                    NombreEvento,
                    Descripcion,
                    Modalidad,
                    Lugar,
                    FechaEvento,
                    HoraInicio,
                    HoraFin,
                    CuposTotales,
                    FechaInicioInscripcion,
                    FechaFinInscripcion,
                    Activo,
                    FechaCreacion
                )
                VALUES
                (
                    @idTipoEvento,
                    @NombreEvento,
                    @Descripcion,
                    @Modalidad,
                    @Lugar,
                    @FechaEvento,
                    @HoraInicio,
                    @HoraFin,
                    @CuposTotales,
                    @FechaInicioInscripcion,
                    @FechaFinInscripcion,
                    @Activo,
                    @FechaCreacion
                )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@idTipoEvento",
                    evento.idTipoEvento);

                cmd.Parameters.AddWithValue(
                    "@NombreEvento",
                    evento.NombreEvento);

                cmd.Parameters.AddWithValue(
                    "@Descripcion",
                    evento.Descripcion);

                cmd.Parameters.AddWithValue(
                    "@Modalidad",
                    evento.Modalidad);

                cmd.Parameters.AddWithValue(
                    "@Lugar",
                    evento.Lugar);

                cmd.Parameters.AddWithValue(
                    "@FechaEvento",
                    evento.FechaEvento);

                cmd.Parameters.AddWithValue(
                    "@HoraInicio",
                    evento.HoraInicio);

                cmd.Parameters.AddWithValue(
                    "@HoraFin",
                    evento.HoraFin);

                cmd.Parameters.AddWithValue(
                    "@CuposTotales",
                    evento.CuposTotales);

                cmd.Parameters.AddWithValue(
                    "@FechaInicioInscripcion",
                    evento.FechaInicioInscripcion);

                cmd.Parameters.AddWithValue(
                    "@FechaFinInscripcion",
                    evento.FechaFinInscripcion);

                cmd.Parameters.AddWithValue(
                    "@Activo",
                    true);

                cmd.Parameters.AddWithValue(
                    "@FechaCreacion",
                    DateTime.Now);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Evento ObtenerPorId(int id)
        {
            Evento evento = null;

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql =
                    @"SELECT * FROM Evento
                      WHERE idEvento=@idEvento";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@idEvento",
                    id);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    evento = new Evento();

                    evento.idEvento =
                        Convert.ToInt32(dr["idEvento"]);

                    evento.idTipoEvento =
                        Convert.ToInt32(dr["idTipoEvento"]);

                    evento.NombreEvento =
                        dr["NombreEvento"].ToString();

                    evento.Descripcion =
                        dr["Descripcion"].ToString();

                    evento.Modalidad =
                        dr["Modalidad"].ToString();

                    evento.Lugar =
                        dr["Lugar"].ToString();

                    evento.FechaEvento =
                        Convert.ToDateTime(dr["FechaEvento"]);

                    evento.HoraInicio =
                        (TimeSpan)dr["HoraInicio"];

                    evento.HoraFin =
                        (TimeSpan)dr["HoraFin"];

                    evento.CuposTotales =
                        Convert.ToInt32(dr["CuposTotales"]);

                    evento.FechaInicioInscripcion =
                        Convert.ToDateTime(
                            dr["FechaInicioInscripcion"]);

                    evento.FechaFinInscripcion =
                        Convert.ToDateTime(
                            dr["FechaFinInscripcion"]);

                    evento.Activo =
                        Convert.ToBoolean(dr["Activo"]);
                }
            }

            return evento;
        }

        public bool Editar(Evento evento)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                UPDATE Evento
                SET
                    idTipoEvento=@idTipoEvento,
                    NombreEvento=@NombreEvento,
                    Descripcion=@Descripcion,
                    Modalidad=@Modalidad,
                    Lugar=@Lugar,
                    FechaEvento=@FechaEvento,
                    HoraInicio=@HoraInicio,
                    HoraFin=@HoraFin,
                    CuposTotales=@CuposTotales,
                    FechaInicioInscripcion=@FechaInicioInscripcion,
                    FechaFinInscripcion=@FechaFinInscripcion
                WHERE idEvento=@idEvento";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@idEvento",
                    evento.idEvento);

                cmd.Parameters.AddWithValue(
                    "@idTipoEvento",
                    evento.idTipoEvento);

                cmd.Parameters.AddWithValue(
                    "@NombreEvento",
                    evento.NombreEvento);

                cmd.Parameters.AddWithValue(
                    "@Descripcion",
                    evento.Descripcion);

                cmd.Parameters.AddWithValue(
                    "@Modalidad",
                    evento.Modalidad);

                cmd.Parameters.AddWithValue(
                    "@Lugar",
                    evento.Lugar);

                cmd.Parameters.AddWithValue(
                    "@FechaEvento",
                    evento.FechaEvento);

                cmd.Parameters.AddWithValue(
                    "@HoraInicio",
                    evento.HoraInicio);

                cmd.Parameters.AddWithValue(
                    "@HoraFin",
                    evento.HoraFin);

                cmd.Parameters.AddWithValue(
                    "@CuposTotales",
                    evento.CuposTotales);

                cmd.Parameters.AddWithValue(
                    "@FechaInicioInscripcion",
                    evento.FechaInicioInscripcion);

                cmd.Parameters.AddWithValue(
                    "@FechaFinInscripcion",
                    evento.FechaFinInscripcion);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CambiarEstado(int idEvento)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                UPDATE Evento
                SET Activo =
                CASE
                    WHEN Activo = 1 THEN 0
                    ELSE 1
                END
                WHERE idEvento=@idEvento";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@idEvento",
                    idEvento);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "DELETE FROM Evento WHERE idEvento = @idEvento";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@idEvento", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}