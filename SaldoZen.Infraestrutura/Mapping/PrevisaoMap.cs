using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaldoZen.Domain.Model;

namespace SaldoZen.Infraestrutura.Mapping
{
    public class PrevisaoMap : IEntityTypeConfiguration<Previsao>
    {
        public void Configure(EntityTypeBuilder<Previsao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.ValorOriginal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Juros)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Multa)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Desconto)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.ValorOrcado)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.ValorRealizado)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.DataVencimento)
                .IsRequired();

            builder.Property(p => p.Observacoes)
                .HasMaxLength(500);

            builder.Property(p => p.Status);

            builder.HasOne(p => p.Categoria)
                .WithMany() 
                .HasForeignKey(p => p.CategoriaId);

            builder.HasMany(p => p.Baixas)
                .WithOne(b => b.Previsao)
                .HasForeignKey(b => b.PrevisaoId);
        }
    }
}
