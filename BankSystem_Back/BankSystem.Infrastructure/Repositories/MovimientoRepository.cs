using BankSystem.Application.Interfaces;
using BankSystem.Domain.Entities;
using BankSystem.Infrastructure.Persistence;
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

        public Task AddAsync(Movimiento movimiento)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Movimiento movimiento)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Movimiento>> GetAllByCuentaIdAsync(int cuentaId)
        {
            throw new NotImplementedException();
        }

        public Task<Movimiento> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Movimiento>> GetByRangoFechaAsync(int cuentaId, DateTime limiteInferior, DateTime limiteSuperior)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Movimiento movimiento)
        {
            throw new NotImplementedException();
        }
    }
}
