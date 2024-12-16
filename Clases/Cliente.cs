namespace UF5_AC1.Clases
{
    public class Cliente : Usuario
    {
        public Cliente(string nombre, string apellido, int edad, string direccion, string telefono)
            : base(nombre, apellido, edad, direccion, telefono) { }
    }
}
