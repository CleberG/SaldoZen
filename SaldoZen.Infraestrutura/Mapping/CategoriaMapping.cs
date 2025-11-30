using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaldoZen.Domain.Model;

namespace SaldoZen.Infraestrutura.Mapping
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Tipo);
        }
    }
}
