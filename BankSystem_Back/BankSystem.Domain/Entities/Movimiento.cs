using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Entities
{
    public class Movimiento
    {
        public int MovimientoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public int Valor { get; set;  }
        public int Saldo { get; set; }

        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; } = new Cuenta();
    }
}
