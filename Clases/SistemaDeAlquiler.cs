using System.Collections.Generic;

namespace UF5_AC1.Clases
{
    public class SistemaDeAlquiler
    {
        public LinkedList<Usuario> Usuarios { get; private set; }
        public Almacen Almacen { get; private set; }

        public SistemaDeAlquiler()
        {
            Usuarios = new LinkedList<Usuario>();
            Almacen = new Almacen();
        }

        public void AltaUsuario(Usuario usuario)
        {
            Usuarios.AddLast(usuario);
        }

        public void BajaUsuario(Usuario usuario)
        {
            Usuarios.Remove(usuario);
        }

        public void AltaVideojuego(Videojuego videojuego)
        {
            Almacen.Videojuegos.AddLast(videojuego);
        }

        public void BajaVideojuego(Videojuego videojuego)
        {
            Almacen.Videojuegos.Remove(videojuego);
        }

        public LinkedList<Videojuego> ListarVideojuegosDisponibles()
        {
            LinkedList<Videojuego> disponibles = new LinkedList<Videojuego>();
            foreach (var videojuego in Almacen.Videojuegos)
            {
                bool alquilado = false;
                foreach (var usuario in Usuarios)
                {
                    if (usuario.JuegosAlquilados.Contains(videojuego))
                    {
                        alquilado = true;
                        break;
                    }
                }
                if (!alquilado && videojuego.Estado.Activo)
                {
                    disponibles.AddLast(videojuego);
                }
            }
            return disponibles;
        }

        public LinkedList<Videojuego> ListarVideojuegosAlquilados()
        {
            LinkedList<Videojuego> alquilados = new LinkedList<Videojuego>();
            foreach (var usuario in Usuarios)
            {
                foreach (var videojuego in usuario.JuegosAlquilados)
                {
                    if (!alquilados.Contains(videojuego))
                    {
                        alquilados.AddLast(videojuego);
                    }
                }
            }
            return alquilados;
        }

        public LinkedList<Usuario> ListarUsuariosConJuegosPrestados()
        {
            LinkedList<Usuario> usuariosConPrestamos = new LinkedList<Usuario>();
            foreach (var usuario in Usuarios)
            {
                if (usuario.JuegosAlquilados.Count > 0)
                {
                    usuariosConPrestamos.AddLast(usuario);
                }
            }
            return usuariosConPrestamos;
        }
    }
}
