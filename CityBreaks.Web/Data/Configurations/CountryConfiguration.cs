using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(c => c.CountryName)
            .HasMaxLength(150)
            .HasColumnName("Name");

        builder.Property(c => c.CountryCode)
            .HasColumnName("Code");

        builder.HasData(
            new Country { Id = 1, CountryCode = "ES", CountryName = "Spain" },
            new Country { Id = 2, CountryCode = "FR", CountryName = "France" },
            new Country { Id = 3, CountryCode = "BR", CountryName = "Brazil" },
            new Country { Id = 4, CountryCode = "AR", CountryName = "Argentina" }
        );
    }
}