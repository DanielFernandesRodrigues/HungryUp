using HungryUp.Domain.Model;
using HungryUp.Infrastructure.Data.Map;
using System.Data.Entity;

namespace HungryUp.Infrastructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base ("ConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());

            modelBuilder.Entity<User>()
                .HasRequired(s => s.Email);
            modelBuilder.Entity<User>()
                .HasRequired(s => s.Password);
        }
    }
}
