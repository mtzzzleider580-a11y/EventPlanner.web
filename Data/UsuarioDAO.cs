using EventPlanner.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventPlanner.Web.Data
{
    public class UsuarioDAO

    {
        public bool Registrar(Usuario usuario)
        {
            try
            {
                Conexion conexion = new Conexion();

                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"INSERT INTO Usuario(idProgramaFormacion,TipoDocumento,NumeroDocumento,NombreCompleto,Correo,Ficha,Jornada,Rol,FechaRegistro,Contrasena)
                    VALUES (@idProgramaFormacion,@TipoDocumento,@NumeroDocumento,@NombreCompleto,@Correo,@Ficha,@Jornada,@Rol,@FechaRegistro,@Contrasena)";

                    SqlCommand cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@idProgramaFormacion", usuario.idProgramaFormacion);
                    cmd.Parameters.AddWithValue("@TipoDocumento", usuario.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", usuario.NumeroDocumento);
                    cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@Ficha", usuario.Ficha);
                    cmd.Parameters.AddWithValue("@Jornada", usuario.Jornada);
                    cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                    cmd.Parameters.AddWithValue("@FechaRegistro", usuario.FechaRegistro);
                    cmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // aqui vamos con el login
        public Usuario Login(string correo, string contrasena)
        {
            Usuario usuario = null;

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT *
                       FROM Usuario
                       WHERE Correo = @Correo
                       AND Contrasena = @Contrasena";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    usuario = new Usuario();

                    usuario.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    usuario.NombreCompleto = dr["NombreCompleto"].ToString();
                    usuario.Correo = dr["Correo"].ToString();
                    usuario.Rol = dr["Rol"].ToString();
                }
            }

            return usuario;
        }

        public bool ExisteCorreo(string correo)
        {
            bool existe = false;

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT COUNT(*)
                       FROM Usuario
                       WHERE Correo = @Correo";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Correo", correo);

                int cantidad = (int)cmd.ExecuteScalar();

                existe = cantidad > 0;
            }

            return existe;
        }

        public bool ExisteDocumento(string numeroDocumento)
        {
            bool existe = false;

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"SELECT COUNT(*)
                       FROM Usuario
                       WHERE NumeroDocumento = @NumeroDocumento";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@NumeroDocumento",
                    numeroDocumento
                );

                int cantidad = (int)cmd.ExecuteScalar();

                existe = cantidad > 0;
            }

            return existe;
        }

    }
}