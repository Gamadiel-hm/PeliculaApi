using PeliculaModel.Entities;

namespace PeliculaModel.Dtos
{
    public class PeliculaActorUpdateDto
    {
        public int PeliculaId { get; set; }
        public int ActorId { get; set; }
        public string Charadter { get; set; }
    }
}
