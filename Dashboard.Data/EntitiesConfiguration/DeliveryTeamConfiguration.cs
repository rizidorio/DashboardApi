using Dashboard.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Data.EntitiesConfiguration
{
    public class DeliveryTeamConfiguration : IEntityTypeConfiguration<DeliveryTeam>
    {
        public void Configure(EntityTypeBuilder<DeliveryTeam> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired();
            builder.Property(x => x.LicensePlate).HasMaxLength(10);
        }
    }
}
