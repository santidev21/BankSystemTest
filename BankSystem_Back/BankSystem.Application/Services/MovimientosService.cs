using BankSystem.Application.DTOs;
using BankSystem.Application.DTOs.Movimientos;
using BankSystem.Application.Interfaces.Repositories;
using BankSystem.Application.Interfaces.Services;
using BankSystem.Domain.Constants;
using BankSystem.Domain.Entities;
using BankSystem.Infrastructure.Exceptions;

namespace BankSystem.Application.Services
{
    public class MovimientosService : IMovimientosService
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMovimientoRepository _movimientoRepository;

        public MovimientosService(ICuentaRepository cuentaRepository, IMovimientoRepository movimientoRepository)
        {
            _cuentaRepository = cuentaRepository;
            _movimientoRepository = movimientoRepository;
        }

        public async Task AddMovimientoAsync(CrearMovimientoDTO movimientoDto)
        {
            var cuenta = await _cuentaRepository.GetByIdAsync(movimientoDto.CuentaId);
            if (cuenta == null)
                throw new KeyNotFoundException("Cuenta no encontrada.");


            var balanceCuenta = await _cuentaRepository.GetBalanceAsync(movimientoDto.CuentaId);
            int nuevoSaldo = 0;

            if (movimientoDto.Tipo == CuentasRules.debito)
            {
                if (movimientoDto.Valor >= CuentasRules.limiteDiario)
                    throw new BankSystemException("El valor a debitar supera el limite diario.");

                if (movimientoDto.Valor > balanceCuenta)
                    throw new BankSystemException("El saldo de la cuenta es menor al valor a debitar.");

                var movimientosDia = await _movimientoRepository.GetByRangoFechaAsync(DateTime.UtcNow.Date, DateTime.UtcNow.Date.AddDays(1), movimientoDto.CuentaId);
                var debitosDia = movimientosDia.Where(mov => mov.Tipo == CuentasRules.debito).Sum(mov => mov.Valor);
                if (debitosDia > CuentasRules.limiteDiario)
                    throw new BankSystemException("La cuenta a superado el limite diario.");
                nuevoSaldo = balanceCuenta - movimientoDto.Valor;
            }
            else
            {
                nuevoSaldo = balanceCuenta + movimientoDto.Valor;
            }

                Movimiento movimiento = new Movimiento
                {
                    Fecha = DateTime.UtcNow,
                    Tipo = movimientoDto.Tipo,
                    Saldo = nuevoSaldo,
                    Valor = movimientoDto.Valor,
                    CuentaId = movimientoDto.CuentaId
                };

            await _movimientoRepository.AddAsync(movimiento);
        }

        public async Task<IList<MovimientosDTO>> GetAllAsync()
        {
            var movimientos = await _movimientoRepository.GetAllAsync();
            return MapMovimientosToMovimientosDTO(movimientos);
        }

        public async Task<IList<MovimientosDTO>> GetAllByCuentaIdAsync(int cuentaId)
        {
            var movimientos = await _movimientoRepository.GetAllByCuentaIdAsync(cuentaId);
            return MapMovimientosToMovimientosDTO(movimientos);
        }

        public async Task<IList<MovimientosDTO>> GetByRangoFechaAsync(FiltroReporteDTO filtro)
        {
            var movimientos = await _movimientoRepository.GetByRangoFechaAsync(filtro.LimiteInferior, filtro.LimiteSuperior, filtro.cuentaId);
            return MapMovimientosToMovimientosDTO(movimientos);            
        }

        public static IList<MovimientosDTO> MapMovimientosToMovimientosDTO(IList<Movimiento> movimientos)
        {
            return movimientos.Select(mov => new MovimientosDTO
            {
                MovimientoId = mov.MovimientoId,
                CuentaId = mov.Cuenta.CuentaId,
                Fecha = mov.Fecha,
                NombreCliente = mov.Cuenta.Cliente.Nombre,
                NumeroCuenta = mov.Cuenta.NumeroCuenta,
                TipoCuenta = mov.Cuenta.Tipo,
                SaldoInicial = mov.Cuenta.SaldoInicial,
                Estado = mov.Cuenta.Estado,
                Movimiento = mov.Valor,
                SaldoDisponible = mov.Saldo,
                TipoMovimiento = mov.Tipo
            }).ToList();
        }
    }
}
