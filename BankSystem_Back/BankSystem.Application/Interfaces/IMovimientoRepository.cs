using BankSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Interfaces
{
    public interface IMovimientoRepository
    {
        Task AddAsync(Movimiento movimiento);
        Task UpdateAsync(Movimiento movimiento);
        Task DeleteAsync(Movimiento movimiento);
        Task<Movimiento> GetByIdAsync(int id);
        Task<IList<Movimiento>> GetAllByCuentaIdAsync(int cuentaId);
        Task<IList<Movimiento>> GetByRangoFechaAsync(int cuentaId, DateTime limiteInferior, DateTime limiteSuperior);
    }
}
