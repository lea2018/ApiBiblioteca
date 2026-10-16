using Microsoft.Data.Sqlite;

namespace ApiBiblioteca.Data
{
    public class BibliotecaBD
    {
        private readonly string _connectionString;

        public BibliotecaBD(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Biblioteca")
                ?? "Data Source=Biblioteca.db";
        }

        public SqliteConnection CrearConexion()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}

