using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Context;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Repositories.Book;

public class BookReadRepository : GenericReadRepository<BookEntity>, IBookReadRepository
{
    public BookReadRepository(AppDbContext context) : base(context)
    {
    }
}
