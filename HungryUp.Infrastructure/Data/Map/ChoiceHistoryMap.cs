using HungryUp.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HungryUp.Infrastructure.Data.Map
{
    public class ChoiceHistoryMap : EntityTypeConfiguration<ChoiceHistory>
    {
        public ChoiceHistoryMap()
        {
            ToTable("ChoiceHistory");

            Property(x => x.ChoiceHistoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Restaurant);
        }
    }
}
