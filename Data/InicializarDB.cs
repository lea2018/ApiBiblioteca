
using Dapper;

namespace ApiBiblioteca.Data
{
    public class InicializarBD
    {
        private readonly BibliotecaBD _bibliotecaBD;

        public InicializarBD(BibliotecaBD bibliotecaBD)
        {
            _bibliotecaBD = bibliotecaBD;
        }

        public async Task CrearTablasAsync()
        {
            using var conexion = _bibliotecaBD.CrearConexion();
            await conexion.OpenAsync();

            var sql = @"
                CREATE TABLE IF NOT EXISTS Estudiantes (
                    EstudianteID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Apellido TEXT NOT NULL,
                    Matricula TEXT NOT NULL UNIQUE,
                    Telefono TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Direccion TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Libros (
                    LibroID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titulo TEXT NOT NULL,
                    Autor TEXT NOT NULL,
                    ISBN TEXT NOT NULL UNIQUE,
                    Categoria TEXT NOT NULL,
                    CantidadDisponible INTEGER NOT NULL DEFAULT 0
                );

                CREATE TABLE IF NOT EXISTS Prestamos (
                    PrestamoID INTEGER PRIMARY KEY AUTOINCREMENT,
                    EstudianteID INTEGER NOT NULL,
                    LibroID INTEGER NOT NULL,
                    FechaPrestamo TEXT NOT NULL,
                    FechaVencimiento TEXT NOT NULL,
                    FOREIGN KEY (EstudianteID)
                        REFERENCES Estudiantes(EstudianteID),
                    FOREIGN KEY (LibroID)
                        REFERENCES Libros(LibroID)
                );

                CREATE TABLE IF NOT EXISTS Devoluciones (
                    DevolucionID INTEGER PRIMARY KEY AUTOINCREMENT,
                    PrestamoID INTEGER NOT NULL,
                    FechaDevolucion TEXT NOT NULL,
                    Estado TEXT NOT NULL,
                    FOREIGN KEY (PrestamoID)
                        REFERENCES Prestamos(PrestamoID)
                );
            ";

            await conexion.ExecuteAsync(sql);
        }
    }
}

