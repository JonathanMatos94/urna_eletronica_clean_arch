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
    public class EleicaoMap : IEntityTypeConfiguration<Eleicao>
    {
        public void Configure(EntityTypeBuilder<Eleicao> builder)
        {
            builder.ToTable("Eleicoes");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataInicio)
                .HasColumnName("Inicio")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.DataFim)
                .HasColumnName("Termino")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.Ativa)
                .HasColumnName("Situacao")
                .IsRequired();
        }
    }
}
