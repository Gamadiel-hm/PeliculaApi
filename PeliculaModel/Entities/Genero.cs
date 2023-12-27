namespace PeliculaModel.Entities
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Name { get; set; }
        public List<PeliculaGenero> PeliculaGeneros { get; set; }
    }
}
