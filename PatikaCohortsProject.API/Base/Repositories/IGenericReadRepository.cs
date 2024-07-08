using System.Linq.Expressions;

namespace PatikaCohortsProject.API.Base.Repositories;

public interface IGenericReadRepository<T>: IGenericRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
    Task<T> GetByIdAsync(int id);
}
