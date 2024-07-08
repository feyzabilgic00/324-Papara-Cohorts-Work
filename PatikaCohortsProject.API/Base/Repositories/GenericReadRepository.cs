using Microsoft.EntityFrameworkCore;
using PatikaCohortsProject.API.Context;
using System.Linq.Expressions;

namespace PatikaCohortsProject.API.Base.Repositories;

public class GenericReadRepository<T> : IGenericReadRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    public GenericReadRepository(AppDbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll()
    {
        return Table;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
    {
       return Table.Where(method);
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
    {
        return await Table.FirstOrDefaultAsync(method);
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await Table.FirstOrDefaultAsync(data => data.Id == id);
    }

}
