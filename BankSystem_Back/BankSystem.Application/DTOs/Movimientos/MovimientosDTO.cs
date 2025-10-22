namespace BankSystem.Application.DTOs.Movimientos
{
    public class MovimientosDTO
    {
        public int MovimientoId { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }

        public string NombreCliente { get; set; }
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public int SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public string TipoMovimiento { get; set; }
        public int Movimiento { get; set; }
        public int SaldoDisponible { get; set; }
    }
}
