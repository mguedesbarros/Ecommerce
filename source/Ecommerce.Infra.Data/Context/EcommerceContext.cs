using System;
using Ecommerce.Domain.Entities;
using Ecommerce.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Data.Context
{
    public class EcommerceContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("EcommerceDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
           
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
