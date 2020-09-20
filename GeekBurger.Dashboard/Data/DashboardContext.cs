using Microsoft.EntityFrameworkCore;
using GeekBurger.Dashboard.Data.Mapping;
using GeekBurger.Dashboard.Model;

namespace GeekBurger.Dashboard.Data
{
    public class DashboardContext : DbContext
    {
        public DashboardContext()
        {
        }
        public DashboardContext(DbContextOptionsBuilder<DashboardContext> options)
           : base(options.Options)
        {
        }

        public DbSet<Sale> Sale { get; set; }

        public DbSet<UserWithLessOffer> UserWithLessOffer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MapSale());
            modelBuilder.ApplyConfiguration(new MapUserWithLessOffer());

            base.OnModelCreating(modelBuilder);
        }
    }
}
