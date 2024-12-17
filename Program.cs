using UF5_AC1.Clases;

namespace UF5_AC1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SistemaDeAlquiler sistema = new SistemaDeAlquiler();

            // Crear ejemplos iniciales
            CrearEjemplos(sistema);

            // Menú principal
            int opcion;
            do
            {
                Console.WriteLine("\n--- GAMING ALQUILER ---");
                Console.WriteLine("1. Crear cliente");
                Console.WriteLine("2. Crear empleado");
                Console.WriteLine("3. Alquilar videojuego");
                Console.WriteLine("4. Devolver videojuego");
                Console.WriteLine("5. Ver estado de videojuegos");
                Console.WriteLine("6. Lista de clientes");
                Console.WriteLine("7. Quién tiene videojuegos");
                Console.WriteLine("8. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;

                switch (opcion)
                {
                    case 1:
                        CrearCliente(sistema);
                        break;
                    case 2:
                        CrearEmpleado(sistema);
                        break;
                    case 3:
                        AlquilarVideojuego(sistema);
                        break;
                    case 4:
                        DevolverVideojuego(sistema);
                        break;
                    case 5:
                        VerEstadoVideojuegos(sistema);
                        break;
                    case 6:
                        ListarClientes(sistema);
                        break;
                    case 7:
                        VerQuienTieneVideojuegos(sistema);
                        break;
                    case 8:
                        Console.WriteLine("Saliendo de la aplicacion GAMING. ¡Chau pescau!");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida, intentalo de nuevo :).");
                        break;
                }

            } while (opcion != 8);
        }

        static void CrearEjemplos(SistemaDeAlquiler sistema)
        {
            // Videojuegos
            sistema.AltaVideojuego(new Videojuego("World of Warcraft", 2004, "MMORPG", "Blizzard Entertainment"));
            sistema.AltaVideojuego(new Videojuego("Black Desert Online", 2015, "MMORPG", "Pearl Abyss"));
            sistema.AltaVideojuego(new Videojuego("League of Legends", 2009, "MOBA", "Riot Games"));
            sistema.AltaVideojuego(new Videojuego("Lost Ark", 2019, "MMORPG", "Smilegate RPG"));
            sistema.AltaVideojuego(new Videojuego("Throne and Liberty", 2023, "MMORPG", "NCSoft"));

            // Clientes
            sistema.AltaUsuario(new Cliente("Didac", "Soler", 19, "Calle Lupita 33", "635874589"));
            sistema.AltaUsuario(new Cliente("Ana", "Lopez", 25, "Calle Diagonal 82", "632156987"));
            sistema.AltaUsuario(new Cliente("Maria", "Guadalupe", 16, "Calle Kiko 12", "632431237"));
            sistema.AltaUsuario(new Cliente("Federico", "Perez", 26, "Calle Horizontal 82", "632178387"));

            // Empleados
            sistema.AltaUsuario(new Empleado("Sergi", "Martínez", 28, "Calle Censurada 53", "612345678", "Gerente", 2500m));
        }

        static void CrearCliente(SistemaDeAlquiler sistema)
        {
            Console.WriteLine("\n--- Crear Cliente ---");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine()!;
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine()!;
            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine()!);
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine()!;
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine()!;

            sistema.AltaUsuario(new Cliente(nombre, apellido, edad, direccion, telefono));
            Console.WriteLine("Cliente creado correctamente.");
        }

        static void CrearEmpleado(SistemaDeAlquiler sistema)
        {
            Console.WriteLine("\n--- Crear Empleado ---");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine()!;
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine()!;
            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine()!);
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine()!;
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine()!;
            Console.Write("Categoría: ");
            string categoria = Console.ReadLine()!;
            Console.Write("Salario: ");
            decimal salario = decimal.Parse(Console.ReadLine()!);

            sistema.AltaUsuario(new Empleado(nombre, apellido, edad, direccion, telefono, categoria, salario));
            Console.WriteLine("Empleado creado correctamente.");
        }

        static void AlquilarVideojuego(SistemaDeAlquiler sistema)
        {
            Console.WriteLine("\n--- Alquilar Videojuego ---");

            int clienteIndex;
            Cliente cliente;
            do
            {
                ListarClientes(sistema);
                Console.Write("Selecciona el numero del cliente (o -1 para volver al menú): ");
                clienteIndex = int.Parse(Console.ReadLine()!);

                if (clienteIndex == -1) return;

                try
                {
                    cliente = sistema.Usuarios.OfType<Cliente>().ElementAt(clienteIndex);
                    break;
                }
                catch
                {
                    Console.WriteLine("Numero no valido. Intentalo de nuevo.");
                }
            } while (true);

            Console.WriteLine("Videojuegos disponibles:");
            var disponibles = sistema.ListarVideojuegosDisponibles().ToList();

            if (disponibles.Count == 0)
            {
                Console.WriteLine("No hay videojuegos disponibles.");
                return;
            }

            int juegoIndex;
            do
            {
                for (int i = 0; i < disponibles.Count; i++)
                {
                    Console.WriteLine($"{i}. {disponibles[i].Titulo}");
                }
                Console.Write("Seleccione el numero del videojuego (o -1 para volver al menú): ");
                juegoIndex = int.Parse(Console.ReadLine()!);

                if (juegoIndex == -1) return;

                if (juegoIndex >= 0 && juegoIndex < disponibles.Count)
                {
                    var videojuegoSeleccionado = disponibles[juegoIndex];
                    cliente.AlquilarJuego(videojuegoSeleccionado);
                    videojuegoSeleccionado.Estado.Deshabilitar(); // Marcamos el videojuego como no disponible
                    Console.WriteLine("Videojuego alquilado correctamente.");
                    return;
                }
                else
                {
                    Console.WriteLine("Numero no valido. Intentalo de nuevo.");
                }
            } while (true);
        }

        static void DevolverVideojuego(SistemaDeAlquiler sistema)
        {
            Console.WriteLine("\n--- Devolver Videojuego ---");

            int clienteIndex;
            Cliente cliente;
            do
            {
                ListarClientes(sistema);
                Console.Write("Selecciona el numero del cliente (o -1 para volver al menú): ");
                clienteIndex = int.Parse(Console.ReadLine()!);

                if (clienteIndex == -1) return;

                try
                {
                    cliente = sistema.Usuarios.OfType<Cliente>().ElementAt(clienteIndex);
                    break;
                }
                catch
                {
                    Console.WriteLine("Numero no valido. Intentalo de nuevo.");
                }
            } while (true);

            Console.WriteLine("Videojuegos alquilados:");
            var alquilados = cliente.JuegosAlquilados.ToList();

            if (alquilados.Count == 0)
            {
                Console.WriteLine("El cliente no tiene videojuegos alquilados.");
                return;
            }

            int juegoIndex;
            do
            {
                for (int i = 0; i < alquilados.Count; i++)
                {
                    Console.WriteLine($"{i}. {alquilados[i].Titulo}");
                }
                Console.Write("Seleccione el numero del videojuego para devolver (o -1 para volver al menú): ");
                juegoIndex = int.Parse(Console.ReadLine()!);

                if (juegoIndex == -1) return;

                if (juegoIndex >= 0 && juegoIndex < alquilados.Count)
                {
                    var videojuegoSeleccionado = alquilados[juegoIndex];
                    cliente.JuegosAlquilados.Remove(videojuegoSeleccionado);
                    videojuegoSeleccionado.Estado.Habilitar(); // Marcamos el videojuego como disponible
                    Console.WriteLine("Videojuego devuelto correctamente.");
                    return;
                }
                else
                {
                    Console.WriteLine("Numero no valido. Intentalo de nuevo.");
                }
            } while (true);
        }

        static void VerEstadoVideojuegos(SistemaDeAlquiler sistema)
        {
            Console.WriteLine("\n--- Estado de Videojuegos ---");
            foreach (var videojuego in sistema.Almacen.Videojuegos)
            {
                Console.WriteLine($"- {videojuego.Titulo}: {(videojuego.Estado.Activo ? "Disponible" : "No disponible")}, Veces alquilado: {videojuego.VecesAlquilado}");
            }
        }

        static void ListarClientes(SistemaDeAlquiler sistema)
        {
            Console.WriteLine("\n--- Lista de Clientes ---");
            var clientes = sistema.Usuarios.OfType<Cliente>().ToList();
            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine($"{i}. {clientes[i].Nombre} {clientes[i].Apellido}");
            }
        }

        static void VerQuienTieneVideojuegos(SistemaDeAlquiler sistema)
        {
            Console.WriteLine("\n--- Videojuegos Alquilados por Usuarios ---");
            foreach (var usuario in sistema.ListarUsuariosConJuegosPrestados())
            {
                Console.WriteLine($"Usuario: {usuario.Nombre} {usuario.Apellido}");
                foreach (var juego in usuario.JuegosAlquilados)
                {
                    Console.WriteLine($"  - {juego.Titulo}");
                }
            }
        }
    }
}
