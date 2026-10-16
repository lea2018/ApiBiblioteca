
namespace ApiBiblioteca.Models
{
    public class Prestamos
    {
        public int PrestamoID { get; set; }
        public int EstudianteID { get; set; }
        public int LibroID { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}

