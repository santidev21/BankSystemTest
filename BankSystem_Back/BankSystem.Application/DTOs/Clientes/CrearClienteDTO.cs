namespace BankSystem.Application.DTOs.Clientes
{
    public class CrearClienteDTO
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public int Identificacion { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
    }
}
