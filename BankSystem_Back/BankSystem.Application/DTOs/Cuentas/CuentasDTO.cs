using BankSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.DTOs.Cuentas
{
    public class CuentasDTO
    {
        public int CuentaId { get; set; }
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public int SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public string NombreCliente { get; set; }
        public int PersonaId { get; set; }
    }
}
