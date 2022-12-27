﻿// <auto-generated />
using System;
using Autoglass.Backend.Data.SQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Autoglass.Backend.Data.SQL.Migrations
{
    [DbContext(typeof(AutoglassContext))]
    [Migration("20221226011657_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Autoglass.Backend.Core.Entities.Fornecedor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_Fornecedor")
                        .IsClustered(false);

                    b.ToTable("Fornecedor");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Cnpj = "12123123000122",
                            Descricao = "Fornecedor de para-brisa"
                        },
                        new
                        {
                            Id = 2L,
                            Cnpj = "34345345000144",
                            Descricao = "Fornecedor de retrovisor"
                        },
                        new
                        {
                            Id = 3L,
                            Cnpj = "12456456000166",
                            Descricao = "Fornecedor de vidro"
                        });
                });

            modelBuilder.Entity("Autoglass.Backend.Core.Entities.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("DataFabricacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("FornecedorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK_Produto");

                    b.HasIndex("FornecedorId")
                        .HasDatabaseName("IDX_PRODUTOS_DESCRICAO_ATIVOS")
                        .HasAnnotation("SqlServer:Include", new[] { "Id", "Descricao", "Ativo" });

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Autoglass.Backend.Core.Entities.Produto", b =>
                {
                    b.HasOne("Autoglass.Backend.Core.Entities.Fornecedor", null)
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .HasConstraintName("FK_Produto_Fornecedor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
