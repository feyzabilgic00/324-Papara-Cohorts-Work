using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Context;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Repositories.Product;

public class ProductWriteRepository: GenericWriteRepository<ProductEntity>, IProductWriteRepository
{
    public ProductWriteRepository(AppDbContext context):base(context)
    {
        
    }
}
