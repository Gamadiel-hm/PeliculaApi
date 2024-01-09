namespace PeliculaModel.Dtos
{
    public class PeliculaCreateDto
    {
        public string Name { get; set; }
        public bool InView { get; set; }
        public DateTime Premier { get; set; }
        public List<int> PeliculaGeneroIds { get; set; }
        public List<PeliculaActorCreate> PeliculaActorIds { get; set; }
    }
}
