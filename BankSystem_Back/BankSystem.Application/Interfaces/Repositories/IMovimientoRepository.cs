using BankSystem.Domain.Entities;

namespace BankSystem.Application.Interfaces.Repositories
{
    public interface IMovimientoRepository
    {
        Task AddAsync(Movimiento movimiento);
        Task<IList<Movimiento>> GetAllAsync();
        Task<IList<Movimiento>> GetAllByCuentaIdAsync(int cuentaId);
        Task<IList<Movimiento>> GetByRangoFechaAsync(DateTime limiteInferior, DateTime limiteSuperior, int? cuentaId);
    }
}
