using DinasCardapio.Domain.Entities;
using DinasCardapio.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DinasCardapio.Infra.Data
{
    public class DinasDataContext : DbContext
    {
        public DinasDataContext(DbContextOptions<DinasDataContext> options) : base(options)
        {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}
