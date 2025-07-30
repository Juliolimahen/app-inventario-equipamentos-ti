using it_inventory_api.Models;
using Microsoft.EntityFrameworkCore;

namespace it_inventory_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
