using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Protocol;
using SaldoZen.McpServer.HttpClients;

var builder = Host.CreateApplicationBuilder(args);


builder.Services.AddMcpServer(configureOptions =>
{
    configureOptions.ServerInfo = new Implementation
    {
        Name = "SaldoZen Financeiro",
        Version = "1.0.0"
    };
})
.WithStdioServerTransport()
.WithToolsFromAssembly();


builder.Services.AddHttpClient<CategoriasClient>(client =>
{
    //var baseAddress = builder.Configuration["ApiSettings:BaseUrl"];
    //if (string.IsNullOrEmpty(baseAddress))
    //{
    //    throw new InvalidOperationException("ApiSettings:BaseUrl not configured in appsettings.json");
    //}
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

builder.Logging.ClearProviders();
var app = builder.Build();


await app.RunAsync();