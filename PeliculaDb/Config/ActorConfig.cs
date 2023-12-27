using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeliculaModel.Entities;

namespace PeliculaDb.Config
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(prop => prop.Name)
                .IsRequired().HasMaxLength(80);
            builder.Property(prop => prop.BirthDate)
                .IsRequired();
            builder.Property(prop => prop.Biography)
                .IsRequired();
        }
    }
}
