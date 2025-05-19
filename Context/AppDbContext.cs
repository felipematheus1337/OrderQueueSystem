using Microsoft.EntityFrameworkCore;
using OrderQueueSystem.Domain;

namespace OrderQueueSystem.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pedido>? Pedidos { get; set; }

}
