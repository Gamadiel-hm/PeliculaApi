namespace PeliculaModel.Entities
{
    public class EntitySoftDelete
    {
        public bool Delete { get; set; } = false;
        public DateTime DateDelete { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.UtcNow;
    }
}
