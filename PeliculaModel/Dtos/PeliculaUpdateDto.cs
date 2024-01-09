namespace PeliculaModel.Dtos
{
    public class PeliculaUpdateDto
    {
        public string Name { get; set; }
        public bool InView { get; set; }
        public DateTime Premier { get; set; }
        public List<PeliculaGeneroUpdateDto> PeliculaGeneros { get; set; }
        public List<PeliculaActorUpdateDto> PeliculaActors { get; set; }
    }
}
