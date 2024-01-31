using CleanArch.Application.Repositories;
using CleanArch.Infrastructure.Contexts;
using CleanArch.Infrastructure.Persistence;
using CleanArch.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt =>
                opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CleanArch;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();


            return services;
        }

    }
}
