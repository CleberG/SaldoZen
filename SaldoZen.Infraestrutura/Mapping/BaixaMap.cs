using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaldoZen.Domain.Model;

namespace SaldoZen.Infraestrutura.Mapping
{
    public class BaixaMap : IEntityTypeConfiguration<Baixa>
    {
        public void Configure(EntityTypeBuilder<Baixa> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.ValorTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(b => b.DataBaixa)
                .IsRequired();

            builder.Property(b => b.ValorOriginal)
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.Juros)
                .HasColumnType("decimal(18,2)");
            
            builder.Property(b => b.Multa)
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.Desconto)
                .HasColumnType("decimal(18,2)");
 
            builder.HasOne(b => b.Previsao)
                .WithMany(p => p.Baixas)
                .HasForeignKey(b => b.PrevisaoId);
        }
    }
}
