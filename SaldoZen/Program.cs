using Microsoft.EntityFrameworkCore;
using SaldoZen.Infraestrutura.Context;
using SaldoZen.Infraestrutura.Extensoes;
using SaldoZen.MiddlewareExecption;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SaldoZenContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddInfraestrutura(builder.Configuration);
//builder.Services.AddAddAuth();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<SaldoZenContext>();
        // O m�todo .Migrate() aplica todas as migrations pendentes no banco de dados.
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Opcional: Adiciona um log caso algo d� errado com a migration
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro durante a execu��o das migrations.");
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
