using System;
using EventPlanner.Web.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventPlanner.Web.Data
{
    public class EquipoDAO
    {
        public List<Equipo> Listar()
        {
            List<Equipo> lista = new List<Equipo>();
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                SELECT E.*, EV.NombreEvento
                FROM Equipo E
                INNER JOIN Evento EV ON E.idEvento = EV.idEvento
                ORDER BY E.idEquipo DESC";

                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Equipo e = new Equipo
                    {
                        idEquipo = Convert.ToInt32(dr["idEquipo"]),
                        idEvento = Convert.ToInt32(dr["idEvento"]),
                        NombreEquipo = dr["NombreEquipo"].ToString(),
                        CantidadMinima = Convert.ToInt32(dr["CantidadMinima"]),
                        CantidadMaxima = Convert.ToInt32(dr["CantidadMaxima"]),
                        NombreEvento = dr["NombreEvento"].ToString()
                    };

                    lista.Add(e);
                }
            }

            return lista;
        }

        public bool Registrar(Equipo equipo)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                INSERT INTO Equipo
                (idEvento, NombreEquipo, CantidadMinima, CantidadMaxima)
                VALUES
                (@idEvento, @NombreEquipo, @CantidadMinima, @CantidadMaxima)";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@idEvento", equipo.idEvento);
                cmd.Parameters.AddWithValue("@NombreEquipo", equipo.NombreEquipo);
                cmd.Parameters.AddWithValue("@CantidadMinima", equipo.CantidadMinima);
                cmd.Parameters.AddWithValue("@CantidadMaxima", equipo.CantidadMaxima);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Equipo ObtenerPorId(int id)
        {
            Equipo equipo = null;
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                SELECT E.*, EV.NombreEvento
                FROM Equipo E
                LEFT JOIN Evento EV ON E.idEvento = EV.idEvento
                WHERE E.idEquipo = @idEquipo";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@idEquipo", id);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    equipo = new Equipo
                    {
                        idEquipo = Convert.ToInt32(dr["idEquipo"]),
                        idEvento = Convert.ToInt32(dr["idEvento"]),
                        NombreEquipo = dr["NombreEquipo"].ToString(),
                        CantidadMinima = Convert.ToInt32(dr["CantidadMinima"]),
                        CantidadMaxima = Convert.ToInt32(dr["CantidadMaxima"]),
                        NombreEvento = dr["NombreEvento"] != DBNull.Value ? dr["NombreEvento"].ToString() : null
                    };
                }
            }

            return equipo;
        }

        public bool Editar(Equipo equipo)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                UPDATE Equipo
                SET idEvento = @idEvento,
                    NombreEquipo = @NombreEquipo,
                    CantidadMinima = @CantidadMinima,
                    CantidadMaxima = @CantidadMaxima
                WHERE idEquipo = @idEquipo";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@idEvento", equipo.idEvento);
                cmd.Parameters.AddWithValue("@NombreEquipo", equipo.NombreEquipo);
                cmd.Parameters.AddWithValue("@CantidadMinima", equipo.CantidadMinima);
                cmd.Parameters.AddWithValue("@CantidadMaxima", equipo.CantidadMaxima);
                cmd.Parameters.AddWithValue("@idEquipo", equipo.idEquipo);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = "DELETE FROM Equipo WHERE idEquipo = @idEquipo";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@idEquipo", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}