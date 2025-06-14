﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using urna_eletronica.Data.Context;

#nullable disable

namespace urna_eletronica.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("urna_eletronica.Domain.Entities.Candidato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nome");

                    b.Property<int>("Numero")
                        .HasMaxLength(7)
                        .HasColumnType("int");

                    b.Property<string>("Partido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Candidatos", (string)null);
                });

            modelBuilder.Entity("urna_eletronica.Domain.Entities.Eleicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativa")
                        .HasColumnType("bit")
                        .HasColumnName("Situacao");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime")
                        .HasColumnName("Termino");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime")
                        .HasColumnName("Inicio");

                    b.HasKey("Id");

                    b.ToTable("Eleicoes", (string)null);
                });

            modelBuilder.Entity("urna_eletronica.Domain.Entities.Eleitor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("JaVotou")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Eleitores", (string)null);
                });

            modelBuilder.Entity("urna_eletronica.Domain.Entities.Voto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("CandidatoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CandidatoId");

                    b.Property<Guid>("EleitorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EleitorId");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("EleitorId");

                    b.ToTable("Votos", (string)null);
                });

            modelBuilder.Entity("urna_eletronica.Domain.Entities.Eleitor", b =>
                {
                    b.OwnsOne("urna_eletronica.Domain.ValueObjects.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("EleitorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("CPF");

                            b1.HasKey("EleitorId");

                            b1.ToTable("Eleitores");

                            b1.WithOwner()
                                .HasForeignKey("EleitorId");
                        });

                    b.OwnsOne("urna_eletronica.Domain.ValueObjects.NomeCompleto", "Nome", b1 =>
                        {
                            b1.Property<Guid>("EleitorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Nome");

                            b1.HasKey("EleitorId");

                            b1.ToTable("Eleitores");

                            b1.WithOwner()
                                .HasForeignKey("EleitorId");
                        });

                    b.OwnsOne("urna_eletronica.Domain.ValueObjects.TituloEleitoral", "TituloEleitoral", b1 =>
                        {
                            b1.Property<Guid>("EleitorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)")
                                .HasColumnName("Titulo");

                            b1.HasKey("EleitorId");

                            b1.ToTable("Eleitores");

                            b1.WithOwner()
                                .HasForeignKey("EleitorId");
                        });

                    b.Navigation("CPF")
                        .IsRequired();

                    b.Navigation("Nome")
                        .IsRequired();

                    b.Navigation("TituloEleitoral")
                        .IsRequired();
                });

            modelBuilder.Entity("urna_eletronica.Domain.Entities.Voto", b =>
                {
                    b.HasOne("urna_eletronica.Domain.Entities.Candidato", "Candidato")
                        .WithMany()
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("urna_eletronica.Domain.Entities.Eleitor", "Eleitor")
                        .WithMany()
                        .HasForeignKey("EleitorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Eleitor");
                });
#pragma warning restore 612, 618
        }
    }
}
