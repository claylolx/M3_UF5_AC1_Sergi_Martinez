namespace UF5_AC1.Clases
{
    public class Estado
    {
        public bool Activo { get; private set; }

        public Estado()
        {
            Activo = true;
        }

        public void Habilitar() => Activo = true;

        public void Deshabilitar() => Activo = false;
    }
}
