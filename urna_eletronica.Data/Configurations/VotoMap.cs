using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using urna_eletronica.Domain.Entities;

namespace urna_eletronica.Data.Configurations
{
    public class VotoMap : IEntityTypeConfiguration<Voto>
    {
        public void Configure(EntityTypeBuilder<Voto> builder)
        {

            builder.ToTable("Votos");

            // Chave primária
            builder.HasKey(v => v.Id);

            // Propriedades simples
            builder.Property(v => v.Id)
                   .HasColumnName("Id")
                   .IsRequired();

            builder.Property(v => v.EleitorId)
                   .HasColumnName("EleitorId")
                   .IsRequired();

            builder.Property(v => v.CandidatoId)
                   .HasColumnName("CandidatoId")
                   .IsRequired();

            // Relacionamento com Eleitor
            builder.HasOne(v => v.Eleitor)
                   .WithMany() // ou WithOne() se for um-para-um
                   .HasForeignKey(v => v.EleitorId)
                   .OnDelete(DeleteBehavior.Restrict); // evita cascade delete acidental

            // Relacionamento com Candidato
            builder.HasOne(v => v.Candidato)
                   .WithMany() // ou WithOne() se for um-para-um
                   .HasForeignKey(v => v.CandidatoId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
