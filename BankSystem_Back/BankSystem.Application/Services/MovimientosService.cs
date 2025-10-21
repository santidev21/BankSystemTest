using BankSystem.Application.DTOs.Movimientos;
using BankSystem.Application.Interfaces.Repositories;
using BankSystem.Application.Interfaces.Services;
using BankSystem.Domain.Constants;
using BankSystem.Domain.Entities;

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
                throw new NotImplementedException();


            var balanceCuenta = await _cuentaRepository.GetBalanceAsync(movimientoDto.CuentaId);
            int nuevoSaldo = 0;

            if (movimientoDto.Tipo == CuentasRules.debito)
            {
                if (movimientoDto.Valor > balanceCuenta)
                    throw new NotImplementedException();

                var movimientosDia = await _movimientoRepository.GetByRangoFechaAsync(movimientoDto.CuentaId, DateTime.UtcNow.Date, DateTime.UtcNow.Date.AddDays(1));
                var debitosDia = movimientosDia.Where(mov => mov.Tipo == CuentasRules.debito).Sum(mov => mov.Valor);
                if (debitosDia > CuentasRules.limiteDiario)
                    throw new NotImplementedException();
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

        public async Task<IList<MovimientosDTO>> GetByRangoFechaAsync(int cuentaId, DateTime limiteInferior, DateTime limiteSuperior)
        {
            var movimientos = await _movimientoRepository.GetByRangoFechaAsync(cuentaId, limiteInferior, limiteSuperior);
            return MapMovimientosToMovimientosDTO(movimientos);            
        }

        private IList<MovimientosDTO> MapMovimientosToMovimientosDTO(IList<Movimiento> movimientos)
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
                SaldoDisponible = mov.Saldo
            }).ToList();
        }
    }
}
