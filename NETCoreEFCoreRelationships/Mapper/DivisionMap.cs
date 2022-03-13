using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NETCoreEFCoreRelationships.Model;

namespace NETCoreEFCoreRelationships.Mapper
{
    public class DivisionMap : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.ToTable("division");

            builder.HasKey(x =>x.ID);

            builder.Property(x => x.ID)
                .IsRequired().
                UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.HasOne(x => x.Championship)
              .WithMany(x => x.DivisionList)
              .HasForeignKey(x=> x.ChampionshipID)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
