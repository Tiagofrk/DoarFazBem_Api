using DoarFazBem.Models;
using Microsoft.EntityFrameworkCore;

namespace DoarFazBem_Api.Context
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<DoarFazBem.Models.Usuario> Usuario { get; set; }

        public DbSet<DoarFazBem.Models.Hemocentro> Hemocentro { get; set; }

        public DbSet<DoarFazBem.Models.Doador> Doador { get; set; }

        public DbSet<DoarFazBem.Models.Donation> Donation { get; set; }

        public DbSet<DoarFazBem.Models.Login> Login { get; set; }

    }
}
