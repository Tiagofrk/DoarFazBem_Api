using DoarFazBem_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DoarFazBem_Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cnae> Cnaes { get; set; }
    }
}
