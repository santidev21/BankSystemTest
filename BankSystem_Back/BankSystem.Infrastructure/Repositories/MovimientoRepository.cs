using BankSystem.Application.Interfaces;
using BankSystem.Domain.Entities;
using BankSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _context.Movimientos.Where(mov => mov.CuentaId == cuentaId).ToListAsync();
        }

        public async Task<Movimiento> GetByIdAsync(int id)
        {
            return await _context.Movimientos.FindAsync(id);
        }

        public async Task<IList<Movimiento>> GetByRangoFechaAsync(int cuentaId, DateTime limiteInferior, DateTime limiteSuperior)
        {
            return await _context.Movimientos
                .Where(mov => mov.CuentaId == cuentaId && mov.Fecha >= limiteInferior && mov.Fecha <= limiteSuperior)
                .ToListAsync();
        }
    }
}
