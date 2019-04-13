using System;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Tipo).IsRequired().HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.Tamanho).IsRequired().HasMaxLength(5).HasColumnType("varchar(5)");
            builder.Property(x => x.Quantidade).IsRequired().HasColumnType("int");
            builder.Property(x => x.Valor).IsRequired().HasColumnType("money");
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(500).HasColumnType("varchar(500)");
        }
    }
}
