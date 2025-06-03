using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(150)
            .HasColumnName("PropertyName");

        builder.HasData(
            new Property { Id = 1, Name = "Apartamento em Barcelona", PricePerNight = 150, CityId = 1 },
            new Property { Id = 2, Name = "Apartamento em Paris", PricePerNight = 200, CityId = 2 },
            new Property { Id = 3, Name = "Casa em Copacabana", PricePerNight = 120, CityId = 3 },
            new Property { Id = 4, Name = "Casa em Palermo", PricePerNight = 100, CityId = 4 }
        );
    }
}