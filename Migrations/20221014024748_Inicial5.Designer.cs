// <auto-generated />
using System;
using FluxoCaixa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FluxoCaixa.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221014024748_Inicial5")]
    partial class Inicial5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("FluxoCaixa.Models.Lancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Saldo")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal");

                    b.Property<int>("TipoLancamentoId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("TipoLancamentoId");

                    b.ToTable("Lancamento");
                });

            modelBuilder.Entity("FluxoCaixa.Models.TipoLancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sigla")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoLancamento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Receita",
                            Sigla = "C"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Despesa",
                            Sigla = "D"
                        });
                });

            modelBuilder.Entity("FluxoCaixa.Models.Lancamento", b =>
                {
                    b.HasOne("FluxoCaixa.Models.TipoLancamento", "TipoLancamento")
                        .WithMany("Lancamento")
                        .HasForeignKey("TipoLancamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoLancamento");
                });

            modelBuilder.Entity("FluxoCaixa.Models.TipoLancamento", b =>
                {
                    b.Navigation("Lancamento");
                });
#pragma warning restore 612, 618
        }
    }
}
