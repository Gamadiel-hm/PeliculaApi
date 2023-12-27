namespace PeliculaModel.Entities
{
    public class PeliculaGenero
    {
        public int PeliculaÏd { get; set; }
        public int GeneroId { get; set; }
        public Pelicula Pelicula { get; set; }
        public Genero Genero { get; set; }
    }
}
