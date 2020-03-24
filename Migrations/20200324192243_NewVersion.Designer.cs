﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

namespace csharp_mvc_blockbuster.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200324192243_NewVersion")]
    partial class NewVersion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Dias")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtNasc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Models.Filme", b =>
                {
                    b.Property<int>("FilmeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DtLancamento")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LocacaoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeFilme")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("QtdEstoque")
                        .HasColumnType("int");

                    b.Property<string>("Sinopse")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("FilmeId");

                    b.HasIndex("LocacaoId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Models.Locacao", b =>
                {
                    b.Property<int>("LocacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtLocacao")
                        .HasColumnType("datetime(6)");

                    b.HasKey("LocacaoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Locacoes");
                });

            modelBuilder.Entity("Models.Filme", b =>
                {
                    b.HasOne("Models.Locacao", null)
                        .WithMany("Filmes")
                        .HasForeignKey("LocacaoId");
                });

            modelBuilder.Entity("Models.Locacao", b =>
                {
                    b.HasOne("Models.Cliente", "Cliente")
                        .WithMany("Locacoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
