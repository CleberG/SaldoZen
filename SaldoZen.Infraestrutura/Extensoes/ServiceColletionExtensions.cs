using Microsoft.Extensions.DependencyInjection;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Infraestrutura.Auth;
using SaldoZen.Infraestrutura.Repositories.Base;

namespace SaldoZen.Infraestrutura.Extensoes
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddInfraestrutura(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddAddAuth(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
