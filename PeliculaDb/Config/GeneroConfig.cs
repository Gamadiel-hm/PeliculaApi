using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeliculaModel.Entities;

namespace PeliculaDb.Config
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.Property(prop => prop.Name)
                .IsRequired().HasMaxLength(50);

            builder.HasQueryFilter(prop => !prop.Delete);
        }
    }
}
