using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NETCoreEFCoreRelationships.Model;

namespace NETCoreEFCoreRelationships.Mapper
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("team");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired().
                UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.Division)
              .WithMany(x => x.LstTeam)
              .HasForeignKey(x=> x.DivisionID)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
