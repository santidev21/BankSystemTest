using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.DTOs.Movimientos
{
    public class CrearMovimientoDTO
    {
        public string Tipo { get; set; }
        public int Valor { get; set; }

        public int CuentaId { get; set; }
    }
}
