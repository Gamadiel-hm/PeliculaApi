using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeliculaModel.Entities;

namespace PeliculaDb.Config
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            builder.HasKey(key => new { key.PeliculaId, key.ActorId });
            builder.Property(prop => prop.Charadter)
                .IsRequired().HasMaxLength(100);
        }
    }
}
