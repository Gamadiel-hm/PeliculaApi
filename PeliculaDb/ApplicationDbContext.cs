using Microsoft.EntityFrameworkCore;
using PeliculaModel.Entities;
using System.Reflection;

namespace PeliculaDb
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<PeliculaActor> PeliculaActors { get; set; }
        public DbSet<PeliculaGenero> PeliculaGeneros { get; set; }
    }
}
