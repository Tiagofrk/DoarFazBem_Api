using DoarFazBem.Models;
using Microsoft.EntityFrameworkCore;

namespace DoarFazBem_Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cadastro> Cadastros { get; set; }
    }
}
