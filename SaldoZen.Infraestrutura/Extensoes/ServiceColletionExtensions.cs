using Microsoft.Extensions.DependencyInjection;
using SaldoZen.Domain.Interfaces;
using SaldoZen.Infraestrutura.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoZen.Infraestrutura.Extensoes
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddInfraestrutura(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            return services;
        }
    }
}
