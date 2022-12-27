using Autoglass.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Autoglass.Backend.Data.SQL.EntityConfigurations
{
    class ProdutoEntityTypeConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Produto");

            builder.HasKey(b => b.Id)
                .HasName("PK_Produto");

            builder.Property(b => b.Id);

            builder.Property(b => b.Descricao)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(b => b.DataFabricacao)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(b => b.DataValidade)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(b => b.Ativo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne<Fornecedor>()
                .WithMany()
                .HasForeignKey(b => b.FornecedorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Produto_Fornecedor");

            builder
                .HasIndex(b => new
                {
                    b.FornecedorId
                })
                .IncludeProperties(b => new
                {
                    b.Id,
                    b.Descricao,
                    b.Ativo
                })
                .HasDatabaseName("IDX_PRODUTOS_DESCRICAO_ATIVOS");
        }
    }
}
