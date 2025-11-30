using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SaldoZen.Domain.Interfaces;
using SaldoZen.Domain.Interfaces.Base;
using SaldoZen.Domain.Interfaces.PlanoConta;
using SaldoZen.Domain.Model;
using SaldoZen.Infraestrutura.Auth;
using SaldoZen.Infraestrutura.Repositories;
using SaldoZen.Infraestrutura.Repositories.Base;
using SaldoZen.Infraestrutura.Repositories.Categorias;
using System.Text;

namespace SaldoZen.Infraestrutura.Extensoes
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddInfraestrutura(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAddAuth(configuration);

            return services;
        }

        public static IServiceCollection AddAddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });
            return services;
        }

    }
}
