using System;
using System.Collections.Generic;
using EventPlanner.Web.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventPlanner.Web.Data
{
    public class TipoEventoDAO
    {
        public List<TipoEvento> Listar()
        {
            List<TipoEvento> lista =
                new List<TipoEvento>();

            Conexion conexion =
                new Conexion();

            using (SqlConnection cn =
                conexion.ObtenerConexion())
            {
                cn.Open();

                string sql =
                    @"SELECT * FROM TipoEvento";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    TipoEvento tipo =
                        new TipoEvento();

                    tipo.idTipoEvento =
                        (int)dr["idTipoEvento"];

                    tipo.NombreTipoEvento =
                        dr["NombreTipoEvento"]
                        .ToString();

                    lista.Add(tipo);
                }
            }

            return lista;
        }
    }
}