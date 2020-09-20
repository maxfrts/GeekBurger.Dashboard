using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GeekBurger.Dashboard.Model;

namespace GeekBurger.Dashboard.Data.Mapping
{
    public class MapSale : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");
            builder.HasKey(x => x.SaleId);
        }
    }
}
