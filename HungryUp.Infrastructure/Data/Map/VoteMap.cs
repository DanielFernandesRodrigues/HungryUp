using HungryUp.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HungryUp.Infrastructure.Data.Map
{
    public class VoteMap : EntityTypeConfiguration<Vote>
    {
        public VoteMap()
        {
            ToTable("Vote");

            Property(x => x.VoteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Date).IsRequired();

            HasRequired(x => x.User);
            HasRequired(x => x.Restaurant);
        }
    }
}
