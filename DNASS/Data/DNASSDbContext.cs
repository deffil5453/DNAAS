using DNASS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DNASS.Data
{
    public class DNASSDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<OrderProduct> OrderProducts{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QHR1LI1\\MSSQLSERVERR;database=DNASS;Trusted_Connection=true;Integrated Security=true; TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
