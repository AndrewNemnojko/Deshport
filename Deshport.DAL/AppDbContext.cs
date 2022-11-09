using Deshport.Domain.EntityModel;
using Microsoft.EntityFrameworkCore;


namespace Deshport.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
