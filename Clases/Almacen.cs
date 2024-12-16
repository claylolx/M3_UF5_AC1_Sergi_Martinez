using System.Collections.Generic;

namespace UF5_AC1.Clases
{
    public class Almacen
    {
        public LinkedList<Videojuego> Videojuegos { get; private set; }

        public Almacen()
        {
            Videojuegos = new LinkedList<Videojuego>();
        }

        public LinkedList<Videojuego> ObtenerListaVideojuegos() => Videojuegos;
    }
}
