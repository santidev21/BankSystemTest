using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.DTOs.Cuentas
{
    public class CrearCuentaDTO
    {
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public int SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int PersonaId { get; set; }
    }
}

