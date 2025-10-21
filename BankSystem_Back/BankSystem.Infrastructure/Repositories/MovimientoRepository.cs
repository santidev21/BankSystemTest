using BankSystem.Application.Interfaces.Repositories;
using BankSystem.Domain.Entities;
using BankSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly AppDbContext _context;
        public MovimientoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Movimiento movimiento)
        {
            await _context.Movimientos.AddAsync(movimiento);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Movimiento>> GetAllByCuentaIdAsync(int cuentaId)
        {
            return await _context.Movimientos.Where(mov => mov.CuentaId == cuentaId)
                .Include(mov => mov.Cuenta)
                .ThenInclude(cta => cta.Cliente)
                .ToListAsync();
        }

        public async Task<IList<Movimiento>> GetByRangoFechaAsync(int cuentaId, DateTime limiteInferior, DateTime limiteSuperior)
        {
            return await _context.Movimientos
                .Where(mov => mov.CuentaId == cuentaId &&
                    mov.Fecha >= limiteInferior.Date &&
                    mov.Fecha <= limiteSuperior.AddDays(1).Date)
                .Include(mov => mov.Cuenta)
                .ThenInclude(cta => cta.Cliente)
                .ToListAsync();
        }
    }
}
