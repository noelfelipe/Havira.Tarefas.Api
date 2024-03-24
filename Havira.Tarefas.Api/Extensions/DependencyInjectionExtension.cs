using Microsoft.Extensions.DependencyInjection;
using Havira.Tarefas.Application.Interfaces;
using Havira.Tarefas.Application.Services;
using Havira.Tarefas.Domain.Interfaces;
using Havira.Tarefas.Infrastructure.Repositories;
using Havira.Tarefas.Infrastructure.Data;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Havira.Tarefas.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                return new SqlConnection(connectionString);
            });

            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            return services;
        }
    }
}
