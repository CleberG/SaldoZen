using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaldoZen.Domain.Model;

namespace SaldoZen.Infraestrutura.Mapping
{
    public class PlanoContasMapping : IEntityTypeConfiguration<PlanoContas>
    {
        public void Configure(EntityTypeBuilder<PlanoContas> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Tipo);
        }
    }
}
