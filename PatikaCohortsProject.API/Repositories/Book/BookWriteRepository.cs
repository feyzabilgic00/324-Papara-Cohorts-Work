using PatikaCohortsProject.API.Base.Repositories;
using PatikaCohortsProject.API.Context;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Repositories.Book;

public class BookWriteRepository : GenericWriteRepository<BookEntity>, IBookWriteRepository
{
    public BookWriteRepository(AppDbContext context) : base(context)
    {
    }
}
