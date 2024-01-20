using EcomApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace EcomApi2.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        public DbSet<Coupon> Coupones2 { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
