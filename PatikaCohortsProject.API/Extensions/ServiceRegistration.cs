using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Context;
using PatikaCohortsProject.API.Model;
using PatikaCohortsProject.API.Repositories.Product;
using PatikaCohortsProject.API.Services;

namespace PatikaCohortsProject.API.Extensions;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGenericReadRepository<ProductEntity>, GenericReadRepository<ProductEntity>>();
        services.AddScoped<IGenericWriteRepository<ProductEntity>, GenericWriteRepository<ProductEntity>>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IProductService, ProductService>();
    }
}
