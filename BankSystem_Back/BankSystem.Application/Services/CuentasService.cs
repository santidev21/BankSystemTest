using BankSystem.Application.DTOs.Cuentas;
using BankSystem.Application.Interfaces.Repositories;
using BankSystem.Application.Interfaces.Services;
using BankSystem.Domain.Entities;

namespace BankSystem.Application.Services
{
    public class CuentasService : ICuentasService
    {
        private ICuentaRepository _cuentaRepository;
        public CuentasService(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        public async Task AddAsync(CrearCuentaDTO cuenta)
        {
            var nuevaCuenta = MapCrearCuentaDTOToCuenta(cuenta);
            await _cuentaRepository.AddAsync(nuevaCuenta);
        }

        public async Task DeleteAsync(int id)
        {
            var cuenta = await _cuentaRepository.GetByIdAsync(id);
            if(cuenta  != null)
                await _cuentaRepository.DeleteAsync(cuenta);
        }

        public async Task<IList<CuentasDTO>> GetAllAsync()
        {
            var cuentas = await _cuentaRepository.GetAllAsync();
            return cuentas.Select(cta => MapCuentatoCuentasDTO(cta)).ToList();
        }

        public async Task<CuentasDTO> GetByIdAsync(int id)
        {
            var cuenta = await _cuentaRepository.GetByIdAsync(id);
            if (cuenta == null)
                throw new NotImplementedException();

            return MapCuentatoCuentasDTO(cuenta);
        }

        public async Task UpdateAsync(CuentasDTO cuenta)
        {

            var cuentaActualizada = MapCuentasDTOToCuenta(cuenta);
            await _cuentaRepository.UpdateAsync(cuentaActualizada);
        }

        private Cuenta MapCrearCuentaDTOToCuenta(CrearCuentaDTO cuenta)
        {
            return new Cuenta
            {
                NumeroCuenta = cuenta.NumeroCuenta,
                Tipo = cuenta.Tipo,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                PersonaId = cuenta.PersonaId
            };
        }

        private Cuenta MapCuentasDTOToCuenta(CuentasDTO cuentasDTO)
        {
            return new Cuenta
            {
                CuentaId = cuentasDTO.CuentaId,
                NumeroCuenta = cuentasDTO.NumeroCuenta,
                Tipo = cuentasDTO.Tipo,
                SaldoInicial = cuentasDTO.SaldoInicial,
                Estado = cuentasDTO.Estado,
                PersonaId = cuentasDTO.PersonaId
            };
        }

        private CuentasDTO MapCuentatoCuentasDTO(Cuenta cuenta)
        {
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
    }
}
