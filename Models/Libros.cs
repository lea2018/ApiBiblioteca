namespace ApiBiblioteca.Models
{
    public class Libros
    {
        public int LibroID { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
        public int CantidadDisponible { get; set; }

    }
}

