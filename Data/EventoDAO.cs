using EventPlanner.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventPlanner.Web.Data
{
    public class EventoDAO
    {



        public List<Evento> ListarDisponibles()
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
                WHERE E.Activo = 1
                ";

                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Evento evento = new Evento();

                    evento.idEvento = (int)dr["idEvento"];
                    evento.NombreEvento = dr["NombreEvento"].ToString();
                    evento.Descripcion = dr["Descripcion"].ToString();
                    evento.Modalidad = dr["Modalidad"].ToString();
                    evento.Lugar = dr["Lugar"].ToString();
                    evento.FechaEvento = (System.DateTime)dr["FechaEvento"];
                    evento.HoraInicio = (System.TimeSpan)dr["HoraInicio"];
                    evento.HoraFin = (System.TimeSpan)dr["HoraFin"];
                    evento.CuposTotales = (int)dr["CuposTotales"];
                    evento.NombreTipoEvento = dr["NombreTipoEvento"].ToString();

                    lista.Add(evento);
                }
            }

            return lista;


        }
    }
}