using BankSystem.Application.DTOs.Cuentas;
using BankSystem.Application.Interfaces.Repositories;
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

        public async Task AddAsync(CrearCuentaDTO cuenta)
        {
            var nuevaCuenta = new Cuenta
            {
                NumeroCuenta = cuenta.NumeroCuenta,
                Tipo = cuenta.Tipo,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                PersonaId = cuenta.PersonaId,
            };

            await _context.AddAsync(nuevaCuenta);
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

        public async Task<IList<CuentasDTO>> GetAllAsync()
        {

            return await _context.Cuentas.Include(C => C.Cliente)
                .Select(c => new CuentasDTO
                {
                    CuentaId = c.CuentaId,
                    NumeroCuenta = c.NumeroCuenta,
                    Tipo = c.Tipo,
                    SaldoInicial = c.SaldoInicial,
                    Estado = c.Estado,
                    NombreCliente = c.Cliente.Nombre,
                    PersonaId = c.Cliente.PersonaId

                }).ToListAsync();
        }

        public async Task<CuentasDTO> GetByIdAsync(int id)
        {

            var cuenta = await _context.Cuentas.Include(C => C.Cliente).FirstOrDefaultAsync(c => c.CuentaId == id);
            if (cuenta == null)
                return null;

            return new CuentasDTO
            {
                CuentaId = cuenta.CuentaId,
                NumeroCuenta = cuenta.NumeroCuenta,
                Tipo = cuenta.Tipo,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                NombreCliente = cuenta.Cliente.Nombre,
                PersonaId = cuenta.Cliente.PersonaId
            };
            
        }

        public async Task UpdateAsync(CuentasDTO cuenta)
        {
            var cuentaActualizada = new Cuenta
            {
                CuentaId = cuenta.CuentaId,
                NumeroCuenta = cuenta.NumeroCuenta,
                Tipo = cuenta.Tipo,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                PersonaId = cuenta.PersonaId
            };

            _context.Cuentas.Update(cuentaActualizada);
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
