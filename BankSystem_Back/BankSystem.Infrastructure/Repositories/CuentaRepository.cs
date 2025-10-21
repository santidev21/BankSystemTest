using BankSystem.Application.DTOs.Cuentas;
using BankSystem.Application.Interfaces.Repositories;
using BankSystem.Domain.Entities;
using BankSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly AppDbContext _context;
        public CuentaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cuenta cuenta)
        {
            await _context.AddAsync(cuenta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cuenta cuenta)
        {
            _context.Remove(cuenta);
            await _context.SaveChangesAsync();

        }

        public async Task<IList<Cuenta>> GetAllAsync()
        {
            return await _context.Cuentas.Include(C => C.Cliente).ToListAsync();
        }

        public async Task<Cuenta> GetByIdAsync(int id)
        {
            return await _context.Cuentas.Include(C => C.Cliente).FirstOrDefaultAsync(c => c.CuentaId == id);
        }

        public async Task UpdateAsync(Cuenta cuenta)
        {
            _context.Cuentas.Update(cuenta);
            await _context.SaveChangesAsync();
        }
        
        public async Task<int> GetBalanceAsync(int id)
        {
            var movimiento = await _context.Movimientos.Where(mov => mov.CuentaId == id)
                .OrderByDescending(mov => mov.Fecha)
                .FirstOrDefaultAsync();

            if(movimiento != null)
                return movimiento.Saldo;

            var cuenta = await _context.Cuentas.Where(cta => cta.CuentaId.Equals(id)).FirstOrDefaultAsync();
            return cuenta.SaldoInicial;
        }
    }
}
