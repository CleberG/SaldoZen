using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using ModelContextProtocol.Protocol;
using SaldoZen.McpServer.Tools;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using SaldoZen.McpServer.HttpClients;

var builder = Host.CreateApplicationBuilder(args);

// Adicione logging detalhado
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

Console.WriteLine("=== Iniciando SaldoZen MCP Server ===");

builder.Services.AddMcpServer(configureOptions =>
{
    configureOptions.ServerInfo = new Implementation
    {
        Name = "SaldoZen Financeiro",
        Version = "1.0.0"
    };
    Console.WriteLine($"MCP Server configurado: {configureOptions.ServerInfo.Name}");
})
.WithStdioServerTransport()
.WithToolsFromAssembly();

Console.WriteLine("Transport STDIO configurado");

builder.Services.AddHttpClient<PlanoContasClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7130/api/");
    client.Timeout = TimeSpan.FromSeconds(30);
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    var handler = new HttpClientHandler();

    if (builder.Environment.IsDevelopment())
    {
        handler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
    }

    return handler;
});

Console.WriteLine("HttpClient configurado");

var app = builder.Build();

Console.WriteLine("=== Servidor MCP pronto para conexões ===");

await app.RunAsync();