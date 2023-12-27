using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeliculaModel.Entities;

namespace PeliculaDb.Config
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(prop => prop.Name)
                .IsRequired().HasMaxLength(40);
            builder.Property(prop => prop.InView)
                .HasDefaultValue(false);
            builder.Property(prop => prop.Premier)
                .IsRequired();
        }
    }
}
