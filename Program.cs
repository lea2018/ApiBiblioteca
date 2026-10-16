using ApiBiblioteca.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrar los servicios de la API
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Registrar la conexion con SQLite
builder.Services.AddScoped<BibliotecaBD>();

// Registrar el inicializador de la base de datos
builder.Services.AddScoped<InicializarBD>();

var app = builder.Build();

// Crear las tablas al iniciar la aplicacion
using (var scope = app.Services.CreateScope())
{
    var inicializador = scope.ServiceProvider
        .GetRequiredService<InicializarBD>();

    await inicializador.CrearTablasAsync();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

