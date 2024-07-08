using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Base.Services;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Services
{
    public class ProductService : GenericService<ProductEntity>, IProductService
    {
        public ProductService(IGenericReadRepository<ProductEntity> readRepository, IGenericWriteRepository<ProductEntity> writeRepository) : base(readRepository, writeRepository)
        {
        }
    }
}
