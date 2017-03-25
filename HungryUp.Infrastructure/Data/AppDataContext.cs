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
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
