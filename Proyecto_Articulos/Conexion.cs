using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto_Articulos
{
    public class Conexion
    {
        public static SqlConnection CrearConexion()
        {
            string servidor = "DESKTOP-6F2PUEF\\SQLEXPRESS";
            string strConn = "Data Source="+servidor+";Initial Catalog=ventas;Persist Security Info=True;User ID=sa;Password=1234";

               SqlConnection conn;
            // no se si va el try
            try
            {
                conn = LibreriaBD.UsoBD.ConectaBD(strConn);
            }
            catch (Exception ex)
            {
                conn = null;
                throw ex;

            }
            return conn;

        }

        private static string GetConnectionString()
        {
            string strConn = "";

            try
            {
                strConn = ConfigurationManager.ConnectionStrings["conStrBD"].ConnectionString;
            }
            catch (Exception)
            {
                throw;
            }
            return strConn;
        }
    }
}
