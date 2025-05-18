using Microsoft.EntityFrameworkCore;
using SaldoZen.Domain.Model;

namespace SaldoZen.Infraestrutura.Context
{
    public class SaldoZenContext : DbContext
    {
        public SaldoZenContext(DbContextOptions<SaldoZenContext> options) : base(options) { }

        public DbSet<PlanoContas> PlanoContas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica automaticamente todas as classes que implementam IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaldoZenContext).Assembly);
        }

    }
}
