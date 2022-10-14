using FluxoCaixa.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TipoLancamento> TipoLancamento { get; set; }
        public DbSet<Lancamento> Lancamento { get; set; }

        public AppDbContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lancamento>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Lancamento>()
                .Property(p => p.Descricao)
                .HasColumnType("varchar(30)")
                .IsRequired();

            modelBuilder.Entity<Lancamento>()
                .Property(p => p.Valor)
                .HasColumnType("decimal")
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<Lancamento>()
                .Property(p => p.Saldo)
                .HasColumnType("decimal")
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<Lancamento>()
                .Property(p => p.DataLancamento)
                .IsRequired();

            modelBuilder.Entity<Lancamento>()
                .Navigation(e => e.TipoLancamento)
                .AutoInclude();

            modelBuilder.Entity<TipoLancamento>()
                .HasData(
                    new TipoLancamento
                    {
                        Id = 1,
                        Nome = "Receita",
                        Sigla = "C"
                    },
                    new TipoLancamento
                    {
                        Id = 2,
                        Nome = "Despesa",
                        Sigla = "D"
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}