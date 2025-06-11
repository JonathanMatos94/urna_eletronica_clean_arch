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
    public class CandidatoMap : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.ToTable("Candidatos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Partido)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Numero)
                .HasMaxLength(7)
                .IsRequired();

        }
    }
}
