using System;
using System.Data;


namespace Proyecto_Articulos
{
    public class NArticulos
    {
        public static DataTable ObtenArticulos()
        {
            return DArticulos.ObtenArticulos();
        }

        public static string Agregar(Articulos articulo)
        {
            //validar que el libro No exista
            //buscandolo en el Datos por medio de 'existe'
            string existe = DArticulos.BuscarClave(articulo.pArtID);
            //si no existe
            //se agrega invocando el agregar de 'Datos'
            if (existe.Equals("0"))
            {
                return DArticulos.Agregar(articulo);
            }
            else
            {
                return "YA EXISTE";
            }
        }

        public static string BuscarNombreArticulo(string nombreLibro)
        {
            string respuesta = "NO EXISTE";
            string retorno = DArticulos.BuscarNombreArticulo(nombreLibro);

            if (retorno.Equals("1"))
                respuesta = "YA EXISTE";
            return respuesta;
        }
    }
}
