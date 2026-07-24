using Microsoft.EntityFrameworkCore;
using TimewareAPI.Infrastructure;
using TimewareAPI.Application;

var builder = WebApplication.CreateBuilder(args);

// Configura o Banco de Dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=joalheria.db"));

// Registra a camada de Serviço e os Controllers
builder.Services.AddScoped<VendaService>();
builder.Services.AddControllers();

var app = builder.Build();

// Mapeia as rotas dos Controllers
app.MapControllers();

app.Run();