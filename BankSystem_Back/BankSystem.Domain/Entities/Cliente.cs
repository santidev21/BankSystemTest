using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Entities
{
    public class Cliente : Persona
    {
        public string Contraseña { get; set; }
        public bool Estado { get; set; }
        public IList<Cuenta> Cuentas { get; set; } = new List<Cuenta>();
    }
}
