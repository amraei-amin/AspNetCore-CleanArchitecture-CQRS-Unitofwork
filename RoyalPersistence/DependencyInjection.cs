using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoyalDomain.Interfaces.Common;
using RoyalPersistence.Context;
using RoyalPersistence.Repositories.Common;

namespace RoyalPersistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RoyalDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(RoyalDbContext).Assembly.FullName)));
            services.AddScoped<IRoyalUnitOfWork, RoyalUnitOfWork>();                       
        }        
    }
}
