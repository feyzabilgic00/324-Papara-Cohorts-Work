using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Base.Services;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Services;

public class BookService : GenericService<BookEntity>, IBookService
{
    public BookService(IGenericReadRepository<BookEntity> readRepository, IGenericWriteRepository<BookEntity> writeRepository) : base(readRepository, writeRepository)
    {
    }
}
