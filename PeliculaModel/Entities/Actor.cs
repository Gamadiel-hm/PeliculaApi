namespace PeliculaModel.Entities
{
    public class Actor : EntitySoftDelete
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public List<PeliculaActor> PeliculaActors { get; set; }
    }
}
