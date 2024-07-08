using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Context;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Repositories.Product;

public class ProductReadRepository: GenericReadRepository<ProductEntity>, IProductReadRepository
{
    public ProductReadRepository(AppDbContext context) : base(context)
    {
        
    }
}
