using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using urna_eletronica.Data.Configurations;
using urna_eletronica.Domain.Entities;

namespace urna_eletronica.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Eleitor> Eleitores { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Eleicao> Eleicoes { get; set; }
        public DbSet<Voto> Votos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EleitorMap());
            modelBuilder.ApplyConfiguration(new CandidatoMap());
            modelBuilder.ApplyConfiguration(new EleicaoMap());
            modelBuilder.ApplyConfiguration(new VotoMap());
        }
    }
}
