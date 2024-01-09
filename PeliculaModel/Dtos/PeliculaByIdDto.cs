namespace PeliculaModel.Dtos
{
    public class PeliculaByIdDto
    {
        public int PeliculaId { get; set; }
        public string Name { get; set; }
        public bool InView { get; set; }
        public DateTime Premier { get; set; }
        public List<GeneroDto> Generos { get; set; }
        public List<PeliculaActorDto> PeliculaActors { get; set; }
    }
}
