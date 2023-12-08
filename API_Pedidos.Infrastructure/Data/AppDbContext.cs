using API_Pedidos.Domain.PedidosContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Pedidos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        //no caso de estar usando sqlServer 
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Produto>().Property(p => p.Valor).HasColumnType("decimal(10,2)");
        //}

    }
}
