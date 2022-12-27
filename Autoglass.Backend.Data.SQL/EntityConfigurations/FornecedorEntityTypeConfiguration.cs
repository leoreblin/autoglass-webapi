using Autoglass.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Autoglass.Backend.Data.SQL.EntityConfigurations
{
    class FornecedorEntityTypeConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Fornecedor");

            builder
                .HasKey(b => b.Id)
                .IsClustered(false)
                .HasName("PK_Fornecedor");

            builder.Property(b => b.Id);

            builder.Property(b => b.Descricao)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(b => b.Cnpj)
                .HasColumnType("nvarchar(14)")
                .IsRequired();
        }
    }
}
