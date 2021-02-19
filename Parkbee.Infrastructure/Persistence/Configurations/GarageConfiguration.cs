using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parkbee.Domain.Entities;

namespace Parkbee.Infrastructure.Persistence.Configurations
{
    public class GarageConfiguration : IEntityTypeConfiguration<Garage>
    {
        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(280)
                .IsRequired();
        }
    }
}
