using Microsoft.EntityFrameworkCore;
using SaldoZen.Infraestrutura.Context;
using SaldoZen.Infraestrutura.Extensoes;
using SaldoZen.MiddlewareExecption;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SaldoZenContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddInfraestrutura();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<SaldoZenContext>();
        // O método .Migrate() aplica todas as migrations pendentes no banco de dados.
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Opcional: Adiciona um log caso algo dê errado com a migration
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro durante a execução das migrations.");
    }
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

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
