using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Entities;

namespace MovieApi.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.CostPrice).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x=>x.Genre)
                   .WithMany(x=>x.Movies)
                   .HasForeignKey(x=>x.GenreId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
