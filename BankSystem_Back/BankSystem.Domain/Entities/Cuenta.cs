using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Entities
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public int NumeroCuenta {  get; set; }
        public string Tipo { get; set; }
        public int SaldoInicial { get; set; }
        public bool Estado { get; set; }

        public int PersonaId {  get; set; }
        public Cliente Cliente { get; set; }

        public IList<Movimiento> Movimientos { get; set; }
    }
}
