using Microsoft.EntityFrameworkCore;
using TimewareAPI.Domain;

namespace TimewareAPI.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Joia> Joias { get; set; }
    public DbSet<Venda> Vendas { get; set; }
}