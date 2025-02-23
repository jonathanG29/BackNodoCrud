using Microsoft.EntityFrameworkCore;
using AztroWebApplication1.Models;


namespace AztroWebApplication1.Data{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}