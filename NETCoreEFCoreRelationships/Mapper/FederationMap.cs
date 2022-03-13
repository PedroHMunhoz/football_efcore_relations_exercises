using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NETCoreEFCoreRelationships.Model;

namespace NETCoreEFCoreRelationships.Mapper
{
    public class FederationMap : IEntityTypeConfiguration<Federation>
    {
        public void Configure(EntityTypeBuilder<Federation> builder)
        {
            builder.ToTable("federation");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired().
                UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired(false)
                .HasMaxLength(100);
        }
    }
}
