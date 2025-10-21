using BankSystem.Application.DTOs.Clientes;
using BankSystem.Application.Interfaces.Repositories;
using BankSystem.Application.Interfaces.Services;
using BankSystem.Domain.Entities;

namespace BankSystem.Application.Services
{
    public class ClientesService : IClientesService
    {
        private IClienteRepository _clienteRepository;
        public ClientesService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AddAsync(CrearClienteDTO cliente)
        {
            var nuevoCliente = MapCrearClienteDTO(cliente);
            await _clienteRepository.AddAsync(nuevoCliente);
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new NotImplementedException();

            await _clienteRepository.DeleteAsync(cliente);
        }

        public async Task<IList<ClienteDTO>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return clientes.Select(c => MapClienteToClienteDTO(c)).ToList();
        }

        public async Task<ClienteDTO> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new NotImplementedException();

            return MapClienteToClienteDTO(cliente);
        }

        public async Task UpdateAsync(ClienteDTO cliente)
        {
            var clienteActualizar = MapClienteDTOToCliente(cliente);
            await _clienteRepository.UpdateAsync(clienteActualizar);
        }

        private Cliente MapCrearClienteDTO(CrearClienteDTO cliente)
        {
            return new Cliente
            {
                Nombre = cliente.Nombre,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Estado = cliente.Estado,
                Contraseña = cliente.Contrasena
            };
        }

        private ClienteDTO MapClienteToClienteDTO(Cliente cliente)
        {
            return new ClienteDTO
            {
                PersonaId = cliente.PersonaId,
                Nombre = cliente.Nombre,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Estado = cliente.Estado,
                Contrasena = cliente.Contraseña
            };
        }

        private Cliente MapClienteDTOToCliente(ClienteDTO cliente)
        {
            return new Cliente
            {
                PersonaId = cliente.PersonaId,
                Nombre = cliente.Nombre,
                Genero = cliente.Genero,
                Edad = cliente.Edad,
                Identificacion = cliente.Identificacion,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Estado = cliente.Estado,
                Contraseña = cliente.Contrasena
            };
        }
    }
}
