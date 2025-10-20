using BankSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasBaseType<Persona>();

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Cuentas)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.PersonaId);

            modelBuilder.Entity<Cuenta>()
                .HasMany(c => c.Movimientos)
                .WithOne(c => c.Cuenta)
                .HasForeignKey(c => c.CuentaId);

            modelBuilder.Entity<Cuenta>()
                .HasIndex(c => c.NumeroCuenta)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
