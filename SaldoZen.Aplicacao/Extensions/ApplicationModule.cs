using Microsoft.Extensions.DependencyInjection;
using SaldoZen.Aplicacao.Commands.Categorias.InsertCategorias;

namespace SaldoZen.Aplicacao.Extensions
{
    public static class ApplicationModule
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers();

            return services;
        }
        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<InsertCategoriasCommand>());

            return services;
        }
    }
}
