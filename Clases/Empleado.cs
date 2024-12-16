namespace UF5_AC1.Clases
{
    public class Empleado : Usuario
    {
        public string Categoria { get; set; }
        public decimal Salario { get; set; }

        public Empleado(string nombre, string apellido, int edad, string direccion, string telefono, string categoria, decimal salario)
            : base(nombre, apellido, edad, direccion, telefono)
        {
            Categoria = categoria;
            Salario = salario;
        }
    }
}
