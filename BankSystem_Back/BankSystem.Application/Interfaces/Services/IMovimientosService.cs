using BankSystem.Application.DTOs;
using BankSystem.Application.DTOs.Movimientos;

namespace BankSystem.Application.Interfaces.Services
{
    public interface IMovimientosService
    {
        Task AddMovimientoAsync(CrearMovimientoDTO movimientoDto);
        Task<IList<MovimientosDTO>> GetAllAsync();
        Task<IList<MovimientosDTO>> GetAllByCuentaIdAsync(int cuentaId);
        Task<IList<MovimientosDTO>> GetByRangoFechaAsync(FiltroReporteDTO filtro);
    }
}
