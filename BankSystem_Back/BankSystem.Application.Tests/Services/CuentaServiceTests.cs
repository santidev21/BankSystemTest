using BankSystem.Application.DTOs.Cuentas;
using BankSystem.Application.Interfaces.Repositories;
using BankSystem.Application.Interfaces.Services;
using BankSystem.Application.Services;
using BankSystem.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace BankSystem.Application.Tests.Services
{
    public class CuentaServiceTests
    {
        private readonly Mock<ICuentaRepository> _repoMock;
        private readonly CuentasService _service;

        public CuentaServiceTests()
        {
            _repoMock = new Mock<ICuentaRepository>();
            _service = new CuentasService(_repoMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedCuentasDTO()
        {
            var cuentas = new List<Cuenta>
            {
                new Cuenta { CuentaId = 1, NumeroCuenta = 1001, Tipo = "Ahorros", SaldoInicial = 1000, Estado = true, Cliente = new Cliente { Nombre = "Juan" }, PersonaId = 1 },
                new Cuenta { CuentaId = 2, NumeroCuenta = 1002, Tipo = "Corriente", SaldoInicial = 500, Estado = true, Cliente = new Cliente { Nombre = "Maria" }, PersonaId = 2 }
            };
            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(cuentas);

            var result = await _service.GetAllAsync();

            result.Should().HaveCount(2);
            result[0].NombreCliente.Should().Be("Juan");
            result[1].NombreCliente.Should().Be("Maria");

            _repoMock.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepository_WithMappedCuenta()
        {
            var nuevaCuentaDto = new CrearCuentaDTO
            {
                NumeroCuenta = 2001,
                Tipo = "Ahorros",
                SaldoInicial = 0,
                Estado = true,
                PersonaId = 1
            };

            _repoMock.Setup(r => r.AddAsync(It.IsAny<Cuenta>())).Returns(Task.CompletedTask);

            await _service.AddAsync(nuevaCuentaDto);

            _repoMock.Verify(r => r.AddAsync(It.Is<Cuenta>(
                c => c.NumeroCuenta == 2001 &&
                     c.Tipo == "Ahorros" &&
                     c.SaldoInicial == 0 &&
                     c.Estado == true &&
                     c.PersonaId == 1
            )), Times.Once);
        }
    }
}
