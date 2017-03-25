using HungryUp.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HungryUp.Infrastructure.Data.Map
{
    public class RestaurantMap : EntityTypeConfiguration<Restaurant>
    {
        public RestaurantMap()
        {
            ToTable("Restaurant");

            Property(x => x.RestaurantId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
