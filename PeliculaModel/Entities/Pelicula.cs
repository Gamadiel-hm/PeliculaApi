namespace PeliculaModel.Entities
{
    public class Pelicula
    {
        public int PeliculaId { get; set; }
        public string Name { get; set; }
        public bool InView { get; set; }
        public DateTime Premier { get; set; }
        public List<PeliculaGenero> PeliculaGeneros { get; set; }
        public List<PeliculaActor> PeliculaActors { get; set; }
    }
}
