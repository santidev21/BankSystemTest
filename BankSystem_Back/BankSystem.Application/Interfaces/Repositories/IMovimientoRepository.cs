using BankSystem.Domain.Entities;

namespace BankSystem.Application.Interfaces.Repositories
{
    public interface IMovimientoRepository
    {
        Task AddAsync(Movimiento movimiento);
        Task<IList<Movimiento>> GetAllByCuentaIdAsync(int cuentaId);
        Task<IList<Movimiento>> GetByRangoFechaAsync(int cuentaId, DateTime limiteInferior, DateTime limiteSuperior);
    }
}
