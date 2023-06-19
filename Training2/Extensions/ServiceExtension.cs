using Business.Abstractions;
using Business.Implementations;
using Data.Abstractions.IRepositories;
using Data.Abstractions.IUnitOfWork;
using Data.Implementations.DatabaseContext;
using Data.Implementations.Repositories;
using Data.Implementations.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Training2.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextClass>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClientRepository, ClientRepository>();
            
            return services;
        }
    }
}
