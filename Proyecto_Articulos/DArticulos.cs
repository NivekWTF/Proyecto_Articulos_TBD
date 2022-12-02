using System;
using System.Data;
using System.Data.SqlClient;


namespace Proyecto_Articulos
{
    public class DArticulos
    {

        public static DataTable ObtenArticulos()
        {
            SqlDataReader lector = null;
            DataTable tabla = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = Conexion.CrearConexion();
                SqlCommand comando = new SqlCommand("Ventas_Listar", conn);
                comando.CommandType = CommandType.StoredProcedure;
                lector = comando.ExecuteReader();
                tabla.Load(lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public static string BuscarClave(int clave)
        {
            SqlConnection conn = null;
            string Rpta = "";

            try
            {
                conn = Conexion.CrearConexion();
                SqlCommand comando = new SqlCommand("Articulo_ExisteClave", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = clave;
                SqlParameter parExiste = new SqlParameter();
                parExiste.ParameterName = "@existe";
                parExiste.SqlDbType = SqlDbType.Int;
                parExiste.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parExiste);
                comando.ExecuteNonQuery();
                Rpta = Convert.ToString(parExiste.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return Rpta;
        }

        public static string Agregar(Articulos articulos)
        {
            string Rpta = "";
            SqlConnection conn = null;
            try
            {
                conn = Conexion.CrearConexion();
                SqlCommand comando = new SqlCommand("Articulos_Insertar", conn);
                comando.CommandType = CommandType.StoredProcedure;
                // insertar

                comando.Parameters.AddWithValue("@artid", articulos.pArtID);
                comando.Parameters.AddWithValue("@artnombre", articulos.pArtNombre);
                comando.Parameters.AddWithValue("@artdescripcion", articulos.pArtDescripcion);
                comando.Parameters.AddWithValue("@artprecio ", articulos.pArtPrecio);
                comando.Parameters.AddWithValue("@famid", articulos.pFamid);



                Rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";

            }
            catch (Exception EX)
            {
                throw EX;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return Rpta;
        }

        public static string BuscarNombreArticulo(string NombreArticulo)
        {
            SqlConnection conn = null;
            string Rpta = "";

            try
            {
                conn = Conexion.CrearConexion();
                SqlCommand comando = new SqlCommand("Articulos_ExisteNombre", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = NombreArticulo;
                SqlParameter parExiste = new SqlParameter();
                parExiste.ParameterName = "@existe";
                parExiste.SqlDbType = SqlDbType.Int;
                parExiste.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parExiste);
                comando.ExecuteNonQuery();
                Rpta = Convert.ToString(parExiste.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return Rpta;
        }


    }
}
