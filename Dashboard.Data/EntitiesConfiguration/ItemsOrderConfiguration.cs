using Dashboard.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Data.EntitiesConfiguration
{
    public class ItemsOrderConfiguration : IEntityTypeConfiguration<ItemsOrder>
    {
        public void Configure(EntityTypeBuilder<ItemsOrder> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.HasOne(x => x.Order).WithMany(x => x.ItemsOrders).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.TotalValue).HasColumnType("decimal(15,2)");
        }
    }
}
