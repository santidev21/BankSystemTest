using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Entities
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad {  get; set; }
        public int Identificacion { get; set; }
        public string Direccion {  get; set; }
        public int Telefono { get; set; }
    }
}
