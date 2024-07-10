using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Context;
using PatikaCohortsProject.API.Model;
using PatikaCohortsProject.API.Repositories.Product;
using PatikaCohortsProject.API.Repositories.User;
using PatikaCohortsProject.API.Services;

namespace PatikaCohortsProject.API.Extensions;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddServicesForRepository();
        services.AddServicesForService();
    }
    public static void AddServicesForService(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
    }
    public static void AddServicesForRepository(this IServiceCollection services)
    {
        services.AddScoped<IGenericReadRepository<ProductEntity>, GenericReadRepository<ProductEntity>>();
        services.AddScoped<IGenericWriteRepository<ProductEntity>, GenericWriteRepository<ProductEntity>>();
        services.AddScoped<IGenericReadRepository<UserEntity>, GenericReadRepository<UserEntity>>();
        services.AddScoped<IGenericWriteRepository<UserEntity>, GenericWriteRepository<UserEntity>>();

        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();

    }
}
