using System.Collections.Generic;

namespace UF5_AC1.Clases
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public LinkedList<Videojuego> JuegosAlquilados { get; private set; }
        public Estado Estado { get; private set; }

        public Usuario(string nombre, string apellido, int edad, string direccion, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Direccion = direccion;
            Telefono = telefono;
            JuegosAlquilados = new LinkedList<Videojuego>();
            Estado = new Estado();
        }

        public void AlquilarJuego(Videojuego videojuego)
        {
            JuegosAlquilados.AddLast(videojuego);
            videojuego.IncrementarVecesAlquilado();
        }
    }
}
