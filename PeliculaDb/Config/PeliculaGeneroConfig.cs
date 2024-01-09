using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeliculaModel.Entities;

namespace PeliculaDb.Config
{
    public class PeliculaGeneroConfig : IEntityTypeConfiguration<PeliculaGenero>
    {
        public void Configure(EntityTypeBuilder<PeliculaGenero> builder)
        {
            builder.HasKey(key => new { key.PeliculaId, key.GeneroId });
        }
    }
}
