using BankSystem.Application.Interfaces;
using BankSystem.Domain.Entities;
using BankSystem.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Services
{
    public class MovimientosService
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMovimientoRepository _movimientoRepository;

        public MovimientosService(ICuentaRepository cuentaRepository, IMovimientoRepository movimientoRepository)
        {
            _cuentaRepository = cuentaRepository;
            _movimientoRepository = movimientoRepository;
        }

        public async Task AddMovimientoAsync(Movimiento movimiento)
        {
            var cuenta = await _cuentaRepository.GetByIdAsync(movimiento.CuentaId);
            if (cuenta == null)
                throw new NotImplementedException();


            if (movimiento.Tipo == CuentasRules.debito)
            {

                var balanceCuenta = await _cuentaRepository.GetBalanceAsync(movimiento.CuentaId);
                if (movimiento.Valor > balanceCuenta)
                    throw new NotImplementedException();

                var movimientosDia = await _movimientoRepository.GetByRangoFechaAsync(movimiento.CuentaId, DateTime.UtcNow.Date, DateTime.UtcNow.Date.AddDays(1));
                var debitosDia = movimientosDia.Where(mov => mov.Tipo == CuentasRules.debito).Sum(mov => mov.Valor);
                if (debitosDia > CuentasRules.limiteDiario)
                    throw new NotImplementedException();
            }

            await _movimientoRepository.AddAsync(movimiento);
             
        }
    }
}
