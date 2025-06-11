using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using urna_eletronica.Domain.Entities;

namespace urna_eletronica.Data.Configurations
{
    public class EleitorMap : IEntityTypeConfiguration<Eleitor>
    {
        public void Configure(EntityTypeBuilder<Eleitor> builder)
        {
            builder.ToTable("Eleitores");

            builder.HasKey(e => e.Id);

            builder.OwnsOne(e => e.CPF, cpf =>
            {
                cpf.Property(c => c.Numero)
                .HasColumnName("CPF")
                .IsRequired()
                .HasMaxLength(11);
            });

            builder.OwnsOne(e => e.TituloEleitoral, titulo =>
            {
                titulo.Property(t => t.Numero)
                .HasColumnName("Titulo")
                .IsRequired()
                .HasMaxLength(12);
            });

            builder.OwnsOne(e => e.Nome, nome =>
            {
                nome.Property(n => n.Valor)
                    .HasColumnName("Nome")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            builder.Property(e => e.JaVotou)
                .IsRequired();
        }
    }
}
