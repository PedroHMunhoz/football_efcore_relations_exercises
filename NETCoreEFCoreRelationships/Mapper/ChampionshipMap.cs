using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NETCoreEFCoreRelationships.Model;

namespace NETCoreEFCoreRelationships.Mapper
{
    public class ChampionshipMap : IEntityTypeConfiguration<Championship>
    {
        public void Configure(EntityTypeBuilder<Championship> builder)
        {
            builder.ToTable("championship");

            builder.HasKey(x=> x.ID);

            builder.Property(x => x.ID)
                .IsRequired().
                UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.HasOne(x => x.Federation)
                .WithMany(x => x.LstChampionship)
                .HasForeignKey(x=> x.FederationID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
