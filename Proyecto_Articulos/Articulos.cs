using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Articulos
{
    public class Articulos
    {
        private int artid;
        private string artNombre;
        private string artDescripcion;
        private double artPrecio;
        private int famid;

        public Articulos(int ArtID, string ArtNombre, string ArtDescripcion, double ArtPrecio, int FamID)
        {
            artid = ArtID;
            artNombre = ArtNombre;
            artDescripcion = ArtDescripcion;
            artPrecio = ArtPrecio;
            famid = FamID;
        }

        public int pArtID
        {
            get
            {
                return artid;
            }

        }
        public string pArtNombre
        {
            get
            {
                return artNombre;
            }

        }
        public string pArtDescripcion
        {
            get
            {
                return artDescripcion;
            }

        }

        public double pArtPrecio
        {
            get
            {
                return artPrecio;
            }
        }
        public int pFamid
        {
            get
            {
                return famid;
            }

        }
    }
}
