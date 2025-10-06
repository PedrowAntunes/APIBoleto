using ApiBoleto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBoleto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
    }
}
