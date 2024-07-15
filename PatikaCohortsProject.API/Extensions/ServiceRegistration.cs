using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Base.Services;
using PatikaCohortsProject.API.Model;
using PatikaCohortsProject.API.Repositories.Book;
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
        services.AddScoped<IBookService, BookService>();
    }
    public static void AddServicesForRepository(this IServiceCollection services)
    {
        services.AddScoped<IGenericReadRepository<ProductEntity>, GenericReadRepository<ProductEntity>>();
        services.AddScoped<IGenericWriteRepository<ProductEntity>, GenericWriteRepository<ProductEntity>>();
        services.AddScoped<IGenericReadRepository<UserEntity>, GenericReadRepository<UserEntity>>();
        services.AddScoped<IGenericWriteRepository<UserEntity>, GenericWriteRepository<UserEntity>>();
        services.AddScoped<IGenericReadRepository<BookEntity>, GenericReadRepository<BookEntity>>();
        services.AddScoped<IGenericWriteRepository<BookEntity>, GenericWriteRepository<BookEntity>>();

        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>(); 
        services.AddScoped<IBookReadRepository, BookReadRepository>();
        services.AddScoped<IBookWriteRepository, BookWriteRepository>();

    }
 }
