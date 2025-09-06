using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaldoZen.Domain.Model;

namespace SaldoZen.Infraestrutura.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Nome, nome =>
            {
                nome.Property(n => n.NomeCompleto)
                    .HasColumnName("Nome")
                    .IsRequired()
                    .HasMaxLength(150);
            });

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.DataNascimento)
                .IsRequired(false);

            builder.OwnsOne(x => x.Login, login =>
            {
                login.Property(l => l.Email)
                    .HasColumnName("LoginEmail")
                    .IsRequired()
                    .HasMaxLength(150);
            });

            builder.OwnsOne(x => x.Senha, senha =>
            {
                senha.Property(s => s.SenhaHash)
                    .HasColumnName("SenhaHash")
                    .IsRequired()
                    .HasMaxLength(255);
            });

            builder.Property(x => x.Status)
                .IsRequired();
        }
    }
}
