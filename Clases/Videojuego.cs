namespace UF5_AC1.Clases
{
    public class Videojuego
    {
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Tematica { get; set; }
        public string Estudio { get; set; }
        public int VecesAlquilado { get; private set; }
        public Estado Estado { get; private set; }

        public Videojuego(string titulo, int anio, string tematica, string estudio)
        {
            Titulo = titulo;
            Anio = anio;
            Tematica = tematica;
            Estudio = estudio;
            VecesAlquilado = 0;
            Estado = new Estado();
        }

        public void IncrementarVecesAlquilado()
        {
            VecesAlquilado++;
        }
    }
}
