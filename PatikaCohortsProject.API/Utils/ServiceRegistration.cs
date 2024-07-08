using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatikaCohortsProject.API.Context;
using PatikaCohortsProject.API.Repositories.Product;

namespace PatikaCohortsProject.API.Utils;

public static class ServiceRegistration
{
    //public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetSection("ConnectionDB").Value));
    //    services.AddScoped<IProductReadRepository, ProductReadRepository>();
    //    services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
    //}
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
    }
}
