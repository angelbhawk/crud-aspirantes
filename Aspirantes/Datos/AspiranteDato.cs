using Aspirantes.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aspirantes.Datos
{
    public class AspiranteDato
    {
        public List<AspiranteModel> Listar()
        {
            var oLista = new List<AspiranteModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Todos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new AspiranteModel()
                        {
                            IdAspirante = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Localidad = dr["Localidad"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public AspiranteModel Obtener(int IdAspirante)
        {
            var oLista = new AspiranteModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("Id", IdAspirante);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.IdAspirante = Convert.ToInt32(dr["Id"]);
                        oLista.Nombre = dr["Nombre"].ToString();
                        oLista.Apellido = dr["Apellido"].ToString();
                        oLista.Telefono = dr["Telefono"].ToString();
                        oLista.Localidad = dr["Localidad"].ToString();
                        oLista.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oLista;
        }

        public bool Guardar(AspiranteModel oaspirante)
        {
            bool rpta;

            try 
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oaspirante.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oaspirante.Apellido);
                    cmd.Parameters.AddWithValue("Telefono", oaspirante.Telefono);
                    cmd.Parameters.AddWithValue("Localidad", oaspirante.Localidad);
                    cmd.Parameters.AddWithValue("Correo", oaspirante.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e) 
            {
                string erro = e.Message;
                rpta = false;
            }

            return rpta;
        }


        public bool Editar(AspiranteModel oaspirante)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Modificar", conexion);
                    cmd.Parameters.AddWithValue("Id", oaspirante.IdAspirante);
                    cmd.Parameters.AddWithValue("Nombre", oaspirante.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oaspirante.Apellido);
                    cmd.Parameters.AddWithValue("Telefono", oaspirante.Telefono);
                    cmd.Parameters.AddWithValue("Localidad", oaspirante.Localidad);
                    cmd.Parameters.AddWithValue("Correo", oaspirante.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string erro = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Borrar", conexion);
                    cmd.Parameters.AddWithValue("Id", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string erro = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
