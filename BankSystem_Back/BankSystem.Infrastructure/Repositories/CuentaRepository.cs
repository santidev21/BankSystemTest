using BankSystem.Application.Interfaces;
using BankSystem.Domain.Constants;
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

        public async Task DeleteAsync(int id)
        {
            var cuenta = await _context.Cuentas.FindAsync(id);
            if(cuenta != null)
            {
                _context.Remove(cuenta);
                await _context.SaveChangesAsync();
            }
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
        
        public async Task<decimal> GetBalanceAsync(int id)
        {
            var movimientos = await _context.Movimientos.Where(mov => mov.CuentaId == id).ToListAsync();
            var creditosTotales = movimientos.Where(mov => mov.Tipo == CuentasRules.credito).Sum(mov => mov.Valor);
            var debitosTotales = movimientos.Where(mov => mov.Tipo == CuentasRules.debito).Sum(mov => mov.Valor);

            return creditosTotales - debitosTotales;

        }
    }
}
