using boutique_zyx_api.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
namespace boutique_zyx_api
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure composite primary key using HasKey method
            modelBuilder.Entity<Usuario>()
              .HasKey(s => new { s.CodigoTrabajador });
            modelBuilder.Entity<Pedido>()
             .HasKey(s => new { s.NumeroPedido });
            modelBuilder.Entity<Producto>()
             .HasKey(s => new { s.SKU });
            modelBuilder.Entity<ProductoPedido>()
             .HasKey(s => new { s.NumeroPedido,s.SKU });
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoPedido> ProductoPedidos { get; set; }
    }
}
