using Autoglass.Backend.Core.Entities;
using Autoglass.Backend.Data.SQL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Autoglass.Backend.Data.SQL.Context
{
    public class AutoglassContext : DbContext
    {
        public AutoglassContext(DbContextOptions<AutoglassContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder
                .ApplyConfiguration(new ProdutoEntityTypeConfiguration())
                .ApplyConfiguration(new FornecedorEntityTypeConfiguration());

            modelBuilder.Entity<Fornecedor>().HasData(
                new Fornecedor { Id = 1, Descricao = "Fornecedor de para-brisa", Cnpj = "12123123000122" },
                new Fornecedor { Id = 2, Descricao = "Fornecedor de retrovisor", Cnpj = "34345345000144" },
                new Fornecedor { Id = 3, Descricao = "Fornecedor de vidro", Cnpj = "12456456000166" });
        }
    }
}
