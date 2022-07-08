using biblioteca.Data;
using biblioteca.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var connString = "";

if (builder.Environment.IsDevelopment())
{
    connString = "Server=(localdb)\\mssqllocaldb;Database=itsc-proyectofinal-sqldb;Trusted_Connection=True;";
}

else
{
    connString =
    Environment.GetEnvironmentVariable("SQLAZURECONNSTR_itsc_proyectofinal_cs");

    if (connString is null)
        connString = "Variable not found.";
}

builder.Services.AddSqlServer<BibliotecaContext>(connString);
builder.Services.AddScoped<AutorService>();
builder.Services.AddScoped<LibroService>();
builder.Services.AddScoped<PacienteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();